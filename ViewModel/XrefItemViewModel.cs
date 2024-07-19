using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json;
using xrefBrowser.Model;

namespace xrefBrowser.ViewModel;

public class XrefItemViewModel: ObservableObject
{
    private bool _isExpanded;
    private JsonElement _jsonProperty;
    private ApiType _apiType;

    public string Uid => _apiType.uid;
    public string Href => _apiType.href;
    public string SchemaType => _apiType.schemaType;
    public string MonikerGroup => _apiType.monikerGroup;
    public string CommentID => _apiType.commentId;
    public string FullName => _apiType.fullName;
    public string Name => _apiType.name;
    public string NameWithType => _apiType.nameWithType;
    public string Summary => _apiType.summary;
    public string Type => _apiType.type;

    public IReadOnlyCollection<XrefItemViewModel> Items { get; }

    public XrefItemViewModel(JsonElement property)
    {
        _jsonProperty = property;
        Items = new List<XrefItemViewModel>();

        _apiType = JsonSerializer.Deserialize<ApiType>(property);
    }
}
