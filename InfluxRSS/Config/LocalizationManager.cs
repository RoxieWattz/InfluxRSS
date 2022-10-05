using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace InfluxRSS.Config
{
	public class LocalizationManager
	{
		private static Dictionary<string, string> EnglishUS { get; } = new() {
			{ "tools.refresh", "Refresh" },
			{ "tools.settings","Settings" },
			{ "tools.about", "About" },
			{ "tools.donate", "Donate" },
			{ "tools.exit", "Exit" },
			{ "item.by", "By" },
			{ "item.source", "From" },
			{ "item.desc", "Description:" },
			{ "error.nofeeds", "You have no feeds! Start by adding some in settings." }
		};

		private List<Localization> Localizations;

		public Localization ActiveLocalization;

		public LocalizationManager(ConfigManager c) {
			
			// set stuff here idfk i'm getting pissed
			string langRoot = "localization";

			if (!Directory.Exists(langRoot)) {
				Directory.CreateDirectory(langRoot);
			}

			string[] localConfigs = Directory.GetFiles(langRoot);

			Localizations = new();

			Localizations.Add(new("en-us", EnglishUS));

			foreach (string config in localConfigs) {
				string name = config.Replace(langRoot, null);
				name = name.Replace(".ini", null);
				name = name.Replace("\\", null);

				if(name!="en-us") {
					Localizations.Add(new(name, config));
				}
					
			}

			ActiveLocalization = Localizations.Where(l => l.name == c.Language).FirstOrDefault();

			//ActiveLocalization ??= new("en-us", EnglishUS);


		}

		


	}
}
