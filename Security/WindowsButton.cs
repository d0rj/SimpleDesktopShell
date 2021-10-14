namespace SimpleDesktopShell.Security
{
	public sealed class WindowsButton : SetRegistryTweak
	{
		protected override string RegisterKeyPath { get; init; } =
			@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer";
		protected override string ValueName { get; init; } = "NoWinKeys";
		protected override object FillValue { get; init; } = "1";
	}
}
