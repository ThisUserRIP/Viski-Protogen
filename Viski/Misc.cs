using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200003B RID: 59
	[Component]
	public class Misc : MonoBehaviour
	{
		// Token: 0x0600017A RID: 378 RVA: 0x0000B568 File Offset: 0x00009768
		public void Start()
		{
			Misc.ThirdAttachmentsField = typeof(UseableGun).GetField("thirdAttachments", BindingFlags.Instance | BindingFlags.NonPublic);
			Misc.rend = base.GetComponent<Renderer>();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000B59C File Offset: 0x0000979C
		public void Update()
		{
			Misc.float_0 += (Time.unscaledDeltaTime - Misc.float_0) * 0.1f;
			Misc.float_3 += Time.deltaTime;
			if (Misc.float_3 >= 0.5f)
			{
				Misc.float_1 = 1f / Misc.float_0;
				Misc.float_2 = Provider.ping;
				Misc.float_3 = 0f;
			}
			if (G.Settings.SilentOptions.RGBFov)
			{
				Misc.float_4 += Time.deltaTime * G.Settings.SilentOptions.float_0 * 0.05f;
				if (Misc.float_4 > 1f)
				{
					Misc.float_4 -= 1f;
				}
				Misc.color_0 = Color.HSVToRGB(Misc.float_4, 1f, 1f);
			}
			if (VectorUtilities.ShouldRun())
			{
				if (SpyUtilities.BeingSpied)
				{
					Misc.GetPrivateVar<CharacterAnimator>(typeof(PlayerAnimator), "thirdAnimator", Player.player.animator).transform.localEulerAngles = new Vector3(90f, 0f, 0f);
				}
				else if (G.Settings.MiscOptions.Spinbot && G.Settings.MiscOptions.LocalSpinbot)
				{
					Misc.GetPrivateVar<CharacterAnimator>(typeof(PlayerAnimator), "thirdAnimator", Player.player.animator).transform.localEulerAngles = new Vector3(90f, (float)Random.Range(50, 256), 0f);
				}
				else if (!G.Settings.MiscOptions.Spinbot || !G.Settings.MiscOptions.LocalSpinbot)
				{
					Misc.GetPrivateVar<CharacterAnimator>(typeof(PlayerAnimator), "thirdAnimator", Player.player.animator).transform.localEulerAngles = new Vector3(90f, 0f, 0f);
				}
				if (SpyUtilities.BeingSpied)
				{
					using (List<SteamPlayer>.Enumerator enumerator = Provider.clients.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							SteamPlayer steamPlayer = enumerator.Current;
							if (steamPlayer.player != Player.player)
							{
								steamPlayer.player.transform.localScale = new Vector3(1f, 1f, 1f);
							}
						}
						goto IL_2C0;
					}
				}
				foreach (SteamPlayer steamPlayer2 in Provider.clients)
				{
					if (steamPlayer2.player != Player.player)
					{
						steamPlayer2.player.transform.localScale = Misc.pscale;
					}
				}
				IL_2C0:
				if (Misc.SpectatedPlayer != null && !SpyUtilities.BeingSpied)
				{
					Player.player.look.IsControllingFreecam = true;
					Player.player.look.orbitPosition = Misc.SpectatedPlayer.transform.position - Player.player.transform.position;
					Player.player.look.orbitPosition += new Vector3(0f, 3f, 0f);
				}
				else
				{
					Player.player.look.IsControllingFreecam = G.Settings.MiscOptions.Freecam;
				}
				ItemGunAsset itemGunAsset;
				if ((itemGunAsset = (Player.player.equipment.asset as ItemGunAsset)) != null)
				{
					if (!Misc.AssetBackups.ContainsKey(itemGunAsset.id))
					{
						float[] value = new float[]
						{
							itemGunAsset.recoilMax_x,
							itemGunAsset.recoilMax_y,
							itemGunAsset.recoilMin_x,
							itemGunAsset.recoilMin_y,
							itemGunAsset.recoilCrouch,
							itemGunAsset.recoilProne,
							itemGunAsset.recoilSprint,
							itemGunAsset.recoilSwimming,
							itemGunAsset.recoilMidair,
							itemGunAsset.recover_x,
							itemGunAsset.recover_y,
							itemGunAsset.aimingRecoilMultiplier,
							itemGunAsset.spreadAim,
							itemGunAsset.spreadCrouch,
							itemGunAsset.spreadProne,
							itemGunAsset.spreadSprint,
							itemGunAsset.spreadSwimming,
							itemGunAsset.spreadMidair,
							itemGunAsset.shakeMax_x,
							itemGunAsset.shakeMax_y,
							itemGunAsset.shakeMax_z,
							itemGunAsset.shakeMin_x,
							itemGunAsset.shakeMin_y,
							itemGunAsset.shakeMin_z
						};
						Misc.AssetBackups.Add(itemGunAsset.id, value);
					}
					if (G.Settings.MiscOptions.NoRecoil)
					{
						itemGunAsset.recoilMax_x = G.Settings.MiscOptions.NoRecoil1;
						itemGunAsset.recoilMax_y = G.Settings.MiscOptions.NoRecoil1;
						itemGunAsset.recoilMin_x = G.Settings.MiscOptions.NoRecoil1;
						itemGunAsset.recoilMin_y = G.Settings.MiscOptions.NoRecoil1;
						itemGunAsset.recoilCrouch = G.Settings.MiscOptions.NoRecoil1;
						itemGunAsset.recoilProne = G.Settings.MiscOptions.NoRecoil1;
						itemGunAsset.recoilSprint = G.Settings.MiscOptions.NoRecoil1;
						itemGunAsset.recoilSwimming = G.Settings.MiscOptions.NoRecoil1;
						itemGunAsset.recoilMidair = G.Settings.MiscOptions.NoRecoil1;
						itemGunAsset.recover_x = G.Settings.MiscOptions.NoRecoil1;
						itemGunAsset.recover_y = G.Settings.MiscOptions.NoRecoil1;
						itemGunAsset.aimingRecoilMultiplier = G.Settings.MiscOptions.NoRecoil1;
					}
					else
					{
						itemGunAsset.recoilMax_x = Misc.AssetBackups[itemGunAsset.id][0];
						itemGunAsset.recoilMax_y = Misc.AssetBackups[itemGunAsset.id][1];
						itemGunAsset.recoilMin_x = Misc.AssetBackups[itemGunAsset.id][2];
						itemGunAsset.recoilMin_y = Misc.AssetBackups[itemGunAsset.id][3];
						itemGunAsset.recoilCrouch = Misc.AssetBackups[itemGunAsset.id][4];
						itemGunAsset.recoilProne = Misc.AssetBackups[itemGunAsset.id][5];
						itemGunAsset.recoilSprint = Misc.AssetBackups[itemGunAsset.id][6];
						itemGunAsset.recoilSwimming = Misc.AssetBackups[itemGunAsset.id][7];
						itemGunAsset.recoilMidair = Misc.AssetBackups[itemGunAsset.id][8];
						itemGunAsset.recover_x = Misc.AssetBackups[itemGunAsset.id][9];
						itemGunAsset.recover_y = Misc.AssetBackups[itemGunAsset.id][10];
						itemGunAsset.aimingRecoilMultiplier = Misc.AssetBackups[itemGunAsset.id][11];
					}
					if (!G.Settings.MiscOptions.NoSpread)
					{
						itemGunAsset.spreadAim = Misc.AssetBackups[itemGunAsset.id][12];
						itemGunAsset.spreadCrouch = Misc.AssetBackups[itemGunAsset.id][13];
						itemGunAsset.spreadProne = Misc.AssetBackups[itemGunAsset.id][14];
						itemGunAsset.spreadSprint = Misc.AssetBackups[itemGunAsset.id][15];
						itemGunAsset.spreadSwimming = Misc.AssetBackups[itemGunAsset.id][16];
						itemGunAsset.spreadMidair = Misc.AssetBackups[itemGunAsset.id][17];
						itemGunAsset.shakeMax_x = Misc.AssetBackups[itemGunAsset.id][18];
						itemGunAsset.shakeMax_y = Misc.AssetBackups[itemGunAsset.id][19];
						itemGunAsset.shakeMax_z = Misc.AssetBackups[itemGunAsset.id][20];
						itemGunAsset.shakeMin_x = Misc.AssetBackups[itemGunAsset.id][21];
						itemGunAsset.shakeMin_y = Misc.AssetBackups[itemGunAsset.id][22];
						itemGunAsset.shakeMin_z = Misc.AssetBackups[itemGunAsset.id][23];
					}
					else
					{
						itemGunAsset.spreadAim = G.Settings.MiscOptions.NoSpread1;
						itemGunAsset.spreadCrouch = G.Settings.MiscOptions.NoSpread1;
						itemGunAsset.spreadProne = G.Settings.MiscOptions.NoSpread1;
						itemGunAsset.spreadSprint = G.Settings.MiscOptions.NoSpread1;
						itemGunAsset.spreadSwimming = G.Settings.MiscOptions.NoSpread1;
						itemGunAsset.spreadMidair = G.Settings.MiscOptions.NoSpread1;
						itemGunAsset.shakeMax_x = G.Settings.MiscOptions.NoSpread1;
						itemGunAsset.shakeMax_y = G.Settings.MiscOptions.NoSpread1;
						itemGunAsset.shakeMax_z = G.Settings.MiscOptions.NoSpread1;
						itemGunAsset.shakeMin_x = G.Settings.MiscOptions.NoSpread1;
						itemGunAsset.shakeMin_y = G.Settings.MiscOptions.NoSpread1;
						itemGunAsset.shakeMin_z = G.Settings.MiscOptions.NoSpread1;
						OptionsSettings.useStaticCrosshair = true;
						OptionsSettings.staticCrosshairSize = 0f;
					}
					if (G.Settings.MiscOptions.NoSway)
					{
						Player.player.animator.scopeSway = new Vector3(G.Settings.MiscOptions.NoSway1, G.Settings.MiscOptions.NoSway1, G.Settings.MiscOptions.NoSway1);
					}
				}
				Misc.hue += Time.deltaTime * Misc.colorChangeSpeed;
				if (Misc.hue > 1f)
				{
					Misc.hue -= 1f;
				}
				Misc.colorrrr = Color.HSVToRGB(Misc.hue, 1f, 1f);
				Misc.rend.material.color = Misc.colorrrr;
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000C00C File Offset: 0x0000A20C
		public void FixedUpdate()
		{
			if (SpyUtilities.BeingSpied)
			{
				if (G.Settings.MiscOptions.Freecam)
				{
					Misc.FreecamBeforeSpy = true;
					G.Settings.MiscOptions.Freecam = false;
				}
			}
			else if (Misc.FreecamBeforeSpy)
			{
				Misc.FreecamBeforeSpy = false;
				G.Settings.MiscOptions.Freecam = true;
			}
			Misc.VehicleFlight();
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000C06C File Offset: 0x0000A26C
		public void OnGUI()
		{
			GUI.skin = Asset.Skin;
			if (G.Settings.MiscOptions.bool_0 && VectorUtilities.ShouldRun() && !SpyUtilities.BeingSpied)
			{
				string text = string.Format("DarkNight | {0:F0} FPS | {1:F0}ms", Misc.float_1, Misc.float_2);
				GUIStyle guistyle = new GUIStyle(GUI.skin.label);
				guistyle.fontSize = 14;
				guistyle.normal.textColor = Color.white;
				guistyle.fontStyle = 1;
				GUIStyle guistyle2 = new GUIStyle(guistyle);
				guistyle2.normal.textColor = Color.black;
				GUI.Label(new Rect(12f, 12f, 300f, 20f), text, guistyle2);
				GUI.Label(new Rect(10f, 10f, 300f, 20f), text, guistyle);
			}
			if (!SpyUtilities.BeingSpied && VectorUtilities.ShouldRun())
			{
				ItemGunAsset itemGunAsset = Player.player.equipment.asset as ItemGunAsset;
				float range;
				if (!G.Settings.SilentOptions.ExtraRange)
				{
					range = ((itemGunAsset == null) ? 15.5f : (itemGunAsset.range + 10f));
				}
				else
				{
					range = ((itemGunAsset == null) ? 15.5f : (itemGunAsset.range + (float)G.Settings.SilentOptions.ExtraRangeM));
				}
				GameObject gameObject;
				Vector3 vector;
				SilentUtilities.GetTargetObject(SilentUtilities.Objects, out gameObject, out vector, range);
				if (G.Settings.SilentOptions.Silent && gameObject != null)
				{
					Vector3 position = gameObject.gameObject.transform.position;
					Vector3 localScale = gameObject.gameObject.transform.localScale;
					Visual.smethod_0(new Bounds(position + new Vector3(0f, 0.05f, 0f), localScale + new Vector3(-0.04f, -0.04f, -0.04f)), Color.white);
					Misc.TargetInfoWin = GUILayout.Window(2, Misc.TargetInfoWin, new GUI.WindowFunction(Misc.TargetInfoWindow), "", "SelectedButtonDropdown", Array.Empty<GUILayoutOption>());
					Misc.DrawSnapline(Color.cyan);
				}
				if (G.Settings.SilentOptions.Silent && G.Settings.SilentOptions.TargetPlayers && G.Settings.SilentOptions.TargetInfo && gameObject != null)
				{
					Misc.TargetInfoWinUI = GUILayout.Window(3, Misc.TargetInfoWinUI, new GUI.WindowFunction(Misc.TargetWindowsUI), "Target Info", "Box", Array.Empty<GUILayoutOption>());
				}
				if (G.Settings.MiscOptions.LookedWarning)
				{
					Misc.LookingInfoWinUI = GUILayout.Window(7, Misc.LookingInfoWinUI, new GUI.WindowFunction(Misc.LookingWinUI), "Looking", "Box", Array.Empty<GUILayoutOption>());
				}
				if (G.Settings.MiscOptions.ShowWeaponInfo)
				{
					Misc.WeapontInfoWin = GUILayout.Window(4, Misc.WeapontInfoWin, new GUI.WindowFunction(Misc.WeaponInfoWindow), "", "SelectedButtonDropdown", Array.Empty<GUILayoutOption>());
				}
				if (G.Settings.MiscOptions.ShowAdmin)
				{
					Misc.ShowAdminWin = GUILayout.Window(5, Misc.ShowAdminWin, new GUI.WindowFunction(Misc.ShowAdminWindow), "Admins", "Box", Array.Empty<GUILayoutOption>());
				}
				if (G.Settings.SilentOptions.SilentAimUseFOV && G.Settings.SilentOptions.ShowSilentFOV && G.Settings.SilentOptions.Silent)
				{
					Color32 color = G.Settings.SilentOptions.RGBFov ? Misc.color_0 : C.GetColor("Silent_Aim_FOV_Circle");
					Misc.DrawCircle(color, new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), Misc.smethod_0(G.Settings.SilentOptions.SilentAimFOV));
				}
				if (G.Settings.AimbotOptions.AimbotShowFOV && G.Settings.AimbotOptions.AimbotUseFov && G.Settings.AimbotOptions.Aimbot)
				{
					Misc.DrawCircle(C.GetColor("Aimlock_FOV_Circle"), new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), Misc.smethod_0(G.Settings.AimbotOptions.float_0));
				}
				if (G.Settings.MiscOptions.NearbyItems)
				{
					Misc.ItemsWin = GUILayout.Window(6, Misc.ItemsWin, new GUI.WindowFunction(Misc.ItemsWindow), "Items", "Box", Array.Empty<GUILayoutOption>());
				}
				Misc.ProcessTracers();
			}
			if (SpyUtilities.BeingSpied)
			{
				using (List<Misc.Tracer>.Enumerator enumerator = Misc.tracers.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Misc.Tracer tracer = enumerator.Current;
						tracer.tracerObject.SetActive(false);
					}
					return;
				}
			}
			foreach (Misc.Tracer tracer2 in Misc.tracers)
			{
				tracer2.tracerObject.SetActive(true);
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000C5E0 File Offset: 0x0000A7E0
		public static void AddTracer(Vector3 startPoint, Vector3 endPoint)
		{
			if (G.Settings.SilentOptions.Tracers && startPoint != Vector3.zero && endPoint != Vector3.zero)
			{
				Misc.tracers.Add(new Misc.Tracer(startPoint, endPoint, 0f));
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000C634 File Offset: 0x0000A834
		public static void ProcessTracers()
		{
			Color color = Misc.colorrrr;
			float a = color.a;
			int num = -1;
			for (int i = 0; i < Misc.tracers.Count; i++)
			{
				Misc.Tracer tracer = Misc.tracers[i];
				tracer.deleteProgression += Time.deltaTime / Misc.TracerTime;
				if (tracer.deleteProgression > 1f)
				{
					num = i;
				}
				else
				{
					Misc.tracers[i].material.color = new Color(color.r, color.g, color.b, a * (1f - tracer.deleteProgression));
				}
				Misc.tracers[i] = tracer;
			}
			if (num != -1)
			{
				Object.Destroy(Misc.tracers[num].tracerObject);
				Misc.tracers.RemoveAt(num);
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000C72C File Offset: 0x0000A92C
		public static GameObject GetTracer()
		{
			if (Misc.tracerObject == null)
			{
				Misc.CreateTracer();
			}
			return Misc.tracerObject;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000C754 File Offset: 0x0000A954
		public static void CreateTracer()
		{
			try
			{
				Misc.tracerObject = new GameObject("Tracer");
				Misc.tracerObject.transform.position = new Vector3(0f, -245f, 0f);
				Misc.tracerObject.transform.rotation = Player.player.look.aim.rotation;
				Misc.tracerObject.transform.eulerAngles += new Vector3(0f, 0f, 90f);
				MeshFilter meshFilter = Misc.tracerObject.AddComponent<MeshFilter>();
				MeshRenderer meshRenderer = Misc.tracerObject.AddComponent<MeshRenderer>();
				Misc.tracerObject.layer = 16;
				Mesh mesh = new Mesh();
				meshFilter.mesh = mesh;
				Vector3[] vertices = new Vector3[]
				{
					new Vector3(-0.1f, 0f, -0.1f),
					new Vector3(-0.1f, 0f, 0.1f),
					new Vector3(0.1f, 0f, 0.1f),
					new Vector3(0.1f, 0f, -0.1f)
				};
				int[] triangles = new int[]
				{
					0,
					1,
					2,
					2,
					3,
					0
				};
				Vector2[] uv = new Vector2[]
				{
					new Vector2(0f, 0f),
					new Vector2(0f, 1f),
					new Vector2(1f, 1f),
					new Vector2(1f, 0f)
				};
				mesh.vertices = vertices;
				mesh.triangles = triangles;
				mesh.uv = uv;
				mesh.RecalculateNormals();
				meshRenderer.sharedMaterial = new Material(Managed.DrawMaterial);
				GameObject gameObject = Object.Instantiate<GameObject>(Misc.tracerObject);
				gameObject.transform.SetParent(Misc.tracerObject.transform);
				gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
				CombineInstance[] array = new CombineInstance[2];
				array[0] = default(CombineInstance);
				array[0].mesh = mesh;
				array[0].transform = meshRenderer.transform.localToWorldMatrix;
				array[1] = default(CombineInstance);
				array[1].mesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
				array[1].transform = gameObject.transform.localToWorldMatrix;
				Mesh mesh2 = new Mesh();
				mesh2.CombineMeshes(array);
				Object.Destroy(gameObject);
			}
			catch
			{
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000CA30 File Offset: 0x0000AC30
		public static void VehicleFlight()
		{
			InteractableVehicle vehicle = Player.player.movement.getVehicle();
			if (!(vehicle == null))
			{
				Rigidbody component = vehicle.GetComponent<Rigidbody>();
				if (!(component == null) && vehicle.isDriver)
				{
					if (!G.Settings.MiscOptions.VehicleFly)
					{
						if (Misc.fly)
						{
							Misc.fly = false;
							component.isKinematic = false;
						}
					}
					else
					{
						Misc.fly = true;
						component.isKinematic = true;
						float num = (!G.Settings.MiscOptions.VehicleUseMaxSpeed) ? (G.Settings.MiscOptions.VehicleSpeed / 3f) : (vehicle.asset.TargetForwardVelocity * Time.fixedDeltaTime);
						num *= 0.98f;
						Transform transform = component.transform;
						Vector3 zero = Vector3.zero;
						Vector3 vector = Vector3.zero;
						if (Input.GetKey(100))
						{
							zero.y += 2f;
						}
						if (Input.GetKey(97))
						{
							zero.y += -2f;
						}
						if (Input.GetKey(276))
						{
							zero.z += 2f;
						}
						if (Input.GetKey(275))
						{
							zero.z += -2f;
						}
						if (Input.GetKey(273))
						{
							zero.x += -1.5f;
						}
						if (Input.GetKey(274))
						{
							zero.x += 1.5f;
						}
						if (Input.GetKey(32))
						{
							vector.y += 0.6f;
						}
						if (Input.GetKey(306))
						{
							vector.y -= 0.6f;
						}
						if (Input.GetKey(113))
						{
							vector -= transform.right;
						}
						if (Input.GetKey(101))
						{
							vector += transform.right;
						}
						if (Input.GetKey(119))
						{
							vector += transform.forward;
						}
						if (Input.GetKey(115))
						{
							vector -= transform.forward;
						}
						vector = vector * num + transform.position;
						if (G.Settings.MiscOptions.VehicleRigibody)
						{
							transform.position = vector;
							transform.Rotate(zero);
						}
						else
						{
							component.MovePosition(vector);
							component.MoveRotation(transform.localRotation * Quaternion.Euler(zero));
						}
					}
				}
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000CCB8 File Offset: 0x0000AEB8
		public static T GetPrivateVar<T>(Type script, string varName, object obj)
		{
			return (T)((object)Misc.GetPrivateVar(script, varName, obj));
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000CCD4 File Offset: 0x0000AED4
		public static object GetPrivateVar(Type script, string varName, object obj)
		{
			FieldInfo field = script.GetField(varName, BindingFlags.Instance | BindingFlags.NonPublic);
			return field.GetValue(obj);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000CCF8 File Offset: 0x0000AEF8
		public static void ItemsWindow(int winid)
		{
			GUILayout.Space(0f);
			GUILayout.Label("", Array.Empty<GUILayoutOption>());
			Misc.regionsInRadius.Clear();
			Regions.getRegionsInRadius(Player.player.look.aim.position, 20f, Misc.regionsInRadius);
			Misc.itemsInRadius.Clear();
			ItemManager.getItemsInRadius(Player.player.look.aim.position, 400f, Misc.regionsInRadius, Misc.itemsInRadius);
			int num = 5;
			float num2 = 50f;
			float num3 = 50f;
			float num4 = 10f;
			int num5 = 0;
			int num6 = Mathf.CeilToInt((float)Misc.itemsInRadius.Count / 5f);
			Misc.ItemsWin.height = 40f + (float)num6 * 60f;
			Misc.ItemsWin.width = 310f;
			float num7 = 10f;
			float num8 = 40f;
			for (int i = 0; i < num6; i++)
			{
				for (int j = 0; j < num; j++)
				{
					if (num5 < Misc.itemsInRadius.Count)
					{
						InteractableItem interactableItem = Misc.itemsInRadius[num5];
						if (interactableItem != null && VectorUtilities.GetDistance(Player.player.transform.position, interactableItem.gameObject.transform.position) < 20.0)
						{
							float num9 = num7 + (float)j * (num2 + num4);
							float num10 = num8 + (float)i * (num3 + num4);
							Rect rect;
							rect..ctor(num9, num10, num2, num3);
							GUI.DrawTexture(rect, Misc.GetItemTexture(interactableItem.item.id), 2);
							if (Event.current.type == 1 && rect.Contains(Event.current.mousePosition))
							{
								interactableItem.use();
							}
						}
						num5++;
					}
				}
			}
			GUI.DragWindow();
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000CEF4 File Offset: 0x0000B0F4
		public static void LookingWinUI(int winid)
		{
			if (!SpyUtilities.BeingSpied)
			{
				GUILayout.Space(0f);
				GUILayout.Label("Looking", Array.Empty<GUILayoutOption>());
				GUILayout.Space(5f);
				foreach (SteamPlayer steamPlayer in Provider.clients)
				{
					if (!(steamPlayer.player == Player.player) && !steamPlayer.player.life.isDead)
					{
						Vector3 vector = Player.player.transform.position + new Vector3(0f, 1.8f, 0f);
						Vector3 vector2 = steamPlayer.player.transform.position + new Vector3(0f, 1.8f, 0f);
						Vector3 normalized = (vector - vector2).normalized;
						float num = Vector3.Distance(vector, vector2);
						if (num <= G.Settings.MiscOptions.LookedWarningDistance)
						{
							Vector3 forward = steamPlayer.player.look.aim.forward;
							float num2 = Vector3.Dot(forward, normalized);
							if (num2 > 0.95f)
							{
								string str = string.Format("{0:F0}m", num);
								GUILayout.Label(steamPlayer.playerID.characterName + " (" + str + ")", Array.Empty<GUILayoutOption>());
							}
						}
					}
				}
				GUI.DragWindow();
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000D0A8 File Offset: 0x0000B2A8
		public static void TargetWindowsUI(int winid)
		{
			GUILayout.Space(0f);
			GUILayout.Label("", Array.Empty<GUILayoutOption>());
			GUI.DragWindow();
			ItemGunAsset itemGunAsset = Player.player.equipment.asset as ItemGunAsset;
			float range;
			if (G.Settings.SilentOptions.ExtraRange)
			{
				range = ((itemGunAsset == null) ? 15.5f : (itemGunAsset.range + (float)G.Settings.SilentOptions.ExtraRangeM));
			}
			else
			{
				range = ((itemGunAsset != null) ? (itemGunAsset.range + 10f) : 15.5f);
			}
			GameObject gameObject;
			Vector3 vector;
			SilentUtilities.GetTargetObject(SilentUtilities.Objects, out gameObject, out vector, range);
			foreach (SteamPlayer steamPlayer in Provider.clients)
			{
				if (steamPlayer.player.gameObject == gameObject && steamPlayer.player != null)
				{
					GUI.Label(new Rect(8f, 50f, 160f, 80f), Provider.provider.communityService.getIcon(steamPlayer.player.channel.owner.playerID.steamID, false));
					if (steamPlayer.playerID.characterName.Length > 10)
					{
						GUI.Label(new Rect(50f, 49f, 120f, 60f), steamPlayer.playerID.characterName.Substring(0, 14));
					}
					if (steamPlayer.playerID.characterName.Length < 10)
					{
						GUI.Label(new Rect(50f, 49f, 120f, 60f), steamPlayer.playerID.characterName);
					}
					GUI.Label(new Rect(51f, 67f, 120f, 60f), VectorUtilities.GetDistance2(steamPlayer.player.transform.position).ToString());
					if (!string.IsNullOrEmpty(steamPlayer.player.clothing.hatAsset.id.ToString()))
					{
						GUI.Label(new Rect(5f, 90f, 50f, 40f), Misc.GetItemTexture(steamPlayer.player.clothing.hatAsset.id));
					}
					if (!string.IsNullOrEmpty(steamPlayer.player.clothing.shirtAsset.id.ToString()))
					{
						GUI.Label(new Rect(40f, 90f, 70f, 60f), Misc.GetItemTexture(steamPlayer.player.clothing.shirtAsset.id));
					}
					if (!string.IsNullOrEmpty(steamPlayer.player.clothing.vestAsset.ToString()))
					{
						GUI.Label(new Rect(103f, 90f, 63f, 50f), Misc.GetItemTexture(steamPlayer.player.clothing.vestAsset.id));
					}
					if (!string.IsNullOrEmpty(steamPlayer.player.clothing.pantsAsset.ToString()))
					{
						GUI.Label(new Rect(150f, 90f, 60f, 50f), Misc.GetItemTexture(steamPlayer.player.clothing.pantsAsset.id));
					}
					if (!string.IsNullOrEmpty(steamPlayer.player.equipment.asset.ToString()))
					{
						GUI.Label(new Rect(5f, 140f, 170f, 60f), Misc.GetItemTexture(steamPlayer.player));
					}
				}
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000D494 File Offset: 0x0000B694
		public static byte[] GetItemState(Player p)
		{
			byte[] state;
			if (p.equipment.asset is ItemGunAsset)
			{
				Attachments attachments = Misc.ThirdAttachmentsField.GetValue(p.equipment.useable) as Attachments;
				state = (p.equipment.asset as ItemGunAsset).getState(attachments.sightID, attachments.tacticalID, attachments.gripID, attachments.barrelID, attachments.magazineID, 0);
			}
			else
			{
				state = p.equipment.asset.getState(0);
			}
			return state;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000D524 File Offset: 0x0000B724
		public static Texture2D GetItemTexture(Player player)
		{
			return (player.equipment.asset == null) ? null : Misc.GetItemTexture(player.equipment.asset.id, Misc.GetItemState(player));
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00002E5C File Offset: 0x0000105C
		public static Texture2D GetItemTexture(ushort id)
		{
			return Misc.GetItemTexture(id, new byte[0]);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000D55C File Offset: 0x0000B75C
		public static Texture2D GetItemTexture(ushort id, byte[] state)
		{
			Misc.<>c__DisplayClass48_0 CS$<>8__locals1 = new Misc.<>c__DisplayClass48_0();
			CS$<>8__locals1.ushort_0 = id;
			CS$<>8__locals1.byte_0 = state;
			Texture2D result;
			if (Misc.cachedItemIcons.ContainsKey(CS$<>8__locals1.ushort_0))
			{
				if (Misc.cachedItemIcons[CS$<>8__locals1.ushort_0].Contains(CS$<>8__locals1.byte_0))
				{
					result = Misc.cachedItemIcons[CS$<>8__locals1.ushort_0].Get(CS$<>8__locals1.byte_0);
				}
				else
				{
					Misc.cachedItemIcons[CS$<>8__locals1.ushort_0].states.Add(CS$<>8__locals1.byte_0, null);
					ItemTool.getIcon(CS$<>8__locals1.ushort_0, 100, CS$<>8__locals1.byte_0, new ItemIconReady(CS$<>8__locals1.method_1));
					result = null;
				}
			}
			else
			{
				Misc.cachedItemIcons.Add(CS$<>8__locals1.ushort_0, new Misc.ItemIcon(CS$<>8__locals1.ushort_0));
				Misc.cachedItemIcons[CS$<>8__locals1.ushort_0].states.Add(CS$<>8__locals1.byte_0, null);
				ItemTool.getIcon(CS$<>8__locals1.ushort_0, 100, CS$<>8__locals1.byte_0, new ItemIconReady(CS$<>8__locals1.method_0));
				result = null;
			}
			return result;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000D694 File Offset: 0x0000B894
		public static void ShowAdminWindow(int winid)
		{
			GUILayout.Space(0f);
			GUILayout.Label("", Array.Empty<GUILayoutOption>());
			foreach (SteamPlayer steamPlayer in Provider.clients)
			{
				if (steamPlayer.player.channel.owner.isAdmin)
				{
					GUILayout.Label(steamPlayer.playerID.characterName, Array.Empty<GUILayoutOption>());
				}
			}
			GUI.DragWindow();
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000D730 File Offset: 0x0000B930
		public static void TargetInfoWindow(int winid)
		{
			ItemGunAsset itemGunAsset = Player.player.equipment.asset as ItemGunAsset;
			float range;
			if (!G.Settings.SilentOptions.ExtraRange)
			{
				range = ((itemGunAsset == null) ? 15.5f : (itemGunAsset.range + 10f));
			}
			else
			{
				range = ((itemGunAsset == null) ? 15.5f : (itemGunAsset.range + (float)G.Settings.SilentOptions.ExtraRangeM));
			}
			GameObject gameObject;
			Vector3 vector;
			SilentUtilities.GetTargetObject(SilentUtilities.Objects, out gameObject, out vector, range);
			GUILayout.Label("", Array.Empty<GUILayoutOption>());
			GUILayout.Label(string.Format("       Target: [{0}] {1}", VectorUtilities.GetDistance2(gameObject.transform.position), gameObject.name), Array.Empty<GUILayoutOption>());
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000D7F8 File Offset: 0x0000B9F8
		public static void WeaponInfoWindow(int winid)
		{
			GUILayout.Label("", Array.Empty<GUILayoutOption>());
			if (!G.Settings.SilentOptions.ExtraRange)
			{
				GUILayout.Label("<size=17>       Weapon Range: </size><size=17>" + VectorUtilities.GetGunDistance().ToString() + "</size>", Array.Empty<GUILayoutOption>());
			}
			else
			{
				GUILayout.Label("<size=17>       Weapon Range: </size><size=17>" + (VectorUtilities.GetGunDistance() + (float)G.Settings.SilentOptions.ExtraRangeM).ToString() + "</size>", Array.Empty<GUILayoutOption>());
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000D8C0 File Offset: 0x0000BAC0
		public static void DrawSnapline(Color color)
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
			GameObject gameObject;
			Vector3 vector;
			SilentUtilities.GetTargetObject(SilentUtilities.Objects, out gameObject, out vector, range);
			Vector3 vector2;
			vector2..ctor(gameObject.transform.position.x, gameObject.transform.position.y + 1.9f, gameObject.transform.position.z);
			Vector3 vector3 = Camera.main.WorldToScreenPoint(vector2);
			if (vector3.z > 0f)
			{
				vector3.y = (float)Screen.height - vector3.y;
				GL.PushMatrix();
				GL.Begin(1);
				Managed.DrawMaterial.SetPass(0);
				GL.Color(color);
				GL.Vertex3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f);
				GL.Vertex3(vector3.x, vector3.y, 0f);
				GL.End();
				GL.PopMatrix();
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000DA14 File Offset: 0x0000BC14
		public static void DrawCircle(Color Col, Vector2 Center, float Radius)
		{
			GL.PushMatrix();
			Managed.DrawMaterial.SetPass(0);
			GL.Begin(1);
			GL.Color(Col);
			for (float num = 0f; num < 6.2831855f; num += G.Settings.SilentOptions.float_1)
			{
				GL.Vertex(new Vector3(Mathf.Cos(num) * Radius + Center.x, Mathf.Sin(num) * Radius + Center.y));
				GL.Vertex(new Vector3(Mathf.Cos(num + G.Settings.SilentOptions.float_1) * Radius + Center.x, Mathf.Sin(num + G.Settings.SilentOptions.float_1) * Radius + Center.y));
			}
			GL.End();
			GL.PopMatrix();
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000DAEC File Offset: 0x0000BCEC
		public static float smethod_0(float fov)
		{
			float fieldOfView = Camera.main.fieldOfView;
			return (float)(Math.Tan((double)fov * 0.017453292519943295 / 2.0) / Math.Tan((double)fieldOfView * 0.017453292519943295 / 2.0) * (double)Screen.height);
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000DB4C File Offset: 0x0000BD4C
		public void Awake()
		{
			Misc.main = this;
			Misc.preparedFilter = new ServerListFilters();
			Misc.preparedFilter.attendance = 1;
			Misc.preparedFilter.vacProtection = 2;
			Misc.preparedFilter.workshop = 2;
			Misc.preparedFilter.plugins = 2;
			Misc.preparedFilter.password = 0;
			Misc.preparedFilter.camera = 4;
			Misc.preparedFilter.battlEyeProtection = 2;
			Misc.preparedFilter.cheats = 2;
			Misc.preparedFilter.notFull = true;
			Misc.preparedFilter.gold = 0;
			Misc.preparedFilter.listSource = 0;
			Misc.preparedFilter.combat = 2;
			Misc.preparedFilter.monetization = 1;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000DBF8 File Offset: 0x0000BDF8
		public void StartPlayerSearching(string nickName)
		{
			if (!string.IsNullOrEmpty(nickName))
			{
				Misc.searchGoal = nickName;
				Misc.servers.Clear();
				Misc.findedPlayers.Clear();
				Misc.currentlySearchesIndex = 0;
				Misc.isServersFetched = false;
				Misc.isFindingEnded = false;
				Misc.isFinding = true;
				this.StartSearchServers();
			}
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000DC48 File Offset: 0x0000BE48
		public void StartSearchServers()
		{
			this.fetchC = base.StartCoroutine(this.fetchServersChecking());
			Provider.provider.matchmakingService.refreshMasterServer(Misc.preparedFilter);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00002E6A File Offset: 0x0000106A
		public IEnumerator fetchServersChecking()
		{
			Misc.<fetchServersChecking>d__72 <fetchServersChecking>d__ = new Misc.<fetchServersChecking>d__72(0);
			<fetchServersChecking>d__.<>4__this = this;
			return <fetchServersChecking>d__;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0000DC7C File Offset: 0x0000BE7C
		public void StopSearcesImmediate()
		{
			for (int i = 0; i < Misc.servers.Count; i++)
			{
				Misc.servers[i].ForceStop();
			}
			if (this.fetchC != null)
			{
				base.StopCoroutine(this.fetchC);
				this.fetchC = null;
			}
			Misc.servers.Clear();
			Misc.isFinding = false;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000DCE4 File Offset: 0x0000BEE4
		public void onFetchFinished(string nickname, float playTime, int index)
		{
			if (Misc.isFinding)
			{
				for (int i = 0; i < Misc.servers.Count; i++)
				{
					if (Misc.servers[i].index == index)
					{
						if (!string.IsNullOrEmpty(nickname))
						{
							TimeSpan timeSpan = TimeSpan.FromSeconds((double)playTime);
							string text = string.Empty;
							if (timeSpan.Days > 0)
							{
								text = text + " " + timeSpan.Days.ToString() + "d";
							}
							if (timeSpan.Hours > 0)
							{
								text = text + " " + timeSpan.Hours.ToString() + "h";
							}
							if (timeSpan.Minutes > 0)
							{
								text = text + " " + timeSpan.Minutes.ToString() + "m";
							}
							if (timeSpan.Seconds > 0)
							{
								text = text + " " + timeSpan.Seconds.ToString() + "s";
							}
							Misc.FindedPlayer item = new Misc.FindedPlayer(Misc.servers[i].serverIP, Misc.servers[i].serverPort, Misc.servers[i].name, nickname.ToLower(), text);
							Misc.findedPlayers.Add(item);
						}
						Misc.servers.RemoveAt(i);
						break;
					}
				}
				if (Provider.provider.matchmakingService.serverList.Count != Misc.currentlySearchesIndex || Misc.servers.Count != 0)
				{
					if (Provider.provider.matchmakingService.serverList.Count != Misc.currentlySearchesIndex)
					{
						SteamServerAdvertisement steamServerAdvertisement = Provider.provider.matchmakingService.serverList[Misc.currentlySearchesIndex];
						Misc.FetchedServer fetchedServer = new Misc.FetchedServer(steamServerAdvertisement.ip, steamServerAdvertisement.queryPort, steamServerAdvertisement.connectionPort, steamServerAdvertisement.name, Misc.currentlySearchesIndex, new Action<string, float, int>(this.onFetchFinished));
						Misc.servers.Add(fetchedServer);
						fetchedServer.Refresh();
						Misc.currentlySearchesIndex++;
					}
				}
				else
				{
					Misc.isFindingEnded = true;
					Misc.isFinding = false;
				}
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000DF3C File Offset: 0x0000C13C
		public static bool IsItemWhitelistedForPickup(InteractableItem item)
		{
			return G.Settings.MiscOptions.AutoPickupNoFilter || (G.Settings.MiscOptions.AutoPickupGun && item.asset is ItemGunAsset) || (G.Settings.MiscOptions.AutoPickupBackpack && item.asset is ItemBackpackAsset) || (G.Settings.MiscOptions.AutoPickupAmmo && (item.asset is ItemMagazineAsset || item.asset is ItemCaliberAsset)) || (G.Settings.MiscOptions.AutoPickupAttachments && (item.asset is ItemBarrelAsset || item.asset is ItemOpticAsset)) || (G.Settings.MiscOptions.AutoPickupClothing && item.asset is ItemClothingAsset) || (G.Settings.MiscOptions.AutoPickupFuel && item.asset is ItemFuelAsset) || (G.Settings.MiscOptions.AutoPickupMedical && item.asset is ItemMedicalAsset) || (G.Settings.MiscOptions.AutoPickupMelee && item.asset is ItemMeleeAsset) || (G.Settings.MiscOptions.AutoPickupThrowable && item.asset is ItemThrowableAsset) || (G.Settings.MiscOptions.AutoPickupFoodWater && (item.asset is ItemFoodAsset || item.asset is ItemWaterAsset)) || (G.Settings.MiscOptions.AutoPickupExtra && (!(item.asset is ItemGunAsset) && !(item.asset is ItemBackpackAsset) && !(item.asset is ItemMagazineAsset) && !(item.asset is ItemCaliberAsset) && !(item.asset is ItemBarrelAsset) && !(item.asset is ItemOpticAsset) && !(item.asset is ItemClothingAsset) && !(item.asset is ItemFuelAsset) && !(item.asset is ItemMedicalAsset) && !(item.asset is ItemMeleeAsset) && !(item.asset is ItemThrowableAsset) && !(item.asset is ItemFoodAsset) && !(item.asset is ItemWaterAsset)));
		}

		// Token: 0x04000151 RID: 337
		public static Dictionary<ushort, Misc.ItemIcon> cachedItemIcons = new Dictionary<ushort, Misc.ItemIcon>();

		// Token: 0x04000152 RID: 338
		public static Rect SpyWin = new Rect((float)(Screen.width - 400), 600f, 340f, 350f);

		// Token: 0x04000153 RID: 339
		public static Rect TargetInfoWinUI = new Rect((float)(Screen.width / 2 - 110), (float)(Screen.height / 2 + 200), 206f, 200f);

		// Token: 0x04000154 RID: 340
		public static Rect LookingInfoWinUI = new Rect((float)(Screen.width / 2 - 150), (float)(Screen.height / 2 + 200), 206f, 200f);

		// Token: 0x04000155 RID: 341
		public static Rect ShowAdminWin = new Rect((float)(Screen.width - 500), 50f, 200f, 100f);

		// Token: 0x04000156 RID: 342
		public static Rect WeapontInfoWin = new Rect(0f, (float)(Screen.height / 2 - 90), 220f, 0f);

		// Token: 0x04000157 RID: 343
		public static Rect TargetInfoWin = new Rect(0f, (float)(Screen.height / 2 - 20), 220f, 0f);

		// Token: 0x04000158 RID: 344
		public static Rect ItemsWin = new Rect((float)(Screen.width - 800), 50f, 200f, 100f);

		// Token: 0x04000159 RID: 345
		public static Dictionary<ushort, float[]> AssetBackups = new Dictionary<ushort, float[]>();

		// Token: 0x0400015A RID: 346
		public static bool fly;

		// Token: 0x0400015B RID: 347
		public static int Killer2 = -1;

		// Token: 0x0400015C RID: 348
		public static Player SpectatedPlayer;

		// Token: 0x0400015D RID: 349
		public static float TracerTime = 1f;

		// Token: 0x0400015E RID: 350
		public static Renderer rend;

		// Token: 0x0400015F RID: 351
		public static float hue;

		// Token: 0x04000160 RID: 352
		public static float colorChangeSpeed = 0.05f;

		// Token: 0x04000161 RID: 353
		public static Color colorrrr;

		// Token: 0x04000162 RID: 354
		public static bool FreecamBeforeSpy;

		// Token: 0x04000163 RID: 355
		public static FieldInfo ThirdAttachmentsField;

		// Token: 0x04000164 RID: 356
		public static List<InteractableItem> itemsInRadius = new List<InteractableItem>();

		// Token: 0x04000165 RID: 357
		public static List<RegionCoordinate> regionsInRadius = new List<RegionCoordinate>(4);

		// Token: 0x04000166 RID: 358
		public static Vector3 pscale = new Vector3(1f, 1f, 1f);

		// Token: 0x04000167 RID: 359
		private static float float_0 = 0f;

		// Token: 0x04000168 RID: 360
		private static float float_1 = 0f;

		// Token: 0x04000169 RID: 361
		private static float float_2 = 0f;

		// Token: 0x0400016A RID: 362
		private static float float_3 = 0f;

		// Token: 0x0400016B RID: 363
		private static float float_4 = 0f;

		// Token: 0x0400016C RID: 364
		private static Color color_0 = Color.red;

		// Token: 0x0400016D RID: 365
		public static List<Misc.Tracer> tracers = new List<Misc.Tracer>();

		// Token: 0x0400016E RID: 366
		public static GameObject tracerObject;

		// Token: 0x0400016F RID: 367
		public static List<Misc.TracerObject> TracerLines = new List<Misc.TracerObject>();

		// Token: 0x04000170 RID: 368
		public static ServerListFilters preparedFilter = null;

		// Token: 0x04000171 RID: 369
		public const int playersMaxCurrentRefreshesCount = 5;

		// Token: 0x04000172 RID: 370
		public static string searchGoal = "";

		// Token: 0x04000173 RID: 371
		public static List<Misc.FetchedServer> servers = new List<Misc.FetchedServer>();

		// Token: 0x04000174 RID: 372
		public static List<Misc.FindedPlayer> findedPlayers = new List<Misc.FindedPlayer>();

		// Token: 0x04000175 RID: 373
		public static int currentlySearchesIndex = 0;

		// Token: 0x04000176 RID: 374
		public static bool isServersFetched = false;

		// Token: 0x04000177 RID: 375
		public static bool isFindingEnded = false;

		// Token: 0x04000178 RID: 376
		public static bool isFinding = false;

		// Token: 0x04000179 RID: 377
		public static Misc main;

		// Token: 0x0400017A RID: 378
		public Coroutine fetchC;

		// Token: 0x0200003C RID: 60
		public struct Tracer
		{
			// Token: 0x0600019B RID: 411 RVA: 0x0000E434 File Offset: 0x0000C634
			public Tracer(Vector3 startPoint, Vector3 endPoint, float deleteProgression)
			{
				this.tracerObject = Object.Instantiate<GameObject>(Misc.GetTracer());
				this.tracerObject.transform.position = Vector3.Lerp(startPoint, endPoint, 0.5f);
				float num = 1f;
				this.tracerObject.transform.localScale = new Vector3(num, num, Vector3.Distance(startPoint, endPoint) * 5f);
				this.tracerObject.transform.LookAt(endPoint);
				this.tracerObject.transform.eulerAngles += new Vector3(0f, 0f, 90f);
				this.tracerObject.SetActive(!SpyUtilities.BeingSpied);
				this.material = this.tracerObject.GetComponent<MeshRenderer>().material;
				this.deleteProgression = deleteProgression;
			}

			// Token: 0x0400017B RID: 379
			public GameObject tracerObject;

			// Token: 0x0400017C RID: 380
			public Material material;

			// Token: 0x0400017D RID: 381
			public float deleteProgression;
		}

		// Token: 0x0200003D RID: 61
		public class TracerObject
		{
			// Token: 0x0400017E RID: 382
			public DateTime ShotTime;

			// Token: 0x0400017F RID: 383
			public Vector3 PlayerPos;

			// Token: 0x04000180 RID: 384
			public Vector3 HitPos;
		}

		// Token: 0x0200003E RID: 62
		public class ItemIcon
		{
			// Token: 0x0600019D RID: 413 RVA: 0x0000E50C File Offset: 0x0000C70C
			public ItemIcon(ushort itemId)
			{
				this.itemId = itemId;
				this.states = new Dictionary<byte[], Texture2D>();
			}

			// Token: 0x0600019E RID: 414 RVA: 0x0000E534 File Offset: 0x0000C734
			public bool Contains(byte[] state)
			{
				foreach (byte[] array in this.states.Keys)
				{
					bool flag = true;
					if (state.Length == array.Length)
					{
						for (int i = 0; i < array.Length; i++)
						{
							if (state[i] != array[i])
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x0600019F RID: 415 RVA: 0x0000E5D4 File Offset: 0x0000C7D4
			public Texture2D Get(byte[] state)
			{
				using (Dictionary<byte[], Texture2D>.KeyCollection.Enumerator enumerator = this.states.Keys.GetEnumerator())
				{
					IL_5D:
					while (enumerator.MoveNext())
					{
						byte[] array = enumerator.Current;
						bool flag = true;
						if (state.Length == array.Length)
						{
							int i = 0;
							while (i < array.Length)
							{
								if (state[i] == array[i])
								{
									i++;
								}
								else
								{
									flag = false;
									IL_59:
									if (!flag)
									{
										goto IL_5D;
									}
									return this.states[array];
								}
							}
							goto IL_59;
						}
					}
				}
				return null;
			}

			// Token: 0x04000181 RID: 385
			public ushort itemId;

			// Token: 0x04000182 RID: 386
			public Dictionary<byte[], Texture2D> states;
		}

		// Token: 0x0200003F RID: 63
		public class FetchedServer
		{
			// Token: 0x060001A0 RID: 416 RVA: 0x0000E680 File Offset: 0x0000C880
			public FetchedServer(uint serverIP, ushort serverPort, ushort connectionPort, string name, int index, Action<string, float, int> onPlayersRefreshed)
			{
				Misc.FetchedServer.<>c__DisplayClass11_0 CS$<>8__locals1 = new Misc.FetchedServer.<>c__DisplayClass11_0();
				CS$<>8__locals1.action_0 = onPlayersRefreshed;
				CS$<>8__locals1.int_0 = index;
				base..ctor();
				CS$<>8__locals1.fetchedServer_0 = this;
				this.serverIP = serverIP;
				this.serverPort = serverPort;
				this.connectionPort = connectionPort;
				this.name = name;
				this.onPlayersRefreshed = CS$<>8__locals1.action_0;
				this.index = CS$<>8__locals1.int_0;
				this.cachedQuery = HServerQuery.Invalid;
				this.fetchedPlayer = "";
				this.fetchedPlayerPlaytime = 0f;
				this.playersResponse = new ISteamMatchmakingPlayersResponse(new ISteamMatchmakingPlayersResponse.AddPlayerToList(CS$<>8__locals1.method_0), new ISteamMatchmakingPlayersResponse.PlayersFailedToRespond(CS$<>8__locals1.method_1), new ISteamMatchmakingPlayersResponse.PlayersRefreshComplete(CS$<>8__locals1.method_2));
			}

			// Token: 0x060001A1 RID: 417 RVA: 0x0000E754 File Offset: 0x0000C954
			public void Refresh()
			{
				if (this.atempts <= 4)
				{
					this.atempts++;
					this.cachedQuery = SteamMatchmakingServers.PlayerDetails(this.serverIP, this.serverPort, this.playersResponse);
				}
				else
				{
					this.cachedQuery = HServerQuery.Invalid;
					this.onPlayersRefreshed("", 0f, this.index);
				}
			}

			// Token: 0x060001A2 RID: 418 RVA: 0x0000E7C0 File Offset: 0x0000C9C0
			public void ForceStop()
			{
				if (this.cachedQuery != HServerQuery.Invalid)
				{
					SteamMatchmakingServers.CancelServerQuery(this.cachedQuery);
					this.cachedQuery = HServerQuery.Invalid;
				}
			}

			// Token: 0x04000183 RID: 387
			public uint serverIP;

			// Token: 0x04000184 RID: 388
			public ushort serverPort;

			// Token: 0x04000185 RID: 389
			public ushort connectionPort;

			// Token: 0x04000186 RID: 390
			public string name;

			// Token: 0x04000187 RID: 391
			public int index;

			// Token: 0x04000188 RID: 392
			public Action<string, float, int> onPlayersRefreshed;

			// Token: 0x04000189 RID: 393
			public string fetchedPlayer = "";

			// Token: 0x0400018A RID: 394
			public float fetchedPlayerPlaytime = 0f;

			// Token: 0x0400018B RID: 395
			public HServerQuery cachedQuery;

			// Token: 0x0400018C RID: 396
			public ISteamMatchmakingPlayersResponse playersResponse;

			// Token: 0x0400018D RID: 397
			public int atempts = 0;
		}

		// Token: 0x02000041 RID: 65
		public struct FindedPlayer
		{
			// Token: 0x060001A7 RID: 423 RVA: 0x0000E890 File Offset: 0x0000CA90
			public FindedPlayer(uint ip, ushort port, string name, string nickname, string time)
			{
				this.ip = ip;
				this.port = port;
				this.nickname = nickname;
				this.name = name;
				this.time = time;
			}

			// Token: 0x04000191 RID: 401
			public uint ip;

			// Token: 0x04000192 RID: 402
			public ushort port;

			// Token: 0x04000193 RID: 403
			public string nickname;

			// Token: 0x04000194 RID: 404
			public string name;

			// Token: 0x04000195 RID: 405
			public string time;
		}
	}
}
