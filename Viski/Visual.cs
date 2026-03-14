using System;
using System.Collections;
using System.Collections.Generic;
using HighlightingSystem;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000020 RID: 32
	[Component]
	public class Visual : MonoBehaviour
	{
		// Token: 0x0600008A RID: 138 RVA: 0x000060D8 File Offset: 0x000042D8
		public void OnGUI()
		{
			if (VectorUtilities.ShouldRun())
			{
				for (int i = 0; i < Visual.EObjects.Count; i++)
				{
					Visual.ESPObj espobj = Visual.EObjects[i];
					if (SpyUtilities.BeingSpied)
					{
						Highlighter component = espobj.GObject.GetComponent<Highlighter>();
						if (component != null)
						{
							component.ConstantOffImmediate();
						}
						Visual.RemoveShaders(espobj.GObject);
					}
					else if (!(espobj.GObject == null) && Visual.InScreenView(Camera.main.WorldToViewportPoint(espobj.GObject.transform.position)) && espobj.Options.Enabled && Visual.GetDistance(espobj.GObject.transform.position) <= (float)espobj.Options.MaxDistance && (espobj.Target != Visual.ESPObject.Player || !((SteamPlayer)espobj.Object).player.life.isDead) && (espobj.Target != Visual.ESPObject.Zombie || !((Zombie)espobj.Object).isDead) && (espobj.Target != Visual.ESPObject.Vehicle || !((InteractableVehicle)espobj.Object).isDead) && (espobj.Target != Visual.ESPObject.Vehicle || !G.Settings.GlobalOptions.OnlyUnlocked || !((InteractableVehicle)espobj.Object).isLocked) && (espobj.Target != Visual.ESPObject.Farm || !G.Settings.GlobalOptions.FullGrown || ((InteractableFarm)espobj.Object).IsFullyGrown) && (espobj.Target != Visual.ESPObject.Bed || !G.Settings.GlobalOptions.OnlyUnclaimed || !((InteractableBed)espobj.Object).isClaimed) && (espobj.Target != Visual.ESPObject.Item || Visual.IsItemWhitelisted((InteractableItem)espobj.Object, G.Settings.GlobalOptions)))
					{
						string text = string.Format("<size={0}>", espobj.Options.FontSize);
						string text2 = string.Format("<size={0}>", espobj.Options.FontSize);
						Color32 color = C.GetColor("Box_Color");
						Color32 color2 = C.GetColor(Enum.GetName(typeof(Visual.ESPObject), espobj.Target) + "_ESP");
						if (espobj.Options.Distance)
						{
							if (Visual.GetDistance(espobj.GObject.transform.position) >= 0f && Visual.GetDistance(espobj.GObject.transform.position) < 50f)
							{
								float num = Mathf.InverseLerp(0f, 50f, Visual.GetDistance(espobj.GObject.transform.position));
								Color color3 = Color.Lerp(Color.red, Color.red, num);
								string arg = ColorUtility.ToHtmlStringRGB(color3);
								text += string.Format("<color=white>[</color><color=#{0}>{1}</color><color=white>]</color>", arg, Visual.GetDistance(espobj.GObject.transform.position));
								text2 += string.Format("[{0}]", Visual.GetDistance(espobj.GObject.transform.position));
							}
							if (Visual.GetDistance(espobj.GObject.transform.position) >= 50f && Visual.GetDistance(espobj.GObject.transform.position) < 300f)
							{
								float num2 = Mathf.InverseLerp(50f, 300f, Visual.GetDistance(espobj.GObject.transform.position));
								Color color4 = Color.Lerp(Color.red, Color.yellow, num2);
								string arg2 = ColorUtility.ToHtmlStringRGB(color4);
								text += string.Format("<color=white>[</color><color=#{0}>{1}</color><color=white>]</color>", arg2, Visual.GetDistance(espobj.GObject.transform.position));
								text2 += string.Format("[{0}]", Visual.GetDistance(espobj.GObject.transform.position));
							}
							if (Visual.GetDistance(espobj.GObject.transform.position) >= 300f)
							{
								float num3 = Mathf.InverseLerp(300f, 1000f, Visual.GetDistance(espobj.GObject.transform.position));
								Color color5 = Color.Lerp(Color.yellow, Color.green, num3);
								string arg3 = ColorUtility.ToHtmlStringRGB(color5);
								text += string.Format("<color=white>[</color><color=#{0}>{1}</color><color=white>]</color>", arg3, Visual.GetDistance(espobj.GObject.transform.position));
								text2 += string.Format("[{0}]", Visual.GetDistance(espobj.GObject.transform.position));
							}
						}
						switch (espobj.Target)
						{
						case Visual.ESPObject.Player:
						{
							Player player = ((SteamPlayer)espobj.Object).player;
							Visual.Priority priority = Visual.GetPriority(((SteamPlayer)espobj.Object).playerID.steamID.m_SteamID);
							Visual.Priority priority2 = priority;
							if (priority2 == Visual.Priority.Friendly)
							{
								color2 = C.GetColor("Friendly_Player_ESP");
							}
							if (PlayersTab.IsFriendly(player))
							{
								color2 = C.GetColor("Friendly_Player_ESP");
							}
							if (espobj.Options.Name)
							{
								text += ((SteamPlayer)espobj.Object).playerID.characterName;
								text2 += ((SteamPlayer)espobj.Object).playerID.characterName;
							}
							if (G.Settings.GlobalOptions.Weapon)
							{
								string str = (player.equipment.asset == null) ? "None" : ((SteamPlayer)espobj.Object).player.equipment.asset.itemName;
								text = text + "<color=white>\n" + str + "</color>";
								text2 = text2 + "\n" + str;
							}
							if (G.Settings.GlobalOptions.Skeleton)
							{
								Visual.DrawSkeleton(espobj.GObject.transform, Color.yellow);
							}
							if (G.Settings.GlobalOptions.ShowLookDirection && espobj.Options.Enabled && !SpyUtilities.BeingSpied)
							{
								Visual.DrawLookDirection(player, color2);
							}
							break;
						}
						case Visual.ESPObject.Zombie:
							if (espobj.Options.Name)
							{
								text += "Zombie";
								text2 += "Zombie";
							}
							if (espobj.Options.Name && ((Zombie)espobj.Object).isBoss)
							{
								text += "Mega Zombie";
								text2 += "Mega Zombie";
							}
							break;
						case Visual.ESPObject.Item:
							if (espobj.Options.Name)
							{
								text += ((InteractableItem)espobj.Object).asset.itemName;
								text2 += ((InteractableItem)espobj.Object).asset.itemName;
							}
							break;
						case Visual.ESPObject.Sentry:
						case Visual.ESPObject.Flag:
							goto IL_916;
						case Visual.ESPObject.Bed:
							if (espobj.Options.Name)
							{
								text += Enum.GetName(typeof(Visual.ESPObject), espobj.Target);
								text2 += Enum.GetName(typeof(Visual.ESPObject), espobj.Target);
							}
							if (G.Settings.GlobalOptions.Claimed)
							{
								if (!((InteractableBed)espobj.Object).isClaimed)
								{
									text += "<color=white>\n</color><color=ff5a00>Unclaimed</color>";
									text2 += "\nUnclaimed";
								}
								else
								{
									text += "<color=white>\nClaimed</color>";
									text2 += "\nClaimed";
								}
							}
							if (G.Settings.GlobalOptions.BedOwner)
							{
								using (List<SteamPlayer>.Enumerator enumerator = Provider.clients.GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										SteamPlayer steamPlayer = enumerator.Current;
										if (((InteractableBed)espobj.Object).owner == steamPlayer.playerID.steamID)
										{
											text = text + "<color=white>\n" + steamPlayer.playerID.characterName + "</color>";
											text2 = text2 + "\n" + steamPlayer.playerID.characterName;
										}
									}
									break;
								}
								goto IL_916;
							}
							break;
						case Visual.ESPObject.Vehicle:
							if (espobj.Options.Name)
							{
								text += ((InteractableVehicle)espobj.Object).asset.vehicleName;
								text2 += ((InteractableVehicle)espobj.Object).asset.vehicleName;
							}
							if (G.Settings.GlobalOptions.VehicleLocked)
							{
								if (!((InteractableVehicle)espobj.Object).isLocked)
								{
									text += "<color=white>\n</color><color=ff5a00>Unlocked</color>";
									text2 += "\nUnlocked";
								}
								else
								{
									text += "<color=white>\nLocked</color>";
									text2 += "\nLocked";
								}
							}
							break;
						case Visual.ESPObject.Storage:
						{
							BarricadeData barricadeData = null;
							if (espobj.Options.Name || G.Settings.GlobalOptions.ShowLocked)
							{
								try
								{
									byte b;
									byte b2;
									ushort num4;
									ushort index;
									BarricadeRegion barricadeRegion;
									if (BarricadeManager.tryGetInfo(((InteractableStorage)espobj.Object).transform, ref b, ref b2, ref num4, ref index, ref barricadeRegion))
									{
										barricadeData = barricadeRegion.barricades[(int)index];
									}
									goto IL_F02;
								}
								catch
								{
									goto IL_F02;
								}
								goto IL_A93;
							}
							goto IL_F02;
							IL_ADC:
							if (G.Settings.GlobalOptions.ShowLocked)
							{
								if (barricadeData != null)
								{
									if (barricadeData.barricade.asset.isLocked)
									{
										text += "<color=white>\nLocked</color>";
										text2 += "\nLocked";
									}
									else
									{
										text += "<color=white>\n</color><color=ff5a00>Unlocked</color>";
										text2 += "\nUnlocked";
									}
								}
								else
								{
									text += "<color=white>\nUnknown</color>";
									text2 += "\nUnknown";
								}
							}
							if (G.Settings.GlobalOptions.StorageOwner)
							{
								foreach (SteamPlayer steamPlayer2 in Provider.clients)
								{
									if (barricadeData.owner == steamPlayer2.playerID.steamID.m_SteamID)
									{
										text = text + "<color=white>\n" + steamPlayer2.playerID.characterName + "</color>";
										text2 = text2 + "\n" + steamPlayer2.playerID.characterName;
									}
								}
								break;
							}
							break;
							IL_F02:
							if (!espobj.Options.Name)
							{
								goto IL_ADC;
							}
							IL_A93:
							string str2 = "Storage";
							if (barricadeData != null)
							{
								str2 = barricadeData.barricade.asset.name.Replace("_", " ");
							}
							text += str2;
							text2 += str2;
							goto IL_ADC;
						}
						default:
							goto IL_916;
						}
						IL_C05:
						text += "</size>";
						text2 += "</size>";
						if (!string.IsNullOrEmpty(text))
						{
							Visual.DrawESPLabel(espobj.GObject.transform.position, color2, Color.black, text, text2);
						}
						switch (espobj.Options.BoxType)
						{
						case Visual.BoxType.None:
							goto IL_EF7;
						case Visual.BoxType.Corners:
						{
							if (espobj.Target != Visual.ESPObject.Player)
							{
								Vector2[] rectangleLines = Visual.GetRectangleLines(Camera.main, espobj.GObject.GetComponent<Collider>().bounds);
								Visual.PrepareRectangleCorners(rectangleLines, color, Visual.GetDistance(espobj.GObject.transform.position));
								goto IL_EF7;
							}
							Vector3 position = espobj.GObject.transform.position;
							Vector3 localScale = espobj.GObject.transform.localScale;
							Vector2[] rectangleLines2 = Visual.GetRectangleLines(Camera.main, new Bounds(espobj.GObject.transform.position + new Vector3(0f, 1.1f, 0f), espobj.GObject.transform.localScale + new Vector3(0f, 0.95f, 0f)));
							Visual.PrepareRectangleCorners(rectangleLines2, color, Visual.GetDistance(espobj.GObject.transform.position));
							goto IL_EF7;
						}
						case Visual.BoxType.Box2D:
						{
							if (espobj.Target != Visual.ESPObject.Player)
							{
								Vector2[] rectangleLines3 = Visual.GetRectangleLines(Camera.main, espobj.GObject.GetComponent<Collider>().bounds);
								Visual.PrepareRectangleLines(rectangleLines3, color);
								goto IL_EF7;
							}
							Vector3 position2 = espobj.GObject.transform.position;
							Vector3 localScale2 = espobj.GObject.transform.localScale;
							Vector2[] rectangleLines4 = Visual.GetRectangleLines(Camera.main, new Bounds(espobj.GObject.transform.position + new Vector3(0f, 1.1f, 0f), espobj.GObject.transform.localScale + new Vector3(0f, 0.95f, 0f)));
							Visual.PrepareRectangleLines(rectangleLines4, color);
							goto IL_EF7;
						}
						case Visual.BoxType.Box3D:
							if (espobj.Target == Visual.ESPObject.Player)
							{
								Vector3 position3 = espobj.GObject.transform.position;
								Vector3 localScale3 = espobj.GObject.transform.localScale;
								Visual.smethod_0(new Bounds(position3 + new Vector3(0f, 1.1f, 0f), localScale3 + new Vector3(0f, 0.95f, 0f)), color);
								goto IL_EF7;
							}
							Visual.smethod_0(espobj.GObject.GetComponent<Collider>().bounds, color);
							goto IL_EF7;
						default:
							goto IL_EF7;
						}
						IL_916:
						if (espobj.Options.Name)
						{
							text += Enum.GetName(typeof(Visual.ESPObject), espobj.Target);
							text2 += Enum.GetName(typeof(Visual.ESPObject), espobj.Target);
							goto IL_C05;
						}
						goto IL_C05;
					}
					IL_EF7:;
				}
				GL.PushMatrix();
				GL.Begin(1);
				int j = 0;
				IL_FED:
				while (j < Visual.DrawBuffer2.Count)
				{
					Visual.ESPBox2 espbox = Visual.DrawBuffer2.Dequeue();
					GL.Color(espbox.Color);
					Vector2[] vertices = espbox.Vertices;
					bool flag = true;
					for (int k = 0; k < vertices.Length; k++)
					{
						if (k < vertices.Length - 1)
						{
							Vector2 vector = vertices[k];
							Vector2 vector2 = vertices[k + 1];
							if (Vector2.Distance(vector2, vector) > (float)(Screen.width / 2))
							{
								flag = false;
								IL_FA2:
								if (flag)
								{
									for (int l = 0; l < vertices.Length; l++)
									{
										GL.Vertex3(vertices[l].x, vertices[l].y, 0f);
									}
								}
								j++;
								goto IL_FED;
							}
						}
					}
					goto IL_FA2;
				}
				GL.End();
				GL.PopMatrix();
				Player player2 = Player.player;
				Highlighter highlighter;
				if (player2 != null)
				{
					GameObject gameObject = player2.gameObject;
					highlighter = ((gameObject != null) ? gameObject.GetComponent<Highlighter>() : null);
				}
				else
				{
					highlighter = null;
				}
				Highlighter highlighter2 = highlighter;
				if (highlighter2 != null)
				{
					highlighter2.ConstantOffImmediate();
				}
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00007148 File Offset: 0x00005348
		public static bool IsItemWhitelisted(InteractableItem item, OtherOptions itemWhitelistObject)
		{
			return !itemWhitelistObject.filterItems || (itemWhitelistObject.allowGun && item.asset is ItemGunAsset) || (itemWhitelistObject.allowBackpack && item.asset is ItemBackpackAsset) || (itemWhitelistObject.allowAmmo && (item.asset is ItemMagazineAsset || item.asset is ItemCaliberAsset)) || (itemWhitelistObject.allowAttachments && (item.asset is ItemBarrelAsset || item.asset is ItemOpticAsset)) || (itemWhitelistObject.allowClothing && item.asset is ItemClothingAsset) || (itemWhitelistObject.allowFuel && item.asset is ItemFuelAsset) || (itemWhitelistObject.allowMedical && item.asset is ItemMedicalAsset) || (itemWhitelistObject.allowMelee && item.asset is ItemMeleeAsset) || (itemWhitelistObject.allowThrowable && item.asset is ItemThrowableAsset) || (itemWhitelistObject.allowFoodWater && (item.asset is ItemFoodAsset || item.asset is ItemWaterAsset)) || (itemWhitelistObject.allowExtra && (!(item.asset is ItemGunAsset) && !(item.asset is ItemBackpackAsset) && !(item.asset is ItemMagazineAsset) && !(item.asset is ItemCaliberAsset) && !(item.asset is ItemBarrelAsset) && !(item.asset is ItemOpticAsset) && !(item.asset is ItemClothingAsset) && !(item.asset is ItemFuelAsset) && !(item.asset is ItemMedicalAsset) && !(item.asset is ItemMeleeAsset) && !(item.asset is ItemThrowableAsset) && !(item.asset is ItemFoodAsset) && !(item.asset is ItemWaterAsset)));
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000073C8 File Offset: 0x000055C8
		public static Vector2[] GetRectangleLines(Camera cam, Bounds b)
		{
			Vector3[] array = new Vector3[]
			{
				cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z)),
				cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z)),
				cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z)),
				cam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z)),
				cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z)),
				cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z)),
				cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z)),
				cam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z))
			};
			for (int i = 0; i < array.Length; i++)
			{
				array[i].y = (float)Screen.height - array[i].y;
			}
			Vector3 vector = array[0];
			Vector3 vector2 = array[0];
			for (int j = 1; j < array.Length; j++)
			{
				vector = Vector3.Min(vector, array[j]);
				vector2 = Vector3.Max(vector2, array[j]);
			}
			return new Vector2[]
			{
				new Vector2(vector.x, vector.y),
				new Vector2(vector2.x, vector.y),
				new Vector2(vector.x, vector2.y),
				new Vector2(vector2.x, vector2.y)
			};
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000077BC File Offset: 0x000059BC
		public static void PrepareRectangleLines(Vector2[] nvectors, Color c)
		{
			Visual.DrawBuffer2.Enqueue(new Visual.ESPBox2
			{
				Color = c,
				Vertices = new Vector2[]
				{
					nvectors[0],
					nvectors[1],
					nvectors[1],
					nvectors[3],
					nvectors[3],
					nvectors[2],
					nvectors[2],
					nvectors[0]
				}
			});
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00007864 File Offset: 0x00005A64
		public static void PrepareRectangleCorners(Vector2[] nvectors, Color c, float distance)
		{
			float num = 15f;
			float num2 = num / (distance * 0.1f);
			Visual.DrawBuffer2.Enqueue(new Visual.ESPBox2
			{
				Color = c,
				Vertices = new Vector2[]
				{
					nvectors[0],
					new Vector2(nvectors[0].x + num2, nvectors[0].y),
					nvectors[0],
					new Vector2(nvectors[0].x, nvectors[0].y + num2),
					nvectors[1],
					new Vector2(nvectors[1].x - num2, nvectors[1].y),
					nvectors[1],
					new Vector2(nvectors[1].x, nvectors[1].y + num2),
					nvectors[3],
					new Vector2(nvectors[3].x - num2, nvectors[3].y),
					nvectors[3],
					new Vector2(nvectors[3].x, nvectors[3].y - num2),
					nvectors[2],
					new Vector2(nvectors[2].x + num2, nvectors[2].y),
					nvectors[2],
					new Vector2(nvectors[2].x, nvectors[2].y - num2)
				}
			});
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00007A5C File Offset: 0x00005C5C
		public static void DrawColorCorners(Rect rect, Color c)
		{
			GUI.skin = Asset.Skin;
			Color backgroundColor = GUI.backgroundColor;
			GUI.backgroundColor = c;
			float num = 15f;
			GUI.Button(new Rect(rect.x, rect.y, num, 1f), " ", Visual.textumonoyle);
			GUI.Button(new Rect(rect.x, rect.y, 1f, num), " ", Visual.textumonoyle);
			GUI.Button(new Rect(rect.xMax - num, rect.y, num, 1f), " ", Visual.textumonoyle);
			GUI.Button(new Rect(rect.xMax, rect.y, 1f, num), " ", Visual.textumonoyle);
			GUI.Button(new Rect(rect.xMax - num, rect.yMax, num, 1f), " ", Visual.textumonoyle);
			GUI.Button(new Rect(rect.xMax, rect.yMax - num, 1f, num), " ", Visual.textumonoyle);
			GUI.Button(new Rect(rect.x, rect.yMax, num, 1f), " ", Visual.textumonoyle);
			GUI.Button(new Rect(rect.x, rect.yMax - num, 1f, num), " ", Visual.textumonoyle);
			GUI.backgroundColor = backgroundColor;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00007BF4 File Offset: 0x00005DF4
		public static void DrawColorBox(Color color, Rect Pos, int thinkness = 1)
		{
			GUI.skin = Asset.Skin;
			Color backgroundColor = GUI.backgroundColor;
			GUI.backgroundColor = color;
			GUI.Button(new Rect(Pos.x, Pos.y, Pos.width, (float)thinkness), " ", Visual.textumonoyle);
			GUI.Button(new Rect(Pos.x + Pos.width, Pos.y, (float)thinkness, Pos.height), " ", Visual.textumonoyle);
			GUI.Button(new Rect(Pos.x, Pos.y, (float)thinkness, Pos.height), " ", Visual.textumonoyle);
			GUI.Button(new Rect(Pos.x, Pos.y + Pos.height, Pos.width, (float)thinkness), " ", Visual.textumonoyle);
			GUI.backgroundColor = backgroundColor;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00007CE4 File Offset: 0x00005EE4
		public static bool InScreenView(Vector3 scrnpt)
		{
			return scrnpt.z > 0f && scrnpt.x > 0f && scrnpt.x < 1f && scrnpt.y > 0f && scrnpt.y < 1f;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00007D44 File Offset: 0x00005F44
		public static float GetDistance(Vector3 endpos)
		{
			return (float)Math.Round((double)Vector3.Distance(Player.player.look.aim.position, endpos));
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00007D78 File Offset: 0x00005F78
		public static void DrawESPLabel2(Vector3 worldpos, Color textcolor, Color outlinecolor, string text, Texture texture, string outlinetext = null)
		{
			GUIContent guicontent = new GUIContent(text);
			if (outlinetext == null)
			{
				outlinetext = text;
			}
			GUIContent guicontent2 = new GUIContent(outlinetext);
			GUIStyle label = GUI.skin.label;
			label.alignment = 4;
			Vector2 vector = label.CalcSize(guicontent);
			Vector3 vector2 = Camera.main.WorldToScreenPoint(worldpos);
			vector2.y = (float)Screen.height - vector2.y;
			if (vector2.z >= 0f)
			{
				GUI.color = Color.black;
				GUI.Label(new Rect(vector2.x - vector.x / 2f - 1f, vector2.y - 1f, vector.x, vector.y), guicontent2);
				GUI.Label(new Rect(vector2.x - vector.x / 2f + 1f, vector2.y + 1f, vector.x, vector.y), guicontent2);
				GUI.Label(new Rect(vector2.x - vector.x / 2f - 1f, vector2.y - 1f, vector.x, vector.y), guicontent2);
				GUI.Label(new Rect(vector2.x - vector.x / 2f + 1f, vector2.y - 1f, vector.x, vector.y), guicontent2);
				GUI.Label(new Rect(vector2.x - vector.x / 2f - 1f, vector2.y + 1f, vector.x, vector.y), guicontent2);
				GUI.color = textcolor;
				GUI.Label(new Rect(vector2.x - vector.x / 2f, vector2.y, vector.x, vector.y), guicontent);
				GUI.color = Color.white;
				GUI.DrawTexture(new Rect(vector2.x - vector.x / 2f - 20f - 5f, vector2.y - 2f, 20f, 20f), texture);
				GUI.color = Main.GUIColor;
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00007FE0 File Offset: 0x000061E0
		public static void DrawESPLabel(Vector3 worldpos, Color textcolor, Color outlinecolor, string text, string outlinetext = null)
		{
			GUIContent guicontent = new GUIContent(text);
			if (outlinetext == null)
			{
				outlinetext = text;
			}
			GUIContent guicontent2 = new GUIContent(outlinetext);
			GUIStyle label = GUI.skin.label;
			label.alignment = 4;
			Vector2 vector = label.CalcSize(guicontent);
			Vector3 vector2 = Camera.main.WorldToScreenPoint(worldpos);
			vector2.y = (float)Screen.height - vector2.y;
			if (vector2.z >= 0f)
			{
				GUI.color = Color.black;
				GUI.Label(new Rect(vector2.x - vector.x / 2f - 1f, vector2.y - 1f, vector.x, vector.y), guicontent2);
				GUI.Label(new Rect(vector2.x - vector.x / 2f + 1f, vector2.y + 1f, vector.x, vector.y), guicontent2);
				GUI.Label(new Rect(vector2.x - vector.x / 2f - 1f, vector2.y - 1f, vector.x, vector.y), guicontent2);
				GUI.Label(new Rect(vector2.x - vector.x / 2f + 1f, vector2.y - 1f, vector.x, vector.y), guicontent2);
				GUI.Label(new Rect(vector2.x - vector.x / 2f - 1f, vector2.y + 1f, vector.x, vector.y), guicontent2);
				GUI.color = textcolor;
				GUI.Label(new Rect(vector2.x - vector.x / 2f, vector2.y, vector.x, vector.y), guicontent);
				GUI.color = Color.white;
				GUI.color = Main.GUIColor;
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00008204 File Offset: 0x00006404
		public static Vector3 GetLimbPosition(Transform target, string objName)
		{
			Transform[] componentsInChildren = target.transform.GetComponentsInChildren<Transform>();
			Vector3 vector = Vector3.zero;
			Vector3 result;
			if (componentsInChildren == null)
			{
				result = vector;
			}
			else
			{
				foreach (Transform transform in componentsInChildren)
				{
					if (!(transform.name.Trim() != objName))
					{
						vector = transform.position + new Vector3(0f, 0.4f, 0f);
						break;
					}
				}
				result = vector;
			}
			return result;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00008290 File Offset: 0x00006490
		public static void DrawSkeleton(Transform transform, Color color)
		{
			Vector3 vector = Camera.main.WorldToScreenPoint(Visual.GetLimbPosition(transform, "Skull") - new Vector3(0f, 0.4f, 0f));
			vector.y = (float)Screen.height - vector.y;
			Vector3 vector2 = Camera.main.WorldToScreenPoint(Visual.GetLimbPosition(transform, "Spine") - new Vector3(0f, 0.4f, 0f));
			vector2.y = (float)Screen.height - vector2.y;
			Vector3 vector3 = Camera.main.WorldToScreenPoint(Visual.GetLimbPosition(transform, "Right_Shoulder") - new Vector3(0f, 0.4f, 0f));
			vector3.y = (float)Screen.height - vector3.y;
			Vector3 vector4 = Camera.main.WorldToScreenPoint(Visual.GetLimbPosition(transform, "Left_Shoulder") - new Vector3(0f, 0.4f, 0f));
			vector4.y = (float)Screen.height - vector4.y;
			Vector3 vector5 = Camera.main.WorldToScreenPoint(Visual.GetLimbPosition(transform, "Right_Arm") - new Vector3(0f, 0.4f, 0f));
			vector5.y = (float)Screen.height - vector5.y;
			Vector3 vector6 = Camera.main.WorldToScreenPoint(Visual.GetLimbPosition(transform, "Left_Arm") - new Vector3(0f, 0.4f, 0f));
			vector6.y = (float)Screen.height - vector6.y;
			Vector3 vector7 = Camera.main.WorldToScreenPoint(Visual.GetLimbPosition(transform, "Right_Hand") - new Vector3(0f, 0.4f, 0f));
			vector7.y = (float)Screen.height - vector7.y;
			Vector3 vector8 = Camera.main.WorldToScreenPoint(Visual.GetLimbPosition(transform, "Left_Hand") - new Vector3(0f, 0.4f, 0f));
			vector8.y = (float)Screen.height - vector8.y;
			Vector3 vector9 = Camera.main.WorldToScreenPoint(Visual.GetLimbPosition(transform, "Left_Hip") - new Vector3(0f, 0.4f, 0f));
			vector9.y = (float)Screen.height - vector9.y;
			Vector3 vector10 = Camera.main.WorldToScreenPoint(Visual.GetLimbPosition(transform, "Right_Hip") - new Vector3(0f, 0.4f, 0f));
			vector10.y = (float)Screen.height - vector10.y;
			Vector3 vector11 = Camera.main.WorldToScreenPoint(Visual.GetLimbPosition(transform, "Left_Foot") - new Vector3(0f, 0.4f, 0f));
			vector11.y = (float)Screen.height - vector11.y;
			Vector3 vector12 = Camera.main.WorldToScreenPoint(Visual.GetLimbPosition(transform, "Right_Foot") - new Vector3(0f, 0.4f, 0f));
			vector12.y = (float)Screen.height - vector12.y;
			Vector3 vector13 = Camera.main.WorldToScreenPoint(Visual.GetLimbPosition(transform, "Left_Leg") - new Vector3(0f, 0.4f, 0f));
			vector13.y = (float)Screen.height - vector13.y;
			Vector3 vector14 = Camera.main.WorldToScreenPoint(Visual.GetLimbPosition(transform, "Right_Leg") - new Vector3(0f, 0.4f, 0f));
			vector14.y = (float)Screen.height - vector14.y;
			GL.PushMatrix();
			GL.Begin(1);
			Managed.DrawMaterial.SetPass(0);
			GL.Color(color);
			GL.Vertex3(vector.x, vector.y, 0f);
			GL.Vertex3(vector2.x, vector2.y, 0f);
			GL.Vertex3(vector2.x, vector2.y, 0f);
			GL.Vertex3(vector4.x, vector4.y, 0f);
			GL.Vertex3(vector4.x, vector4.y, 0f);
			GL.Vertex3(vector6.x, vector6.y, 0f);
			GL.Vertex3(vector6.x, vector6.y, 0f);
			GL.Vertex3(vector8.x, vector8.y, 0f);
			GL.Vertex3(vector2.x, vector2.y, 0f);
			GL.Vertex3(vector3.x, vector3.y, 0f);
			GL.Vertex3(vector3.x, vector3.y, 0f);
			GL.Vertex3(vector5.x, vector5.y, 0f);
			GL.Vertex3(vector5.x, vector5.y, 0f);
			GL.Vertex3(vector7.x, vector7.y, 0f);
			GL.Vertex3(vector2.x, vector2.y, 0f);
			GL.Vertex3(vector9.x, vector9.y, 0f);
			GL.Vertex3(vector9.x, vector9.y, 0f);
			GL.Vertex3(vector13.x, vector13.y, 0f);
			GL.Vertex3(vector13.x, vector13.y, 0f);
			GL.Vertex3(vector11.x, vector11.y, 0f);
			GL.Vertex3(vector2.x, vector2.y, 0f);
			GL.Vertex3(vector10.x, vector10.y, 0f);
			GL.Vertex3(vector10.x, vector10.y, 0f);
			GL.Vertex3(vector14.x, vector14.y, 0f);
			GL.Vertex3(vector14.x, vector14.y, 0f);
			GL.Vertex3(vector12.x, vector12.y, 0f);
			GL.End();
			GL.PopMatrix();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00008908 File Offset: 0x00006B08
		public static void smethod_0(Bounds b, Color color)
		{
			Vector3[] array = new Vector3[]
			{
				Camera.main.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z)),
				Camera.main.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z)),
				Camera.main.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z)),
				Camera.main.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z)),
				Camera.main.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z)),
				Camera.main.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z)),
				Camera.main.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z)),
				Camera.main.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z))
			};
			for (int i = 0; i < array.Length; i++)
			{
				array[i].y = (float)Screen.height - array[i].y;
			}
			GL.PushMatrix();
			GL.Begin(1);
			Managed.DrawMaterial.SetPass(0);
			GL.End();
			GL.PopMatrix();
			GL.PushMatrix();
			GL.Begin(1);
			Managed.DrawMaterial.SetPass(0);
			GL.Color(color);
			GL.Vertex3(array[0].x, array[0].y, 0f);
			GL.Vertex3(array[1].x, array[1].y, 0f);
			GL.Vertex3(array[1].x, array[1].y, 0f);
			GL.Vertex3(array[5].x, array[5].y, 0f);
			GL.Vertex3(array[5].x, array[5].y, 0f);
			GL.Vertex3(array[4].x, array[4].y, 0f);
			GL.Vertex3(array[4].x, array[4].y, 0f);
			GL.Vertex3(array[0].x, array[0].y, 0f);
			GL.Vertex3(array[2].x, array[2].y, 0f);
			GL.Vertex3(array[3].x, array[3].y, 0f);
			GL.Vertex3(array[3].x, array[3].y, 0f);
			GL.Vertex3(array[7].x, array[7].y, 0f);
			GL.Vertex3(array[7].x, array[7].y, 0f);
			GL.Vertex3(array[6].x, array[6].y, 0f);
			GL.Vertex3(array[6].x, array[6].y, 0f);
			GL.Vertex3(array[2].x, array[2].y, 0f);
			GL.Vertex3(array[2].x, array[2].y, 0f);
			GL.Vertex3(array[0].x, array[0].y, 0f);
			GL.Vertex3(array[3].x, array[3].y, 0f);
			GL.Vertex3(array[1].x, array[1].y, 0f);
			GL.Vertex3(array[7].x, array[7].y, 0f);
			GL.Vertex3(array[5].x, array[5].y, 0f);
			GL.Vertex3(array[6].x, array[6].y, 0f);
			GL.Vertex3(array[4].x, array[4].y, 0f);
			GL.End();
			GL.PopMatrix();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00009010 File Offset: 0x00007210
		public static Visual.Priority GetPriority(ulong id)
		{
			Visual.Priority result;
			G.Settings.Priority.TryGetValue(id, out result);
			return result;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00009038 File Offset: 0x00007238
		public static void ApplyChams(Visual.ESPObj gameObject, Color vis, Color invis)
		{
			switch (gameObject.Options.ChamType)
			{
			case Visual.ShaderType.Lightening:
				Visual.Lightening(gameObject.GObject);
				break;
			case Visual.ShaderType.WireFrame:
				Visual.WireFrame(gameObject.GObject);
				break;
			case Visual.ShaderType.Xray:
				Visual.XRay(gameObject.GObject);
				break;
			case Visual.ShaderType.Flat:
				Visual.Chams(gameObject.GObject, vis, invis);
				break;
			default:
				Visual.RemoveShaders(gameObject.GObject);
				break;
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000090B8 File Offset: 0x000072B8
		public static void Chams(GameObject pgo, Color32 VisibleColor, Color32 OccludedColor)
		{
			if (!(Asset.Shaders["Chams"] == null))
			{
				Renderer[] componentsInChildren = pgo.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					if (!(componentsInChildren[i] is ParticleSystemRenderer))
					{
						Material[] materials = componentsInChildren[i].materials;
						for (int j = 0; j < materials.Length; j++)
						{
							materials[j].shader = Asset.Shaders["Chams"];
							materials[j].SetColor("_ColorVisible", VisibleColor);
							materials[j].SetColor("_ColorBehind", OccludedColor);
						}
					}
				}
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000917C File Offset: 0x0000737C
		public static void WireFrame(GameObject pgo)
		{
			if (!(Asset.Shaders["WireFrame"] == null))
			{
				Renderer[] componentsInChildren = pgo.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					if (!(componentsInChildren[i] is ParticleSystemRenderer))
					{
						Material[] materials = componentsInChildren[i].materials;
						for (int j = 0; j < materials.Length; j++)
						{
							materials[j].shader = Asset.Shaders["WireFrame"];
							materials[j].SetFloat("_WireThickness", 100f);
							materials[j].SetVector("_WireColor", new Vector4(0f, 1f, 0f, 1f));
							materials[j].SetVector("_BaseColor", new Vector4(0f, 0f, 0f, 0f));
						}
					}
				}
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00009284 File Offset: 0x00007484
		public static void Lightening(GameObject pgo)
		{
			if (!(Asset.Shaders["Lightening"] == null))
			{
				Renderer[] componentsInChildren = pgo.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					if (!(componentsInChildren[i] is ParticleSystemRenderer))
					{
						Material[] materials = componentsInChildren[i].materials;
						for (int j = 0; j < materials.Length; j++)
						{
							materials[j].shader = Asset.Shaders["Lightening"];
							materials[j].SetTexture("_LightningTex", Asset.Lightening2);
							Asset.Lightening2.wrapMode = 0;
						}
					}
				}
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00009338 File Offset: 0x00007538
		public static void XRay(GameObject pgo)
		{
			if (!(Asset.Shaders["XRay"] == null))
			{
				Renderer[] componentsInChildren = pgo.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					if (!(componentsInChildren[i] is ParticleSystemRenderer))
					{
						Material[] materials = componentsInChildren[i].materials;
						for (int j = 0; j < materials.Length; j++)
						{
							materials[j].shader = Asset.Shaders["XRay"];
						}
					}
				}
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000093C4 File Offset: 0x000075C4
		public static void RemoveShaders(GameObject pgo)
		{
			if (!(Shader.Find("Standard/Clothes") == null))
			{
				Renderer[] componentsInChildren = pgo.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					if (componentsInChildren[i].material.shader != Shader.Find("Standard/Clothes"))
					{
						Material[] materials = componentsInChildren[i].materials;
						for (int j = 0; j < materials.Length; j++)
						{
							if (materials[j].shader != Shader.Find("Standard/Clothes"))
							{
								if (materials[j].name.Contains("Clothes"))
								{
									materials[j].shader = Shader.Find("Standard/Clothes");
								}
								else
								{
									materials[j].shader = Shader.Find("Standard");
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000023F0 File Offset: 0x000005F0
		public static IEnumerator ESPUp()
		{
			return new Visual.<ESPUp>d__30(0);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000094B4 File Offset: 0x000076B4
		public static void DrawLookDirection(Player player, Color32 _)
		{
			if (!(player == null) && !(player.look == null))
			{
				Vector3 vector = player.transform.position + Vector3.up * 1.8f;
				Vector3 forward = player.look.aim.forward;
				Vector3 vector2 = vector + forward * Visual.lookDirectionLength;
				Vector3 vector3 = Camera.main.WorldToScreenPoint(vector);
				Vector3 vector4 = Camera.main.WorldToScreenPoint(vector2);
				if (vector3.z >= 0f && vector4.z >= 0f)
				{
					Color32 color = C.GetColor("LookDirection_Arrow");
					Color color_;
					color_..ctor((float)color.r / 255f, (float)color.g / 255f, (float)color.b / 255f, 0.8f);
					Visual.smethod_1(new Vector2(vector3.x, (float)Screen.height - vector3.y), new Vector2(vector4.x, (float)Screen.height - vector4.y), color_, 2f);
					Vector2 normalized = (new Vector2(vector4.x, (float)Screen.height - vector4.y) - new Vector2(vector3.x, (float)Screen.height - vector3.y)).normalized;
					Vector2 vector5;
					vector5..ctor(vector4.x, (float)Screen.height - vector4.y);
					Vector2 vector2_ = vector5 - normalized * 8f + new Vector2(-normalized.y, normalized.x) * 4f;
					Vector2 vector2_2 = vector5 - normalized * 8f + new Vector2(normalized.y, -normalized.x) * 4f;
					Visual.smethod_1(vector5, vector2_, color_, 2f);
					Visual.smethod_1(vector5, vector2_2, color_, 2f);
				}
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000096DC File Offset: 0x000078DC
		private static void smethod_1(Vector2 vector2_0, Vector2 vector2_1, Color color_0, float float_0)
		{
			Vector2 normalized = (vector2_1 - vector2_0).normalized;
			float num = Vector2.Distance(vector2_0, vector2_1);
			int num2 = 0;
			while ((float)num2 < num)
			{
				Vector2 vector = vector2_0 + normalized * (float)num2;
				GUI.color = color_0;
				GUI.DrawTexture(new Rect(vector.x - float_0 / 2f, vector.y - float_0 / 2f, float_0, float_0), Texture2D.whiteTexture);
				num2 += 2;
			}
			GUI.color = Color.white;
		}

		// Token: 0x04000073 RID: 115
		public static Queue<Visual.ESPBox2> DrawBuffer2 = new Queue<Visual.ESPBox2>();

		// Token: 0x04000074 RID: 116
		public static SteamPlayer[] ConnectedPlayers;

		// Token: 0x04000075 RID: 117
		public static readonly GUIStyle textumonoyle = new GUIStyle
		{
			normal = new GUIStyleState
			{
				background = Texture2D.whiteTexture
			}
		};

		// Token: 0x04000076 RID: 118
		public static List<Visual.ESPObj> EObjects = new List<Visual.ESPObj>();

		// Token: 0x04000077 RID: 119
		public static float lookDirectionLength = 3f;

		// Token: 0x02000021 RID: 33
		public enum BoxType
		{
			// Token: 0x04000079 RID: 121
			None,
			// Token: 0x0400007A RID: 122
			Corners,
			// Token: 0x0400007B RID: 123
			Box2D,
			// Token: 0x0400007C RID: 124
			Box3D
		}

		// Token: 0x02000022 RID: 34
		public class ESPBox2
		{
			// Token: 0x0400007D RID: 125
			public Color Color;

			// Token: 0x0400007E RID: 126
			public Vector2[] Vertices;
		}

		// Token: 0x02000023 RID: 35
		public class ESPObj
		{
			// Token: 0x060000A5 RID: 165 RVA: 0x000097B8 File Offset: 0x000079B8
			public ESPObj(Visual.ESPObject t, object o, GameObject go, VisualOptions opt)
			{
				this.Target = t;
				this.Object = o;
				this.GObject = go;
				this.Options = opt;
			}

			// Token: 0x0400007F RID: 127
			public Visual.ESPObject Target;

			// Token: 0x04000080 RID: 128
			public object Object;

			// Token: 0x04000081 RID: 129
			public GameObject GObject;

			// Token: 0x04000082 RID: 130
			public VisualOptions Options;
		}

		// Token: 0x02000024 RID: 36
		public enum ESPObject
		{
			// Token: 0x04000084 RID: 132
			Player,
			// Token: 0x04000085 RID: 133
			Zombie,
			// Token: 0x04000086 RID: 134
			Item,
			// Token: 0x04000087 RID: 135
			Sentry,
			// Token: 0x04000088 RID: 136
			Bed,
			// Token: 0x04000089 RID: 137
			Flag,
			// Token: 0x0400008A RID: 138
			Vehicle,
			// Token: 0x0400008B RID: 139
			Storage,
			// Token: 0x0400008C RID: 140
			Airdrop,
			// Token: 0x0400008D RID: 141
			NPC,
			// Token: 0x0400008E RID: 142
			Farm,
			// Token: 0x0400008F RID: 143
			Resources
		}

		// Token: 0x02000025 RID: 37
		public enum Priority
		{
			// Token: 0x04000091 RID: 145
			None = 1,
			// Token: 0x04000092 RID: 146
			Friendly
		}

		// Token: 0x02000026 RID: 38
		public enum ShaderType
		{
			// Token: 0x04000094 RID: 148
			Lightening,
			// Token: 0x04000095 RID: 149
			WireFrame,
			// Token: 0x04000096 RID: 150
			Xray,
			// Token: 0x04000097 RID: 151
			Flat,
			// Token: 0x04000098 RID: 152
			None
		}
	}
}
