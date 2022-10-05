using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace InfluxRSS.Config
{
	public class ConfigManager
	{
		public int MaxResults { get; set; }
		public string Language { get; set; }
		public List<string> FeedURIs { get; set; }

		public ConfigManager() {

			// Config files
			string configRoot = GetFolderPath(SpecialFolder.LocalApplicationData) + "/InfluxRSS/";
			string configPath = GetFolderPath(SpecialFolder.LocalApplicationData) + "/InfluxRSS/config.txt";
			string feedPath = GetFolderPath(SpecialFolder.LocalApplicationData) + "/InfluxRSS/feeds.txt";
			

			// Create root directory if it doesn't exist
			if (!Directory.Exists(configRoot)) {
				Directory.CreateDirectory(configRoot);
			}

			// Set default values for settings
			MaxResults = 20;
			Language = "en-us";

			if (!File.Exists(configPath))
			{
				File.WriteAllText(configPath, "MaxResults:20\nLanguage:en-us");
				
			}
			else
			{
				string[] configLines = File.ReadAllLines(configPath);

				foreach (string line in configLines)
				{
					string[] properties = line.Split(':');

					switch (properties[0].Trim()) {
						case "MaxResults":
							MaxResults = int.Parse(properties[1].Trim());
							break;
						case "Language":
							Language = properties[1].Trim();
							break;
						default:
							break;
					}
					
				}
			}

			// Feed URIs
			FeedURIs = new List<string>();

			// Check if file exists before trying to read it
			if (!File.Exists(feedPath))
			{
				FileStream f = File.Create(feedPath);
				f.Close();
				
			}

			FeedURIs.AddRange(File.ReadAllLines(feedPath));


		}
	}
}
