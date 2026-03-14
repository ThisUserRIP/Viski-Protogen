using System;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200006F RID: 111
	[Component]
	public class Main : MonoBehaviour
	{
		// Token: 0x0600026C RID: 620 RVA: 0x000154E0 File Offset: 0x000136E0
		public void OnGUI()
		{
			if (!SpyUtilities.BeingSpied)
			{
				GUI.skin = Asset.Skin;
				foreach (NotificationWindow notificationWindow in NotificationWindow.Notifications)
				{
					notificationWindow.Run();
				}
				if (Main.MenuOpen)
				{
					if (Main._cursorTexture == null)
					{
						Main._cursorTexture = Asset.Textures["Imleç"];
					}
					GUI.Label(new Rect(Main.WindowRect.x + 80f, Main.WindowRect.y + 122f, 32f, 32f), Asset.AimbotIcon);
					GUI.Label(new Rect(Main.WindowRect.x + 80f, Main.WindowRect.y + 183f, 32f, 32f), Asset.VisualIcon);
					GUI.Label(new Rect(Main.WindowRect.x + 80f, Main.WindowRect.y + 245f, 32f, 32f), Asset.MiscIcon);
					GUI.Label(new Rect(Main.WindowRect.x + 80f, Main.WindowRect.y + 305f, 32f, 32f), Asset.PlayerIcon);
					GUI.Label(new Rect(Main.WindowRect.x + 80f, Main.WindowRect.y + 370f, 40f, 40f), Asset.SkinIcon);
					GUI.Label(new Rect(Main.WindowRect.x + 80f, Main.WindowRect.y + 430f, 32f, 32f), Asset.SettingsIcon);
					GUI.Label(new Rect(Main.WindowRect.x + 80f, Main.WindowRect.y + 493f, 32f, 32f), Asset.KeyboardIcon);
					GUI.Label(new Rect(Main.WindowRect.x + 130f, Main.WindowRect.y + 30f, 500f, 70f), "<size=30><b>DarkNight</b></size>");
					GUI.Label(new Rect(Main.WindowRect.x + 17f, Main.WindowRect.y + -11f, 120f, 120f), Asset.DNLogo);
					GUI.Label(new Rect(Main.WindowRect.x + 37f, Main.WindowRect.y + 570f, 50f, 50f), Asset.Battleye);
					GUI.depth = -1;
					GUIStyle guistyle = new GUIStyle("label");
					guistyle.margin = new RectOffset(10, 10, 5, 5);
					guistyle.fontSize = 22;
					Main.WindowRect = GUILayout.Window(1, Main.WindowRect, new GUI.WindowFunction(Main.MW), "", Array.Empty<GUILayoutOption>());
					GUI.depth = -2;
					Main.CursorPos.x = Input.mousePosition.x;
					Main.CursorPos.y = (float)Screen.height - Input.mousePosition.y;
					GUI.DrawTexture(Main.CursorPos, Main._cursorTexture);
					Cursor.lockState = 0;
					if (PlayerUI.window != null)
					{
						PlayerUI.window.showCursor = true;
					}
					GUI.skin = null;
				}
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00015874 File Offset: 0x00013A74
		public void Update()
		{
			if (Input.GetKeyDown(Hotkeys.GetKey("Menu")))
			{
				if (!Main.MenuOpen)
				{
					Main.MenuOpen = true;
				}
				else
				{
					Main.MenuOpen = false;
				}
			}
			if (Input.GetKeyDown(Hotkeys.GetKey("Freecam")))
			{
				if (G.Settings.MiscOptions.Freecam = !G.Settings.MiscOptions.Freecam)
				{
					NotificationWindow.AddNotification("FreeCam <b> ON</b>");
				}
				else
				{
					NotificationWindow.AddNotification("FreeCam <b> OFF</b>");
				}
			}
			if (Input.GetKeyDown(Hotkeys.GetKey("VehicleFly")))
			{
				if (!(G.Settings.MiscOptions.VehicleFly = !G.Settings.MiscOptions.VehicleFly))
				{
					NotificationWindow.AddNotification("VehicleFly <b> OFF</b>");
				}
				else
				{
					NotificationWindow.AddNotification("VehicleFly <b> ON</b>");
				}
			}
			if (Input.GetKeyDown(Hotkeys.GetKey("Backtrack")))
			{
				if (!(G.Settings.BacktrackOptions.Enabled = !G.Settings.BacktrackOptions.Enabled))
				{
					NotificationWindow.AddNotification("Backtrack <b> OFF</b>");
				}
				else
				{
					NotificationWindow.AddNotification("Backtrack <b> ON</b>");
				}
			}
			if (Input.GetKeyDown(Hotkeys.GetKey("Disconnect")))
			{
				Provider.disconnect();
				NotificationWindow.AddNotification("Disconnect");
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x000159C4 File Offset: 0x00013BC4
		public void Start()
		{
			foreach (object obj in Enum.GetValues(typeof(Main.MenuTab)))
			{
				Main.MenuTab menuTab = (Main.MenuTab)obj;
				Main.MenuButtons.Add(new GUIContent(Enum.GetName(typeof(Main.MenuTab), menuTab)));
			}
			foreach (object obj2 in Enum.GetValues(typeof(Visual.ESPObject)))
			{
				Visual.ESPObject espobject = (Visual.ESPObject)obj2;
				Main.VisualButtons.Add(new GUIContent(Enum.GetName(typeof(Visual.ESPObject), espobject)));
			}
			foreach (object obj3 in Enum.GetValues(typeof(SettingsOptions)))
			{
				SettingsOptions settingsOptions = (SettingsOptions)obj3;
				Main.SettingsButtons.Add(new GUIContent(Enum.GetName(typeof(SettingsOptions), settingsOptions)));
			}
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00015B4C File Offset: 0x00013D4C
		public static void MW(int windowID)
		{
			GUILayout.Space(0f);
			switch (Main.SelectedTab)
			{
			case Main.MenuTab.Aimbot:
				AimbotTab.Tab();
				break;
			case Main.MenuTab.Visuals:
				VisualsTab.Tab();
				break;
			case Main.MenuTab.Misc:
				MiscTab.Tab();
				break;
			case Main.MenuTab.Players:
				PlayersTab.Tab();
				break;
			case Main.MenuTab.Settings:
				SettingsTab.Tab();
				break;
			case Main.MenuTab.const_6:
				HotkeyTab.Tab();
				break;
			}
			GUILayout.BeginArea(new Rect(35f, 108f, 260f, 500f));
			int fontSize = GUI.skin.button.fontSize;
			GUI.skin.button.fixedHeight = 58f;
			GUI.skin.button.fontSize = 20;
			Main.SelectedTab = (Main.MenuTab)GUILayout.SelectionGrid((int)Main.SelectedTab, Main.MenuButtons.ToArray(), 1, Array.Empty<GUILayoutOption>());
			GUI.skin.button.fixedHeight = 40f;
			GUI.skin.button.fontSize = fontSize;
			GUILayout.EndArea();
			GUI.DragWindow();
		}

		// Token: 0x040002D8 RID: 728
		public static bool MenuOpen = true;

		// Token: 0x040002D9 RID: 729
		public static Main.MenuTab SelectedTab = Main.MenuTab.Aimbot;

		// Token: 0x040002DA RID: 730
		public static Rect WindowRect = new Rect(80f, 80f, 1010f, 645f);

		// Token: 0x040002DB RID: 731
		public static List<GUIContent> SettingsButtons = new List<GUIContent>();

		// Token: 0x040002DC RID: 732
		public static List<GUIContent> SkinButtons = new List<GUIContent>();

		// Token: 0x040002DD RID: 733
		public static List<GUIContent> VisualButtons = new List<GUIContent>();

		// Token: 0x040002DE RID: 734
		public static List<GUIContent> MenuButtons = new List<GUIContent>();

		// Token: 0x040002DF RID: 735
		public static Rect CursorPos = new Rect(0f, 0f, 20f, 20f);

		// Token: 0x040002E0 RID: 736
		public static Texture _cursorTexture;

		// Token: 0x040002E1 RID: 737
		public static Color GUIColor;

		// Token: 0x02000070 RID: 112
		public enum MenuTab
		{
			// Token: 0x040002E3 RID: 739
			Aimbot,
			// Token: 0x040002E4 RID: 740
			Visuals,
			// Token: 0x040002E5 RID: 741
			Misc,
			// Token: 0x040002E6 RID: 742
			Players,
			// Token: 0x040002E7 RID: 743
			Skins,
			// Token: 0x040002E8 RID: 744
			Settings,
			// Token: 0x040002E9 RID: 745
			const_6
		}
	}
}
