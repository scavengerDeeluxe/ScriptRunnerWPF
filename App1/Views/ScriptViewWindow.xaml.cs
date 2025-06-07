using MahApps.Metro.Controls;

namespace App1.Views;

public partial class ScriptViewWindow : MetroWindow
{
    public ScriptViewWindow(string scriptText)
    {
        InitializeComponent();
        ScriptTextBox.Text = scriptText;
    }
}
