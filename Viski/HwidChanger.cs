using System;
using System.Collections;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200002D RID: 45
	public class HwidChanger
	{
		// Token: 0x060000B6 RID: 182 RVA: 0x0000A6E4 File Offset: 0x000088E4
		[Initializer]
		public static void a()
		{
			HwidChanger.methodhwid = (byte[][])HwidChanger.method.Invoke(null, null);
			HwidChanger.hwid = (byte[][])HwidChanger.methodhwid;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00002400 File Offset: 0x00000600
		public static IEnumerator SetHwid()
		{
			return new HwidChanger.<SetHwid>d__1(0);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000A718 File Offset: 0x00008918
		[Override(typeof(LocalHwid), "GetHwids", BindingFlags.Static | BindingFlags.Public, 0)]
		public static byte[][] OV_GetHwids()
		{
			return HwidChanger.hwid;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000A730 File Offset: 0x00008930
		public static void CreateRandomHwid()
		{
			HwidChanger.Hwid1 = new byte[20];
			for (int i = 0; i < 20; i++)
			{
				HwidChanger.Hwid1[i] = (byte)Random.Range(0, 256);
			}
			HwidChanger.Hwid2 = new byte[20];
			for (int j = 0; j < 20; j++)
			{
				HwidChanger.Hwid2[j] = (byte)Random.Range(0, 256);
			}
			HwidChanger.Hwid3 = new byte[20];
			for (int k = 0; k < 20; k++)
			{
				HwidChanger.Hwid3[k] = (byte)Random.Range(0, 256);
			}
		}

		// Token: 0x04000112 RID: 274
		public static byte[][] methodhwid;

		// Token: 0x04000113 RID: 275
		public static byte[] Hwid1;

		// Token: 0x04000114 RID: 276
		public static byte[] Hwid2;

		// Token: 0x04000115 RID: 277
		public static byte[] Hwid3;

		// Token: 0x04000116 RID: 278
		public static byte[][] hwid;

		// Token: 0x04000117 RID: 279
		public static MethodBase method = typeof(LocalHwid).GetMethod("InitHwids", BindingFlags.Static | BindingFlags.NonPublic);
	}
}
