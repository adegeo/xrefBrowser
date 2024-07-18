using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace xrefBrowser.Model;

public class XREF
{
    public XrefFileInfo Info { get; set; }

    public JsonDocument XrefMap { get; set; }

    public static bool StatusFileExists() =>
        System.IO.File.Exists("xrefinfo.json");

    public static bool XrefMapExists() =>
        System.IO.File.Exists(".xrefmap.json");


    public bool IsInfoValid() =>
        Info.LastUpdated != default && !string.IsNullOrEmpty(Info.MD5);

    public async Task<bool> IsLatest()
    {
        

        return false;
    }

    public static async Task Download(IProgress<string> progress)
    {
        await Task.Delay(1000);
        progress.Report("50/100");
        await Task.Delay(1000);
        progress.Report("75/100");
        await Task.Delay(1000);
    }

}
