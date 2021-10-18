using Microsoft.Win32;


namespace SimpleDesktopShell.Security
{
	/// <summary> Tweak which activates with Windows Register
	/// by some values changes </summary>
	public abstract class RegistryTweak : ITweak
	{
		/// <summary> Path of Register value to change </summary>
		protected abstract string RegisterKeyPath { get; init; }
		/// <summary> Name of value to create/change/delete/ect. </summary>
		protected abstract string ValueName { get; init; }
		/// <summary> Value to set when tweak setted to Enable state </summary>
		protected abstract object FillValue { get; init; }

		/// <summary> Create Register path if it's not exists </summary>
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
