using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluxRSS.Config
{
	public class Localization
	{
		public string ID;
		public string? Name;
		private Dictionary<string, string> Replacements;

		// Construct Localization from file
		public Localization(string name, string file) {
			ID = name;
			
			string[] lines = File.ReadAllLines(file);

			Replacements = new Dictionary<string, string>();

			// Parse language file
			foreach(string l in lines) {
				string[] parts = l.Split(':');
				Replacements.Add(parts[0].Trim(), parts[1].Trim());
			}

			// Get name from new dictionary
			Name = Replacements.GetValueOrDefault("dictionary.name");

			// Replace name with proper string if null
			Name ??= "Unknown";

		}

		// Construct localization from already existing Dictionary
		public Localization(string name, Dictionary<string, string> replacements)
		{
			ID = name;
			Replacements = replacements;
		}

		// Get the local string here
		public string GetTextFromKey(string key)
		{
			if (Replacements.TryGetValue(key, out string? result))
			{
				return result;
			}
			else return key;
		}

	}
}
