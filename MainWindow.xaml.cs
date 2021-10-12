using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

using SimpleDesktopShell.Security;


namespace SimpleDesktopShell
{
	public sealed partial class MainWindow : Window
	{
		private readonly ITweak hideTaskbar = new TaskbarDisabler();
		private readonly ITweak cmdDisabler = new CommandLine();
		private readonly ITweak disableTaskManager = new TaskManager();
		private readonly ITweak disableWindows = new WindowsButton();

		public MainWindow()
		{
			hideTaskbar.Enable();
			disableTaskManager.Enable();
			disableWindows.Enable();
			cmdDisabler.Enable();

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
			disableTaskManager.Disable();
			disableWindows.Disable();
			cmdDisabler.Disable();
			hideTaskbar.Disable();
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
