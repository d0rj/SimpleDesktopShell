namespace SimpleDesktopShell.Security
{
	public sealed class CommandLine : SetRegistryTweak
	{
		protected override string RegisterKeyPath { get; init; } = @"Software\Policies\Microsoft\Windows";
		protected override string ValueName { get; init; } = "DisableCMD";
		protected override object FillValue { get; init; } = "2";
	}
}
