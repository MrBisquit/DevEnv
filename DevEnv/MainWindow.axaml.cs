using Avalonia;
using Avalonia.Controls;
using Avalonia.Dialogs;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;
using System;

namespace DevEnv
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Events.UpdateEngineStatus += (object? sender, Core.EngineManagement.EngineStatus status) =>
            {
                if(status.status == Core.EngineManagement.EngineStatus.Status.Online)
                {
                    EngineStatusIcon.Foreground = new SolidColorBrush(Color.FromRgb(57, 203, 44));
                    EngineStatusText.Foreground = new SolidColorBrush(Color.FromRgb(57, 203, 44));
                    EngineStatusIcon.Value = "fa-power-off";
                } else if(status.status == Core.EngineManagement.EngineStatus.Status.Starting)
                {
                    EngineStatusIcon.Foreground = new SolidColorBrush(Color.FromRgb(233, 162, 32));
                    EngineStatusText.Foreground = new SolidColorBrush(Color.FromRgb(233, 162, 32));
                    EngineStatusIcon.Value = "fa-pause";
                } else if(status.status == Core.EngineManagement.EngineStatus.Status.Offline)
                {
                    EngineStatusIcon.Foreground = new SolidColorBrush(Color.FromRgb(229, 32, 32));
                    EngineStatusText.Foreground = new SolidColorBrush(Color.FromRgb(229, 32, 32));
                    EngineStatusIcon.Value = "fa-power-off";
                }

                EngineStatusText.Text = status.text;
            };
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Wizard wizard = new Wizard();
            wizard.ShowDialog(this);

            Global.config = new Core.Config();
            Global.config.LoadConfig();
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