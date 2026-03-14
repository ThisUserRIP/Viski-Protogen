using System;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200005F RID: 95
	public static class SilentUtilities
	{
		// Token: 0x0600021F RID: 543 RVA: 0x00013568 File Offset: 0x00011768
		public static RaycastInfo GenerateOriginalRaycast(Ray ray, float range, int mask, Player ignorePlayer = null)
		{
			RaycastHit raycastHit;
			Physics.Raycast(ray, ref raycastHit, range, mask);
			RaycastInfo raycastInfo = new RaycastInfo(raycastHit);
			raycastInfo.direction = ray.direction;
			raycastInfo.limb = 12;
			if (raycastInfo.transform != null)
			{
				if (raycastInfo.transform.CompareTag("Barricade"))
				{
					raycastInfo.transform = DamageTool.getBarricadeRootTransform(raycastInfo.transform);
				}
				else if (!raycastInfo.transform.CompareTag("Structure"))
				{
					if (!raycastInfo.transform.CompareTag("Resource"))
					{
						if (raycastInfo.transform.CompareTag("Enemy"))
						{
							raycastInfo.player = DamageTool.getPlayer(raycastInfo.transform);
							if (raycastInfo.player == ignorePlayer)
							{
								raycastInfo.player = null;
							}
							raycastInfo.limb = DamageTool.getLimb(raycastInfo.transform);
						}
						else if (raycastInfo.transform.CompareTag("Zombie"))
						{
							raycastInfo.zombie = DamageTool.getZombie(raycastInfo.transform);
							raycastInfo.limb = DamageTool.getLimb(raycastInfo.transform);
						}
						else if (!raycastInfo.transform.CompareTag("Animal"))
						{
							if (raycastInfo.transform.CompareTag("Vehicle"))
							{
								raycastInfo.vehicle = DamageTool.getVehicle(raycastInfo.transform);
							}
						}
						else
						{
							raycastInfo.animal = DamageTool.getAnimal(raycastInfo.transform);
							raycastInfo.limb = DamageTool.getLimb(raycastInfo.transform);
						}
					}
					else
					{
						raycastInfo.transform = DamageTool.getResourceRootTransform(raycastInfo.transform);
					}
				}
				else
				{
					raycastInfo.transform = DamageTool.getStructureRootTransform(raycastInfo.transform);
				}
				raycastInfo.materialName = PhysicsTool.GetMaterialName(raycastHit);
			}
			return raycastInfo;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00013744 File Offset: 0x00011944
		public static bool GenerateRaycast(out RaycastInfo info)
		{
			ItemGunAsset itemGunAsset = Player.player.equipment.asset as ItemGunAsset;
			float range;
			if (!G.Settings.SilentOptions.ExtraRange)
			{
				range = ((itemGunAsset != null) ? (itemGunAsset.range + 10f) : 15.5f);
			}
			else
			{
				range = ((itemGunAsset == null) ? 15.5f : (itemGunAsset.range + (float)G.Settings.SilentOptions.ExtraRangeM));
			}
			info = SilentUtilities.GenerateOriginalRaycast(new Ray(Player.player.look.aim.position, Player.player.look.aim.forward), range, RayMasks.DAMAGE_CLIENT, null);
			GameObject @object;
			Vector3 point;
			bool result;
			if (SilentUtilities.GetTargetObject(SilentUtilities.Objects, out @object, out point, range))
			{
				info = SilentUtilities.GenerateRaycast(@object, point, info.collider);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00013824 File Offset: 0x00011A24
		public static RaycastInfo GenerateRaycast(GameObject Object, Vector3 Point, Collider col)
		{
			ELimb limb = 13;
			if (G.Settings.SilentOptions.UseRandomLimb)
			{
				ELimb[] array = (ELimb[])Enum.GetValues(typeof(ELimb));
				limb = array[new Random().Next(0, array.Length)];
			}
			return new RaycastInfo(Object.transform)
			{
				point = Point,
				direction = Player.player.look.aim.forward,
				limb = limb,
				collider = col,
				transform = Object.transform,
				player = Object.GetComponent<Player>(),
				zombie = Object.GetComponentInParent<Zombie>(),
				vehicle = Object.GetComponent<InteractableVehicle>(),
				animal = Object.GetComponentInParent<Animal>(),
				materialName = PhysicsTool.GetMaterialName(Point, Object.transform, col)
			};
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00013900 File Offset: 0x00011B00
		public static bool GetTargetObject(HashSet<GameObject> Objects, out GameObject Object, out Vector3 Point, float Range)
		{
			double num = (double)(Range + 1f);
			double num2 = 360.0;
			Object = null;
			Point = Vector3.zero;
			Vector3 position = Player.player.look.aim.position;
			Vector3 forward = Player.player.look.aim.forward;
			foreach (GameObject gameObject in Objects)
			{
				if (!(gameObject == null))
				{
					SilentComponent component = gameObject.GetComponent<SilentComponent>();
					if (component == null)
					{
						gameObject.AddComponent<SilentComponent>();
					}
					else
					{
						Vector3 position2 = gameObject.transform.position;
						Player component2 = gameObject.GetComponent<Player>();
						if (!component2 || !component2.life.isDead)
						{
							if (component2)
							{
								try
								{
									if (PlayersTab.IsFriendly(component2))
									{
										continue;
									}
								}
								catch (Exception)
								{
									continue;
								}
							}
							if ((!G.Settings.SilentOptions.SafeZone || !(component2 != null) || !LevelNodes.isPointInsideSafezone(component2.transform.position, ref SilentUtilities.isSafeInfo)) && (!G.Settings.SilentOptions.Admin || !(component2 != null) || !component2.channel.owner.isAdmin))
							{
								Zombie component3 = gameObject.GetComponent<Zombie>();
								if (!component3 || !component3.isDead)
								{
									double distance = VectorUtilities.GetDistance(position, position2);
									if (distance <= (double)Range)
									{
										if (G.Settings.SilentOptions.SilentAimUseFOV)
										{
											double angleDelta = VectorUtilities.GetAngleDelta(position, forward, position2);
											if (angleDelta > (double)G.Settings.SilentOptions.SilentAimFOV || angleDelta > num2)
											{
												continue;
											}
											num2 = angleDelta;
										}
										else if (distance > num)
										{
											continue;
										}
										Vector3 vector;
										if (SilentSphere.GetRaycast(gameObject, position, out vector))
										{
											Object = gameObject;
											num = distance;
											Point = vector;
										}
									}
								}
							}
						}
					}
				}
			}
			return Object != null;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00013B48 File Offset: 0x00011D48
		public static T Next<T>(this T src) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(string.Format("Argument {0} is not an Enum", typeof(T).FullName));
			}
			T[] array = (T[])Enum.GetValues(src.GetType());
			int num = Array.IndexOf<T>(array, src) + 1;
			return (array.Length == num) ? array[0] : array[num];
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00013BC4 File Offset: 0x00011DC4
		public static void AddRange<T>(this HashSet<T> source, IEnumerable<T> target)
		{
			foreach (T item in target)
			{
				source.Add(item);
			}
		}

		// Token: 0x0400027A RID: 634
		public static SafezoneNode isSafeInfo;

		// Token: 0x0400027B RID: 635
		public static HashSet<GameObject> Objects = new HashSet<GameObject>();
	}
}
