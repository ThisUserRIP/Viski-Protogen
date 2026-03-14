using System;
using System.Collections.Generic;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000054 RID: 84
	public class OV_UseableGun
	{
		// Token: 0x060001ED RID: 493 RVA: 0x000117B0 File Offset: 0x0000F9B0
		[Initializer]
		public static void Load()
		{
			OV_UseableGun.BulletsField = typeof(UseableGun).GetField("bullets", BindingFlags.Instance | BindingFlags.NonPublic);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x000117DC File Offset: 0x0000F9DC
		public static bool IsRaycastInvalid(RaycastInfo info)
		{
			return info.player == null && info.zombie == null && info.animal == null && info.vehicle == null && info.transform == null;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00011830 File Offset: 0x0000FA30
		[Override(typeof(UseableGun), "ballistics", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public void OV_ballistics()
		{
			Useable useable = Player.player.equipment.useable;
			if (Provider.isServer)
			{
				OverrideUtilities.CallOriginal(useable, new object[0]);
			}
			else
			{
				ItemGunAsset itemGunAsset = (ItemGunAsset)Player.player.equipment.asset;
				PlayerLook look = Player.player.look;
				if (!(itemGunAsset.projectile != null))
				{
					List<BulletInfo> list = (List<BulletInfo>)OV_UseableGun.BulletsField.GetValue(useable);
					if (list.Count != 0)
					{
						RaycastInfo raycastInfo = null;
						if (G.Settings.SilentOptions.Silent)
						{
							SilentUtilities.GenerateRaycast(out raycastInfo);
							Misc.AddTracer(Player.player.look.aim.position, raycastInfo.point);
						}
						if (Provider.modeConfigData.Gameplay.Ballistics)
						{
							if (raycastInfo != null)
							{
								for (int i = 0; i < list.Count; i++)
								{
									BulletInfo bulletInfo = list[i];
									double distance = VectorUtilities.GetDistance(Player.player.transform.position, raycastInfo.point);
									if ((double)((float)bulletInfo.steps * itemGunAsset.ballisticTravel) >= distance)
									{
										EPlayerHit eplayerHit = OV_UseableGun.CalcHitMarker(itemGunAsset, ref raycastInfo);
										PlayerUI.hitmark(Vector3.zero, false, eplayerHit);
										Player.player.input.sendRaycast(raycastInfo, 3);
										bulletInfo.steps = 254;
									}
								}
								for (int num = list.Count - 1; num >= 0; num--)
								{
									BulletInfo bulletInfo2 = list[num];
									BulletInfo bulletInfo3 = bulletInfo2;
									BulletInfo bulletInfo4 = bulletInfo3;
									bulletInfo4.steps += 1;
									if (bulletInfo2.steps >= itemGunAsset.ballisticSteps)
									{
										list.RemoveAt(num);
									}
								}
							}
							else
							{
								OverrideUtilities.CallOriginal(useable, new object[0]);
							}
						}
						else if (raycastInfo != null)
						{
							for (int j = 0; j < list.Count; j++)
							{
								EPlayerHit eplayerHit2 = OV_UseableGun.CalcHitMarker(itemGunAsset, ref raycastInfo);
								PlayerUI.hitmark(Vector3.zero, false, eplayerHit2);
								Player.player.input.sendRaycast(raycastInfo, 3);
							}
							list.Clear();
						}
						else
						{
							OverrideUtilities.CallOriginal(useable, new object[0]);
						}
					}
				}
			}
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00011A7C File Offset: 0x0000FC7C
		public static EPlayerHit CalcHitMarker(ItemGunAsset PAsset, ref RaycastInfo ri)
		{
			EPlayerHit eplayerHit = 0;
			EPlayerHit result;
			if (ri == null || PAsset == null)
			{
				result = eplayerHit;
			}
			else
			{
				if (!ri.animal && !ri.player && !ri.zombie)
				{
					if (ri.transform)
					{
						if (!ri.transform.CompareTag("Barricade") || PAsset.barricadeDamage <= 1f)
						{
							if (ri.transform.CompareTag("Structure") && PAsset.structureDamage > 1f)
							{
								ushort num;
								if (!ushort.TryParse(ri.transform.name, out num))
								{
									return eplayerHit;
								}
								ItemStructureAsset itemStructureAsset = (ItemStructureAsset)Assets.find(1, num);
								if (itemStructureAsset == null || (!itemStructureAsset.isVulnerable && !PAsset.isInvulnerable))
								{
									return eplayerHit;
								}
								if (eplayerHit == 0)
								{
									eplayerHit = 3;
								}
							}
							else if (!ri.transform.CompareTag("Resource") || PAsset.resourceDamage <= 1f)
							{
								if (PAsset.objectDamage > 1f)
								{
									InteractableObjectRubble component = ri.transform.GetComponent<InteractableObjectRubble>();
									if (component == null)
									{
										return eplayerHit;
									}
									ri.section = component.getSection(ri.collider.transform);
									if (component.isSectionDead(ri.section) || (!component.asset.rubbleIsVulnerable && !PAsset.isInvulnerable))
									{
										return eplayerHit;
									}
									if (eplayerHit == 0)
									{
										eplayerHit = 3;
									}
								}
							}
							else
							{
								byte b;
								byte b2;
								ushort num2;
								if (!ResourceManager.tryGetRegion(ri.transform, ref b, ref b2, ref num2))
								{
									return eplayerHit;
								}
								ResourceSpawnpoint resourceSpawnpoint = ResourceManager.getResourceSpawnpoint(b, b2, num2);
								if (resourceSpawnpoint == null || resourceSpawnpoint.isDead || !PAsset.hasBladeID(resourceSpawnpoint.asset.bladeID))
								{
									return eplayerHit;
								}
								if (eplayerHit == 0)
								{
									eplayerHit = 3;
								}
							}
						}
						else
						{
							ushort num3;
							if (!ushort.TryParse(ri.transform.name, out num3))
							{
								return eplayerHit;
							}
							ItemBarricadeAsset itemBarricadeAsset = (ItemBarricadeAsset)Assets.find(1, num3);
							if (itemBarricadeAsset == null || (!itemBarricadeAsset.isVulnerable && !PAsset.isInvulnerable))
							{
								return eplayerHit;
							}
							if (eplayerHit == 0)
							{
								eplayerHit = 3;
							}
						}
					}
					else if (ri.vehicle && !ri.vehicle.isDead && PAsset.vehicleDamage > 1f && (ri.vehicle.asset != null && (ri.vehicle.asset.isVulnerable || PAsset.isInvulnerable)) && eplayerHit == 0)
					{
						eplayerHit = 3;
					}
				}
				else
				{
					eplayerHit = 1;
					if (ri.limb == 13)
					{
						eplayerHit = 2;
					}
				}
				result = eplayerHit;
			}
			return result;
		}

		// Token: 0x04000229 RID: 553
		public static FieldInfo BulletsField;
	}
}
