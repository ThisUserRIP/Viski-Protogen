using System;
using System.Reflection;
using SDG.Unturned;

namespace Viski
{
	// Token: 0x02000049 RID: 73
	public static class OV_PlayerPauseUI
	{
		// Token: 0x060001BC RID: 444 RVA: 0x0000F828 File Offset: 0x0000DA28
		[Override(typeof(PlayerPauseUI), "onClickedExitButton", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void OV_onClickedExitButton(ISleekElement button)
		{
			Provider.disconnect();
		}

		// Token: 0x060001BD RID: 445 RVA: 0x0000F83C File Offset: 0x0000DA3C
		[Override(typeof(PlayerPauseUI), "onClickedQuitButton", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void OV_onClickedQuitButton(ISleekElement button)
		{
			Provider.QuitGame("");
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000F854 File Offset: 0x0000DA54
		[Override(typeof(PlayerPauseUI), "onClickedSuicideButton", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void OV_onClickedSuicideButton(ISleekElement button)
		{
			PlayerPauseUI.closeAndGotoAppropriateHUD();
			Player.player.life.sendSuicide();
		}
	}
}
