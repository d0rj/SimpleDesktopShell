using Microsoft.Win32;


namespace SimpleDesktopShell.Security
{
	public abstract class RegistryTweak : ITweak
	{
		protected abstract string RegisterKeyPath { get; init; }
		protected abstract string ValueName { get; init; }
		protected abstract object EnableValue { get; init; }

		private void CreatePathIfNotExists()
		{
			using RegistryKey localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

			var reg = localMachine.OpenSubKey(RegisterKeyPath, true);
			if (reg == null)
			{
				reg = localMachine.CreateSubKey(RegisterKeyPath);
			}
			reg.Dispose();
		}

		public void SetEnabled(bool isEnabled)
		{
			CreatePathIfNotExists();
			using RegistryKey objRegistryKey =
				Registry.CurrentUser.CreateSubKey(RegisterKeyPath);

			if (isEnabled && objRegistryKey.GetValue(ValueName) != null)
			{
				objRegistryKey.DeleteValue(ValueName);
			}
			else
			{
				objRegistryKey.SetValue(ValueName, EnableValue);
			}
		}
	}
}
