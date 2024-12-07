using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Reflection;

namespace DevEnv;

public partial class About : Window
{
    public About()
    {
        InitializeComponent();
        Version.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
}