using System;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200002C RID: 44
	public class Hotkeys
	{
		// Token: 0x060000B1 RID: 177 RVA: 0x0000A5D4 File Offset: 0x000087D4
		public static void AddKey()
		{
			Hotkeys.AddKey("Menu", 282);
			Hotkeys.AddKey("Freecam", 283);
			Hotkeys.AddKey("Aimbot", 102);
			Hotkeys.AddKey("Zoom", 98);
			Hotkeys.AddKey("Disconnect", 286);
			Hotkeys.AddKey("VehicleFly", 301);
			Hotkeys.AddKey("Backtrack", 116);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000A648 File Offset: 0x00008848
		public static KeyCode GetKey(string identifier)
		{
			KeyCode keyCode;
			KeyCode result;
			if (G.Settings.GlobalOptions.Hotkeyd.TryGetValue(identifier, out keyCode))
			{
				result = keyCode;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000A67C File Offset: 0x0000887C
		public static string HotkeyToHex(KeyCode color)
		{
			return color.ToString("X2");
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000A6A4 File Offset: 0x000088A4
		public static void AddKey(string id, KeyCode c)
		{
			if (!G.Settings.GlobalOptions.Hotkeyd.ContainsKey(id))
			{
				G.Settings.GlobalOptions.Hotkeyd.Add(id, c);
			}
		}
	}
}
