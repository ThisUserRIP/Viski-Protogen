using System;
using System.Collections.Generic;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000047 RID: 71
	public static class OV_SearchForMapsInInventory
	{
		// Token: 0x060001B7 RID: 439 RVA: 0x0000F38C File Offset: 0x0000D58C
		[Override(typeof(PlayerDashboardInformationUI), "searchForMapsInInventory", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void OV_searchForMapsInInventory(ref bool enableChart, ref bool enableMap)
		{
			if (G.Settings.GlobalOptions.GPS || !SpyUtilities.BeingSpied)
			{
				enableMap = true;
				enableChart = true;
			}
			else
			{
				OverrideUtilities.CallOriginal(null, new object[]
				{
					enableChart,
					enableMap
				});
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x0000F3E0 File Offset: 0x0000D5E0
		public static List<ISleekImage> remotePlayerImages
		{
			get
			{
				return OV_SearchForMapsInInventory.RemotePlayerImagesField.GetValue(null) as List<ISleekImage>;
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000F400 File Offset: 0x0000D600
		[Thread]
		public static void Init()
		{
			OV_SearchForMapsInInventory.RemotePlayerImagesField = typeof(PlayerDashboardInformationUI).GetField("remotePlayerImages", BindingFlags.Static | BindingFlags.NonPublic);
			OV_SearchForMapsInInventory.MarkerImagesField = typeof(PlayerDashboardInformationUI).GetField("markerImages", BindingFlags.Static | BindingFlags.NonPublic);
			OV_SearchForMapsInInventory.MapMarkersContainerField = typeof(PlayerDashboardInformationUI).GetField("mapMarkersContainer", BindingFlags.Static | BindingFlags.NonPublic);
			OV_SearchForMapsInInventory.MapRemotePlayersContainerField = typeof(PlayerDashboardInformationUI).GetField("mapRemotePlayersContainer", BindingFlags.Static | BindingFlags.NonPublic);
			OV_SearchForMapsInInventory.ShowPlayerAvatarsToggleField = typeof(PlayerDashboardInformationUI).GetField("showPlayerAvatarsToggle", BindingFlags.Static | BindingFlags.NonPublic);
			OV_SearchForMapsInInventory.ShowPlayerNamesToggleField = typeof(PlayerDashboardInformationUI).GetField("showPlayerNamesToggle", BindingFlags.Static | BindingFlags.NonPublic);
			OV_SearchForMapsInInventory.ProjectWorldPositionToMapMethod = typeof(PlayerDashboardInformationUI).GetMethod("ProjectWorldPositionToMap", BindingFlags.Static | BindingFlags.NonPublic);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0000F4D4 File Offset: 0x0000D6D4
		[Override(typeof(PlayerDashboardInformationUI), "updateRemotePlayerAvatars", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		private static void smethod_0()
		{
			int num = 0;
			bool areSpecStatsVisible = Player.player.look.areSpecStatsVisible;
			foreach (SteamPlayer steamPlayer in Provider.clients)
			{
				if (!(steamPlayer.model == null) && !(steamPlayer.playerID.steamID == Provider.client))
				{
					bool flag = steamPlayer.player.quests.isMemberOfSameGroupAs(Player.player);
					if (areSpecStatsVisible || flag || (G.Settings.GlobalOptions.ShowPlayerOnMap && !SpyUtilities.BeingSpied))
					{
						ISleekImage sleekImage;
						if (num >= OV_SearchForMapsInInventory.remotePlayerImages.Count)
						{
							sleekImage = Glazier.Get().CreateImage();
							sleekImage.PositionOffset_X = -10f;
							sleekImage.PositionOffset_Y = -10f;
							sleekImage.SizeOffset_X = 20f;
							sleekImage.SizeOffset_Y = 20f;
							sleekImage.AddLabel(string.Empty, 1);
							(OV_SearchForMapsInInventory.MapRemotePlayersContainerField.GetValue(null) as ISleekElement).AddChild(sleekImage);
							OV_SearchForMapsInInventory.remotePlayerImages.Add(sleekImage);
						}
						else
						{
							sleekImage = OV_SearchForMapsInInventory.remotePlayerImages[num];
							sleekImage.IsVisible = true;
						}
						num++;
						Vector2 vector = (Vector2)OV_SearchForMapsInInventory.ProjectWorldPositionToMapMethod.Invoke(null, new object[]
						{
							steamPlayer.player.transform.position
						});
						sleekImage.PositionScale_X = vector.x;
						sleekImage.PositionScale_Y = vector.y;
						if (!OptionsSettings.streamer && (OV_SearchForMapsInInventory.ShowPlayerAvatarsToggleField.GetValue(null) as ISleekToggle).Value)
						{
							sleekImage.Texture = Provider.provider.communityService.getIcon(steamPlayer.playerID.steamID, true);
						}
						else
						{
							sleekImage.Texture = null;
						}
						if ((OV_SearchForMapsInInventory.ShowPlayerNamesToggleField.GetValue(null) as ISleekToggle).Value)
						{
							if (!flag || string.IsNullOrEmpty(steamPlayer.playerID.nickName))
							{
								sleekImage.UpdateLabel(steamPlayer.playerID.characterName);
							}
							else
							{
								sleekImage.UpdateLabel(steamPlayer.playerID.nickName);
							}
						}
						else
						{
							sleekImage.UpdateLabel(string.Empty);
						}
					}
				}
			}
			for (int i = OV_SearchForMapsInInventory.remotePlayerImages.Count - 1; i >= num; i--)
			{
				OV_SearchForMapsInInventory.remotePlayerImages[i].IsVisible = false;
			}
		}

		// Token: 0x040001F8 RID: 504
		public static FieldInfo fieldInfo_0;

		// Token: 0x040001F9 RID: 505
		public static FieldInfo fieldInfo_1;

		// Token: 0x040001FA RID: 506
		public static FieldInfo fieldInfo_2;

		// Token: 0x040001FB RID: 507
		public static FieldInfo fieldInfo_3;

		// Token: 0x040001FC RID: 508
		public static FieldInfo fieldInfo_4;

		// Token: 0x040001FD RID: 509
		public static FieldInfo fieldInfo_5;

		// Token: 0x040001FE RID: 510
		public static MethodInfo methodInfo_0;

		// Token: 0x040001FF RID: 511
		public static FieldInfo RemotePlayerImagesField;

		// Token: 0x04000200 RID: 512
		public static FieldInfo MarkerImagesField;

		// Token: 0x04000201 RID: 513
		public static FieldInfo MapMarkersContainerField;

		// Token: 0x04000202 RID: 514
		public static FieldInfo MapRemotePlayersContainerField;

		// Token: 0x04000203 RID: 515
		public static FieldInfo ShowPlayerAvatarsToggleField;

		// Token: 0x04000204 RID: 516
		public static FieldInfo ShowPlayerNamesToggleField;

		// Token: 0x04000205 RID: 517
		public static MethodInfo ProjectWorldPositionToMapMethod;
	}
}
