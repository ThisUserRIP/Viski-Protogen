using System;
using System.Collections;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000016 RID: 22
	[Component]
	public class Backtrack : MonoBehaviour
	{
		// Token: 0x0600005B RID: 91 RVA: 0x000050F4 File Offset: 0x000032F4
		private void Start()
		{
			if (!Backtrack.bool_0)
			{
				base.StartCoroutine(this.method_0());
				base.StartCoroutine(this.method_1());
				Backtrack.bool_0 = true;
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000023B2 File Offset: 0x000005B2
		private IEnumerator method_0()
		{
			Backtrack.<UpdateBacktrackPositions>d__6 <UpdateBacktrackPositions>d__ = new Backtrack.<UpdateBacktrackPositions>d__6(0);
			<UpdateBacktrackPositions>d__.<>4__this = this;
			return <UpdateBacktrackPositions>d__;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000023C1 File Offset: 0x000005C1
		private IEnumerator method_1()
		{
			Backtrack.<CleanupOldData>d__7 <CleanupOldData>d__ = new Backtrack.<CleanupOldData>d__7(0);
			<CleanupOldData>d__.<>4__this = this;
			return <CleanupOldData>d__;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000512C File Offset: 0x0000332C
		private void method_2()
		{
			if (Provider.clients != null)
			{
				float time = Time.time;
				Backtrack.float_0 = time;
				foreach (SteamPlayer steamPlayer in Provider.clients)
				{
					if (!(((steamPlayer == null) ? null : steamPlayer.player) == null) && !steamPlayer.player.life.isDead && !(steamPlayer.playerID.steamID == Player.player.channel.owner.playerID.steamID))
					{
						ulong steamID = steamPlayer.playerID.steamID.m_SteamID;
						if (!Backtrack.dictionary_0.ContainsKey(steamID))
						{
							Backtrack.dictionary_0[steamID] = new Backtrack.BacktrackPlayer(steamPlayer);
						}
						Backtrack.BacktrackPlayer backtrackPlayer = Backtrack.dictionary_0[steamID];
						float num = Vector3.Distance(Player.player.transform.position, steamPlayer.player.transform.position);
						float backtrackLatency = num * 0.001f + Random.Range(0f, 0.05f);
						backtrackPlayer.AddPosition(steamPlayer.player.transform.position, steamPlayer.player.life.isDead, backtrackLatency);
						backtrackPlayer.LastUpdateTime = time;
						backtrackPlayer.LastBacktrackUpdate = time;
					}
				}
				List<ulong> list = new List<ulong>();
				foreach (KeyValuePair<ulong, Backtrack.BacktrackPlayer> keyValuePair in Backtrack.dictionary_0)
				{
					if (time - keyValuePair.Value.LastUpdateTime > 8f)
					{
						list.Add(keyValuePair.Key);
					}
				}
				foreach (ulong key in list)
				{
					Backtrack.dictionary_0.Remove(key);
				}
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00005394 File Offset: 0x00003594
		private void method_3()
		{
			foreach (Backtrack.BacktrackPlayer backtrackPlayer in Backtrack.dictionary_0.Values)
			{
				backtrackPlayer.CleanupOldPositions();
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000053F0 File Offset: 0x000035F0
		public static List<Backtrack.BacktrackPlayer> GetAllTrackedPlayers()
		{
			return new List<Backtrack.BacktrackPlayer>(Backtrack.dictionary_0.Values);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00005410 File Offset: 0x00003610
		public static int GetTotalTrackedPlayers()
		{
			return Backtrack.dictionary_0.Count;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000542C File Offset: 0x0000362C
		public static void ClearAllData()
		{
			Backtrack.dictionary_0.Clear();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00005444 File Offset: 0x00003644
		public static Backtrack.BacktrackPlayer GetPlayerBySteamID(ulong steamID)
		{
			Backtrack.BacktrackPlayer backtrackPlayer;
			Backtrack.BacktrackPlayer result;
			if (!Backtrack.dictionary_0.TryGetValue(steamID, out backtrackPlayer))
			{
				result = null;
			}
			else
			{
				result = backtrackPlayer;
			}
			return result;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000546C File Offset: 0x0000366C
		public static List<Backtrack.BacktrackPlayer> GetPlayersInRange(Vector3 position, float range)
		{
			List<Backtrack.BacktrackPlayer> list = new List<Backtrack.BacktrackPlayer>();
			foreach (KeyValuePair<ulong, Backtrack.BacktrackPlayer> keyValuePair in Backtrack.dictionary_0)
			{
				SteamPlayer steamPlayer = keyValuePair.Value.SteamPlayer;
				if (!(((steamPlayer != null) ? steamPlayer.player : null) == null))
				{
					float num = Vector3.Distance(position, keyValuePair.Value.SteamPlayer.player.transform.position);
					if (num <= range)
					{
						list.Add(keyValuePair.Value);
					}
				}
			}
			return list;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000551C File Offset: 0x0000371C
		public static Backtrack.PlayerPosition GetBestPositionForAim(ulong steamID, float preferredDelay = 0f)
		{
			Backtrack.BacktrackPlayer backtrackPlayer;
			Backtrack.PlayerPosition result;
			if (!Backtrack.dictionary_0.TryGetValue(steamID, out backtrackPlayer))
			{
				result = null;
			}
			else
			{
				if (preferredDelay > 0f)
				{
					Backtrack.PlayerPosition positionAtBacktrackTime = backtrackPlayer.GetPositionAtBacktrackTime(preferredDelay);
					if (positionAtBacktrackTime != null)
					{
						return positionAtBacktrackTime;
					}
				}
				for (int num = backtrackPlayer.Positions.Count - 1; num >= 0; num--)
				{
					if (!backtrackPlayer.Positions[num].IsDead)
					{
						return backtrackPlayer.Positions[num];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x04000057 RID: 87
		private static Dictionary<ulong, Backtrack.BacktrackPlayer> dictionary_0 = new Dictionary<ulong, Backtrack.BacktrackPlayer>();

		// Token: 0x04000058 RID: 88
		private static bool bool_0 = false;

		// Token: 0x04000059 RID: 89
		private static float float_0 = 0f;

		// Token: 0x02000017 RID: 23
		public class PlayerPosition
		{
			// Token: 0x06000068 RID: 104 RVA: 0x000055F0 File Offset: 0x000037F0
			public PlayerPosition(Vector3 pos, float time, bool dead, float latency = 0f, int packetId = 0)
			{
				this.Position = pos;
				this.Timestamp = time;
				this.IsDead = dead;
				this.BacktrackLatency = latency;
				this.PacketID = packetId;
			}

			// Token: 0x0400005A RID: 90
			public Vector3 Position;

			// Token: 0x0400005B RID: 91
			public float Timestamp;

			// Token: 0x0400005C RID: 92
			public bool IsDead;

			// Token: 0x0400005D RID: 93
			public float BacktrackLatency;

			// Token: 0x0400005E RID: 94
			public int PacketID;
		}

		// Token: 0x02000018 RID: 24
		public class BacktrackPlayer
		{
			// Token: 0x06000069 RID: 105 RVA: 0x0000562C File Offset: 0x0000382C
			public BacktrackPlayer(SteamPlayer player)
			{
				this.SteamPlayer = player;
				this.LastUpdateTime = Time.time;
				this.LastBacktrackUpdate = Time.time;
				this.LastPacketID = 0;
				this.AverageBacktrackLatency = 0f;
			}

			// Token: 0x0600006A RID: 106 RVA: 0x0000567C File Offset: 0x0000387C
			public void AddPosition(Vector3 position, bool isDead, float backtrackLatency = 0f)
			{
				int num = this.LastPacketID + 1;
				this.LastPacketID = num;
				this.Positions.Add(new Backtrack.PlayerPosition(position, Time.time, isDead, backtrackLatency, num));
				int maxPositions = G.Settings.BacktrackOptions.MaxPositions;
				if (this.Positions.Count > maxPositions)
				{
					int count = this.Positions.Count - maxPositions;
					this.Positions.RemoveRange(0, count);
				}
				if (backtrackLatency > 0f)
				{
					this.AverageBacktrackLatency = this.AverageBacktrackLatency * 0.9f + backtrackLatency * 0.1f;
				}
			}

			// Token: 0x0600006B RID: 107 RVA: 0x0000571C File Offset: 0x0000391C
			public List<Backtrack.PlayerPosition> GetPositionsInBacktrackDelay(float backtrackDelay)
			{
				Backtrack.BacktrackPlayer.<>c__DisplayClass8_0 CS$<>8__locals1 = new Backtrack.BacktrackPlayer.<>c__DisplayClass8_0();
				CS$<>8__locals1.float_0 = Time.time - backtrackDelay;
				return this.Positions.FindAll(new Predicate<Backtrack.PlayerPosition>(CS$<>8__locals1.method_0));
			}

			// Token: 0x0600006C RID: 108 RVA: 0x00005758 File Offset: 0x00003958
			public Backtrack.PlayerPosition GetPositionAtBacktrackTime(float timeAgo)
			{
				Backtrack.BacktrackPlayer.<>c__DisplayClass9_0 CS$<>8__locals1 = new Backtrack.BacktrackPlayer.<>c__DisplayClass9_0();
				CS$<>8__locals1.float_0 = Time.time - timeAgo;
				return this.Positions.FindLast(new Predicate<Backtrack.PlayerPosition>(CS$<>8__locals1.method_0));
			}

			// Token: 0x0600006D RID: 109 RVA: 0x00005798 File Offset: 0x00003998
			public List<Backtrack.PlayerPosition> GetBacktrackInterpolatedPositions(float backtrackDelay)
			{
				List<Backtrack.PlayerPosition> list = new List<Backtrack.PlayerPosition>();
				float num = Time.time - backtrackDelay;
				float num2 = 0.05f;
				for (int i = 0; i < this.Positions.Count; i++)
				{
					if (this.Positions[i].Timestamp >= num && !this.Positions[i].IsDead)
					{
						list.Add(this.Positions[i]);
						if (i < this.Positions.Count - 1 && this.Positions[i + 1].Timestamp >= num && !this.Positions[i + 1].IsDead)
						{
							float num3 = this.Positions[i + 1].Timestamp - this.Positions[i].Timestamp;
							if (num3 > num2)
							{
								int num4 = Mathf.Min(Mathf.FloorToInt(num3 / num2), 5);
								for (int j = 1; j < num4; j++)
								{
									float num5 = (float)j / (float)num4;
									Vector3 pos = Vector3.Lerp(this.Positions[i].Position, this.Positions[i + 1].Position, num5);
									float time = Mathf.Lerp(this.Positions[i].Timestamp, this.Positions[i + 1].Timestamp, num5);
									list.Add(new Backtrack.PlayerPosition(pos, time, false, Mathf.Lerp(this.Positions[i].BacktrackLatency, this.Positions[i + 1].BacktrackLatency, num5), -1));
								}
							}
						}
					}
				}
				return list;
			}

			// Token: 0x0600006E RID: 110 RVA: 0x0000595C File Offset: 0x00003B5C
			public void CleanupOldPositions()
			{
				Backtrack.BacktrackPlayer.<>c__DisplayClass11_0 CS$<>8__locals1 = new Backtrack.BacktrackPlayer.<>c__DisplayClass11_0();
				CS$<>8__locals1.float_0 = Time.time - G.Settings.BacktrackOptions.BacktrackDelay - 2f;
				this.Positions.RemoveAll(new Predicate<Backtrack.PlayerPosition>(CS$<>8__locals1.method_0));
			}

			// Token: 0x0600006F RID: 111 RVA: 0x000059AC File Offset: 0x00003BAC
			public float GetBacktrackAccuracy()
			{
				float result;
				if (this.Positions.Count >= 2)
				{
					float num = 0f;
					int num2 = 0;
					for (int i = 1; i < this.Positions.Count; i++)
					{
						float num3 = this.Positions[i].Timestamp - this.Positions[i - 1].Timestamp;
						if (num3 > 0f && num3 < 0.2f)
						{
							float backtrackUpdateRate = G.Settings.BacktrackOptions.BacktrackUpdateRate;
							float num4 = Mathf.Clamp01(1f - Mathf.Abs(num3 - backtrackUpdateRate) / backtrackUpdateRate);
							num += num4;
							num2++;
						}
					}
					result = ((num2 > 0) ? (num / (float)num2) : 0f);
				}
				else
				{
					result = 0f;
				}
				return result;
			}

			// Token: 0x0400005F RID: 95
			public SteamPlayer SteamPlayer;

			// Token: 0x04000060 RID: 96
			public List<Backtrack.PlayerPosition> Positions = new List<Backtrack.PlayerPosition>();

			// Token: 0x04000061 RID: 97
			public float LastUpdateTime;

			// Token: 0x04000062 RID: 98
			public float LastBacktrackUpdate;

			// Token: 0x04000063 RID: 99
			public int LastPacketID;

			// Token: 0x04000064 RID: 100
			public float AverageBacktrackLatency;
		}
	}
}
