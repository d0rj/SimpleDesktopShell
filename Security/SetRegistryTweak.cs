using Microsoft.Win32;


namespace SimpleDesktopShell.Security
{
	/// <summary> Tweak which activates with Windows Register
	/// by setting some value and deactivates with deleting this value</summary>
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
