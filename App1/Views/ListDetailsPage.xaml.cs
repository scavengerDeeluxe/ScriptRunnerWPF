using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

using App1.Contracts.Views;
using App1.Core.Contracts.Services;
using App1.Core.Models;

namespace App1.Views;

public partial class ListDetailsPage : Page, INotifyPropertyChanged, INavigationAware
{
    private readonly IScriptRepositoryService _scriptService;

    private ScriptInfo _selected;

    public ScriptInfo Selected
    {
        get { return _selected; }
        set { Set(ref _selected, value); }
    }

    public ObservableCollection<ScriptInfo> Scripts { get; private set; } = new ObservableCollection<ScriptInfo>();

    public ListDetailsPage(IScriptRepositoryService scriptService)
    {
        _scriptService = scriptService;
        InitializeComponent();
        DataContext = this;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Scripts.Clear();

        var data = await _scriptService.GetScriptsAsync();

        foreach (var item in data)
        {
            Scripts.Add(item);
        }

        Selected = Scripts.FirstOrDefault();
    }

    public void OnNavigatedFrom()
    {
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    {
        if (Equals(storage, value))
        {
            return;
        }

        storage = value;
        OnPropertyChanged(propertyName);
    }

    private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
