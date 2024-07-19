using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using System.Windows.Input;
using xrefBrowser.Model;

namespace xrefBrowser.ViewModel;

public class MainFormViewModel: ObservableObject
{
    private XREF _model;
    private string _query = "";
    private XrefItemViewModel _selectedItem;

    public string Query
    {
        get => _query;
        set
        {
            if (SetProperty(ref _query, value))
                RunQuery();
        }
    }

    public ICommand ClearQueryCommand { get; }

    public Dictionary<string, XrefItemViewModel> Items { get; } = new();

    public MainFormViewModel(XREF model)
    {
        _model = model;

        ClearQueryCommand = new RelayCommand(ClearQuery);
        foreach (JsonElement element in model.XrefMap.RootElement.GetProperty("references").EnumerateArray())
        {
            XrefItemViewModel item = new(element);
            Items.Add(item.Uid, item);
        }
    }

    public BindingList<XrefItemViewModel> Results { get; set; } = new();

    public XrefItemViewModel SelectedItem
    {
        get => _selectedItem;
        set => SetProperty(ref _selectedItem, value);
    }

    public void ClearQuery() =>
        Query = "";

    public void RunQuery()
    {
        Results.Clear();

        if (string.IsNullOrEmpty(Query)) return;

        var results = from item in Items
                      where item.Key.StartsWith(_query, StringComparison.OrdinalIgnoreCase)
                      select item.Value;

        foreach (var item in results.Take(30))
            Results.Add(item);

        if (Results.Count <= 30)
        {
            var results2 = from item in Items
                          where item.Key.Contains(_query, StringComparison.OrdinalIgnoreCase)
                          select item.Value;

            foreach (var item in results2.Take(30))
                Results.Add(item);
        }
    }
}
