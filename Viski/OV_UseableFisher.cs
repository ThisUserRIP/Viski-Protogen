using System;
using System.Reflection;
using SDG.Framework.Water;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000045 RID: 69
	[Component]
	public class OV_UseableFisher : MonoBehaviour
	{
		// Token: 0x060001B2 RID: 434 RVA: 0x0000ECA0 File Offset: 0x0000CEA0
		[Override(typeof(UseableFisher), "Update", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public static void OV_Update(UseableFisher __instance)
		{
			if (G.Settings.MiscOptions.AutoFish)
			{
				OV_UseableFisher.BarF = (float)OV_UseableFisher.strengthMultiplierField.GetValue(__instance);
				Transform transform = (Transform)OV_UseableFisher.fieldInfo_3.GetValue(__instance);
				Rigidbody rigidbody = (Rigidbody)OV_UseableFisher.fieldInfo_4.GetValue(__instance);
				if (transform != null && rigidbody != null)
				{
					if ((bool)OV_UseableFisher.fieldInfo_6.GetValue(__instance))
					{
						if (!G.Settings.MiscOptions.AutoFishInAir)
						{
							bool flag;
							float num;
							WaterUtility.getUnderwaterInfo(transform.position, ref flag, ref num);
							if (flag && transform.position.y < num - 4f)
							{
								rigidbody.collisionDetectionMode = 0;
								rigidbody.useGravity = false;
								rigidbody.isKinematic = true;
								Vector3 position = transform.position;
								position.y = num;
								OV_UseableFisher.fieldInfo_5.SetValue(__instance, position);
								OV_UseableFisher.fieldInfo_6.SetValue(__instance, false);
							}
						}
						else
						{
							rigidbody.collisionDetectionMode = 0;
							rigidbody.useGravity = false;
							rigidbody.isKinematic = true;
							RaycastHit raycastHit;
							bool flag2 = Physics.Raycast(transform.position, Vector3.down, ref raycastHit, 0.5f);
							if (OV_UseableFisher.hasLanded || !flag2)
							{
								if (!flag2)
								{
									OV_UseableFisher.hasLanded = false;
								}
							}
							else
							{
								OV_UseableFisher.hasLanded = true;
							}
							Vector3 position2 = transform.position;
							position2.y = transform.position.y;
							OV_UseableFisher.fieldInfo_5.SetValue(__instance, position2);
							OV_UseableFisher.fieldInfo_6.SetValue(__instance, false);
						}
					}
					else
					{
						float num2 = (float)OV_UseableFisher.fieldInfo_7.GetValue(__instance);
						float num3 = (float)OV_UseableFisher.fieldInfo_8.GetValue(__instance);
						float realtimeSinceStartup = Time.realtimeSinceStartup;
						bool flag3 = (bool)OV_UseableFisher.fieldInfo_9.GetValue(__instance);
						bool flag4 = (bool)OV_UseableFisher.fieldInfo_10.GetValue(__instance);
						bool flag5 = (bool)OV_UseableFisher.fieldInfo_11.GetValue(__instance);
						bool flag6 = (bool)OV_UseableFisher.fieldInfo_12.GetValue(__instance);
						if (realtimeSinceStartup - num2 > num3)
						{
							if (!flag3)
							{
								OV_UseableFisher.methodInfo_0.Invoke(__instance, null);
								OV_UseableFisher.fieldInfo_10.SetValue(__instance, true);
							}
						}
						else if (realtimeSinceStartup - num2 > num3 - 1.4f)
						{
							if (!flag5)
							{
								OV_UseableFisher.fieldInfo_11.SetValue(__instance, true);
								OV_UseableFisher.FishIsOnHook = true;
							}
						}
						else if (realtimeSinceStartup - num2 > num3 - 2.4f && !flag6)
						{
							OV_UseableFisher.fieldInfo_12.SetValue(__instance, true);
							Transform transform2 = ((GameObject)Object.Instantiate(Resources.Load("Fishers/Splash"))).transform;
							transform2.name = "Splash";
							EffectManager.RegisterDebris(transform2.gameObject);
							transform2.position = (Vector3)OV_UseableFisher.fieldInfo_5.GetValue(__instance);
							transform2.rotation = Quaternion.Euler(-90f, Random.Range(0f, 360f), 0f);
							Object.Destroy(transform2.gameObject, 8f);
						}
						if (realtimeSinceStartup - num2 > num3 - 1.4f)
						{
							Vector3 vector = (Vector3)OV_UseableFisher.fieldInfo_5.GetValue(__instance);
							rigidbody.MovePosition(Vector3.Lerp(transform.position, vector + Vector3.down * 4f + Vector3.left * Random.Range(-4f, 4f) + Vector3.forward * Random.Range(-4f, 4f), 4f * Time.deltaTime));
						}
						else
						{
							Vector3 vector2 = (Vector3)OV_UseableFisher.fieldInfo_5.GetValue(__instance);
							rigidbody.MovePosition(Vector3.Lerp(transform.position, vector2 + Vector3.up * Mathf.Sin(Time.time) * 0.25f, 4f * Time.deltaTime));
						}
					}
				}
				else
				{
					OV_UseableFisher.FishIsOnHook = true;
				}
			}
		}

		// Token: 0x040001E2 RID: 482
		private static readonly FieldInfo fieldInfo_0 = typeof(UseableFisher).GetField("isStrengthening", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001E3 RID: 483
		public static readonly FieldInfo strengthMultiplierField = typeof(UseableFisher).GetField("strengthMultiplier", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001E4 RID: 484
		private static readonly FieldInfo fieldInfo_1 = typeof(UseableFisher).GetField("castStrengthBar", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001E5 RID: 485
		private static readonly FieldInfo CyXzwmjpf = typeof(UseableFisher).GetField("castStrengthBox", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001E6 RID: 486
		private static readonly FieldInfo fieldInfo_2 = typeof(UseableFisher).GetField("castStrengthArea", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001E7 RID: 487
		private static readonly FieldInfo fieldInfo_3 = typeof(UseableFisher).GetField("bobberTransform", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001E8 RID: 488
		private static readonly FieldInfo fieldInfo_4 = typeof(UseableFisher).GetField("bobberRigidbody", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001E9 RID: 489
		private static readonly FieldInfo fieldInfo_5 = typeof(UseableFisher).GetField("water", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001EA RID: 490
		private static readonly FieldInfo fieldInfo_6 = typeof(UseableFisher).GetField("isLuring", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001EB RID: 491
		private static readonly FieldInfo fieldInfo_7 = typeof(UseableFisher).GetField("lastLuck", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001EC RID: 492
		private static readonly FieldInfo fieldInfo_8 = typeof(UseableFisher).GetField("luckTime", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001ED RID: 493
		private static readonly FieldInfo fieldInfo_9 = typeof(UseableFisher).GetField("isReeling", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001EE RID: 494
		private static readonly FieldInfo fieldInfo_10 = typeof(UseableFisher).GetField("hasLuckReset", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001EF RID: 495
		private static readonly FieldInfo fieldInfo_11 = typeof(UseableFisher).GetField("hasTugged", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001F0 RID: 496
		private static readonly FieldInfo fieldInfo_12 = typeof(UseableFisher).GetField("hasSplashed", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001F1 RID: 497
		private static readonly FieldInfo fieldInfo_13 = typeof(UseableFisher).GetField("strengthTime", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001F2 RID: 498
		private static readonly MethodInfo methodInfo_0 = typeof(UseableFisher).GetMethod("resetLuck", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040001F3 RID: 499
		public static bool FishIsOnHook = false;

		// Token: 0x040001F4 RID: 500
		public static bool hasLanded = false;

		// Token: 0x040001F5 RID: 501
		public static float BarF;
	}
}
