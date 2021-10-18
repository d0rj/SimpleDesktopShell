namespace SimpleDesktopShell.Security.Tweaks
{
	/// <summary> Tweak which can disable command-line access for simple user.
	///	<remarks>You need to reload Explorer after activation/deactivation</remarks>
	/// </summary>
	public sealed class CommandLineDisabler : SetRegistryTweak
	{
		protected override string RegisterKeyPath { get; init; } = @"Software\Policies\Microsoft\Windows";
		protected override string ValueName { get; init; } = "DisableCMD";
		protected override object FillValue { get; init; } = "2";
	}
}
