using System;
using System.Reflection;
using SDG.Unturned;

namespace Viski
{
	// Token: 0x02000055 RID: 85
	public class OV_UseableMelee
	{
		// Token: 0x060001F2 RID: 498 RVA: 0x00011DBC File Offset: 0x0000FFBC
		[Override(typeof(UseableMelee), "fire", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public static void OV_fire()
		{
			OV_DamageTool.OVType = OverrideType.None;
			if (G.Settings.SilentOptions.Silent && G.Settings.SilentOptions.ExtendMeleeRange)
			{
				OV_DamageTool.OVType = OverrideType.SilentAimMelee;
			}
			else if (G.Settings.SilentOptions.Silent)
			{
				OV_DamageTool.OVType = OverrideType.SilentAim;
			}
			else if (G.Settings.SilentOptions.ExtendMeleeRange)
			{
				OV_DamageTool.OVType = OverrideType.Extended;
			}
			OverrideUtilities.CallOriginal(Player.player.equipment.useable, new object[0]);
			OV_DamageTool.OVType = OverrideType.None;
		}
	}
}
