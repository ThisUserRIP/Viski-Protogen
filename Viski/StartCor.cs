using System;
using System.Threading;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000061 RID: 97
	[Component]
	public class StartCor : MonoBehaviour
	{
		// Token: 0x06000228 RID: 552 RVA: 0x00013C44 File Offset: 0x00011E44
		[Thread]
		public static void Spammer()
		{
			for (;;)
			{
				Thread.Sleep(G.Settings.MiscOptions.SpammerDelay);
				if (G.Settings.MiscOptions.SpammerEnabled)
				{
					ChatManager.sendChat(0, G.Settings.MiscOptions.SpamText);
				}
			}
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00013C90 File Offset: 0x00011E90
		public void Start()
		{
			base.StartCoroutine(new StartCor.<L0g>d__0(0));
			base.StartCoroutine(new StartCor.<AutomaticCloseGenerator>d__1(0));
			base.StartCoroutine(new StartCor.<AutomaticSitToCar>d__2(0));
			base.StartCoroutine(new StartCor.<AutomaticForage>d__3(0));
			base.StartCoroutine(new StartCor.<AutomaticHarvest>d__4(0));
			base.StartCoroutine(new StartCor.<AutomaticStructures>d__5(0));
			base.StartCoroutine(new StartCor.<AutomaticATM>d__6(0));
			base.StartCoroutine(new StartCor.<AutoItemPickupFilter>d__7(0));
			base.StartCoroutine(new StartCor.<AutoFish>d__8(0));
			base.StartCoroutine(Visual.ESPUp());
			base.StartCoroutine(HwidChanger.SetHwid());
			base.StartCoroutine(Aimbot.SetLockedObject());
			base.StartCoroutine(Aimbot.AimToObject());
		}
	}
}
