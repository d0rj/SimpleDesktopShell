using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDesktopShell.Security
{
	public class WindowsButton
	{
		private const string RegisterKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer";

		public static void SetEnabled(bool isEnabled)
		{

			using RegistryKey localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

			var reg = localMachine.OpenSubKey(RegisterKeyPath, true);
			if (reg == null)
			{
				reg = localMachine.CreateSubKey(RegisterKeyPath);
			}
			reg.Dispose();

			using RegistryKey objRegistryKey =
				Registry.CurrentUser.CreateSubKey(RegisterKeyPath);
			if (isEnabled && objRegistryKey.GetValue("NoWinKeys") != null)
			{
				objRegistryKey.DeleteValue("NoWinKeys");
			}
			else
			{
				objRegistryKey.SetValue("NoWinKeys", "1");
			}
		}
	}
}
