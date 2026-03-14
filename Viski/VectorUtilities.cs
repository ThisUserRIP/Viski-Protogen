using System;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000081 RID: 129
	public static class VectorUtilities
	{
		// Token: 0x060002C7 RID: 711 RVA: 0x0001D0B4 File Offset: 0x0001B2B4
		public static bool ShouldRun()
		{
			return Provider.isConnected && !Provider.isLoading && !LoadingUI.isBlocked && Player.player != null && Camera.main != null;
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0001D0F4 File Offset: 0x0001B2F4
		public static float? GetGunDistance()
		{
			Player player = Player.player;
			object obj;
			if (player == null)
			{
				obj = null;
			}
			else
			{
				PlayerEquipment equipment = player.equipment;
				obj = ((equipment != null) ? equipment.asset : null);
			}
			ItemGunAsset itemGunAsset = obj as ItemGunAsset;
			return new float?((itemGunAsset != null) ? itemGunAsset.range : 15.5f);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0001D13C File Offset: 0x0001B33C
		public static double GetDistance(Vector3 point)
		{
			return VectorUtilities.GetDistance(Camera.main.transform.position, point);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00007D44 File Offset: 0x00005F44
		public static float GetDistance2(Vector3 endpos)
		{
			return (float)Math.Round((double)Vector3.Distance(Player.player.look.aim.position, endpos));
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0001D164 File Offset: 0x0001B364
		public static double GetDistance(Vector3 start, Vector3 point)
		{
			Vector3 vector;
			vector.x = start.x - point.x;
			vector.y = start.y - point.y;
			vector.z = start.z - point.z;
			return Math.Sqrt((double)(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z));
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0001D1E8 File Offset: 0x0001B3E8
		public static double GetMagnitude(Vector3 vector)
		{
			return Math.Sqrt((double)(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z));
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0001D228 File Offset: 0x0001B428
		public static Vector3 Normalize(Vector3 vector)
		{
			return vector / (float)VectorUtilities.GetMagnitude(vector);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0001D248 File Offset: 0x0001B448
		public static double GetAngleDelta(Vector3 mainPos, Vector3 forward, Vector3 target)
		{
			Vector3 vector = VectorUtilities.Normalize(target - mainPos);
			return Math.Atan2(VectorUtilities.GetMagnitude(Vector3.Cross(vector, forward)), (double)Vector3.Dot(vector, forward)) * 57.29577951308232;
		}
	}
}
