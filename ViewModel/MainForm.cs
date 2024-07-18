using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using xrefBrowser.Model;

namespace xrefBrowser.ViewModel;

public class MainForm: ObservableObject
{
    private XREF _model;
    private string _query = "Something";

    public string Query
    {
        get => _query;
        set
        {
            Results.Clear();
            SetProperty(ref _query, value);
            
        }
    }

    public ICommand ClearQueryCommand { get; }

    public MainForm(XREF model)
    {
        _model = model;
        ClearQueryCommand = new RelayCommand(ClearQuery);
    }

    public ObservableCollection<XrefItem> Results { get; set; } = new();

    public void ClearQuery() =>
        Query = "";
}
