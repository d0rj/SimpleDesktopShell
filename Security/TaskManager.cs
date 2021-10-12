using Microsoft.Win32;


namespace SimpleDesktopShell.Security
{
	public static class TaskManager
	{
		public static void SetEnabled(bool isEnabled)
		{
			using RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
				@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
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
