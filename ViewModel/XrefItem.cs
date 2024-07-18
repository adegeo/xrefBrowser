using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json;

namespace xrefBrowser.ViewModel;

public class XrefItem: ObservableObject
{
    private bool _isExpanded;
    private JsonProperty _jsonProperty;
    
    public string Name { get; }

    public IReadOnlyCollection<XrefItem> Items { get; }

    public bool HasChildren { get; }

    public bool IsExpanded
    {
        get => _isExpanded;
        set
        {
            if (!HasChildren) return;

            // First time loading
            if (Items.Count == 0)
            {
                // Load the Items collection
                //((List<XrefItem>)Items).AddRange()
            }

            // Notify listeners that we have children showing now
            SetProperty(ref _isExpanded, value);
        }
    }

    public XrefItem(JsonProperty property)
    {
        _jsonProperty = property;
        Name = _jsonProperty.Name;
        Items = new List<XrefItem>();

        // TODO: Peek at property to see if there are members and then set accordingly
        HasChildren = false;
    }
}
