using System;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200006B RID: 107
	public class Viski1
	{
		// Token: 0x06000262 RID: 610 RVA: 0x00014F4C File Offset: 0x0001314C
		public static void Viski2()
		{
			Viski1.xyz = new GameObject(Guid.NewGuid().ToString());
			Object.DontDestroyOnLoad(Viski1.xyz);
			Viski1.xyz.AddComponent<Managed>();
		}

		// Token: 0x040002B4 RID: 692
		public static GameObject xyz;

		// Token: 0x040002B5 RID: 693
		public static string DesktopYol = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

		// Token: 0x040002B6 RID: 694
		public static string AppdatYol = Environment.ExpandEnvironmentVariables("%appdata%");

		// Token: 0x040002B7 RID: 695
		public static string TempYol = Environment.ExpandEnvironmentVariables("%temp%");
	}
}
