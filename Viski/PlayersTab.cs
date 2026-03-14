using System;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000076 RID: 118
	public class PlayersTab
	{
		// Token: 0x0600028A RID: 650 RVA: 0x00018BE4 File Offset: 0x00016DE4
		public static bool IsFriendly(Player player)
		{
			PlayersTab.<>c__DisplayClass3_0 CS$<>8__locals1 = new PlayersTab.<>c__DisplayClass3_0();
			CS$<>8__locals1.player_0 = player;
			bool result;
			if (!(CS$<>8__locals1.player_0 == Player.player))
			{
				if (Player.player.quests.groupID.m_SteamID == 0UL || !CS$<>8__locals1.player_0.quests.isMemberOfGroup(Player.player.quests.groupID))
				{
					SteamPlayer steamPlayer = Provider.clients.Find(new Predicate<SteamPlayer>(CS$<>8__locals1.method_0));
					if (steamPlayer != null)
					{
						ulong steamID = steamPlayer.playerID.steamID.m_SteamID;
						if (G.Settings.Priority.ContainsKey(steamID))
						{
							return G.Settings.Priority[steamID] == Visual.Priority.Friendly;
						}
					}
					result = false;
				}
				else
				{
					result = true;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00018CC0 File Offset: 0x00016EC0
		public static void Tab()
		{
			GUILayout.Space(0f);
			GUILayout.BeginArea(new Rect(335f, 10f, 660f, 90f), "<b>Search Tab</b>", "box");
			PlayersTab.SearchString = GUI.TextField(new Rect(15f, 40f, 630f, 80f), PlayersTab.SearchString);
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(335f, 105f, 350f, 530f), "<b>Players</b>", "box");
			PlayersTab.vector2_0 = GUILayout.BeginScrollView(PlayersTab.vector2_0, Array.Empty<GUILayoutOption>());
			for (int i = 0; i < Provider.clients.Count; i++)
			{
				SteamPlayer steamPlayer = Provider.clients[i];
				if (!(steamPlayer.player == Player.player))
				{
					if (PlayersTab.selectedplayer != steamPlayer)
					{
						if (!G.Settings.Priority.ContainsKey(steamPlayer.playerID.steamID.m_SteamID))
						{
							G.Settings.Priority.Add(steamPlayer.playerID.steamID.m_SteamID, Visual.Priority.None);
						}
						Visual.Priority priority;
						G.Settings.Priority.TryGetValue(steamPlayer.playerID.steamID.m_SteamID, out priority);
						string str = "";
						if (priority == Visual.Priority.Friendly || PlayersTab.IsFriendly(steamPlayer.player))
						{
							str = str + "<color=#" + C.ColorToHex(C.GetColor("Friendly_Player_ESP")) + ">[FRIENDLY] </color>";
						}
						if (steamPlayer.playerID.characterName.ToLower().Contains(PlayersTab.SearchString.ToLower()) && GUILayout.Button(str + steamPlayer.playerID.characterName, "NavBox", Array.Empty<GUILayoutOption>()))
						{
							PlayersTab.selectedplayer = steamPlayer;
						}
					}
					else
					{
						if (!G.Settings.Priority.ContainsKey(steamPlayer.playerID.steamID.m_SteamID))
						{
							G.Settings.Priority.Add(steamPlayer.playerID.steamID.m_SteamID, Visual.Priority.None);
						}
						Visual.Priority priority2;
						G.Settings.Priority.TryGetValue(steamPlayer.playerID.steamID.m_SteamID, out priority2);
						string str2 = "";
						if (priority2 == Visual.Priority.Friendly || PlayersTab.IsFriendly(steamPlayer.player))
						{
							str2 = str2 + "<color=#" + C.ColorToHex(C.GetColor("Friendly_Player_ESP")) + ">[FRIENDLY] </color>";
						}
						if (GUILayout.Button(str2 + steamPlayer.playerID.characterName, "NavBox", Array.Empty<GUILayoutOption>()))
						{
							PlayersTab.selectedplayer = null;
						}
					}
				}
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(695f, 105f, 300f, 530f), "<b>INFORMATION</b>", "box");
			for (int j = 0; j < Provider.clients.Count; j++)
			{
				SteamPlayer steamPlayer2 = Provider.clients[j];
				if (!(steamPlayer2.player == Player.player) && PlayersTab.selectedplayer == steamPlayer2)
				{
					if (!G.Settings.Priority.ContainsKey(steamPlayer2.playerID.steamID.m_SteamID))
					{
						G.Settings.Priority.Add(steamPlayer2.playerID.steamID.m_SteamID, Visual.Priority.None);
					}
					Visual.Priority priority3;
					G.Settings.Priority.TryGetValue(steamPlayer2.playerID.steamID.m_SteamID, out priority3);
					string str3 = "";
					if (priority3 == Visual.Priority.Friendly || PlayersTab.IsFriendly(steamPlayer2.player))
					{
						str3 = str3 + "<color=#" + C.ColorToHex(C.GetColor("Friendly_Player_ESP")) + ">[FRIENDLY] </color>";
					}
					GUILayout.BeginVertical(Array.Empty<GUILayoutOption>());
					GUILayout.Label(Provider.provider.communityService.getIcon(steamPlayer2.playerID.steamID, false), Array.Empty<GUILayoutOption>());
					GUILayout.TextField(steamPlayer2.playerID.characterName + " - " + steamPlayer2.playerID.steamID.m_SteamID.ToString(), "label", Array.Empty<GUILayoutOption>());
					if (GUILayout.Button("Status: " + Enum.GetName(typeof(Visual.Priority), priority3), "NavBox", Array.Empty<GUILayoutOption>()))
					{
						G.Settings.Priority[steamPlayer2.playerID.steamID.m_SteamID] = priority3.Next<Visual.Priority>();
					}
					GUILayout.EndVertical();
				}
			}
			GUILayout.EndArea();
		}

		// Token: 0x040002F9 RID: 761
		public static SteamPlayer selectedplayer = null;

		// Token: 0x040002FA RID: 762
		public static string SearchString = "";

		// Token: 0x040002FB RID: 763
		private static Vector2 vector2_0 = new Vector2(0f, 0f);
	}
}
