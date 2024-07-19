using System.Text.Json;
using xrefBrowser.Model;
using xrefBrowser.ViewModel;

namespace xrefBrowser
{
    public partial class Download : Form
    {
        const int TOTAL_STEPS = 10;

        public readonly record struct ProgressData(string Message, int CurrentProgress, int MaximumProgress);

        CancellationTokenSource _loadingSource;
        IProgress<ProgressData> _progress;

        public MainFormViewModel? ViewModel;


        public Download()
        {
            InitializeComponent();
            _loadingSource = new();
            _progress = new Progress<ProgressData>((s) => lblStatus.Text = $"{s.CurrentProgress}/{s.MaximumProgress}: {s.Message}");
        }

        private void Download_Shown(object sender, EventArgs e)
        {
            // If file is missing, download
            // If date file is missing, download
            // If crc data is different, download
            Task.Run(Start, _loadingSource.Token)
                .ContinueWith((t) => { ViewModel = t.Result; DialogResult = DialogResult.OK; }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async Task<MainFormViewModel?> Start()
        {
            HttpClient httpClient = new();
            XREF? xrefData = null;
            using CancellationTokenSource httpDownloadTokenSource = new();
            XrefFileInfo xrefInfo;

            _progress.Report(new("Loading", 0, TOTAL_STEPS));
            await Task.Delay(1000, _loadingSource.Token);

            // Check if the file exists locally
            _progress.Report(new("Checking if data file exists", 0, TOTAL_STEPS));

            if (XREF.XrefMapExists() && XREF.StatusFileExists())
            {
                // Compare the date times
                XrefFileInfo info = JsonSerializer.Deserialize<XrefFileInfo>(System.IO.File.ReadAllText("xrefinfo.json"));

                try
                {
                    httpDownloadTokenSource.CancelAfter(5000);

                    // Check if file is the latest version
                    _progress.Report(new("Downloading", 0, TOTAL_STEPS));

                    xrefInfo = await DownloadHeaderData(httpClient, httpDownloadTokenSource.Token);

                    _progress.Report(new("Finished downloading header info", 0, TOTAL_STEPS));
                }
                catch (Exception e)
                {
                    xrefInfo = info;
                    _progress.Report(new("Unable to download xref. Loading cached copy.", 0, TOTAL_STEPS));
                    await Task.Delay(2000);
                }
                
                // All good, exit
                if (info.LastUpdated == xrefInfo.LastUpdated)
                {
                    _progress.Report(new("Loading XREF map...", 0, TOTAL_STEPS));
                    xrefData = new()
                    {
                        Info = info,
                        XrefMap = JsonDocument.Parse(System.IO.File.ReadAllText(".xrefmap.json"))
                    };

                    _progress.Report(new("Deserializing XREF types", 0, TOTAL_STEPS));

                    return new(xrefData);
                }
                // Not good, exit the if statement and continue to download
            }

            // Download the latest file
            httpDownloadTokenSource.TryReset();
            httpDownloadTokenSource.CancelAfter(15000);

            try
            {
                _progress.Report(new("Local files missing or old. Downloading filez", 0, TOTAL_STEPS));
                (XrefFileInfo Info, string Json) result2 = await DownloadFile(httpClient, httpDownloadTokenSource.Token);

                // Write the data
                File.WriteAllText("xrefinfo.json", JsonSerializer.Serialize(result2.Info));
                File.WriteAllText(".xrefmap.json", result2.Json);

                // Create the final object
                xrefData = new()
                {
                    Info = result2.Info,
                    XrefMap = JsonDocument.Parse(result2.Json)
                };

                _progress.Report(new($"Done!", 0, TOTAL_STEPS));
            }
            catch (Exception)
            {
                _progress.Report(new ("Unable to download filez 😭", 0, TOTAL_STEPS));
            }

            if (xrefData != null)
            {
                _progress.Report(new("Deserializing XREF types", 0, TOTAL_STEPS));
                return new(xrefData);
            }

            return null;
        }

        private async Task<XrefFileInfo> DownloadHeaderData(HttpClient httpClient, CancellationToken cancelToken)
        {
            //try
            //{
                _progress.Report(new("Contacting Microsoft Learn for latest .xrefmap.json date", 0, TOTAL_STEPS));

                using HttpRequestMessage request = new(HttpMethod.Head, "https://learn.microsoft.com/en-us/dotnet/.xrefmap.json");
                using HttpResponseMessage response = await httpClient.SendAsync(request, cancelToken);

                if (!response.IsSuccessStatusCode)
                {
                    _progress.Report(new($"Error: Unable to get header info, result code {response.StatusCode}", 0, TOTAL_STEPS));
                    _loadingSource.Cancel();
                    return new XrefFileInfo();
                }

                return new XrefFileInfo(DateTime.Parse(response.Content.Headers.GetValues("Last-Modified").First()), "");

            //}
            //catch (Exception)
            //{
            //    return new XrefFileInfo();
            //}
        }

        private async Task<(XrefFileInfo Info, string Json)> DownloadFile(HttpClient httpClient, CancellationToken cancelToken)
        {
            (XrefFileInfo Info, string Json) returnValue = new();

            _progress.Report(new("Downloading .xrefmap.json - No progress because WEB IS BAD", 0, TOTAL_STEPS));

            //using HttpResponseMessage response = await httpClient.GetAsync("https://learn.microsoft.com/en-us/dotnet/.xrefmap.json", HttpCompletionOption.ResponseHeadersRead, cancelToken);

            //// Pull the header information
            //if (!response.IsSuccessStatusCode)
            //{
            //    _progress.Report(new($"Error: Unable to get header info, result code {response.StatusCode}", 0, TOTAL_STEPS));
            //    _loadingSource.Cancel();
            //    return (new XrefFileInfo(), string.Empty);
            //}

            //returnValue.Info = new XrefFileInfo(DateTime.Parse(response.Content.Headers.GetValues("Last-Modified").First()), "");

            //// Stream in the content
            //using Stream stream = await response.Content.ReadAsStreamAsync();
            //StringBuilder stringBuilder = new StringBuilder();
            //while (true)
            //{
            //    Memory<byte> buffer = new();
            //    int count = await stream.ReadAsync(buffer);

            //    if (count == 0)
            //        break;

            //    stringBuilder.Append(buffer.ToString());
            //}
            returnValue.Info = await DownloadHeaderData(httpClient, cancelToken);
            _progress.Report(new($"Downloading .xrefmap.json", 0, TOTAL_STEPS));
            returnValue.Json = await httpClient.GetStringAsync("https://learn.microsoft.com/en-us/dotnet/.xrefmap.json", cancelToken);

            return returnValue;
        }


        ~Download()
        {
            _loadingSource.Dispose();
        }

        private void Download_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loadingSource.Cancel();
        }
    }
}
