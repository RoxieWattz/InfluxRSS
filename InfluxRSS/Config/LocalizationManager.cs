using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluxRSS.Config {
	public class LocalizationManager {
		private static Dictionary<string, string> EnglishUS { get; } = new() {
			{ "dictionary.name", "English (US)" },
			{ "dictionary.author", "Roxie Wattz" },
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
		public Localization? ActiveLocalization;

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

			// Try to set the active localization here based on the configuration
			ActiveLocalization = Localizations.FirstOrDefault(l => l.ID == c.Language);

			// If it ends up being null (caused by the user putting a bad string in
			// the config.txt file), just set it to EN-US so no exceptions are raised.
			ActiveLocalization ??= Localizations[0];
		}
	}
}