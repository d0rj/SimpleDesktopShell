using System.Collections.Generic;


namespace SimpleDesktopShell.Security
{
	/// <summary> Tweak which activate other tweaks in order
	/// relative by Windows Explorer reload </summary>
	public class Tweaker : ITweak
	{
		/// <summary> Tweaks to activate before Explorer reload </summary>
		public List<ITweak> BeforeReloadTweaks { get; init; }
		/// <summary> Tweaks to activate after Explorer reload </summary>
		public List<ITweak> AfterReloadTweaks { get; init; }

		public void SetEnabled(bool isEnabled)
		{
			if (isEnabled)
			{
				foreach (ITweak tweak in BeforeReloadTweaks)
				{
					tweak.Enable();
				}
				Explorer.Reload();
				foreach (ITweak tweak in AfterReloadTweaks)
				{
					tweak.Enable();
				}
			}
			else
			{
				foreach (ITweak tweak in BeforeReloadTweaks)
				{
					tweak.Disable();
				}
				Explorer.Reload();
				foreach (ITweak tweak in AfterReloadTweaks)
				{
					tweak.Disable();
				}
			}
		}
	}
}
