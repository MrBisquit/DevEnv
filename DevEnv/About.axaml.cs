using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DevEnv;

public partial class About : Window
{
    public About()
    {
        InitializeComponent();
        Version.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        EngineVersion.Text = "Not running";
        EnginePlatform.Text = Global.platform.ToString();
    }
}