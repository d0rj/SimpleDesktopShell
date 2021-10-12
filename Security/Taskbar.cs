using System.Runtime.InteropServices;


namespace SimpleDesktopShell.Security
{
	public class Taskbar
	{
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int FindWindow(string className, string windowText);
		[DllImport("user32.dll")]
		private static extern int ShowWindow(int hwnd, int command);

		private const int SW_HIDE = 0;
		private const int SW_SHOW = 1;

		protected static int Handle => FindWindow("Shell_TrayWnd", "");

		private Taskbar() { }

		public static void Show()
		{
			_ = ShowWindow(Handle, SW_SHOW);
		}

		public static void Hide()
		{
			_ = ShowWindow(Handle, SW_HIDE);
		}
	}
}
