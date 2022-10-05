using System;
using System.Collections.Generic;
using System.Configuration;
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

using InfluxRSS.Config;

namespace InfluxRSS
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public ConfigManager cm;
		public LocalizationManager lm;

		public MainWindow()
		{
			cm = new ConfigManager();
			lm = new LocalizationManager(cm);
			InitializeComponent();

			// Populate text components
			ButtonRefresh.Content = lm.ActiveLocalization.GetTextFromKey("tools.refresh");
			ButtonSettings.Content = lm.ActiveLocalization.GetTextFromKey("tools.settings");
			ButtonAbout.Content = lm.ActiveLocalization.GetTextFromKey("tools.about");
			ButtonDonate.Content = lm.ActiveLocalization.GetTextFromKey("tools.donate");
			ButtonExit.Content = lm.ActiveLocalization.GetTextFromKey("tools.exit");

		}

		private void ButtonExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MainWin_Loaded(object sender, RoutedEventArgs e)
		{
			if (cm.FeedURIs.Count == 0) {
				FeedItemPanel.Children.Clear();
				FeedItemPanel.Children.Add(new TextBlock
				{
					MaxWidth = 447,
					TextWrapping = TextWrapping.Wrap,
					Foreground = new SolidColorBrush(Colors.Red),
					Padding = new Thickness(4),
					Text = lm.ActiveLocalization.GetTextFromKey("error.nofeeds")
				});
			}
		}
	}
}
