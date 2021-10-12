namespace SimpleDesktopShell.Security
{
	public interface ITweak
	{
		public void SetEnabled(bool isEnabled);
		public void Enable() => SetEnabled(true);
		public void Disable() => SetEnabled(false);
	}
}
