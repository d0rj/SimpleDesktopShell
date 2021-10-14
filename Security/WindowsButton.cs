using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
