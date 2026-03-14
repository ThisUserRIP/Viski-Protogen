using System;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000079 RID: 121
	public static class SettingsTab
	{
		// Token: 0x06000290 RID: 656 RVA: 0x000191F8 File Offset: 0x000173F8
		public static InteractableItem FirstNotNull(this List<InteractableItem> items)
		{
			foreach (InteractableItem interactableItem in items)
			{
				if (interactableItem != null)
				{
					return interactableItem;
				}
			}
			return null;
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00019250 File Offset: 0x00017450
		public static void Tab()
		{
			GUILayout.Space(0f);
			Rect rect = new Rect(335f, 10f, 660f, 90f);
			GUIStyle guistyle = "box";
			GUILayout.BeginArea(rect, string.Format("<b>{0}</b>", SettingsTab.Select), guistyle);
			SettingsTab.Select = (SettingsOptions)GUI.Toolbar(new Rect(15f, 40f, 630f, 80f), (int)SettingsTab.Select, Main.SettingsButtons.ToArray(), "NavBox");
			GUILayout.EndArea();
			Rect rect2 = new Rect(335f, 105f, 350f, 530f);
			guistyle = "box";
			GUILayout.BeginArea(rect2, string.Format("<b>{0}</b>", SettingsTab.Select), guistyle);
			switch (SettingsTab.Select)
			{
			case SettingsOptions.Config:
				SettingsTab.string_0 = GUILayout.TextField(SettingsTab.string_0, Array.Empty<GUILayoutOption>());
				if (GUILayout.Button("Create Config", "NavBox", Array.Empty<GUILayoutOption>()) && !string.IsNullOrEmpty(SettingsTab.string_0))
				{
					ConfigUtilities.SaveConfig(SettingsTab.string_0, true);
					SettingsTab.string_0 = "";
				}
				if (GUILayout.Button("Save Current Config", "NavBox", Array.Empty<GUILayoutOption>()))
				{
					ConfigUtilities.SaveConfig(ConfigUtilities.SelectedConfig, false);
				}
				break;
			case SettingsOptions.Colors:
				if (G.Settings.GlobalOptions.GlobalColors.Count > 0)
				{
					SettingsTab.vector2_0 = GUILayout.BeginScrollView(SettingsTab.vector2_0, Array.Empty<GUILayoutOption>());
					List<string> list = new List<string>(G.Settings.GlobalOptions.GlobalColors.Keys);
					for (int i = 0; i < list.Count; i++)
					{
						string text = list[i];
						Color32 color = C.GetColor(text);
						string text2 = string.Concat(new string[]
						{
							"<color=#",
							C.ColorToHex(color),
							">",
							text.Replace("_", " "),
							"</color>"
						});
						if (GUILayout.Button(text2, "NavBox", Array.Empty<GUILayoutOption>()))
						{
							SettingsTab.SelectedColorIdentifier = text;
						}
					}
					GUILayout.EndScrollView();
				}
				break;
			case SettingsOptions.Information:
				GUILayout.Label("<b>Status: Undetected</b>", Array.Empty<GUILayoutOption>());
				GUILayout.Label("<b>Owner: Kawauchi.</b>1", Array.Empty<GUILayoutOption>());
				GUILayout.Label("<b>Owner: Shadow</b>", Array.Empty<GUILayoutOption>());
				GUILayout.Label("<b>Discord: .gg/Pgwg69hsCN</b>", Array.Empty<GUILayoutOption>());
				GUILayout.Label("<b>Youtube: .com/UnturnedHack</b>", Array.Empty<GUILayoutOption>());
				if (VectorUtilities.ShouldRun() && Provider.CurrentServerAdvertisement.ip.ToString() != null)
				{
					GUILayout.TextField("Ip&Port: " + Parser.getIPFromUInt32(Provider.CurrentServerAdvertisement.ip) + ":" + Provider.CurrentServerAdvertisement.queryPort.ToString(), new GUILayoutOption[0]);
				}
				break;
			case SettingsOptions.PlayerFinder:
				SettingsTab.vector2_1 = GUILayout.BeginScrollView(SettingsTab.vector2_1, Array.Empty<GUILayoutOption>());
				if (Misc.findedPlayers.Count == 0)
				{
					GUILayout.Label("No Player Finded", Array.Empty<GUILayoutOption>());
				}
				else
				{
					foreach (Misc.FindedPlayer findedPlayer in Misc.findedPlayers)
					{
						GUILayout.Label(string.Concat(new string[]
						{
							string.Format("[{0}:{1}]", Parser.getIPFromUInt32(findedPlayer.ip), findedPlayer.port),
							"\nServer Name : ",
							findedPlayer.name.Substring(0, Math.Min(25, findedPlayer.name.Length)),
							"\nPlayer Name : ",
							findedPlayer.nickname.Substring(0, Math.Min(15, findedPlayer.nickname.Length))
						}), Array.Empty<GUILayoutOption>());
						if (GUILayout.Button("Join", "NavBox", Array.Empty<GUILayoutOption>()))
						{
							SteamConnectionInfo steamConnectionInfo = new SteamConnectionInfo(findedPlayer.ip, findedPlayer.port, "");
							MenuPlayConnectUI.connect(steamConnectionInfo, true, 0);
						}
						GUILayout.Space(5f);
					}
				}
				if (Misc.isFindingEnded || Misc.isFinding)
				{
					if (!Misc.isFindingEnded)
					{
						if (!Misc.isFinding || Misc.isServersFetched)
						{
							if (Misc.isFinding)
							{
								GUILayout.Label(string.Format("Servers fetched ({0})", Provider.provider.matchmakingService.serverList.Count), Array.Empty<GUILayoutOption>());
								GUILayout.Label(string.Format("Searching players ({0}/{1})", Misc.currentlySearchesIndex, Provider.provider.matchmakingService.serverList.Count), Array.Empty<GUILayoutOption>());
							}
						}
						else
						{
							GUILayout.Label(string.Format("Fetching servers... (currently fetched {0})", Provider.provider.matchmakingService.serverList.Count), Array.Empty<GUILayoutOption>());
						}
					}
					else
					{
						GUILayout.Label(string.Format("Scanned all servers ({0})", Provider.provider.matchmakingService.serverList.Count), Array.Empty<GUILayoutOption>());
					}
				}
				GUILayout.EndScrollView();
				break;
			}
			GUILayout.EndArea();
			Rect rect3 = new Rect(695f, 105f, 300f, 530f);
			guistyle = "box";
			GUILayout.BeginArea(rect3, string.Format("<b>{0}</b>", SettingsTab.Select), guistyle);
			switch (SettingsTab.Select)
			{
			case SettingsOptions.Config:
				GUILayout.Space(5f);
				SettingsTab.vector2_1 = GUILayout.BeginScrollView(SettingsTab.vector2_1, Array.Empty<GUILayoutOption>());
				foreach (string text3 in ConfigUtilities.GetConfigs(false))
				{
					string text4 = text3;
					if (text4 == ConfigUtilities.SelectedConfig)
					{
						text4 = "<b>" + text4 + "</b>";
					}
					if (GUILayout.Button(text4, "NavBox", Array.Empty<GUILayoutOption>()))
					{
						ConfigUtilities.LoadConfig(text4);
					}
				}
				GUILayout.EndScrollView();
				break;
			case SettingsOptions.Colors:
			{
				List<string> list2 = new List<string>(G.Settings.GlobalOptions.GlobalColors.Keys);
				for (int j = 0; j < list2.Count; j++)
				{
					string text5 = list2[j];
					Color32 color2 = C.GetColor(text5);
					string.Concat(new string[]
					{
						"<color=#",
						C.ColorToHex(color2),
						">",
						text5.Replace("_", " "),
						"</color>"
					});
					if (SettingsTab.SelectedColorIdentifier == text5)
					{
						GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
						Color32 color3 = color2;
						Color32 color4 = default(Color32);
						color4.a = byte.MaxValue;
						Color32 value = color4;
						GUILayout.Label("Color Preview", Array.Empty<GUILayoutOption>());
						GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
						GUIStyle guistyle2 = new GUIStyle(GUI.skin.box);
						guistyle2.normal.background = Texture2D.whiteTexture;
						Color color5 = GUI.color;
						GUI.color = new Color32(color3.r, color3.g, color3.b, byte.MaxValue);
						GUILayout.Box(GUIContent.none, guistyle2, new GUILayoutOption[]
						{
							GUILayout.Width(140f),
							GUILayout.Height(75f)
						});
						GUI.color = Color.white;
						GUILayout.Box(GUIContent.none, guistyle2, new GUILayoutOption[]
						{
							GUILayout.Width(140f),
							GUILayout.Height(75f)
						});
						GUI.color = color5;
						GUILayout.EndHorizontal();
						GUILayout.Space(5f);
						GUILayout.Label("R: " + color3.r.ToString(), Array.Empty<GUILayoutOption>());
						value.r = (byte)GUILayout.HorizontalSlider((float)color3.r, 0f, 255f, Array.Empty<GUILayoutOption>());
						GUILayout.Space(2f);
						GUILayout.Label("G: " + color3.g.ToString(), Array.Empty<GUILayoutOption>());
						value.g = (byte)GUILayout.HorizontalSlider((float)color3.g, 0f, 255f, Array.Empty<GUILayoutOption>());
						GUILayout.Space(2f);
						GUILayout.Label("B: " + color3.b.ToString(), Array.Empty<GUILayoutOption>());
						value.b = (byte)GUILayout.HorizontalSlider((float)color3.b, 0f, 255f, Array.Empty<GUILayoutOption>());
						G.Settings.GlobalOptions.GlobalColors[text5] = value;
						GUILayout.EndVertical();
					}
				}
				break;
			}
			case SettingsOptions.PlayerFinder:
				if (Misc.isFinding)
				{
					if (GUILayout.Button("Stop searching", "NavBox", Array.Empty<GUILayoutOption>()))
					{
						Misc.main.StopSearcesImmediate();
					}
				}
				else
				{
					GUILayout.Label("Enter nick to find player on unturned servers", Array.Empty<GUILayoutOption>());
					SettingsTab.playerNickname = GUILayout.TextField(SettingsTab.playerNickname, Array.Empty<GUILayoutOption>());
					if (GUILayout.Button("Start Searching", "NavBox", Array.Empty<GUILayoutOption>()))
					{
						Misc.main.StartPlayerSearching(SettingsTab.playerNickname);
					}
				}
				break;
			}
			GUILayout.EndArea();
		}

		// Token: 0x04000302 RID: 770
		public static string playerNickname = "";

		// Token: 0x04000303 RID: 771
		public static string SelectedColorIdentifier = "";

		// Token: 0x04000304 RID: 772
		private static Vector2 vector2_0;

		// Token: 0x04000305 RID: 773
		public static SettingsOptions Select = SettingsOptions.Config;

		// Token: 0x04000306 RID: 774
		private static string string_0 = "New Config";

		// Token: 0x04000307 RID: 775
		private static Vector2 vector2_1 = new Vector2(0f, 0f);
	}
}
