using System;
using System.Reflection;
using SDG.NetPak;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200004F RID: 79
	public class Spinbot2 : PlayerInputPacket
	{
		// Token: 0x060001D7 RID: 471 RVA: 0x00002EDB File Offset: 0x000010DB
		public static int GetInputX(PlayerMovement movement)
		{
			return (int)Spinbot2.fieldInfo_0.GetValue(movement);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00002EED File Offset: 0x000010ED
		public static int GetInputY(PlayerMovement movement)
		{
			return (int)Spinbot2.fieldInfo_1.GetValue(movement);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x000107AC File Offset: 0x0000E9AC
		public float NextSpinbotPitch(float increment)
		{
			Spinbot2.spinbotPitch += increment;
			if (Spinbot2.spinbotPitch > 180f)
			{
				Spinbot2.spinbotPitch -= 180f;
			}
			return Spinbot2.spinbotPitch;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x000107EC File Offset: 0x0000E9EC
		public static float NextSpinbotYaw(float increment)
		{
			Spinbot2.spinbotYaw += increment;
			if (Spinbot2.spinbotYaw >= 360f)
			{
				Spinbot2.spinbotYaw -= 360f;
			}
			return Spinbot2.spinbotYaw;
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00010830 File Offset: 0x0000EA30
		public static float ReverseAngle180(float angle)
		{
			angle += 180f;
			if (angle >= 360f)
			{
				angle -= 360f;
			}
			return angle;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00010864 File Offset: 0x0000EA64
		[Override(typeof(PlayerInputPacket), "write", BindingFlags.Instance | BindingFlags.Public, 0)]
		public void OV_write(NetPakWriter writer)
		{
			SystemNetPakWriterEx.WriteUInt32(writer, this.clientSimulationFrameNumber);
			SystemNetPakWriterEx.WriteInt32(writer, this.recov);
			SystemNetPakWriterEx.WriteUInt16(writer, this.keys);
			writer.WriteBits(this.primaryAttack, 2);
			writer.WriteBits(this.secondaryAttack, 2);
			if (G.Settings.MiscOptions.Spinbot)
			{
				int num = Spinbot2.GetInputX(Player.player.movement);
				int num2 = Spinbot2.GetInputY(Player.player.movement);
				if (num == 0 && num2 == 0)
				{
					SystemNetPakWriterEx.WriteFloat(writer, Spinbot.NextSpinbotYaw(180f));
				}
				else if (Spinbot2.walkSpin)
				{
					SystemNetPakWriterEx.WriteFloat(writer, this.yaw);
					Spinbot2.walkSpin = false;
				}
				else
				{
					num2 *= -1;
					num *= -1;
					SystemNetPakWriterEx.WriteFloat(writer, Spinbot2.ReverseAngle180(Player.player.look.yaw));
					Spinbot2.walkSpin = true;
				}
			}
			else
			{
				SystemNetPakWriterEx.WriteFloat(writer, this.yaw);
			}
			SystemNetPakWriterEx.WriteFloat(writer, this.pitch);
			if (this.clientsideInputs == null)
			{
				SystemNetPakWriterEx.WriteUInt8(writer, 0);
			}
			else
			{
				int num3 = this.clientsideInputs.Count;
				if (num3 > 16)
				{
					UnturnedLog.warn("Discarding excessive hit inputs {0}/{1}", new object[]
					{
						num3,
						16
					});
					num3 = 16;
				}
				SystemNetPakWriterEx.WriteUInt8(writer, (byte)num3);
				for (int i = 0; i < num3; i++)
				{
					RaycastInfo info = this.clientsideInputs[i].info;
					ERaycastInfoUsage usage = this.clientsideInputs[i].usage;
					if (info.player != null)
					{
						ERaycastInfoType_NetEnum.WriteEnum(writer, 3);
						ERaycastInfoUsage_NetEnum.WriteEnum(writer, usage);
						UnityNetPakWriterEx.WriteClampedVector3(writer, info.point, 13, 7);
						UnityNetPakWriterEx.WriteNormalVector3(writer, info.direction, 9);
						UnityNetPakWriterEx.WriteNormalVector3(writer, info.normal, 9);
						ELimb_NetEnum.WriteEnum(writer, info.limb);
						SteamworksNetPakWriterEx.WriteSteamID(writer, info.player.channel.owner.playerID.steamID);
					}
					else if (!(info.zombie != null))
					{
						if (!(info.animal != null))
						{
							if (info.vehicle != null)
							{
								ERaycastInfoType_NetEnum.WriteEnum(writer, 6);
								ERaycastInfoUsage_NetEnum.WriteEnum(writer, usage);
								UnityNetPakWriterEx.WriteClampedVector3(writer, info.point, 13, 7);
								UnityNetPakWriterEx.WriteNormalVector3(writer, info.normal, 9);
								PhysicsMaterialNetIdPakEx.WritePhysicsMaterialName(writer, info.materialName);
								SystemNetPakWriterEx.WriteUInt32(writer, info.vehicle.instanceID);
								Collider collider = info.collider;
								NetIdPakEx.WriteTransform(writer, (collider == null) ? null : collider.transform);
							}
							else if (info.transform != null)
							{
								if (!info.transform.CompareTag("Barricade"))
								{
									if (!info.transform.CompareTag("Structure"))
									{
										if (info.transform.CompareTag("Resource"))
										{
											ERaycastInfoType_NetEnum.WriteEnum(writer, 9);
											ERaycastInfoUsage_NetEnum.WriteEnum(writer, usage);
											info.transform = DamageTool.getResourceRootTransform(info.transform);
											byte b;
											byte b2;
											ushort num4;
											if (ResourceManager.tryGetRegion(info.transform, ref b, ref b2, ref num4))
											{
												UnityNetPakWriterEx.WriteClampedVector3(writer, info.point, 13, 7);
												UnityNetPakWriterEx.WriteNormalVector3(writer, info.direction, 9);
												UnityNetPakWriterEx.WriteNormalVector3(writer, info.normal, 9);
												PhysicsMaterialNetIdPakEx.WritePhysicsMaterialName(writer, info.materialName);
												SystemNetPakWriterEx.WriteUInt8(writer, b);
												SystemNetPakWriterEx.WriteUInt8(writer, b2);
												SystemNetPakWriterEx.WriteUInt16(writer, num4);
											}
											else
											{
												UnityNetPakWriterEx.WriteClampedVector3(writer, Vector3.zero, 13, 7);
												UnityNetPakWriterEx.WriteNormalVector3(writer, Vector3.up, 9);
												UnityNetPakWriterEx.WriteNormalVector3(writer, Vector3.up, 9);
												PhysicsMaterialNetIdPakEx.WritePhysicsMaterialName(writer, null);
												SystemNetPakWriterEx.WriteUInt8(writer, 0);
												SystemNetPakWriterEx.WriteUInt8(writer, 0);
												SystemNetPakWriterEx.WriteUInt16(writer, ushort.MaxValue);
											}
											Collider collider2 = info.collider;
											NetIdPakEx.WriteTransform(writer, (collider2 == null) ? null : collider2.transform);
										}
										else if (info.transform.CompareTag("Small") || info.transform.CompareTag("Medium") || info.transform.CompareTag("Large"))
										{
											ERaycastInfoType_NetEnum.WriteEnum(writer, 2);
											ERaycastInfoUsage_NetEnum.WriteEnum(writer, usage);
											InteractableObjectRubble componentInParent = info.transform.GetComponentInParent<InteractableObjectRubble>();
											if (componentInParent != null)
											{
												info.transform = componentInParent.transform;
												info.section = componentInParent.getSection(info.collider.transform);
											}
											byte b3;
											byte b4;
											ushort num5;
											if (!ObjectManager.tryGetRegion(info.transform, ref b3, ref b4, ref num5))
											{
												UnityNetPakWriterEx.WriteClampedVector3(writer, Vector3.zero, 13, 7);
												UnityNetPakWriterEx.WriteNormalVector3(writer, Vector3.up, 9);
												UnityNetPakWriterEx.WriteNormalVector3(writer, Vector3.up, 9);
												PhysicsMaterialNetIdPakEx.WritePhysicsMaterialName(writer, null);
												SystemNetPakWriterEx.WriteUInt8(writer, byte.MaxValue);
												SystemNetPakWriterEx.WriteUInt8(writer, 0);
												SystemNetPakWriterEx.WriteUInt8(writer, 0);
												SystemNetPakWriterEx.WriteUInt16(writer, ushort.MaxValue);
											}
											else
											{
												UnityNetPakWriterEx.WriteClampedVector3(writer, info.point, 13, 7);
												UnityNetPakWriterEx.WriteNormalVector3(writer, info.direction, 9);
												UnityNetPakWriterEx.WriteNormalVector3(writer, info.normal, 9);
												PhysicsMaterialNetIdPakEx.WritePhysicsMaterialName(writer, info.materialName);
												SystemNetPakWriterEx.WriteUInt8(writer, info.section);
												SystemNetPakWriterEx.WriteUInt8(writer, b3);
												SystemNetPakWriterEx.WriteUInt8(writer, b4);
												SystemNetPakWriterEx.WriteUInt16(writer, num5);
											}
											Collider collider3 = info.collider;
											NetIdPakEx.WriteTransform(writer, (collider3 != null) ? collider3.transform : null);
										}
										else if (info.transform.CompareTag("Ground") || info.transform.CompareTag("Environment"))
										{
											ERaycastInfoType_NetEnum.WriteEnum(writer, 0);
											ERaycastInfoUsage_NetEnum.WriteEnum(writer, usage);
											UnityNetPakWriterEx.WriteClampedVector3(writer, info.point, 13, 7);
											UnityNetPakWriterEx.WriteNormalVector3(writer, info.normal, 9);
											PhysicsMaterialNetIdPakEx.WritePhysicsMaterialName(writer, info.materialName);
										}
										else
										{
											ERaycastInfoType_NetEnum.WriteEnum(writer, 1);
										}
									}
									else
									{
										ERaycastInfoType_NetEnum.WriteEnum(writer, 8);
										ERaycastInfoUsage_NetEnum.WriteEnum(writer, usage);
										info.transform = DamageTool.getStructureRootTransform(info.transform);
										StructureDrop structureDrop = StructureManager.FindStructureByRootTransform(info.transform);
										if (structureDrop == null)
										{
											UnityNetPakWriterEx.WriteClampedVector3(writer, Vector3.zero, 13, 7);
											UnityNetPakWriterEx.WriteNormalVector3(writer, Vector3.up, 9);
											UnityNetPakWriterEx.WriteNormalVector3(writer, Vector3.up, 9);
											PhysicsMaterialNetIdPakEx.WritePhysicsMaterialName(writer, null);
											NetIdPakEx.WriteNetId(writer, NetId.INVALID);
										}
										else
										{
											UnityNetPakWriterEx.WriteClampedVector3(writer, info.point, 13, 7);
											UnityNetPakWriterEx.WriteNormalVector3(writer, info.direction, 9);
											UnityNetPakWriterEx.WriteNormalVector3(writer, info.normal, 9);
											PhysicsMaterialNetIdPakEx.WritePhysicsMaterialName(writer, info.materialName);
											NetIdPakEx.WriteNetId(writer, structureDrop.GetNetId());
										}
										Collider collider4 = info.collider;
										NetIdPakEx.WriteTransform(writer, (collider4 != null) ? collider4.transform : null);
									}
								}
								else
								{
									ERaycastInfoType_NetEnum.WriteEnum(writer, 7);
									ERaycastInfoUsage_NetEnum.WriteEnum(writer, usage);
									info.transform = DamageTool.getBarricadeRootTransform(info.transform);
									BarricadeDrop barricadeDrop = BarricadeManager.FindBarricadeByRootTransform(info.transform);
									if (barricadeDrop == null)
									{
										UnityNetPakWriterEx.WriteClampedVector3(writer, Vector3.zero, 13, 7);
										UnityNetPakWriterEx.WriteNormalVector3(writer, Vector3.up, 9);
										PhysicsMaterialNetIdPakEx.WritePhysicsMaterialName(writer, null);
										NetIdPakEx.WriteNetId(writer, NetId.INVALID);
									}
									else
									{
										UnityNetPakWriterEx.WriteClampedVector3(writer, info.point, 13, 7);
										UnityNetPakWriterEx.WriteNormalVector3(writer, info.normal, 9);
										PhysicsMaterialNetIdPakEx.WritePhysicsMaterialName(writer, info.materialName);
										NetIdPakEx.WriteNetId(writer, barricadeDrop.GetNetId());
									}
									Collider collider5 = info.collider;
									NetIdPakEx.WriteTransform(writer, (collider5 == null) ? null : collider5.transform);
								}
							}
							else
							{
								ERaycastInfoType_NetEnum.WriteEnum(writer, 1);
							}
						}
						else
						{
							ERaycastInfoType_NetEnum.WriteEnum(writer, 5);
							ERaycastInfoUsage_NetEnum.WriteEnum(writer, usage);
							UnityNetPakWriterEx.WriteClampedVector3(writer, info.point, 13, 7);
							UnityNetPakWriterEx.WriteNormalVector3(writer, info.direction, 9);
							UnityNetPakWriterEx.WriteNormalVector3(writer, info.normal, 9);
							ELimb_NetEnum.WriteEnum(writer, info.limb);
							SystemNetPakWriterEx.WriteUInt16(writer, info.animal.index);
						}
					}
					else
					{
						ERaycastInfoType_NetEnum.WriteEnum(writer, 4);
						ERaycastInfoUsage_NetEnum.WriteEnum(writer, usage);
						UnityNetPakWriterEx.WriteClampedVector3(writer, info.point, 13, 7);
						UnityNetPakWriterEx.WriteNormalVector3(writer, info.direction, 9);
						UnityNetPakWriterEx.WriteNormalVector3(writer, info.normal, 9);
						ELimb_NetEnum.WriteEnum(writer, info.limb);
						SystemNetPakWriterEx.WriteUInt16(writer, info.zombie.id);
					}
				}
			}
		}

		// Token: 0x04000213 RID: 531
		public static bool walkSpin;

		// Token: 0x04000214 RID: 532
		public static float spinbotYaw;

		// Token: 0x04000215 RID: 533
		public static float spinbotPitch;

		// Token: 0x04000216 RID: 534
		public static FieldInfo fieldInfo_0 = typeof(PlayerMovement).GetField("input_x", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x04000217 RID: 535
		public static FieldInfo fieldInfo_1 = typeof(PlayerMovement).GetField("input_y", BindingFlags.Instance | BindingFlags.NonPublic);
	}
}
