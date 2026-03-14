using System;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000073 RID: 115
	public class AimbotTab
	{
		// Token: 0x0600027F RID: 639 RVA: 0x00016224 File Offset: 0x00014424
		public static void Tab()
		{
			GUILayout.BeginArea(new Rect(340f, 20f, 350f, 400f), "Silent Aimbot", "box");
			GUILayout.Space(5f);
			AimbotTab.vector2_0 = GUILayout.BeginScrollView(AimbotTab.vector2_0, Array.Empty<GUILayoutOption>());
			G.Settings.SilentOptions.Silent = GUILayout.Toggle(G.Settings.SilentOptions.Silent, "Silent Aim", Array.Empty<GUILayoutOption>());
			if (!G.Settings.SilentOptions.Silent)
			{
				G.Settings.SilentOptions.PunchSilentAim = false;
				G.Settings.SilentOptions.ExtendMeleeRange = false;
			}
			else
			{
				G.Settings.SilentOptions.PunchSilentAim = true;
				G.Settings.SilentOptions.ExtendMeleeRange = true;
				G.Settings.SilentOptions.SilentAimUseFOV = GUILayout.Toggle(G.Settings.SilentOptions.SilentAimUseFOV, "Use FOV", Array.Empty<GUILayoutOption>());
				if (G.Settings.SilentOptions.SilentAimUseFOV)
				{
					GUILayout.Label("FOV: " + G.Settings.SilentOptions.SilentAimFOV.ToString(), Array.Empty<GUILayoutOption>());
					G.Settings.SilentOptions.SilentAimFOV = (float)((int)GUILayout.HorizontalSlider(G.Settings.SilentOptions.SilentAimFOV, 1f, 180f, Array.Empty<GUILayoutOption>()));
					G.Settings.SilentOptions.ShowSilentFOV = GUILayout.Toggle(G.Settings.SilentOptions.ShowSilentFOV, "Draw FOV", Array.Empty<GUILayoutOption>());
					G.Settings.SilentOptions.RGBFov = GUILayout.Toggle(G.Settings.SilentOptions.RGBFov, "RGB FOV", Array.Empty<GUILayoutOption>());
					if (G.Settings.SilentOptions.RGBFov)
					{
						GUILayout.Label("RGB Speed: " + G.Settings.SilentOptions.float_0.ToString("F1") + "x", Array.Empty<GUILayoutOption>());
						G.Settings.SilentOptions.float_0 = GUILayout.HorizontalSlider(G.Settings.SilentOptions.float_0, 0.1f, 5f, Array.Empty<GUILayoutOption>());
					}
				}
				G.Settings.SilentOptions.ExtraRange = GUILayout.Toggle(G.Settings.SilentOptions.ExtraRange, "Extra Range", Array.Empty<GUILayoutOption>());
				if (G.Settings.SilentOptions.ExtraRange)
				{
					GUILayout.Label("Range: " + G.Settings.SilentOptions.ExtraRangeM.ToString(), Array.Empty<GUILayoutOption>());
					G.Settings.SilentOptions.ExtraRangeM = (int)GUILayout.HorizontalSlider((float)G.Settings.SilentOptions.ExtraRangeM, 1f, 200f, Array.Empty<GUILayoutOption>());
				}
				G.Settings.SilentOptions.TargetInfo = GUILayout.Toggle(G.Settings.SilentOptions.TargetInfo, "Target Info", Array.Empty<GUILayoutOption>());
				G.Settings.SilentOptions.Tracers = GUILayout.Toggle(G.Settings.SilentOptions.Tracers, "Bullet Tracers", Array.Empty<GUILayoutOption>());
				if (G.Settings.SilentOptions.Tracers)
				{
					GUILayout.Label("Tracer Lifetime: " + Misc.TracerTime.ToString(), Array.Empty<GUILayoutOption>());
					Misc.TracerTime = GUILayout.HorizontalSlider(Misc.TracerTime, 0.05f, 10f, Array.Empty<GUILayoutOption>());
				}
				G.Settings.SilentOptions.SafeZone = GUILayout.Toggle(G.Settings.SilentOptions.SafeZone, "Dont Hit If In SafeZone", Array.Empty<GUILayoutOption>());
				G.Settings.SilentOptions.Admin = GUILayout.Toggle(G.Settings.SilentOptions.Admin, "Dont Hit If Admin", Array.Empty<GUILayoutOption>());
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(700f, 20f, 290f, 400f), "Silent Aim Targets", "box");
			GUILayout.Space(5f);
			if (G.Settings.SilentOptions.Silent)
			{
				G.Settings.SilentOptions.TargetPlayers = GUILayout.Toggle(G.Settings.SilentOptions.TargetPlayers, "Target: Players", Array.Empty<GUILayoutOption>());
				G.Settings.SilentOptions.TargetBeds = GUILayout.Toggle(G.Settings.SilentOptions.TargetBeds, "Target: Beds", Array.Empty<GUILayoutOption>());
				G.Settings.SilentOptions.TargetZombies = GUILayout.Toggle(G.Settings.SilentOptions.TargetZombies, "Target: Zombies", Array.Empty<GUILayoutOption>());
				G.Settings.SilentOptions.TargetAnimal = GUILayout.Toggle(G.Settings.SilentOptions.TargetAnimal, "Target: Animals", Array.Empty<GUILayoutOption>());
				G.Settings.SilentOptions.TargetGenerators = GUILayout.Toggle(G.Settings.SilentOptions.TargetGenerators, "Target: Generators", Array.Empty<GUILayoutOption>());
				G.Settings.SilentOptions.TargetClaimFlags = GUILayout.Toggle(G.Settings.SilentOptions.TargetClaimFlags, "Target: Claim Flag", Array.Empty<GUILayoutOption>());
				G.Settings.SilentOptions.TargetVehicles = GUILayout.Toggle(G.Settings.SilentOptions.TargetVehicles, "Target: Vehicle", Array.Empty<GUILayoutOption>());
				G.Settings.SilentOptions.TargetStorage = GUILayout.Toggle(G.Settings.SilentOptions.TargetStorage, "Target: Storage", Array.Empty<GUILayoutOption>());
				G.Settings.SilentOptions.TargetSentries = GUILayout.Toggle(G.Settings.SilentOptions.TargetSentries, "Target: Sentries", Array.Empty<GUILayoutOption>());
				G.Settings.SilentOptions.TargetTrees = GUILayout.Toggle(G.Settings.SilentOptions.TargetTrees, "Target: Trees", Array.Empty<GUILayoutOption>());
				G.Settings.SilentOptions.TargetFarm = GUILayout.Toggle(G.Settings.SilentOptions.TargetFarm, "Target: Farm", Array.Empty<GUILayoutOption>());
				G.Settings.SilentOptions.TargetYourSelf = GUILayout.Toggle(G.Settings.SilentOptions.TargetYourSelf, "Target: YourSelf", Array.Empty<GUILayoutOption>());
			}
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(340f, 430f, 350f, 200f), "Silent Aim Settings / Fov", "box");
			GUILayout.Space(5f);
			if (G.Settings.SilentOptions.FovMethod == 0 && GUILayout.Button("Fov Type: Circle", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				G.Settings.SilentOptions.FovMethod = 1;
				G.Settings.SilentOptions.float_1 = 2.098787f;
			}
			if (G.Settings.SilentOptions.FovMethod == 1 && GUILayout.Button("Fov Type: Trigon", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				G.Settings.SilentOptions.FovMethod = 2;
				G.Settings.SilentOptions.float_1 = 1.569352f;
			}
			if (G.Settings.SilentOptions.FovMethod == 2 && GUILayout.Button("Fov Type: Square", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				G.Settings.SilentOptions.FovMethod = 3;
				G.Settings.SilentOptions.float_1 = 1.048189f;
			}
			if (G.Settings.SilentOptions.FovMethod == 3 && GUILayout.Button("Fov Type: Hexagon", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				G.Settings.SilentOptions.FovMethod = 4;
				G.Settings.SilentOptions.float_1 = 0.7899502f;
			}
			if (G.Settings.SilentOptions.FovMethod == 4 && GUILayout.Button("Fov Type: Octagon", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				G.Settings.SilentOptions.FovMethod = 5;
				G.Settings.SilentOptions.float_1 = 0.3946678f;
			}
			if (G.Settings.SilentOptions.FovMethod == 5 && GUILayout.Button("Fov Type: Hexadecimal", "NavBox", Array.Empty<GUILayoutOption>()))
			{
				G.Settings.SilentOptions.FovMethod = 0;
				G.Settings.SilentOptions.float_1 = 0.01f;
			}
			if (G.Settings.SilentOptions.Silent)
			{
				if (GUILayout.Button("Silent Aim Limb: " + Enum.GetName(typeof(ELimb), G.Settings.SilentOptions.TargetLimb), "NavBox", Array.Empty<GUILayoutOption>()))
				{
					G.Settings.SilentOptions.TargetLimb = G.Settings.SilentOptions.TargetLimb.Next<ELimb>();
				}
				G.Settings.SilentOptions.UseRandomLimb = GUILayout.Toggle(G.Settings.SilentOptions.UseRandomLimb, "Random Limb", Array.Empty<GUILayoutOption>());
				GUILayout.Label(Math.Round((double)G.Settings.SilentOptions.SphereRadius, 2).ToString() + "m", Array.Empty<GUILayoutOption>());
				G.Settings.SilentOptions.SphereRadius = (float)((int)GUILayout.HorizontalSlider(G.Settings.SilentOptions.SphereRadius, 1f, 14f, Array.Empty<GUILayoutOption>()));
			}
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(700f, 430f, 290f, 200f), "Aimbot", "box");
			GUILayout.Space(5f);
			AimbotTab.vector2_1 = GUILayout.BeginScrollView(AimbotTab.vector2_1, Array.Empty<GUILayoutOption>());
			G.Settings.AimbotOptions.Aimbot = GUILayout.Toggle(G.Settings.AimbotOptions.Aimbot, "Aimbot", Array.Empty<GUILayoutOption>());
			if (G.Settings.AimbotOptions.Aimbot)
			{
				G.Settings.AimbotOptions.Smooth = GUILayout.Toggle(G.Settings.AimbotOptions.Smooth, "Smooth", Array.Empty<GUILayoutOption>());
				if (G.Settings.AimbotOptions.Smooth)
				{
					GUILayout.Label("Speed: " + G.Settings.AimbotOptions.AimSpeed.ToString(), Array.Empty<GUILayoutOption>());
					G.Settings.AimbotOptions.AimSpeed = (float)((int)GUILayout.HorizontalSlider(G.Settings.AimbotOptions.AimSpeed, 1f, 10f, Array.Empty<GUILayoutOption>()));
				}
				G.Settings.AimbotOptions.OnKey = GUILayout.Toggle(G.Settings.AimbotOptions.OnKey, "On Key (F)", Array.Empty<GUILayoutOption>());
				G.Settings.AimbotOptions.AimbotUseFov = GUILayout.Toggle(G.Settings.AimbotOptions.AimbotUseFov, "Use FOV", Array.Empty<GUILayoutOption>());
				if (G.Settings.AimbotOptions.AimbotUseFov)
				{
					GUILayout.Label("FOV: " + G.Settings.AimbotOptions.float_0.ToString(), Array.Empty<GUILayoutOption>());
					G.Settings.AimbotOptions.float_0 = (float)((int)GUILayout.HorizontalSlider(G.Settings.AimbotOptions.float_0, 1f, 180f, Array.Empty<GUILayoutOption>()));
					G.Settings.AimbotOptions.AimbotShowFOV = GUILayout.Toggle(G.Settings.AimbotOptions.AimbotShowFOV, "Draw FOV", Array.Empty<GUILayoutOption>());
				}
				if (GUILayout.Button("Aimbot Aim Limb: " + Enum.GetName(typeof(AimbotLimb), G.Settings.AimbotOptions.TargetLimb), "NavBox", Array.Empty<GUILayoutOption>()))
				{
					G.Settings.AimbotOptions.TargetLimb = G.Settings.AimbotOptions.TargetLimb.Next<AimbotLimb>();
				}
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		// Token: 0x040002F0 RID: 752
		private static Vector2 vector2_0;

		// Token: 0x040002F1 RID: 753
		private static Vector2 vector2_1;
	}
}
