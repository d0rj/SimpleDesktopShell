namespace SimpleDesktopShell.Security
{
	public sealed class TaskManagerDisabler : SetRegistryTweak
	{
		protected override string RegisterKeyPath { get; init; } =
			@"Software\Microsoft\Windows\CurrentVersion\Policies\System";
		protected override string ValueName { get; init; } = "DisableTaskMgr";
		protected override object FillValue { get; init; } = "1";
	}
}
