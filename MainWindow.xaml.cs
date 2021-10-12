using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

using SimpleDesktopShell.Security;


namespace SimpleDesktopShell
{
	public sealed partial class MainWindow : Window
	{
		private readonly ITweak hideTaskbar = new TaskbarDisabler();

		public MainWindow()
		{
			hideTaskbar.Enable();
			TaskManager.SetEnabled(false);
			WindowsButton.SetEnabled(false);
			CommandLine.SetEnabled(false);

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
			TaskManager.SetEnabled(true);
			WindowsButton.SetEnabled(true);
			CommandLine.SetEnabled(true);
			hideTaskbar.Disable();
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
