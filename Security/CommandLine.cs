namespace SimpleDesktopShell.Security
{
	public sealed class CommandLine : RegistryTweak
	{
		protected override string RegisterKeyPath { get; init; } = @"Software\Policies\Microsoft\Windows";
		protected override string ValueName { get; init; } = "DisableCMD";
		protected override object EnableValue { get; init; } = "2";
	}
}
