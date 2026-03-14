using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200004D RID: 77
	public class OV_UseableHousingPlanner
	{
		// Token: 0x060001D1 RID: 465 RVA: 0x00010414 File Offset: 0x0000E614
		[Override(typeof(UseableHousingPlanner), "UpdatePendingPlacement", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public bool OV_UpdatePendingPlacement()
		{
			bool result;
			if (G.Settings.MiscOptions.BuildToAnywhere && !SpyUtilities.BeingSpied)
			{
				OverrideUtilities.CallOriginal(this, new object[0]);
				if (!((Vector3)OV_UseableHousingPlanner.pointField.GetValue(this) != Vector3.zero) || G.Settings.MiscOptions.Freecam)
				{
					RaycastHit raycastHit;
					if (Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), ref raycastHit, 20f, RayMasks.DAMAGE_CLIENT))
					{
						Vector3 vector = raycastHit.point;
						if (G.Settings.MiscOptions.BuildPosSet)
						{
							vector += OV_UseableBarricade.BuildPos;
						}
						OV_UseableHousingPlanner.pointField.SetValue(this, vector);
						result = true;
					}
					else
					{
						Vector3 vector2 = Camera.main.transform.position + Camera.main.transform.forward * 7f;
						if (G.Settings.MiscOptions.BuildPosSet)
						{
							vector2 += OV_UseableBarricade.BuildPos;
						}
						OV_UseableHousingPlanner.pointField.SetValue(this, vector2);
						result = true;
					}
				}
				else
				{
					if (G.Settings.MiscOptions.BuildPosSet)
					{
						OV_UseableHousingPlanner.pointField.SetValue(this, (Vector3)OV_UseableHousingPlanner.pointField.GetValue(this) + OV_UseableBarricade.BuildPos);
					}
					result = true;
				}
			}
			else
			{
				result = (bool)OverrideUtilities.CallOriginal(this, new object[0]);
			}
			return result;
		}

		// Token: 0x04000211 RID: 529
		public static FieldInfo pointField = typeof(UseableHousingPlanner).GetField("pendingPlacementPosition", BindingFlags.Instance | BindingFlags.NonPublic);
	}
}
