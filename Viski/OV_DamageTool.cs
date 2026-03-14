using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000052 RID: 82
	public static class OV_DamageTool
	{
		// Token: 0x060001E9 RID: 489 RVA: 0x000115DC File Offset: 0x0000F7DC
		[Override(typeof(DamageTool), "raycast", BindingFlags.Static | BindingFlags.Public, 1)]
		public static RaycastInfo OV_raycast(Ray ray, float range, int mask, Player ignorePlayer = null)
		{
			return OV_DamageTool.SetupRaycast(ray, range, mask, ignorePlayer);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x000115F8 File Offset: 0x0000F7F8
		public static RaycastInfo SetupRaycast(Ray ray, float range, int mask, Player ignorePlayer = null)
		{
			switch (OV_DamageTool.OVType)
			{
			case OverrideType.Extended:
				return SilentUtilities.GenerateOriginalRaycast(ray, range, mask, null);
			case OverrideType.PlayerHit:
				for (int i = 0; i < Provider.clients.Count; i++)
				{
					if (VectorUtilities.GetDistance(Player.player.transform.position, Provider.clients[i].player.transform.position) <= 15.5)
					{
						RaycastInfo raycastInfo;
						SilentUtilities.GenerateRaycast(out raycastInfo);
						Misc.AddTracer(Player.player.look.aim.position, raycastInfo.point);
						return raycastInfo;
					}
				}
				break;
			case OverrideType.SilentAim:
			{
				RaycastInfo raycastInfo2;
				if (!SilentUtilities.GenerateRaycast(out raycastInfo2))
				{
					Misc.AddTracer(Player.player.look.aim.position, raycastInfo2.point);
					return SilentUtilities.GenerateOriginalRaycast(ray, range, mask, null);
				}
				return raycastInfo2;
			}
			case OverrideType.SilentAimMelee:
			{
				RaycastInfo raycastInfo3;
				if (SilentUtilities.GenerateRaycast(out raycastInfo3))
				{
					return raycastInfo3;
				}
				Misc.AddTracer(Player.player.look.aim.position, raycastInfo3.point);
				return SilentUtilities.GenerateOriginalRaycast(ray, Mathf.Max(5.5f, range), mask, null);
			}
			}
			return SilentUtilities.GenerateOriginalRaycast(ray, range, mask, ignorePlayer);
		}

		// Token: 0x04000226 RID: 550
		public static OverrideType OVType;
	}
}
