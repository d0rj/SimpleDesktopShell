using Microsoft.Win32;


namespace SimpleDesktopShell.Security
{
	public static class TaskManager
	{
		private const string RegisterKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";

		public static void SetEnabled(bool isEnabled)
		{
			using RegistryKey objRegistryKey =
				Registry.CurrentUser.CreateSubKey(RegisterKeyPath);

			if (isEnabled && objRegistryKey.GetValue("DisableTaskMgr") != null)
			{
				objRegistryKey.DeleteValue("DisableTaskMgr");
			}
			else
			{
				objRegistryKey.SetValue("DisableTaskMgr", "1");
			}
		}
	}
}
