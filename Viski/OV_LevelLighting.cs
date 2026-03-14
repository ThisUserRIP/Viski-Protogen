using System;
using System.Reflection;
using SDG.Unturned;

namespace Viski
{
	// Token: 0x02000046 RID: 70
	public static class OV_LevelLighting
	{
		// Token: 0x060001B5 RID: 437 RVA: 0x0000F2DC File Offset: 0x0000D4DC
		[Initializer]
		public static void Init()
		{
			OV_LevelLighting.Time = typeof(LevelLighting).GetField("_time", BindingFlags.Static | BindingFlags.NonPublic);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000F308 File Offset: 0x0000D508
		[Override(typeof(LevelLighting), "updateLighting", BindingFlags.Static | BindingFlags.Public, 0)]
		public static void OV_updateLighting()
		{
			float time = LevelLighting.time;
			if (VectorUtilities.ShouldRun() && G.Settings.MiscOptions.SetTimeEnabled && !SpyUtilities.BeingSpied)
			{
				OV_LevelLighting.Time.SetValue(null, G.Settings.MiscOptions.Time);
				OverrideUtilities.CallOriginal(null, new object[0]);
				OV_LevelLighting.Time.SetValue(null, time);
			}
			else
			{
				OverrideUtilities.CallOriginal(null, new object[0]);
			}
		}

		// Token: 0x040001F6 RID: 502
		public static FieldInfo Time;

		// Token: 0x040001F7 RID: 503
		public static bool WasEnabled;
	}
}
