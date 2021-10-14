using Microsoft.Win32;


namespace SimpleDesktopShell.Security
{
	public abstract class RegistryTweak : ITweak
	{
		protected abstract string RegisterKeyPath { get; init; }
		protected abstract string ValueName { get; init; }
		protected abstract object FillValue { get; init; }

		protected void CreatePathIfNotExists()
		{
			using RegistryKey localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

			var reg = localMachine.OpenSubKey(RegisterKeyPath, true);
			if (reg == null)
			{
				reg = localMachine.CreateSubKey(RegisterKeyPath);
			}
			reg.Dispose();
		}

		public abstract void SetEnabled(bool isEnabled);
	}
}
