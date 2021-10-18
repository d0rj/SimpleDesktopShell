namespace SimpleDesktopShell.Security
{
	/// <summary> Some system feature to enable or disable </summary>
	public interface ITweak
	{
		/// <summary> Change tweak state </summary>
		/// <param name="isEnabled"> <c>true</c> if you need to activate tweak,
		/// else <c>false</c></param>
		public void SetEnabled(bool isEnabled);
		/// <summary> Activate system tweak (same as <c>.SetEnabled(true)</c>) </summary>
		public void Enable() => SetEnabled(true);
		/// <summary> Deactivate system tweak (same as <c>.SetEnabled(false)</c>) </summary>
		public void Disable() => SetEnabled(false);
	}
}
