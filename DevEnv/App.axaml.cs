using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Projektanker.Icons.Avalonia;
using Projektanker.Icons.Avalonia.FontAwesome;
using System.Runtime.InteropServices;

namespace DevEnv
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            IconProvider.Current
                .Register<FontAwesomeIconProvider>();

            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();

            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Start Windows engine
                Global.platform = Global.Platform.Windows;
            } else if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Start Linux engine
                Global.platform = Global.Platform.Linux;
            } else if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Start OSX (MacOS X) engine
                Global.platform = Global.Platform.OSX;
            } else if(RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
            {
                // Start FreeBSD engine
                Global.platform = Global.Platform.FreeBSD;
            } else
            {
                // Unsupported, tell them and close
            }

            Events.UpdateEngineStatus(this, new Core.EngineManagement.EngineStatus() { status = Core.EngineManagement.EngineStatus.Status.Starting, text = $"Starting {Global.platform} engine" });
        }
    }
}