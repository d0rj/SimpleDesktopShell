namespace SimpleDesktopShell.Security.Tweaks
{
	/// <summary> Tweak which can disable all sortcuts with WIN button.
	/// <remarks>You need to reload Explorer after activation/deactivation</remarks>
	/// </summary>
	public sealed class WindowsButtonDisabler : SetRegistryTweak
	{
		protected override string RegisterKeyPath { get; init; } =
			@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer";
		protected override string ValueName { get; init; } = "NoWinKeys";
		protected override object FillValue { get; init; } = "1";
	}
}
