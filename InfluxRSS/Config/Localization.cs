using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: Flood this file with comments like I did with the other files.
// Tomorrow tho, I am the tired sleepy ~zzzz~

namespace InfluxRSS.Config
{
	public class Localization
	{
		public string name;
		private Dictionary<string, string> Replacements;

		public Localization(string name, string file) {
			this.name = name;
			
			string[] lines = File.ReadAllLines(file);

			Replacements = new Dictionary<string, string>();

			foreach(string l in lines) {
				string[] parts = l.Split(':');
				Replacements.Add(parts[0].Trim(), parts[1].Trim());
			}

		}

		public Localization(string name, Dictionary<string, string> replacements)
		{
			this.name = name;
			Replacements = replacements;
		}

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
