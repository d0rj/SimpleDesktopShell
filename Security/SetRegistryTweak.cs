using Microsoft.Win32;


namespace SimpleDesktopShell.Security
{
	public abstract class SetRegistryTweak : RegistryTweak
	{
		public override void SetEnabled(bool isEnabled)
		{
			CreatePathIfNotExists();
			using RegistryKey objRegistryKey =
				Registry.CurrentUser.CreateSubKey(RegisterKeyPath);

			if (isEnabled)
			{
				objRegistryKey.SetValue(ValueName, FillValue);
			}
			else if (objRegistryKey.GetValue(ValueName) != null)
			{
				objRegistryKey.DeleteValue(ValueName);
			}
		}
	}
}
