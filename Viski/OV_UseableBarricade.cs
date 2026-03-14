using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200004C RID: 76
	public class OV_UseableBarricade
	{
		// Token: 0x060001CE RID: 462 RVA: 0x00010248 File Offset: 0x0000E448
		[Override(typeof(UseableBarricade), "checkSpace", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public bool OV_checkSpace()
		{
			bool result;
			if (G.Settings.MiscOptions.BuildToAnywhere && !SpyUtilities.BeingSpied)
			{
				OverrideUtilities.CallOriginal(this, new object[0]);
				RaycastHit raycastHit;
				if ((Vector3)OV_UseableBarricade.pointField.GetValue(this) != Vector3.zero && !G.Settings.MiscOptions.Freecam)
				{
					if (G.Settings.MiscOptions.BuildPosSet)
					{
						OV_UseableBarricade.pointField.SetValue(this, (Vector3)OV_UseableBarricade.pointField.GetValue(this) + OV_UseableBarricade.BuildPos);
					}
					result = true;
				}
				else if (Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), ref raycastHit, 20f, RayMasks.DAMAGE_CLIENT))
				{
					Vector3 vector = raycastHit.point;
					if (G.Settings.MiscOptions.BuildPosSet)
					{
						vector += OV_UseableBarricade.BuildPos;
					}
					OV_UseableBarricade.pointField.SetValue(this, vector);
					result = true;
				}
				else
				{
					Vector3 vector2 = Camera.main.transform.position + Camera.main.transform.forward * 7f;
					if (G.Settings.MiscOptions.BuildPosSet)
					{
						vector2 += OV_UseableBarricade.BuildPos;
					}
					OV_UseableBarricade.pointField.SetValue(this, vector2);
					result = true;
				}
			}
			else
			{
				result = (bool)OverrideUtilities.CallOriginal(this, new object[0]);
			}
			return result;
		}

		// Token: 0x0400020F RID: 527
		public static Vector3 BuildPos;

		// Token: 0x04000210 RID: 528
		public static FieldInfo pointField = typeof(UseableBarricade).GetField("point", BindingFlags.Instance | BindingFlags.NonPublic);
	}
}
