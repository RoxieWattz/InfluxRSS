using InfluxRSS.Config;
using InfluxRSS.Feed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InfluxRSS {
	/// <summary>
	/// Interaction logic for ControlFeedItem.xaml
	/// </summary>
	public partial class ControlFeedItem : UserControl {
		// TODO: Merge FeedItem class with this class so it's not a mess
		// This is here for click events so the full article can open in a web browser
		private readonly string? URL;
		public ControlFeedItem(LocalizationManager l, FeedItem f) {
			InitializeComponent();

			URL = f.URL;

			FeedTitle.Content = f.Title;
			// overly long string for metadata stuff :D
			FeedMetadata.Content = $"{f.Date} | {l.ActiveLocalization.GetTextFromKey("item.by")} " +
				$"{f.Author} | {l.ActiveLocalization.GetTextFromKey("item.source")} + {f.Source}";
			FeedDescription.Text = $"{l.ActiveLocalization.GetTextFromKey("item.source")} {f.Description}";
		}
	}
}