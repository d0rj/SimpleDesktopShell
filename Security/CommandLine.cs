using Microsoft.Win32;


namespace SimpleDesktopShell.Security
{
	public class CommandLine
	{
		private const string RegisterKeyPath = @"Software\Policies\Microsoft\Windows";

		public static void SetEnabled(bool isEnabled)
		{
			using RegistryKey objRegistryKey =
				Registry.CurrentUser.CreateSubKey(RegisterKeyPath);

			if (isEnabled && objRegistryKey.GetValue("DisableCMD") != null)
			{
				objRegistryKey.DeleteValue("DisableCMD");
			}
			else
			{
				objRegistryKey.SetValue("DisableCMD", "2");
			}
		}
	}
}
