using System.Windows;
using System.Windows.Input;


namespace SimpleDesktopShell
{
	public sealed partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			PreviewKeyDown += (object sender, KeyEventArgs e) =>
			{
				if (e.Key == Key.Escape)
				{
					Close();
				}
				if (e.Key == Key.System && e.SystemKey == Key.F4)
				{
					e.Handled = true;
				}
			};
		}
	}
}
