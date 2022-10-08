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
		// The default dictionary, which cannot be overridden.
		// TODO: Add dictionary.title as a key for better UX
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

		// Available localizations for the settings menu to display
		private List<Localization> Localizations;
		
		// The localization that is currently being used by the program
		public Localization ActiveLocalization;

		public LocalizationManager(ConfigManager c) {
			
			// set stuff here idfk i'm getting pissed
			string langRoot = "localization";

			// Create new folder for the language configurations
			if (!Directory.Exists(langRoot)) {
				Directory.CreateDirectory(langRoot);
			}

			// Scan the (potentially new) directory for configurations
			string[] localConfigs = Directory.GetFiles(langRoot);

			Localizations = new();
			
			// Add the default language
			Localizations.Add(new("en-us", EnglishUS));

			// Add each config file to the available language configs...
			foreach (string config in localConfigs) {
				string name = config.Replace(langRoot, null);
				name = name.Replace(".ini", null);
				name = name.Replace("\\", null);

				// ...unless one of them is named "en-us.ini!"
				if(name!="en-us") {
					Localizations.Add(new(name, config));
				}
					
			}

			// Gay computer magic (idk what else to put here, it's midnight and I'm tired as hell
			try {
				ActiveLocalization = Localizations.FirstOrDefault(l => l.name == c.Language);
			} catch (ArgumentNullException) {
				ActiveLocalization = Localizations[0];
			}
			

			


		}

		


	}
}
