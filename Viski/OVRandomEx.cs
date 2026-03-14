using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200004A RID: 74
	public static class OVRandomEx
	{
		// Token: 0x060001BF RID: 447 RVA: 0x0000F878 File Offset: 0x0000DA78
		[Override(typeof(RandomEx), "GetRandomForwardVectorInCone", BindingFlags.Static | BindingFlags.Public, 0)]
		public static Vector3 OV_GetRandomForwardVectorInCone(float halfAngleRadians)
		{
			halfAngleRadians = (G.Settings.MiscOptions.NoSway ? G.Settings.MiscOptions.NoSway1 : Mathf.Min(halfAngleRadians, 1.5697963f));
			float num = Mathf.Sin(halfAngleRadians * Mathf.Sqrt(Random.value));
			float num2 = 6.2831855f * Random.value;
			float num3 = Mathf.Cos(num2);
			float num4 = Mathf.Sin(num2);
			float num5 = num3 * num;
			float num6 = num4 * num;
			float num7 = Mathf.Sqrt(1f - num5 * num5 - num6 * num6);
			return new Vector3(num5, num6, num7);
		}
	}
}
