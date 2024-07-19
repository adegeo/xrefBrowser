using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace xrefBrowser.Model;

internal class ApiType
{
    public string uid { get; set; }
    public string href { get; set; }
    public string schemaType { get; set; }
    public string monikerGroup { get; set; }
    public string commentId { get; set; }
    public string fullName { get; set; }
    public string[] monikers { get; set; }
    public string name { get; set; }
    public string nameWithType { get; set; }
    public string summary { get; set; }
    public string type { get; set; }
    public bool? isInternalOnly { get; set; }
}
