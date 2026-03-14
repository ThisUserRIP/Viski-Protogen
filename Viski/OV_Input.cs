using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000048 RID: 72
	public static class OV_Input
	{
		// Token: 0x060001BB RID: 443 RVA: 0x0000F790 File Offset: 0x0000D990
		[Override(typeof(Input), "GetKey", BindingFlags.Static | BindingFlags.Public, 0)]
		public static bool OV_GetKey(KeyCode key, UseableFisher __instance)
		{
			bool result;
			if (key != ControlsSettings.primary || !G.Settings.MiscOptions.AutoFish || !OV_UseableFisher.FishIsOnHook)
			{
				result = ((key == ControlsSettings.up && G.Settings.GlobalOptions.AutoWalk) || (bool)OverrideUtilities.CallOriginal(null, new object[]
				{
					key
				}));
			}
			else
			{
				result = (OV_UseableFisher.BarF < 0.9f || OV_UseableFisher.BarF == 1f);
			}
			return result;
		}
	}
}
