using SHDocVw;

using System.Diagnostics;
using System.IO;
using System.Threading;


namespace SimpleDesktopShell
{
	public static class Explorer
	{
		public static void Reload()
		{
			foreach (Process proc in Process.GetProcessesByName("explorer"))
			{
				proc.Kill();
			}
			_ = Process.Start("explorer.exe");

			ShellWindows windows;
			while ((windows = new ShellWindows()).Count == 0)
			{
				Thread.Sleep(50);
			}

			foreach (InternetExplorer p in windows)
			{
				if (Path.GetFileNameWithoutExtension(p.FullName.ToLower()) == "explorer")
				{
					p.Quit();
				}
			}
		}
	}
}
