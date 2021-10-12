namespace SimpleDesktopShell.Security
{
	public sealed class TaskManager : RegistryTweak
	{
		protected override string RegisterKeyPath { get; init; } =
			@"Software\Microsoft\Windows\CurrentVersion\Policies\System";
		protected override string ValueName { get; init; } = "DisableTaskMgr";
		protected override object EnableValue { get; init; } = 1;
	}
}
