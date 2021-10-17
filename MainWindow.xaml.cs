using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

using SimpleDesktopShell.Security;
using SimpleDesktopShell.Security.Tweaks;


namespace SimpleDesktopShell
{
	public sealed partial class MainWindow : Window
	{
		private readonly ITweak tweaks = new Tweaker 
		{
			BeforeReloadTweaks = new List<ITweak> 
			{
				new WindowsButtonDisabler(),
				new CommandLineDisabler(),
			},
			AfterReloadTweaks = new List<ITweak>
			{
				new TaskbarDisabler(),
				new TaskManagerDisabler(),
			},
		};

		public MainWindow()
		{
			tweaks.Enable();

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
			tweaks.Disable();
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
