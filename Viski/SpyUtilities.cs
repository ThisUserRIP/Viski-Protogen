using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200007C RID: 124
	[Component]
	public class SpyUtilities : MonoBehaviour
	{
		// Token: 0x060002AB RID: 683 RVA: 0x0001C1AC File Offset: 0x0001A3AC
		[Override(typeof(Player), "ReceiveTakeScreenshot", BindingFlags.Instance | BindingFlags.Public, 0)]
		public void OV_ReceiveTakeScreenshot()
		{
			base.StartCoroutine(new SpyUtilities.<TakeScreenshot>d__2(0));
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0001C1C8 File Offset: 0x0001A3C8
		public static void _HandleScreenshotData(byte[] data, SteamChannel channel)
		{
			if (Dedicator.isDedicated)
			{
				ReadWrite.writeBytes(string.Concat(new string[]
				{
					ReadWrite.PATH,
					ServerSavedata.directory,
					"/",
					Provider.serverID,
					"/Spy.jpg"
				}), false, false, data);
				ReadWrite.writeBytes(string.Concat(new object[]
				{
					ReadWrite.PATH,
					ServerSavedata.directory,
					"/",
					Provider.serverID,
					"/Spy/",
					channel.owner.playerID.steamID.m_SteamID,
					".jpg"
				}), false, false, data);
				if (Player.player.onPlayerSpyReady != null)
				{
					Player.player.onPlayerSpyReady.Invoke(channel.owner.playerID.steamID, data);
				}
				Queue<PlayerSpyReady> queue = new Queue<PlayerSpyReady>();
				PlayerSpyReady playerSpyReady = queue.Dequeue();
				if (playerSpyReady != null)
				{
					playerSpyReady.Invoke(channel.owner.playerID.steamID, data);
				}
			}
			else
			{
				ReadWrite.writeBytes("/Spy.jpg", false, true, data);
				if (Player.onSpyReady != null)
				{
					Player.onSpyReady.Invoke(channel.owner.playerID.steamID, data);
				}
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00003050 File Offset: 0x00001250
		public static IEnumerator SpyPicIE()
		{
			return new SpyUtilities.<SpyPicIE>d__4(0);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00003058 File Offset: 0x00001258
		public static IEnumerator SpyIE()
		{
			return new SpyUtilities.<SpyIE>d__5(0);
		}

		// Token: 0x04000310 RID: 784
		public static byte[] data;

		// Token: 0x04000311 RID: 785
		public static float LastSpy;

		// Token: 0x04000312 RID: 786
		public static bool BeingSpied;
	}
}
