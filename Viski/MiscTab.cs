using System;
using System.Diagnostics;
using System.Reflection;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000075 RID: 117
	public class MiscTab
	{
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000283 RID: 643 RVA: 0x0001703C File Offset: 0x0001523C
		// (set) Token: 0x06000284 RID: 644 RVA: 0x00017068 File Offset: 0x00015268
		public static float _steerMin
		{
			get
			{
				return Player.player.movement.getVehicle().asset.steerMin;
			}
			set
			{
				FieldInfo field = typeof(VehicleAsset).GetField("_steerMin", BindingFlags.Instance | BindingFlags.NonPublic);
				field.SetValue(Player.player.movement.getVehicle().asset, value);
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000285 RID: 645 RVA: 0x000170B0 File Offset: 0x000152B0
		// (set) Token: 0x06000286 RID: 646 RVA: 0x000170DC File Offset: 0x000152DC
		public static float _steerMax
		{
			get
			{
				return Player.player.movement.getVehicle().asset.steerMax;
			}
			set
			{
				FieldInfo field = typeof(VehicleAsset).GetField("_steerMax", BindingFlags.Instance | BindingFlags.NonPublic);
				field.SetValue(Player.player.movement.getVehicle().asset, value);
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00017124 File Offset: 0x00015324
		public static void Tab()
		{
			GUILayout.BeginArea(new Rect(340f, 20f, 350f, 335f), "Misc 1", "box");
			GUILayout.Space(5f);
			MiscTab.vector2_0 = GUILayout.BeginScrollView(MiscTab.vector2_0, Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.Freecam = GUILayout.Toggle(G.Settings.MiscOptions.Freecam, "FreeCam", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.Freecam && GUILayout.Button("Back To Player (FreeCam)", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				Player.player.look.orbitPosition = Vector3.zero;
			}
			G.Settings.MiscOptions.AutoFish = GUILayout.Toggle(G.Settings.MiscOptions.AutoFish, "Auto Fish", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.AutoFishInAir = GUILayout.Toggle(G.Settings.MiscOptions.AutoFishInAir, "Auto Fish In Air", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.Spinbot = GUILayout.Toggle(G.Settings.MiscOptions.Spinbot, "Spinbot", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.Spinbot)
			{
				G.Settings.MiscOptions.LocalSpinbot = GUILayout.Toggle(G.Settings.MiscOptions.LocalSpinbot, "Show Local Spinbot", Array.Empty<GUILayoutOption>());
			}
			G.Settings.MiscOptions.VehicleSpinbot = GUILayout.Toggle(G.Settings.MiscOptions.VehicleSpinbot, "Vehicle Spinbot", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.ShowSpyPic = GUILayout.Toggle(G.Settings.MiscOptions.ShowSpyPic, "Show Spy Picture", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.AlertOnSpy = GUILayout.Toggle(G.Settings.MiscOptions.AlertOnSpy, "Spy Alert", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.bool_0 = GUILayout.Toggle(G.Settings.MiscOptions.bool_0, "WaterMark", Array.Empty<GUILayoutOption>());
			G.Settings.GlobalOptions.AutoWalk = GUILayout.Toggle(G.Settings.GlobalOptions.AutoWalk, "Auto Walk", Array.Empty<GUILayoutOption>());
			G.Settings.BacktrackOptions.Enabled = GUILayout.Toggle(G.Settings.BacktrackOptions.Enabled, "BackTrack", Array.Empty<GUILayoutOption>());
			if (G.Settings.BacktrackOptions.Enabled)
			{
				GUILayout.Label("BackTrack Delay: " + G.Settings.BacktrackOptions.BacktrackDelay.ToString("F1") + "s", Array.Empty<GUILayoutOption>());
				G.Settings.BacktrackOptions.BacktrackDelay = GUILayout.HorizontalSlider(G.Settings.BacktrackOptions.BacktrackDelay, 0.1f, 99999f, Array.Empty<GUILayoutOption>());
			}
			G.Settings.MiscOptions.SpammerEnabled = GUILayout.Toggle(G.Settings.MiscOptions.SpammerEnabled, "Enable Spam", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.SpamText = GUILayout.TextField(G.Settings.MiscOptions.SpamText, Array.Empty<GUILayoutOption>());
			GUILayout.Label("Spam Delay: " + G.Settings.MiscOptions.SpammerDelay.ToString() + " MilliSecond", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.SpammerDelay = (int)GUILayout.HorizontalSlider((float)G.Settings.MiscOptions.SpammerDelay, 10f, 9999f, Array.Empty<GUILayoutOption>());
			GUILayout.Label("Enemy Scale X: " + Misc.pscale.x.ToString(), Array.Empty<GUILayoutOption>());
			Misc.pscale.x = GUILayout.HorizontalSlider(Misc.pscale.x, 0.1f, 10f, Array.Empty<GUILayoutOption>());
			GUILayout.Label("Enemy Scale Y: " + Misc.pscale.y.ToString(), Array.Empty<GUILayoutOption>());
			Misc.pscale.y = GUILayout.HorizontalSlider(Misc.pscale.y, 0.1f, 10f, Array.Empty<GUILayoutOption>());
			GUILayout.Label("Enemy Scale Z: " + Misc.pscale.z.ToString(), Array.Empty<GUILayoutOption>());
			Misc.pscale.z = GUILayout.HorizontalSlider(Misc.pscale.z, 0.1f, 10f, Array.Empty<GUILayoutOption>());
			if (GUILayout.Button("X,Y,Z Reset", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				Misc.pscale = new Vector3(1f, 1f, 1f);
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(700f, 20f, 290f, 335f), "Weapon", "box");
			GUILayout.Space(5f);
			MiscTab.vector2_1 = GUILayout.BeginScrollView(MiscTab.vector2_1, Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.NoRecoil = GUILayout.Toggle(G.Settings.MiscOptions.NoRecoil, "Remove Recoil", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.NoRecoil)
			{
				GUILayout.Label("Recoil: %" + G.Settings.MiscOptions.NoRecoil1.ToString(), Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.NoRecoil1 = GUILayout.HorizontalSlider(G.Settings.MiscOptions.NoRecoil1, 0f, 1f, Array.Empty<GUILayoutOption>());
			}
			G.Settings.MiscOptions.NoSpread = GUILayout.Toggle(G.Settings.MiscOptions.NoSpread, "Remove Spread", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.NoSpread)
			{
				GUILayout.Label("Spread: %" + G.Settings.MiscOptions.NoSpread1.ToString(), Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.NoSpread1 = GUILayout.HorizontalSlider(G.Settings.MiscOptions.NoSpread1, 0f, 1f, Array.Empty<GUILayoutOption>());
			}
			G.Settings.MiscOptions.NoSway = GUILayout.Toggle(G.Settings.MiscOptions.NoSway, "Remove Sway", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.NoSway)
			{
				GUILayout.Label("Sway: %" + G.Settings.MiscOptions.NoSway1.ToString(), Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.NoSway1 = GUILayout.HorizontalSlider(G.Settings.MiscOptions.NoSway1, 0f, 1f, Array.Empty<GUILayoutOption>());
			}
			G.Settings.MiscOptions.ShowWeaponInfo = GUILayout.Toggle(G.Settings.MiscOptions.ShowWeaponInfo, "Show Weapon Info", Array.Empty<GUILayoutOption>());
			GUILayout.EndScrollView();
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(340f, 365f, 350f, 265f), "Misc 2", "box");
			GUILayout.Space(5f);
			MiscTab.vector2_2 = GUILayout.BeginScrollView(MiscTab.vector2_2, Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.BuildToAnywhere = GUILayout.Toggle(G.Settings.MiscOptions.BuildToAnywhere, "Build To Anywhere", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.BuildPosSet = GUILayout.Toggle(G.Settings.MiscOptions.BuildPosSet, "Change Build Locaion", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.BuildPosSet)
			{
				G.Settings.MiscOptions.BuildToAnywhere = true;
				GUILayout.Label("X: " + OV_UseableBarricade.BuildPos.x.ToString(), Array.Empty<GUILayoutOption>());
				OV_UseableBarricade.BuildPos.x = GUILayout.HorizontalSlider(OV_UseableBarricade.BuildPos.x, -5f, 5f, Array.Empty<GUILayoutOption>());
				GUILayout.Label("Y: " + OV_UseableBarricade.BuildPos.y.ToString(), Array.Empty<GUILayoutOption>());
				OV_UseableBarricade.BuildPos.y = GUILayout.HorizontalSlider(OV_UseableBarricade.BuildPos.y, -5f, 25f, Array.Empty<GUILayoutOption>());
				GUILayout.Label("Z: " + OV_UseableBarricade.BuildPos.z.ToString(), Array.Empty<GUILayoutOption>());
				OV_UseableBarricade.BuildPos.z = GUILayout.HorizontalSlider(OV_UseableBarricade.BuildPos.z, -5f, 5f, Array.Empty<GUILayoutOption>());
				GUILayout.Space(2f);
				if (GUILayout.Button("X,Y,Z Reset", "NavBox", Array.Empty<GUILayoutOption>()))
				{
					OV_UseableBarricade.BuildPos.x = 0f;
					OV_UseableBarricade.BuildPos.y = 0f;
					OV_UseableBarricade.BuildPos.z = 0f;
				}
			}
			G.Settings.MiscOptions.CustomSalvageTime = GUILayout.Toggle(G.Settings.MiscOptions.CustomSalvageTime, "Custom Salvage Time", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.CustomSalvageTime)
			{
				GUILayout.Label("Time: " + G.Settings.MiscOptions.SalvageTime.ToString() + " Seconds", Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.SalvageTime = GUILayout.HorizontalSlider(G.Settings.MiscOptions.SalvageTime, 0.2f, 10f, Array.Empty<GUILayoutOption>());
			}
			G.Settings.MiscOptions.AutoItemPickupFilter = GUILayout.Toggle(G.Settings.MiscOptions.AutoItemPickupFilter, "Auto Pickup", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.AutoItemPickupFilter)
			{
				GUILayout.Label("Delay: " + G.Settings.MiscOptions.AutoPickupDelay.ToString() + " Second", Array.Empty<GUILayoutOption>());
				GUILayout.Space(2f);
				G.Settings.MiscOptions.AutoPickupDelay = GUILayout.HorizontalSlider(G.Settings.MiscOptions.AutoPickupDelay, 0.1f, 10f, Array.Empty<GUILayoutOption>());
				GUILayout.Space(2f);
				GUILayout.Label("Range: " + G.Settings.MiscOptions.AutoPickupRange.ToString() + "m", Array.Empty<GUILayoutOption>());
				GUILayout.Space(2f);
				G.Settings.MiscOptions.AutoPickupRange = (int)GUILayout.HorizontalSlider((float)G.Settings.MiscOptions.AutoPickupRange, 0f, 20f, Array.Empty<GUILayoutOption>());
				GUILayout.Space(5f);
				G.Settings.MiscOptions.AutoPickupGun = GUILayout.Toggle(G.Settings.MiscOptions.AutoPickupGun, " Guns", Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.AutoPickupMelee = GUILayout.Toggle(G.Settings.MiscOptions.AutoPickupMelee, " Melees", Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.AutoPickupBackpack = GUILayout.Toggle(G.Settings.MiscOptions.AutoPickupBackpack, " Backpacks", Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.AutoPickupClothing = GUILayout.Toggle(G.Settings.MiscOptions.AutoPickupClothing, " Clothing", Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.AutoPickupFuel = GUILayout.Toggle(G.Settings.MiscOptions.AutoPickupFuel, " Fuel", Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.AutoPickupFoodWater = GUILayout.Toggle(G.Settings.MiscOptions.AutoPickupFoodWater, " Food/Water", Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.AutoPickupAmmo = GUILayout.Toggle(G.Settings.MiscOptions.AutoPickupAmmo, " Ammo", Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.AutoPickupMedical = GUILayout.Toggle(G.Settings.MiscOptions.AutoPickupMedical, " Medical", Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.AutoPickupThrowable = GUILayout.Toggle(G.Settings.MiscOptions.AutoPickupThrowable, " Throwables", Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.AutoPickupAttachments = GUILayout.Toggle(G.Settings.MiscOptions.AutoPickupAttachments, " Attachments", Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.AutoPickupExtra = GUILayout.Toggle(G.Settings.MiscOptions.AutoPickupExtra, " Extra", Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.AutoPickupNoFilter = GUILayout.Toggle(G.Settings.MiscOptions.AutoPickupNoFilter, " No Filter", Array.Empty<GUILayoutOption>());
			}
			G.Settings.MiscOptions.HwidChanger = GUILayout.Toggle(G.Settings.MiscOptions.HwidChanger, "HWID Changer", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.NearbyItems = GUILayout.Toggle(G.Settings.MiscOptions.NearbyItems, "Remote Pickup With Window", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.ShowAdmin = GUILayout.Toggle(G.Settings.MiscOptions.ShowAdmin, "Show Admins", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.AutomaticCloseGenerator = GUILayout.Toggle(G.Settings.MiscOptions.AutomaticCloseGenerator, "Automatic Close Generator", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.AutomaticSitToCar = GUILayout.Toggle(G.Settings.MiscOptions.AutomaticSitToCar, "Automatic Sit To Car", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.AutomaticForage = GUILayout.Toggle(G.Settings.MiscOptions.AutomaticForage, "Automatic Forage", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.AutomaticHarvest = GUILayout.Toggle(G.Settings.MiscOptions.AutomaticHarvest, "Automatic Harvest", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.AutomaticStructures = GUILayout.Toggle(G.Settings.MiscOptions.AutomaticStructures, "Automatic Take Your Structures", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.AutomaticStructures)
			{
				GUILayout.Label("Structures Time: " + G.Settings.MiscOptions.AutomaticStructuresZ.ToString(), Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.AutomaticStructuresZ = GUILayout.HorizontalSlider(G.Settings.MiscOptions.AutomaticStructuresZ, 0.1f, 5f, Array.Empty<GUILayoutOption>());
				GUILayout.Label("Structures Distance: " + G.Settings.MiscOptions.AutomaticStructuresM.ToString(), Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.AutomaticStructuresM = (int)GUILayout.HorizontalSlider((float)G.Settings.MiscOptions.AutomaticStructuresM, 0f, 1000f, Array.Empty<GUILayoutOption>());
			}
			G.Settings.MiscOptions.AutomaticATM = GUILayout.Toggle(G.Settings.MiscOptions.AutomaticATM, "Automatic ATM Use", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.AutomaticATM)
			{
				G.Settings.MiscOptions.bool_1 = GUILayout.Toggle(G.Settings.MiscOptions.bool_1, "Automatic ATM Pickup Moneys", Array.Empty<GUILayoutOption>());
			}
			G.Settings.MiscOptions.InteractThroughWalls = GUILayout.Toggle(G.Settings.MiscOptions.InteractThroughWalls, "Pickup In Through Walls", Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.SetTimeEnabled = GUILayout.Toggle(G.Settings.MiscOptions.SetTimeEnabled, "Set Time", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.SetTimeEnabled)
			{
				GUILayout.Label("Time: " + G.Settings.MiscOptions.Time.ToString(), Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.Time = GUILayout.HorizontalSlider(G.Settings.MiscOptions.Time, 0f, 0.9f, Array.Empty<GUILayoutOption>());
			}
			G.Settings.MiscOptions.LookedWarning = GUILayout.Toggle(G.Settings.MiscOptions.LookedWarning, "Show Looked Warning", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.LookedWarning)
			{
				GUILayout.Label(string.Format("Warning Distance: {0:F1}m", G.Settings.MiscOptions.LookedWarningDistance), Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.LookedWarningDistance = GUILayout.HorizontalSlider(G.Settings.MiscOptions.LookedWarningDistance, 5f, 100f, Array.Empty<GUILayoutOption>());
			}
			GUILayout.Space(5f);
			GUILayout.EndScrollView();
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(700f, 365f, 290f, 265f), "Misc 3", "box");
			GUILayout.Space(5f);
			MiscTab.vector2_3 = GUILayout.BeginScrollView(MiscTab.vector2_3, Array.Empty<GUILayoutOption>());
			G.Settings.MiscOptions.VehicleDrift = GUILayout.Toggle(G.Settings.MiscOptions.VehicleDrift, "Vehicle Drift", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.VehicleDrift && (Player.player.movement.getVehicle() != null && VectorUtilities.ShouldRun()))
			{
				GUILayout.Label("SteerMin: " + MiscTab._steerMin.ToString(), Array.Empty<GUILayoutOption>());
				MiscTab._steerMin = GUILayout.HorizontalSlider(MiscTab._steerMin, 0f, 100f, Array.Empty<GUILayoutOption>());
				GUILayout.Label("SteerMax: " + MiscTab._steerMax.ToString(), Array.Empty<GUILayoutOption>());
				MiscTab._steerMax = GUILayout.HorizontalSlider(MiscTab._steerMax, 0f, 100f, Array.Empty<GUILayoutOption>());
			}
			G.Settings.MiscOptions.VehicleFly = GUILayout.Toggle(G.Settings.MiscOptions.VehicleFly, "Vehicle Fly", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.VehicleFly)
			{
				G.Settings.MiscOptions.VehicleRigibody = GUILayout.Toggle(G.Settings.MiscOptions.VehicleRigibody, "Vehicle Rigibody", Array.Empty<GUILayoutOption>());
				G.Settings.MiscOptions.VehicleUseMaxSpeed = GUILayout.Toggle(G.Settings.MiscOptions.VehicleUseMaxSpeed, "Vehicle Max Speed", Array.Empty<GUILayoutOption>());
				if (!G.Settings.MiscOptions.VehicleUseMaxSpeed)
				{
					GUILayout.Label("Speed Multiplier: " + G.Settings.MiscOptions.VehicleSpeed.ToString() + "x", Array.Empty<GUILayoutOption>());
					G.Settings.MiscOptions.VehicleSpeed = GUILayout.HorizontalSlider(G.Settings.MiscOptions.VehicleSpeed, 0.1f, 50f, Array.Empty<GUILayoutOption>());
				}
				GUILayout.Space(2f);
			}
			if (GUILayout.Button("Fix Vehicle Status", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				InteractableVehicle vehicle = Player.player.movement.getVehicle();
				if (vehicle != null)
				{
					vehicle.askFillFuel(10000);
					vehicle.askRepair(10000);
					vehicle.askChargeBattery(10000);
				}
			}
			if (GUILayout.Button("Steal Battery", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				InteractableVehicle vehicle2 = Player.player.movement.getVehicle();
				if (vehicle2 != null)
				{
					VehicleManager.sendVehicleBatteryCharge(vehicle2, 0);
					vehicle2.stealBattery(Player.player);
				}
			}
			if (GUILayout.Button("Random Teleport With Vehicle", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				Random random = new Random();
				Player player = Provider.clients[random.Next(0, Provider.clients.Count)].player;
				if (!player.life.isDead && player.channel.owner.playerID != Player.player.channel.owner.playerID)
				{
					Player.player.movement.getVehicle().transform.position = player.transform.position;
				}
			}
			G.Settings.MiscOptions.Fov = GUILayout.Toggle(G.Settings.MiscOptions.Fov, "Change FOV", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.Fov)
			{
				GUILayout.Label(string.Format("Hip: {0}", Provider.preferenceData.Viewmodel.Field_Of_View_Hip), Array.Empty<GUILayoutOption>());
				Provider.preferenceData.Viewmodel.Field_Of_View_Hip = GUILayout.HorizontalSlider(Provider.preferenceData.Viewmodel.Field_Of_View_Hip, -5f, 300f, Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format("Fov Aim: {0}", Provider.preferenceData.Viewmodel.Field_Of_View_Aim), Array.Empty<GUILayoutOption>());
				Provider.preferenceData.Viewmodel.Field_Of_View_Aim = GUILayout.HorizontalSlider(Provider.preferenceData.Viewmodel.Field_Of_View_Aim, -5f, 300f, Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format("Horizontal: {0}", Provider.preferenceData.Viewmodel.Offset_Horizontal), Array.Empty<GUILayoutOption>());
				Provider.preferenceData.Viewmodel.Offset_Horizontal = GUILayout.HorizontalSlider(Provider.preferenceData.Viewmodel.Offset_Horizontal, -3f, 150f, Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format("Vertical:  {0}", Provider.preferenceData.Viewmodel.Offset_Vertical), Array.Empty<GUILayoutOption>());
				Provider.preferenceData.Viewmodel.Offset_Vertical = GUILayout.HorizontalSlider(Provider.preferenceData.Viewmodel.Offset_Vertical, -2f, 6f, Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format("Depth: {0}", Provider.preferenceData.Viewmodel.Offset_Depth), Array.Empty<GUILayoutOption>());
				Provider.preferenceData.Viewmodel.Offset_Depth = GUILayout.HorizontalSlider(Provider.preferenceData.Viewmodel.Offset_Depth, 0f, 150f, Array.Empty<GUILayoutOption>());
			}
			else
			{
				Provider.preferenceData.Viewmodel.Field_Of_View_Aim = 60f;
				Provider.preferenceData.Viewmodel.Field_Of_View_Hip = 60f;
				Provider.preferenceData.Viewmodel.Offset_Horizontal = 0f;
				Provider.preferenceData.Viewmodel.Offset_Vertical = 0f;
				Provider.preferenceData.Viewmodel.Offset_Depth = 0f;
			}
			GUILayout.Space(5f);
			GUILayout.Label("Anti Spy Method:", Array.Empty<GUILayoutOption>());
			if (G.Settings.MiscOptions.AntiSpyMethod == 0 && GUILayout.Button("Hide Hack", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				G.Settings.MiscOptions.AntiSpyMethod = 1;
			}
			if (G.Settings.MiscOptions.AntiSpyMethod == 1)
			{
				if (GUILayout.Button("Random Image in Folder", "NavBox", Array.Empty<GUILayoutOption>()))
				{
					G.Settings.MiscOptions.AntiSpyMethod = 2;
				}
				GUILayout.Space(10f);
				if (GUILayout.Button("Open Directory The Image Folder", "NavBox", Array.Empty<GUILayoutOption>()))
				{
					Process.Start(Viski1.AppdatYol + "\\DarkNight\\CustomScreenShot");
				}
			}
			if (G.Settings.MiscOptions.AntiSpyMethod == 2 && GUILayout.Button("Send No Image", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				G.Settings.MiscOptions.AntiSpyMethod = 3;
			}
			if (G.Settings.MiscOptions.AntiSpyMethod == 3 && GUILayout.Button("No Anti-Spy", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				G.Settings.MiscOptions.AntiSpyMethod = 0;
			}
			GUILayout.Space(10f);
			if (GUILayout.Button("Delete Water", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				if (G.Settings.MiscOptions.Altitude == 0f)
				{
					G.Settings.MiscOptions.Altitude = LevelLighting.seaLevel;
				}
				LevelLighting.seaLevel = ((LevelLighting.seaLevel == 0f) ? G.Settings.MiscOptions.Altitude : 0f);
			}
			GUILayout.Space(5f);
			if (Provider.cameraMode != 2 && GUILayout.Button("Open 3rd Camera", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				Provider.cameraMode = 2;
			}
			if (Provider.cameraMode == 2 && GUILayout.Button("Close 3rd Camera", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				Provider.cameraMode = 3;
			}
			GUILayout.Space(5f);
			if (GUILayout.Button("Learn All Achievements", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				for (uint num = 0U; num < SteamUserStats.GetNumAchievements(); num += 1U)
				{
					SteamUserStats.GetAchievementName(num);
					Provider.provider.achievementsService.setAchievement(SteamUserStats.GetAchievementName(num));
				}
			}
			GUILayout.Space(10f);
			if (GUILayout.Button("Turn Off Cheat Completely!", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				OverrideManager overrideManager = new OverrideManager();
				overrideManager.OffHook();
				Object.DestroyImmediate(Viski1.xyz);
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		// Token: 0x040002F5 RID: 757
		private static Vector2 vector2_0 = new Vector2(0f, 0f);

		// Token: 0x040002F6 RID: 758
		private static Vector2 vector2_1 = new Vector2(0f, 0f);

		// Token: 0x040002F7 RID: 759
		private static Vector2 vector2_2 = new Vector2(0f, 0f);

		// Token: 0x040002F8 RID: 760
		private static Vector2 vector2_3 = new Vector2(0f, 0f);
	}
}
