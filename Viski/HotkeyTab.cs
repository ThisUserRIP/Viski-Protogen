using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000074 RID: 116
	public static class HotkeyTab
	{
		// Token: 0x06000281 RID: 641 RVA: 0x00016E84 File Offset: 0x00015084
		public static void Tab()
		{
			GUILayout.BeginArea(new Rect(340f, 20f, 650f, 610f), "Hotkeys", "box");
			HotkeyTab.vector2_0 = GUILayout.BeginScrollView(HotkeyTab.vector2_0, Array.Empty<GUILayoutOption>());
			foreach (KeyValuePair<string, KeyCode> keyValuePair in G.Settings.GlobalOptions.Hotkeyd.ToList<KeyValuePair<string, KeyCode>>())
			{
				string str = (!HotkeyTab.bool_0 || !(HotkeyTab.string_0 == keyValuePair.Key)) ? G.Settings.GlobalOptions.Hotkeyd[keyValuePair.Key].ToString() : "None";
				if (GUILayout.Button(keyValuePair.Key + " - <size=20>[" + str + "]</size>", "NavBox", Array.Empty<GUILayoutOption>()))
				{
					HotkeyTab.bool_0 = true;
					HotkeyTab.string_0 = keyValuePair.Key;
				}
			}
			if (HotkeyTab.bool_0)
			{
				Event current = Event.current;
				if (current.type == 4)
				{
					G.Settings.GlobalOptions.Hotkeyd[HotkeyTab.string_0] = current.keyCode;
					HotkeyTab.bool_0 = false;
				}
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		// Token: 0x040002F2 RID: 754
		private static bool bool_0 = false;

		// Token: 0x040002F3 RID: 755
		private static string string_0 = string.Empty;

		// Token: 0x040002F4 RID: 756
		private static Vector2 vector2_0 = new Vector2(0f, 0f);
	}
}
