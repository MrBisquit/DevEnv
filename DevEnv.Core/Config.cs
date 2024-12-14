using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEnv.Core
{
    public class Config
    {
        public Config(bool init = false)
        {
            ConfigPath = Path.Combine(BaseDirectory, "config.json");
            if (!init) return;
            // Initialise everything
            LoadConfig();
        }

        private static string BaseDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DevEnv"); // "WTDawson"
        private static string ConfigPath = string.Empty;

        /// <summary>
        /// Checks files and directories
        /// </summary>
        private void CheckFiles()
        {
            Debug.WriteLine(BaseDirectory);
            Debug.WriteLine(ConfigPath);
            if (!Directory.Exists(BaseDirectory))
                Directory.CreateDirectory(BaseDirectory);

            var dirInfo = new DirectoryInfo(BaseDirectory);

            if (dirInfo.Exists && (dirInfo.Attributes & FileAttributes.ReadOnly) != 0)
            {
                Debug.WriteLine("Folder is read-only");
                dirInfo.Attributes &= ~FileAttributes.ReadOnly; // Remove ReadOnly attribute
            } else
            {
                Debug.WriteLine("Folder is not read-only");
            }
        }

        /// <summary>
        /// Loads the configuration
        /// </summary>
        public void LoadConfig()
        {
            CheckFiles();
            if (!File.Exists(ConfigPath))
                SaveConfig();
            try
            {
                Config config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigPath));
                if (config == null) return;
                this.Theme = config.Theme;
                this.EngineLocation = config.EngineLocation;
            } catch { }
        }

        /// <summary>
        /// Saves the configuration
        /// </summary>
        public void SaveConfig()
        {
            CheckFiles();
            try
            {
                File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(this));
            }
            catch { }
        }

        public enum _Theme
        {
            Light = 0,
            Dark = 1,
            Default = 2
        }

        public _Theme Theme { get; set; } = _Theme.Default;
        public string EngineLocation { get; set; } = string.Empty; // Set up during installation

        public int PipeConnectionTimeout = 5000; // Milliseconds

        public string APILocation = "https://devenv.wtdawson.info";
    }
}
