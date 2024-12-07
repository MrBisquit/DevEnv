using Avalonia;
using Avalonia.Controls;
using Avalonia.Dialogs;
using Avalonia.Interactivity;
using Avalonia.Styling;
using System;

namespace DevEnv
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ThemesLightThemeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.RequestedThemeVariant = ThemeVariant.Light;
        }

        public void ThemesDarkThemeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
        }

        public void ThemesDefaultThemeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.RequestedThemeVariant = ThemeVariant.Default;
        }

        public void AboutMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog(this);
        }

        public void ExitMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}