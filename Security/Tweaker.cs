using System.Collections.Generic;


namespace SimpleDesktopShell.Security
{
	public class Tweaker : ITweak
	{
		public List<ITweak> BeforeReloadTweaks { get; init; }
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
				foreach (ITweak tweak in AfterReloadTweaks)
				{
					tweak.Disable();
				}
				Explorer.Reload();
				foreach (ITweak tweak in BeforeReloadTweaks)
				{
					tweak.Disable();
				}
			}
		}
	}
}
