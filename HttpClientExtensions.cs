//public static class HttpClientExtensions
//{
//    public static async Task DownloadAsync(this HttpClient client, string requestUri, Stream destination, IProgress<string> progress, CancellationToken cancellationToken = default)
//    {
//        using (var response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead))
//        {
//            response.EnsureSuccessStatusCode();
//            using (var contentStream = await response.Content.ReadAsStreamAsync())
//            {
//                // Use an extension method for asynchronous stream copying with progress reporting.
//                await contentStream.CopyToAsync(destination, progress, cancellationToken);
//            }
//        }



//        using (HttpResponseMessage response = client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead).Result)
//        {
//            response.EnsureSuccessStatusCode();

//            using (Stream contentStream = await response.Content.ReadAsStreamAsync(), fileStream = new FileStream(dropZipPathAndFileName, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
//            {
//                var totalRead = 0L;
//                var totalReads = 0L;
//                var buffer = new byte[8192];
//                var isMoreToRead = true;

//                do
//                {
//                    var read = await contentStream.ReadAsync(buffer, 0, buffer.Length);
//                    if (read == 0)
//                    {
//                        isMoreToRead = false;
//                    }
//                    else
//                    {
//                        await fileStream.WriteAsync(buffer, 0, read);

//                        totalRead += read;
//                        totalReads += 1;

//                        if (totalReads % 2000 == 0)
//                        {
//                            Console.WriteLine(string.Format("total bytes downloaded so far: {0:n0}", totalRead));
//                        }
//                    }
//                }
//                while (isMoreToRead);
//            }
//        }

//    }



//}
