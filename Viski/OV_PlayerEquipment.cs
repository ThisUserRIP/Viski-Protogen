using System;
using System.Reflection;
using SDG.Unturned;

namespace Viski
{
	// Token: 0x02000053 RID: 83
	public class OV_PlayerEquipment
	{
		// Token: 0x060001EB RID: 491 RVA: 0x00011764 File Offset: 0x0000F964
		[Override(typeof(PlayerEquipment), "punch", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public void OV_punch(EPlayerPunch p)
		{
			if (G.Settings.SilentOptions.PunchSilentAim)
			{
				OV_DamageTool.OVType = OverrideType.PlayerHit;
			}
			OverrideUtilities.CallOriginal(Player.player.equipment, new object[]
			{
				p
			});
			OV_DamageTool.OVType = OverrideType.None;
		}

		// Token: 0x04000227 RID: 551
		public static bool WasPunching;

		// Token: 0x04000228 RID: 552
		public static uint CurrSim;
	}
}
