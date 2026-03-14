using System;
using System.Linq;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200007A RID: 122
	public class VisualsTab
	{
		// Token: 0x06000293 RID: 659 RVA: 0x00019C88 File Offset: 0x00017E88
		public static void Tab()
		{
			GUILayout.Space(0f);
			GUILayout.BeginArea(new Rect(315f, 1f, 880f, 60f));
			int num = (int)((VisualsTab.SelectedObject < Visual.ESPObject.Vehicle) ? VisualsTab.SelectedObject : ((Visual.ESPObject)(-1)));
			int num2 = GUI.Toolbar(new Rect(25f, 5f, 650f, 25f), num, Main.VisualButtons.Take(6).ToArray<GUIContent>(), "NavBox");
			int num3 = (VisualsTab.SelectedObject >= Visual.ESPObject.Vehicle) ? (VisualsTab.SelectedObject - Visual.ESPObject.Vehicle) : -1;
			int num4 = GUI.Toolbar(new Rect(25f, 35f, 650f, 30f), num3, Main.VisualButtons.Skip(6).ToArray<GUIContent>(), "NavBox");
			if (num2 != num && num2 != -1)
			{
				VisualsTab.SelectedObject = (Visual.ESPObject)num2;
			}
			else if (num4 != num3 && num4 != -1)
			{
				VisualsTab.SelectedObject = num4 + Visual.ESPObject.Vehicle;
			}
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(340f, 330f, 350f, 300f), "Options", "box");
			VisualsTab.vector2_0 = GUILayout.BeginScrollView(VisualsTab.vector2_0, Array.Empty<GUILayoutOption>());
			switch (VisualsTab.SelectedObject)
			{
			case Visual.ESPObject.Player:
				VisualsTab.SelectedOptions = G.Settings.PlayerOptions;
				G.Settings.GlobalOptions.Weapon = GUILayout.Toggle(G.Settings.GlobalOptions.Weapon, "Show Weapon", Array.Empty<GUILayoutOption>());
				G.Settings.GlobalOptions.Skeleton = GUILayout.Toggle(G.Settings.GlobalOptions.Skeleton, "Skelaton", Array.Empty<GUILayoutOption>());
				G.Settings.GlobalOptions.ShowLookDirection = GUILayout.Toggle(G.Settings.GlobalOptions.ShowLookDirection, "Show Look Direction", Array.Empty<GUILayoutOption>());
				if (G.Settings.GlobalOptions.ShowLookDirection)
				{
					GUILayout.Label(string.Format("Arrow Length: {0:F1}", Visual.lookDirectionLength), Array.Empty<GUILayoutOption>());
					Visual.lookDirectionLength = GUILayout.HorizontalSlider(Visual.lookDirectionLength, 1f, 10f, Array.Empty<GUILayoutOption>());
				}
				VisualsTab.smethod_13(G.Settings.PlayerOptions);
				break;
			case Visual.ESPObject.Zombie:
				VisualsTab.SelectedOptions = G.Settings.ZombieOptions;
				VisualsTab.smethod_13(G.Settings.ZombieOptions);
				break;
			case Visual.ESPObject.Item:
			{
				VisualsTab.SelectedOptions = G.Settings.ItemOptions;
				OtherOptions globalOptions = G.Settings.GlobalOptions;
				globalOptions.filterItems = GUILayout.Toggle(globalOptions.filterItems, "Filter Item Whitelist", Array.Empty<GUILayoutOption>());
				if (globalOptions.filterItems)
				{
					globalOptions.allowGun = GUILayout.Toggle(globalOptions.allowGun, " Guns", Array.Empty<GUILayoutOption>());
					globalOptions.allowMelee = GUILayout.Toggle(globalOptions.allowMelee, " Melees", Array.Empty<GUILayoutOption>());
					globalOptions.allowBackpack = GUILayout.Toggle(globalOptions.allowBackpack, " Backpacks", Array.Empty<GUILayoutOption>());
					globalOptions.allowClothing = GUILayout.Toggle(globalOptions.allowClothing, " Clothing", Array.Empty<GUILayoutOption>());
					globalOptions.allowFuel = GUILayout.Toggle(globalOptions.allowFuel, " Fuel", Array.Empty<GUILayoutOption>());
					globalOptions.allowFoodWater = GUILayout.Toggle(globalOptions.allowFoodWater, " Food/Water", Array.Empty<GUILayoutOption>());
					globalOptions.allowAmmo = GUILayout.Toggle(globalOptions.allowAmmo, " Ammo", Array.Empty<GUILayoutOption>());
					globalOptions.allowMedical = GUILayout.Toggle(globalOptions.allowMedical, " Medical", Array.Empty<GUILayoutOption>());
					globalOptions.allowThrowable = GUILayout.Toggle(globalOptions.allowThrowable, " Throwables", Array.Empty<GUILayoutOption>());
					globalOptions.allowAttachments = GUILayout.Toggle(globalOptions.allowAttachments, " Attachments", Array.Empty<GUILayoutOption>());
					globalOptions.allowExtra = GUILayout.Toggle(globalOptions.allowExtra, " Extra", Array.Empty<GUILayoutOption>());
				}
				VisualsTab.smethod_13(G.Settings.ItemOptions);
				break;
			}
			case Visual.ESPObject.Sentry:
				VisualsTab.SelectedOptions = G.Settings.SentryOptions;
				VisualsTab.smethod_13(G.Settings.SentryOptions);
				break;
			case Visual.ESPObject.Bed:
				VisualsTab.SelectedOptions = G.Settings.BedOptions;
				G.Settings.GlobalOptions.BedOwner = GUILayout.Toggle(G.Settings.GlobalOptions.BedOwner, "Show Bed Owner", Array.Empty<GUILayoutOption>());
				G.Settings.GlobalOptions.Claimed = GUILayout.Toggle(G.Settings.GlobalOptions.Claimed, "Show Claimed State", Array.Empty<GUILayoutOption>());
				G.Settings.GlobalOptions.OnlyUnclaimed = GUILayout.Toggle(G.Settings.GlobalOptions.OnlyUnclaimed, "Only Display Unclaimed Beds", Array.Empty<GUILayoutOption>());
				VisualsTab.smethod_13(G.Settings.BedOptions);
				break;
			case Visual.ESPObject.Flag:
				VisualsTab.SelectedOptions = G.Settings.FlagOptions;
				VisualsTab.smethod_13(G.Settings.FlagOptions);
				break;
			case Visual.ESPObject.Vehicle:
				VisualsTab.SelectedOptions = G.Settings.VehicleOptions;
				G.Settings.GlobalOptions.VehicleLocked = GUILayout.Toggle(G.Settings.GlobalOptions.VehicleLocked, "Show Lock State", Array.Empty<GUILayoutOption>());
				G.Settings.GlobalOptions.OnlyUnlocked = GUILayout.Toggle(G.Settings.GlobalOptions.OnlyUnlocked, "Only Display Unlocked Vehicles", Array.Empty<GUILayoutOption>());
				VisualsTab.smethod_13(G.Settings.VehicleOptions);
				break;
			case Visual.ESPObject.Storage:
				VisualsTab.SelectedOptions = G.Settings.StorageOptions;
				G.Settings.GlobalOptions.StorageOwner = GUILayout.Toggle(G.Settings.GlobalOptions.StorageOwner, "Show Storage Owner", Array.Empty<GUILayoutOption>());
				G.Settings.GlobalOptions.ShowLocked = GUILayout.Toggle(G.Settings.GlobalOptions.ShowLocked, "Show Lock State", Array.Empty<GUILayoutOption>());
				VisualsTab.smethod_13(G.Settings.StorageOptions);
				break;
			case Visual.ESPObject.Airdrop:
				VisualsTab.SelectedOptions = G.Settings.AirdropOptions;
				VisualsTab.smethod_13(G.Settings.AirdropOptions);
				break;
			case Visual.ESPObject.NPC:
				VisualsTab.SelectedOptions = G.Settings.visualOptions_0;
				VisualsTab.smethod_13(G.Settings.visualOptions_0);
				break;
			case Visual.ESPObject.Farm:
				VisualsTab.SelectedOptions = G.Settings.FarmOptions;
				G.Settings.GlobalOptions.FullGrown = GUILayout.Toggle(G.Settings.GlobalOptions.FullGrown, "Just Full Grown", Array.Empty<GUILayoutOption>());
				VisualsTab.smethod_13(G.Settings.FarmOptions);
				break;
			case Visual.ESPObject.Resources:
				VisualsTab.SelectedOptions = G.Settings.ResourcesOptions;
				VisualsTab.smethod_13(G.Settings.ResourcesOptions);
				break;
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(700f, 430f, 290f, 200f), "Other", "box");
			GUILayout.Space(5f);
			VisualsTab.vector2_1 = GUILayout.BeginScrollView(VisualsTab.vector2_1, Array.Empty<GUILayoutOption>());
			if (GUILayout.Button("Set Graphic Settings(LOW)", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				GraphicsSettings.NormalizedFarClipDistance = 200f;
				GraphicsSettings.normalizedDrawDistance = 100f;
				GraphicsSettings.landmarkQuality = 0;
				GraphicsSettings.ragdolls = false;
				GraphicsSettings.debris = false;
				GraphicsSettings.isAmbientOcclusionEnabled = false;
				GraphicsSettings.bloom = false;
				GraphicsSettings.filmGrain = false;
				GraphicsSettings.blend = false;
				GraphicsSettings.grassDisplacement = false;
				GraphicsSettings.IsWindEnabled = false;
				GraphicsSettings.foliageFocus = false;
				GraphicsSettings.blast = false;
				GraphicsSettings.puddle = false;
				GraphicsSettings.glitter = false;
				GraphicsSettings.triplanar = false;
				GraphicsSettings.skyboxReflection = false;
				GraphicsSettings.IsItemIconAntiAliasingEnabled = false;
				GraphicsSettings.chromaticAberration = false;
				GraphicsSettings.antiAliasingType = 0;
				GraphicsSettings.effectQuality = 1;
				GraphicsSettings.foliageQuality = 1;
				GraphicsSettings.sunShaftsQuality = 0;
				GraphicsSettings.lightingQuality = 0;
				GraphicsSettings.waterQuality = 1;
				GraphicsSettings.scopeQuality = 0;
				GraphicsSettings.outlineQuality = 1;
				GraphicsSettings.terrainQuality = 1;
				MethodBase method = typeof(MenuConfigurationGraphicsUI).GetMethod("updateAll", BindingFlags.Static | BindingFlags.NonPublic);
				method.Invoke(null, null);
			}
			if (GUILayout.Button("Set Options Settings", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				OptionsSettings.debug = true;
				OptionsSettings.chatVoiceIn = true;
				OptionsSettings.chatVoiceOut = true;
				OptionsSettings.VoiceAlwaysRecording = true;
				OptionsSettings.useStaticCrosshair = true;
				OptionsSettings.staticCrosshairSize = 0f;
				OptionsSettings.vehicleThirdPersonCameraMode = 1;
				MethodBase method2 = typeof(MenuConfigurationOptionsUI).GetMethod("updateAll", BindingFlags.Static | BindingFlags.NonPublic);
				method2.Invoke(null, null);
			}
			G.Settings.GlobalOptions.GPS = GUILayout.Toggle(G.Settings.GlobalOptions.GPS, "Force GPS", Array.Empty<GUILayoutOption>());
			G.Settings.GlobalOptions.ShowPlayerOnMap = GUILayout.Toggle(G.Settings.GlobalOptions.ShowPlayerOnMap, "Show Player On Map", Array.Empty<GUILayoutOption>());
			GUILayout.EndScrollView();
			GUILayout.EndArea();
			Rect rect = new Rect(340f, 65f, 350f, 250f);
			GUIStyle guistyle = "box";
			GUILayout.BeginArea(rect, Enum.GetName(typeof(Visual.ESPObject), VisualsTab.SelectedObject), guistyle);
			GUILayout.Space(5f);
			VisualsTab.vector2_2 = GUILayout.BeginScrollView(VisualsTab.vector2_2, Array.Empty<GUILayoutOption>());
			switch (VisualsTab.SelectedObject)
			{
			case Visual.ESPObject.Player:
				VisualsTab.SelectedOptions = G.Settings.PlayerOptions;
				VisualsTab.smethod_12(G.Settings.PlayerOptions, "Players");
				break;
			case Visual.ESPObject.Zombie:
				VisualsTab.SelectedOptions = G.Settings.ZombieOptions;
				VisualsTab.smethod_12(G.Settings.ZombieOptions, "Zombies");
				break;
			case Visual.ESPObject.Item:
				VisualsTab.smethod_12(G.Settings.ItemOptions, "Items");
				break;
			case Visual.ESPObject.Sentry:
				VisualsTab.SelectedOptions = G.Settings.SentryOptions;
				VisualsTab.smethod_12(G.Settings.SentryOptions, "Sentry");
				break;
			case Visual.ESPObject.Bed:
				VisualsTab.SelectedOptions = G.Settings.BedOptions;
				VisualsTab.smethod_12(G.Settings.BedOptions, "Beds");
				break;
			case Visual.ESPObject.Flag:
				VisualsTab.SelectedOptions = G.Settings.FlagOptions;
				VisualsTab.smethod_12(G.Settings.FlagOptions, "Claim Flags");
				break;
			case Visual.ESPObject.Vehicle:
				VisualsTab.SelectedOptions = G.Settings.VehicleOptions;
				VisualsTab.smethod_12(G.Settings.VehicleOptions, "Vehicles");
				break;
			case Visual.ESPObject.Storage:
				VisualsTab.SelectedOptions = G.Settings.StorageOptions;
				VisualsTab.smethod_12(G.Settings.StorageOptions, "Storages");
				break;
			case Visual.ESPObject.Airdrop:
				VisualsTab.SelectedOptions = G.Settings.AirdropOptions;
				VisualsTab.smethod_12(G.Settings.AirdropOptions, "Airdrop");
				break;
			case Visual.ESPObject.NPC:
				VisualsTab.SelectedOptions = G.Settings.visualOptions_0;
				VisualsTab.smethod_12(G.Settings.visualOptions_0, "NPC");
				break;
			case Visual.ESPObject.Farm:
				VisualsTab.SelectedOptions = G.Settings.FarmOptions;
				VisualsTab.smethod_12(G.Settings.FarmOptions, "Farm");
				break;
			case Visual.ESPObject.Resources:
				VisualsTab.SelectedOptions = G.Settings.ResourcesOptions;
				VisualsTab.smethod_12(G.Settings.ResourcesOptions, "Resources");
				break;
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(700f, 65f, 290f, 350f), "box");
			switch (VisualsTab.SelectedObject)
			{
			case Visual.ESPObject.Player:
				VisualsTab.SelectedOptions = G.Settings.PlayerOptions;
				VisualsTab.smethod_0(G.Settings.PlayerOptions);
				break;
			case Visual.ESPObject.Zombie:
				VisualsTab.SelectedOptions = G.Settings.ZombieOptions;
				VisualsTab.smethod_1(G.Settings.ZombieOptions);
				break;
			case Visual.ESPObject.Item:
				VisualsTab.smethod_3(G.Settings.ItemOptions);
				break;
			case Visual.ESPObject.Sentry:
				VisualsTab.SelectedOptions = G.Settings.SentryOptions;
				VisualsTab.smethod_2(G.Settings.SentryOptions);
				break;
			case Visual.ESPObject.Bed:
				VisualsTab.SelectedOptions = G.Settings.BedOptions;
				VisualsTab.smethod_4(G.Settings.BedOptions);
				break;
			case Visual.ESPObject.Flag:
				VisualsTab.SelectedOptions = G.Settings.FlagOptions;
				VisualsTab.smethod_5(G.Settings.FlagOptions);
				break;
			case Visual.ESPObject.Vehicle:
				VisualsTab.SelectedOptions = G.Settings.VehicleOptions;
				VisualsTab.smethod_6(G.Settings.VehicleOptions);
				break;
			case Visual.ESPObject.Storage:
				VisualsTab.SelectedOptions = G.Settings.StorageOptions;
				VisualsTab.smethod_7(G.Settings.StorageOptions);
				break;
			case Visual.ESPObject.Airdrop:
				VisualsTab.SelectedOptions = G.Settings.AirdropOptions;
				VisualsTab.smethod_8(G.Settings.AirdropOptions);
				break;
			case Visual.ESPObject.NPC:
				VisualsTab.SelectedOptions = G.Settings.visualOptions_0;
				VisualsTab.smethod_9(G.Settings.visualOptions_0);
				break;
			case Visual.ESPObject.Farm:
				VisualsTab.SelectedOptions = G.Settings.FarmOptions;
				VisualsTab.smethod_11(G.Settings.FarmOptions);
				break;
			case Visual.ESPObject.Resources:
				VisualsTab.SelectedOptions = G.Settings.ResourcesOptions;
				VisualsTab.smethod_10(G.Settings.ResourcesOptions);
				break;
			}
			GUILayout.EndArea();
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0001AA20 File Offset: 0x00018C20
		private static void smethod_0(object object_0)
		{
			switch (object_0.ChamType)
			{
			case Visual.ShaderType.Lightening:
				GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.Lightening);
				break;
			case Visual.ShaderType.WireFrame:
				GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.WireFrame);
				break;
			case Visual.ShaderType.Xray:
				GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.XrayPlayer);
				break;
			case Visual.ShaderType.Flat:
				GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.ChamsPlayer);
				break;
			case Visual.ShaderType.None:
				GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.Player);
				break;
			}
			switch (object_0.BoxType)
			{
			case Visual.BoxType.Corners:
				Visual.DrawColorCorners(new Rect(15f, 10f, 260f, 280f), Color.cyan);
				break;
			case Visual.BoxType.Box2D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			case Visual.BoxType.Box3D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			}
			if (object_0.Distance || object_0.Name || G.Settings.GlobalOptions.Weapon)
			{
				GUI.Label(new Rect(110f, 300f, 335f, 22f), string.Concat(new string[]
				{
					"<size=",
					object_0.FontSize.ToString(),
					">",
					(!object_0.Distance) ? "" : "[50]",
					(!object_0.Name) ? "" : " 31",
					(!G.Settings.GlobalOptions.Weapon) ? "" : ((object_0.Distance || object_0.Name) ? " - Maplestrike" : "Maplestrike"),
					"</size>"
				}));
			}
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0001AC8C File Offset: 0x00018E8C
		private static void smethod_1(object object_0)
		{
			GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.Zombie);
			switch (object_0.BoxType)
			{
			case Visual.BoxType.Corners:
				Visual.DrawColorCorners(new Rect(15f, 10f, 260f, 280f), Color.cyan);
				break;
			case Visual.BoxType.Box2D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			case Visual.BoxType.Box3D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			}
			if (object_0.Distance || object_0.Name)
			{
				GUI.Label(new Rect(110f, 300f, 335f, 22f), string.Concat(new string[]
				{
					"<size=",
					object_0.FontSize.ToString(),
					">",
					object_0.Distance ? "[50]" : "",
					object_0.Name ? " Zombie" : "",
					G.Settings.GlobalOptions.Weapon ? ((object_0.Distance || object_0.Name) ? "" : "") : "",
					"</size>"
				}));
			}
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0001AE20 File Offset: 0x00019020
		private static void smethod_2(object object_0)
		{
			GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.Sentry);
			switch (object_0.BoxType)
			{
			case Visual.BoxType.Corners:
				Visual.DrawColorCorners(new Rect(15f, 10f, 260f, 280f), Color.cyan);
				break;
			case Visual.BoxType.Box2D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			case Visual.BoxType.Box3D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			}
			if (object_0.Distance || object_0.Name)
			{
				GUI.Label(new Rect(110f, 300f, 335f, 22f), string.Concat(new string[]
				{
					"<size=",
					object_0.FontSize.ToString(),
					">",
					object_0.Distance ? "[50]" : "",
					(!object_0.Name) ? "" : " Sentry",
					(!G.Settings.GlobalOptions.Weapon) ? "" : ((object_0.Distance || object_0.Name) ? "" : ""),
					"</size>"
				}));
			}
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0001AFB4 File Offset: 0x000191B4
		private static void smethod_3(object object_0)
		{
			GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.Item);
			switch (object_0.BoxType)
			{
			case Visual.BoxType.Corners:
				Visual.DrawColorCorners(new Rect(15f, 10f, 260f, 280f), Color.cyan);
				break;
			case Visual.BoxType.Box2D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			case Visual.BoxType.Box3D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			}
			if (object_0.Distance || object_0.Name)
			{
				GUI.Label(new Rect(110f, 300f, 335f, 22f), string.Concat(new string[]
				{
					"<size=",
					object_0.FontSize.ToString(),
					">",
					(!object_0.Distance) ? "" : "[50]",
					(!object_0.Name) ? "" : " Item",
					(!G.Settings.GlobalOptions.Weapon) ? "" : ((object_0.Distance || object_0.Name) ? "" : ""),
					"</size>"
				}));
			}
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0001B148 File Offset: 0x00019348
		private static void smethod_4(object object_0)
		{
			GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.Yatak);
			switch (object_0.BoxType)
			{
			case Visual.BoxType.Corners:
				Visual.DrawColorCorners(new Rect(15f, 10f, 260f, 280f), Color.cyan);
				break;
			case Visual.BoxType.Box2D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			case Visual.BoxType.Box3D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			}
			if (object_0.Distance || object_0.Name)
			{
				GUI.Label(new Rect(110f, 300f, 335f, 22f), string.Concat(new string[]
				{
					"<size=",
					object_0.FontSize.ToString(),
					">",
					object_0.Distance ? "[50]" : "",
					object_0.Name ? " Bed" : "",
					G.Settings.GlobalOptions.Weapon ? ((object_0.Distance || object_0.Name) ? "" : "") : "",
					"</size>"
				}));
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0001B2DC File Offset: 0x000194DC
		private static void smethod_5(object object_0)
		{
			GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.ClaimFlag);
			switch (object_0.BoxType)
			{
			case Visual.BoxType.Corners:
				Visual.DrawColorCorners(new Rect(15f, 10f, 260f, 280f), Color.cyan);
				break;
			case Visual.BoxType.Box2D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			case Visual.BoxType.Box3D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			}
			if (object_0.Distance || object_0.Name)
			{
				GUI.Label(new Rect(110f, 300f, 335f, 22f), string.Concat(new string[]
				{
					"<size=",
					object_0.FontSize.ToString(),
					">",
					object_0.Distance ? "[50]" : "",
					(!object_0.Name) ? "" : " Claim Flag",
					(!G.Settings.GlobalOptions.Weapon) ? "" : ((object_0.Distance || object_0.Name) ? "" : ""),
					"</size>"
				}));
			}
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0001B470 File Offset: 0x00019670
		private static void smethod_6(object object_0)
		{
			GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.Vehicle);
			switch (object_0.BoxType)
			{
			case Visual.BoxType.Corners:
				Visual.DrawColorCorners(new Rect(15f, 10f, 260f, 280f), Color.cyan);
				break;
			case Visual.BoxType.Box2D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			case Visual.BoxType.Box3D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			}
			if (object_0.Distance || object_0.Name)
			{
				GUI.Label(new Rect(110f, 300f, 335f, 22f), string.Concat(new string[]
				{
					"<size=",
					object_0.FontSize.ToString(),
					">",
					object_0.Distance ? "[50]" : "",
					object_0.Name ? " Vehicle" : "",
					G.Settings.GlobalOptions.Weapon ? ((object_0.Distance || object_0.Name) ? "" : "") : "",
					"</size>"
				}));
			}
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0001B604 File Offset: 0x00019804
		private static void smethod_7(object object_0)
		{
			GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.Locker);
			switch (object_0.BoxType)
			{
			case Visual.BoxType.Corners:
				Visual.DrawColorCorners(new Rect(15f, 10f, 260f, 280f), Color.cyan);
				break;
			case Visual.BoxType.Box2D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			case Visual.BoxType.Box3D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			}
			if (object_0.Distance || object_0.Name)
			{
				GUI.Label(new Rect(110f, 300f, 335f, 22f), string.Concat(new string[]
				{
					"<size=",
					object_0.FontSize.ToString(),
					">",
					object_0.Distance ? "[50]" : "",
					object_0.Name ? " Locker" : "",
					G.Settings.GlobalOptions.Weapon ? ((object_0.Distance || object_0.Name) ? "" : "") : "",
					"</size>"
				}));
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0001B798 File Offset: 0x00019998
		private static void smethod_8(object object_0)
		{
			GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.Airdrop);
			switch (object_0.BoxType)
			{
			case Visual.BoxType.Corners:
				Visual.DrawColorCorners(new Rect(15f, 10f, 260f, 280f), Color.cyan);
				break;
			case Visual.BoxType.Box2D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			case Visual.BoxType.Box3D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			}
			if (object_0.Distance || object_0.Name)
			{
				GUI.Label(new Rect(110f, 300f, 335f, 22f), string.Concat(new string[]
				{
					"<size=",
					object_0.FontSize.ToString(),
					">",
					(!object_0.Distance) ? "" : "[50]",
					(!object_0.Name) ? "" : " AIRDROP",
					(!G.Settings.GlobalOptions.Weapon) ? "" : ((object_0.Distance || object_0.Name) ? "" : ""),
					"</size>"
				}));
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0001B92C File Offset: 0x00019B2C
		private static void smethod_9(object object_0)
		{
			GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.NPC);
			switch (object_0.BoxType)
			{
			case Visual.BoxType.Corners:
				Visual.DrawColorCorners(new Rect(15f, 10f, 260f, 280f), Color.cyan);
				break;
			case Visual.BoxType.Box2D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			case Visual.BoxType.Box3D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			}
			if (object_0.Distance || object_0.Name)
			{
				GUI.Label(new Rect(110f, 300f, 335f, 22f), string.Concat(new string[]
				{
					"<size=",
					object_0.FontSize.ToString(),
					">",
					object_0.Distance ? "[50]" : "",
					(!object_0.Name) ? "" : " NPC",
					G.Settings.GlobalOptions.Weapon ? ((object_0.Distance || object_0.Name) ? "" : "") : "",
					"</size>"
				}));
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0001BAC0 File Offset: 0x00019CC0
		private static void smethod_10(object object_0)
		{
			GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.Resources);
			switch (object_0.BoxType)
			{
			case Visual.BoxType.Corners:
				Visual.DrawColorCorners(new Rect(15f, 10f, 260f, 280f), Color.cyan);
				break;
			case Visual.BoxType.Box2D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			case Visual.BoxType.Box3D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			}
			if (object_0.Distance || object_0.Name)
			{
				GUI.Label(new Rect(110f, 300f, 335f, 22f), string.Concat(new string[]
				{
					"<size=",
					object_0.FontSize.ToString(),
					">",
					(!object_0.Distance) ? "" : "[50]",
					object_0.Name ? " Resources" : "",
					G.Settings.GlobalOptions.Weapon ? ((object_0.Distance || object_0.Name) ? "" : "") : "",
					"</size>"
				}));
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0001BC54 File Offset: 0x00019E54
		private static void smethod_11(object object_0)
		{
			GUI.Label(new Rect(25f, 20f, 250f, 400f), Asset.Farm);
			switch (object_0.BoxType)
			{
			case Visual.BoxType.Corners:
				Visual.DrawColorCorners(new Rect(15f, 10f, 260f, 280f), Color.cyan);
				break;
			case Visual.BoxType.Box2D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			case Visual.BoxType.Box3D:
				Visual.DrawColorBox(Color.cyan, new Rect(15f, 10f, 260f, 280f), 1);
				break;
			}
			if (object_0.Distance || object_0.Name)
			{
				GUI.Label(new Rect(110f, 300f, 335f, 22f), string.Concat(new string[]
				{
					"<size=",
					object_0.FontSize.ToString(),
					">",
					object_0.Distance ? "[50]" : "",
					object_0.Name ? " Farm" : "",
					(!G.Settings.GlobalOptions.Weapon) ? "" : ((object_0.Distance || object_0.Name) ? "" : ""),
					"</size>"
				}));
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0001BDE8 File Offset: 0x00019FE8
		private static void smethod_12(VisualOptions visualOptions_0, string string_0)
		{
			GUILayout.Space(2f);
			visualOptions_0.Enabled = GUILayout.Toggle(visualOptions_0.Enabled, string_0 + " - Enabled", Array.Empty<GUILayoutOption>());
			visualOptions_0.Name = GUILayout.Toggle(visualOptions_0.Name, "Name", Array.Empty<GUILayoutOption>());
			visualOptions_0.Distance = GUILayout.Toggle(visualOptions_0.Distance, "Distance", Array.Empty<GUILayoutOption>());
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0001BE5C File Offset: 0x0001A05C
		private static void smethod_13(VisualOptions visualOptions_0)
		{
			if (VisualsTab.SelectedObject == Visual.ESPObject.Player && GUILayout.Button("Cham Type: " + Enum.GetName(typeof(Visual.ShaderType), visualOptions_0.ChamType), "NavBox", Array.Empty<GUILayoutOption>()))
			{
				visualOptions_0.ChamType = visualOptions_0.ChamType.Next<Visual.ShaderType>();
			}
			if (GUILayout.Button("Box Type: " + Enum.GetName(typeof(Visual.BoxType), visualOptions_0.BoxType), "NavBox", Array.Empty<GUILayoutOption>()))
			{
				visualOptions_0.BoxType = visualOptions_0.BoxType.Next<Visual.BoxType>();
			}
			GUILayout.Space(2f);
			GUILayout.Label("Max Render Distance: " + visualOptions_0.MaxDistance.ToString(), Array.Empty<GUILayoutOption>());
			visualOptions_0.MaxDistance = (int)GUILayout.HorizontalSlider((float)visualOptions_0.MaxDistance, 0f, 3000f, Array.Empty<GUILayoutOption>());
			GUILayout.Space(2f);
			GUILayout.Label("Font Size: " + visualOptions_0.FontSize.ToString(), Array.Empty<GUILayoutOption>());
			visualOptions_0.FontSize = (int)GUILayout.HorizontalSlider((float)visualOptions_0.FontSize, 0f, 24f, Array.Empty<GUILayoutOption>());
		}

		// Token: 0x04000308 RID: 776
		public static Visual.ESPObject SelectedObject = Visual.ESPObject.Player;

		// Token: 0x04000309 RID: 777
		private static Vector2 vector2_0;

		// Token: 0x0400030A RID: 778
		private static Vector2 vector2_1;

		// Token: 0x0400030B RID: 779
		private static Vector2 vector2_2;

		// Token: 0x0400030C RID: 780
		public static VisualOptions SelectedOptions = G.Settings.PlayerOptions;
	}
}
