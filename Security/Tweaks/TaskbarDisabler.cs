using System.Runtime.InteropServices;


namespace SimpleDesktopShell.Security.Tweaks
{
	public sealed class TaskbarDisabler : ITweak
	{
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int FindWindow(string className, string windowText);
		[DllImport("user32.dll")]
		private static extern int ShowWindow(int hwnd, int command);

		private const int SW_HIDE = 0;
		private const int SW_SHOW = 1;

		private static int Handle => FindWindow("Shell_TrayWnd", "");

		public void SetEnabled(bool isEnabled)
		{
			if (isEnabled)
				_ = ShowWindow(Handle, SW_HIDE);
			else
				_ = ShowWindow(Handle, SW_SHOW);
		}
	}
}
