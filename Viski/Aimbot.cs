using System;
using System.Collections;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000011 RID: 17
	public static class Aimbot
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002369 File Offset: 0x00000569
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00004698 File Offset: 0x00002898
		public static float Pitch
		{
			get
			{
				return Player.player.look.pitch;
			}
			set
			{
				Aimbot.PitchInfo.SetValue(Player.player.look, value);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000045 RID: 69 RVA: 0x0000237A File Offset: 0x0000057A
		// (set) Token: 0x06000046 RID: 70 RVA: 0x000046C0 File Offset: 0x000028C0
		public static float Yaw
		{
			get
			{
				return Player.player.look.yaw;
			}
			set
			{
				Aimbot.YawInfo.SetValue(Player.player.look, value);
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000046E8 File Offset: 0x000028E8
		[Initializer]
		public static void Init()
		{
			Aimbot.PitchInfo = typeof(PlayerLook).GetField("_pitch", BindingFlags.Instance | BindingFlags.NonPublic);
			Aimbot.YawInfo = typeof(PlayerLook).GetField("_yaw", BindingFlags.Instance | BindingFlags.NonPublic);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000238B File Offset: 0x0000058B
		public static IEnumerator SetLockedObject()
		{
			return new Aimbot.<SetLockedObject>d__7(0);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002393 File Offset: 0x00000593
		public static IEnumerator AimToObject()
		{
			return new Aimbot.<AimToObject>d__8(0);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00004730 File Offset: 0x00002930
		public static void Aim(GameObject obj)
		{
			Camera main = Camera.main;
			Vector3 aimPosition = Aimbot.GetAimPosition(obj.transform, G.Settings.AimbotOptions.TargetLimb.ToString());
			if (aimPosition != Aimbot.PiVector)
			{
				Player.player.transform.LookAt(aimPosition);
				Player.player.transform.eulerAngles = new Vector3(0f, Player.player.transform.rotation.eulerAngles.y, 0f);
				main.transform.LookAt(aimPosition);
				float num = main.transform.localRotation.eulerAngles.x;
				if (num > 90f || num > 270f)
				{
					if (num >= 270f && num <= 360f)
					{
						num = main.transform.localRotation.eulerAngles.x - 270f;
					}
				}
				else
				{
					num = main.transform.localRotation.eulerAngles.x + 90f;
				}
				Aimbot.Pitch = num;
				Aimbot.Yaw = Player.player.transform.rotation.eulerAngles.y;
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00004898 File Offset: 0x00002A98
		public static void SmoothAim(GameObject obj)
		{
			Camera main = Camera.main;
			Vector3 aimPosition = Aimbot.GetAimPosition(obj.transform, G.Settings.AimbotOptions.TargetLimb.ToString());
			if (aimPosition != Aimbot.PiVector)
			{
				Player.player.transform.rotation = Quaternion.Slerp(Player.player.transform.rotation, Quaternion.LookRotation(aimPosition - Player.player.transform.position), Time.deltaTime * G.Settings.AimbotOptions.AimSpeed);
				Player.player.transform.eulerAngles = new Vector3(0f, Player.player.transform.rotation.eulerAngles.y, 0f);
				main.transform.localRotation = Quaternion.Slerp(main.transform.localRotation, Quaternion.LookRotation(aimPosition - main.transform.position), Time.deltaTime * G.Settings.AimbotOptions.AimSpeed);
				float num = main.transform.localRotation.eulerAngles.x;
				if (num <= 90f && num <= 270f)
				{
					num = main.transform.localRotation.eulerAngles.x + 90f;
				}
				else if (num >= 270f && num <= 360f)
				{
					num = main.transform.localRotation.eulerAngles.x - 270f;
				}
				Aimbot.Pitch = num;
				Aimbot.Yaw = Player.player.transform.rotation.eulerAngles.y;
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004A7C File Offset: 0x00002C7C
		public static Vector3 GetAimPosition(Transform parent, string name)
		{
			Transform[] componentsInChildren = parent.GetComponentsInChildren<Transform>();
			Vector3 piVector;
			if (componentsInChildren == null)
			{
				piVector = Aimbot.PiVector;
			}
			else
			{
				foreach (Transform transform in componentsInChildren)
				{
					if (transform.name.Trim() == name)
					{
						return transform.position + new Vector3(0f, 0.4f, 0f);
					}
				}
				piVector = Aimbot.PiVector;
			}
			return piVector;
		}

		// Token: 0x04000025 RID: 37
		public static Vector3 PiVector = new Vector3(0f, 3.1415927f, 0f);

		// Token: 0x04000026 RID: 38
		public static GameObject LockedObject;

		// Token: 0x04000027 RID: 39
		public static bool IsAiming = false;

		// Token: 0x04000028 RID: 40
		public static FieldInfo PitchInfo;

		// Token: 0x04000029 RID: 41
		public static FieldInfo YawInfo;
	}
}
