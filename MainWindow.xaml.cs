using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

using SimpleDesktopShell.Security;


namespace SimpleDesktopShell
{
	public sealed partial class MainWindow : Window
	{
		private readonly IEnumerable<ITweak> tweaks = new List<ITweak>()
		{
			new TaskbarDisabler(),
			new CommandLineDisabler(),
			new TaskManagerDisabler(),
			new WindowsButtonDisabler(),
		};

		public MainWindow()
		{
			foreach (ITweak tweak in tweaks)
				tweak.Enable();

			InitializeComponent();

			PreviewKeyDown += (object sender, KeyEventArgs e) =>
			{
				if (e.Key == Key.System)
				{
					e.Handled = true;
				}
			};
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			foreach (ITweak tweak in tweaks)
				tweak.Disable();
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
