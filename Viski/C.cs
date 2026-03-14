using System;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200001F RID: 31
	public class C
	{
		// Token: 0x06000084 RID: 132 RVA: 0x00005C90 File Offset: 0x00003E90
		public static void AddColors()
		{
			foreach (object obj in Enum.GetValues(typeof(Visual.ESPObject)))
			{
				Visual.ESPObject espobject = (Visual.ESPObject)obj;
				string name = Enum.GetName(typeof(Visual.ESPObject), espobject);
				switch (espobject)
				{
				case Visual.ESPObject.Player:
					C.AddColor(name + "_ESP", Color.red);
					break;
				case Visual.ESPObject.Zombie:
					C.AddColor(name + "_ESP", Color.green);
					break;
				case Visual.ESPObject.Item:
					C.AddColor(name + "_ESP", Color.green);
					break;
				case Visual.ESPObject.Sentry:
					C.AddColor(name + "_ESP", Color.blue);
					break;
				case Visual.ESPObject.Bed:
					C.AddColor(name + "_ESP", Color.magenta);
					break;
				case Visual.ESPObject.Flag:
					C.AddColor(name + "_ESP", Color.yellow);
					break;
				case Visual.ESPObject.Vehicle:
					C.AddColor(name + "_ESP", Color.magenta);
					break;
				case Visual.ESPObject.Storage:
					C.AddColor(name + "_ESP", Color.cyan);
					break;
				case Visual.ESPObject.Airdrop:
					C.AddColor(name + "_ESP", Color.grey);
					break;
				case Visual.ESPObject.NPC:
					C.AddColor(name + "_ESP", Color.white);
					break;
				case Visual.ESPObject.Farm:
					C.AddColor(name + "_ESP", Color.yellow);
					break;
				case Visual.ESPObject.Resources:
					C.AddColor(name + "_ESP", Color.blue);
					break;
				}
				C.AddColor("Player_Chams_Visible_Color", Color.yellow);
				C.AddColor("Player_Chams_Occluded_Color", Color.red);
				C.AddColor("Box_Color", Color.yellow);
			}
			C.AddColor("Friendly_Player_ESP", Color.cyan);
			C.AddColor("Friendly_Chams_Visible_Color", Color.cyan);
			C.AddColor("Friendly_Chams_Occluded_Color", new Color32(0, 128, byte.MaxValue, byte.MaxValue));
			C.AddColor("Silent_Aim_FOV_Circle", Color.red);
			C.AddColor("Aimlock_FOV_Circle", Color.green);
			C.AddColor("LookDirection_Arrow", Color.cyan);
			C.AddColor("Backtrack_ESP", new Color32(byte.MaxValue, 0, byte.MaxValue, 180));
			C.AddColor("Backtrack_Trail", new Color32(byte.MaxValue, byte.MaxValue, 0, 120));
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00005FE8 File Offset: 0x000041E8
		public static Color32 GetColor(string identifier)
		{
			Color32 color;
			Color32 result;
			if (G.Settings.GlobalOptions.GlobalColors.TryGetValue(identifier, out color))
			{
				result = color;
			}
			else
			{
				result = Color.magenta;
			}
			return result;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00006024 File Offset: 0x00004224
		public static void AddColor(string id, Color32 c)
		{
			if (!G.Settings.GlobalOptions.GlobalColors.ContainsKey(id))
			{
				G.Settings.GlobalOptions.GlobalColors.Add(id, c);
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00006064 File Offset: 0x00004264
		public static void SetColor(string id, Color32 c)
		{
			G.Settings.GlobalOptions.GlobalColors[id] = c;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00006088 File Offset: 0x00004288
		public static string ColorToHex(Color32 color)
		{
			return color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
		}

		// Token: 0x04000072 RID: 114
		public static Visual.ESPObject selected;
	}
}
