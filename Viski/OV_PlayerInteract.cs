using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200004B RID: 75
	public class OV_PlayerInteract
	{
		// Token: 0x060001C0 RID: 448 RVA: 0x0000F91C File Offset: 0x0000DB1C
		[Initializer]
		public static void Init()
		{
			OV_PlayerInteract.FocusField = typeof(PlayerInteract).GetField("focus", BindingFlags.Static | BindingFlags.NonPublic);
			OV_PlayerInteract.TargetField = typeof(PlayerInteract).GetField("target", BindingFlags.Static | BindingFlags.NonPublic);
			OV_PlayerInteract.InteractableField = typeof(PlayerInteract).GetField("_interactable", BindingFlags.Static | BindingFlags.NonPublic);
			OV_PlayerInteract.fieldInfo_0 = typeof(PlayerInteract).GetField("_interactable2", BindingFlags.Static | BindingFlags.NonPublic);
			OV_PlayerInteract.PurchaseAssetField = typeof(PlayerInteract).GetField("purchaseAsset", BindingFlags.Static | BindingFlags.NonPublic);
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00002E81 File Offset: 0x00001081
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x0000F9B8 File Offset: 0x0000DBB8
		public static Transform focus
		{
			get
			{
				return (Transform)OV_PlayerInteract.FocusField.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.FocusField.SetValue(null, value);
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00002E93 File Offset: 0x00001093
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x0000F9D4 File Offset: 0x0000DBD4
		public static Transform target
		{
			get
			{
				return (Transform)OV_PlayerInteract.TargetField.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.TargetField.SetValue(null, value);
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00002EA5 File Offset: 0x000010A5
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x0000F9F0 File Offset: 0x0000DBF0
		public static Interactable interactable
		{
			get
			{
				return (Interactable)OV_PlayerInteract.InteractableField.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.InteractableField.SetValue(null, value);
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00002EB7 File Offset: 0x000010B7
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x0000FA0C File Offset: 0x0000DC0C
		public static Interactable2 interactable2
		{
			get
			{
				return (Interactable2)OV_PlayerInteract.fieldInfo_0.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.fieldInfo_0.SetValue(null, value);
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x00002EC9 File Offset: 0x000010C9
		// (set) Token: 0x060001CA RID: 458 RVA: 0x0000FA28 File Offset: 0x0000DC28
		public static ItemAsset purchaseAsset
		{
			get
			{
				return (ItemAsset)OV_PlayerInteract.PurchaseAssetField.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.PurchaseAssetField.SetValue(null, value);
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060001CB RID: 459 RVA: 0x0000FA44 File Offset: 0x0000DC44
		public float salvageTime
		{
			get
			{
				float result;
				if (!G.Settings.MiscOptions.CustomSalvageTime)
				{
					if (!Player.player.channel.owner.isAdmin)
					{
						result = 8f;
					}
					else
					{
						result = 1f;
					}
				}
				else
				{
					result = G.Settings.MiscOptions.SalvageTime;
				}
				return result;
			}
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000FAA0 File Offset: 0x0000DCA0
		[Override(typeof(PlayerInteract), "Update", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public void OV_Update()
		{
			if (VectorUtilities.ShouldRun())
			{
				if (SpyUtilities.BeingSpied)
				{
					Transform transform = Camera.main.transform;
					if (transform != null)
					{
						Physics.Raycast(new Ray(transform.position, transform.forward), ref OV_PlayerInteract.hit, (float)((Player.player.look.perspective == 1) ? 6 : 4), RayMasks.PLAYER_INTERACT, 0);
					}
				}
				if (Player.player.stance.stance == 6 || Player.player.stance.stance == 7 || Player.player.life.isDead || Player.player.workzone.isBuilding)
				{
					if (OV_PlayerInteract.focus != null && PlayerInteract.interactable != null)
					{
						HighlighterTool.unhighlight(PlayerInteract.interactable.transform);
					}
					OV_PlayerInteract.focus = null;
					OV_PlayerInteract.target = null;
					OV_PlayerInteract.interactable = null;
					OV_PlayerInteract.interactable2 = null;
				}
				else
				{
					if (Time.realtimeSinceStartup - OV_PlayerInteract.lastInteract > 0.1f)
					{
						OV_PlayerInteract.lastInteract = Time.realtimeSinceStartup;
						float num = (!G.Settings.MiscOptions.InteractThroughWalls || SpyUtilities.BeingSpied) ? 4f : 20f;
						Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), ref OV_PlayerInteract.hit, (Player.player.look.perspective == 1) ? (num + 2f) : num, RayMasks.PLAYER_INTERACT, 0);
					}
					Transform transform2 = (OV_PlayerInteract.hit.collider != null) ? OV_PlayerInteract.hit.collider.transform : null;
					if (transform2 != OV_PlayerInteract.focus)
					{
						if (OV_PlayerInteract.focus != null && PlayerInteract.interactable != null)
						{
							HighlighterTool.unhighlight(PlayerInteract.interactable.transform);
						}
						OV_PlayerInteract.focus = null;
						OV_PlayerInteract.target = null;
						OV_PlayerInteract.interactable = null;
						OV_PlayerInteract.interactable2 = null;
						if (transform2 != null)
						{
							OV_PlayerInteract.focus = transform2;
							OV_PlayerInteract.interactable = OV_PlayerInteract.focus.GetComponentInParent<Interactable>();
							OV_PlayerInteract.interactable2 = OV_PlayerInteract.focus.GetComponentInParent<Interactable2>();
							if (PlayerInteract.interactable != null)
							{
								OV_PlayerInteract.target = TransformRecursiveFind.FindChildRecursive(PlayerInteract.interactable.transform, "Target");
								if (!PlayerInteract.interactable.checkInteractable())
								{
									OV_PlayerInteract.target = null;
									OV_PlayerInteract.interactable = null;
								}
								else if (PlayerUI.window.isEnabled)
								{
									Color color;
									if (PlayerInteract.interactable.checkUseable())
									{
										if (!PlayerInteract.interactable.checkHighlight(ref color))
										{
											color = Color.green;
										}
									}
									else
									{
										color = Color.red;
									}
									HighlighterTool.highlight(PlayerInteract.interactable.transform, color);
								}
							}
						}
					}
				}
				if (!Player.player.life.isDead)
				{
					if (PlayerInteract.interactable != null)
					{
						EPlayerMessage eplayerMessage;
						string text;
						Color color2;
						if (PlayerInteract.interactable.checkHint(ref eplayerMessage, ref text, ref color2) && !PlayerUI.window.showCursor)
						{
							if (PlayerInteract.interactable.CompareTag("Item"))
							{
								PlayerUI.hint((!(OV_PlayerInteract.target != null)) ? OV_PlayerInteract.focus : OV_PlayerInteract.target, eplayerMessage, text, color2, new object[]
								{
									((InteractableItem)PlayerInteract.interactable).item,
									((InteractableItem)PlayerInteract.interactable).asset
								});
							}
							else
							{
								PlayerUI.hint((OV_PlayerInteract.target != null) ? OV_PlayerInteract.target : OV_PlayerInteract.focus, eplayerMessage, text, color2, new object[0]);
							}
						}
					}
					else if (OV_PlayerInteract.purchaseAsset == null || !(Player.player.movement.purchaseNode != null) || PlayerUI.window.showCursor)
					{
						if (OV_PlayerInteract.focus != null && OV_PlayerInteract.focus.CompareTag("Enemy"))
						{
							Player player = DamageTool.getPlayer(OV_PlayerInteract.focus);
							if (player != null && player != Player.player && !PlayerUI.window.showCursor)
							{
								PlayerUI.hint(null, 11, string.Empty, Color.white, new object[]
								{
									player.channel.owner
								});
							}
						}
					}
					else
					{
						PlayerUI.hint(null, 47, string.Empty, Color.white, new object[]
						{
							OV_PlayerInteract.purchaseAsset.itemName,
							Player.player.movement.purchaseNode.cost
						});
					}
					EPlayerMessage eplayerMessage2;
					float num2;
					if (PlayerInteract.interactable2 != null && PlayerInteract.interactable2.checkHint(ref eplayerMessage2, ref num2) && !PlayerUI.window.showCursor)
					{
						PlayerUI.hint2(eplayerMessage2, (!OV_PlayerInteract.isHoldingKey) ? 0f : ((Time.realtimeSinceStartup - OV_PlayerInteract.lastKeyDown) / this.salvageTime), num2);
					}
					if (Input.GetKeyDown(ControlsSettings.interact))
					{
						OV_PlayerInteract.lastKeyDown = Time.realtimeSinceStartup;
						OV_PlayerInteract.isHoldingKey = true;
					}
					if (Input.GetKeyDown(ControlsSettings.inspect) && ControlsSettings.inspect != ControlsSettings.interact && Player.player.equipment.canInspect)
					{
						Player.player.channel.send("askInspect", 0, 1, new object[0]);
					}
					if (OV_PlayerInteract.isHoldingKey)
					{
						if (Input.GetKeyUp(ControlsSettings.interact))
						{
							OV_PlayerInteract.isHoldingKey = false;
							if (PlayerUI.window.showCursor)
							{
								if (!Player.player.inventory.isStoring || !Player.player.inventory.shouldInteractCloseStorage)
								{
									if (!PlayerBarricadeSignUI.active)
									{
										if (PlayerBarricadeLibraryUI.active)
										{
											PlayerBarricadeLibraryUI.close();
											PlayerLifeUI.open();
										}
										else if (!PlayerNPCDialogueUI.active)
										{
											if (!PlayerNPCQuestUI.active)
											{
												if (PlayerNPCVendorUI.active)
												{
													PlayerNPCVendorUI.closeNicely();
												}
											}
											else
											{
												PlayerNPCQuestUI.closeNicely();
											}
										}
										else if (PlayerNPCDialogueUI.IsDialogueAnimating)
										{
											PlayerNPCDialogueUI.SkipAnimation();
										}
										else if (PlayerNPCDialogueUI.CanAdvanceToNextPage)
										{
											PlayerNPCDialogueUI.AdvancePage();
										}
										else
										{
											PlayerNPCDialogueUI.close();
											PlayerLifeUI.open();
										}
									}
									else
									{
										PlayerBarricadeSignUI.close();
										PlayerLifeUI.open();
									}
								}
								else
								{
									PlayerDashboardUI.close();
									PlayerLifeUI.open();
								}
							}
							else if (Player.player.stance.stance != 6 && Player.player.stance.stance != 7)
							{
								if (OV_PlayerInteract.focus != null && PlayerInteract.interactable != null)
								{
									if (PlayerInteract.interactable.checkUseable())
									{
										PlayerInteract.interactable.use();
									}
								}
								else if (OV_PlayerInteract.purchaseAsset == null)
								{
									if (ControlsSettings.inspect == ControlsSettings.interact && Player.player.equipment.canInspect)
									{
										Player.player.channel.send("askInspect", 0, 1, new object[0]);
									}
								}
								else if (Player.player.skills.experience >= Player.player.movement.purchaseNode.cost)
								{
									Player.player.skills.sendPurchase(Player.player.movement.purchaseNode);
								}
							}
							else
							{
								VehicleManager.exitVehicle();
							}
						}
						else if (Time.realtimeSinceStartup - OV_PlayerInteract.lastKeyDown > this.salvageTime)
						{
							OV_PlayerInteract.isHoldingKey = false;
							if (!PlayerUI.window.showCursor && PlayerInteract.interactable2 != null)
							{
								PlayerInteract.interactable2.use();
							}
						}
					}
				}
			}
		}

		// Token: 0x04000206 RID: 518
		public static FieldInfo FocusField;

		// Token: 0x04000207 RID: 519
		public static FieldInfo TargetField;

		// Token: 0x04000208 RID: 520
		public static FieldInfo InteractableField;

		// Token: 0x04000209 RID: 521
		public static FieldInfo fieldInfo_0;

		// Token: 0x0400020A RID: 522
		public static FieldInfo PurchaseAssetField;

		// Token: 0x0400020B RID: 523
		public static bool isHoldingKey;

		// Token: 0x0400020C RID: 524
		public static float lastInteract;

		// Token: 0x0400020D RID: 525
		public static float lastKeyDown;

		// Token: 0x0400020E RID: 526
		public static RaycastHit hit;
	}
}
