using System;
using System.Collections.Generic;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000072 RID: 114
	[Component]
	public class Spy : MonoBehaviour
	{
		// Token: 0x06000277 RID: 631 RVA: 0x00015F38 File Offset: 0x00014138
		public static void DrawRect(Rect position, Color color, GUIContent content = null)
		{
			Color backgroundColor = GUI.backgroundColor;
			GUI.backgroundColor = color;
			GUI.Box(position, content ?? GUIContent.none, Visual.textumonoyle);
			GUI.backgroundColor = backgroundColor;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00015F70 File Offset: 0x00014170
		public static void DrawBorder(Rect rect, float thickness, Color color)
		{
			Spy.DrawRect(new Rect(rect.xMin - thickness / 2f, rect.yMin - thickness / 2f, rect.width + thickness, thickness), color, null);
			Spy.DrawRect(new Rect(rect.xMin - thickness / 2f, rect.yMax - thickness / 2f, rect.width + thickness, thickness), color, null);
			Spy.DrawRect(new Rect(rect.xMin - thickness / 2f, rect.yMin - thickness / 2f, thickness, rect.height + thickness), color, null);
			Spy.DrawRect(new Rect(rect.xMax - thickness / 2f, rect.yMin - thickness / 2f, thickness, rect.height + thickness), color, null);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00016050 File Offset: 0x00014250
		private void OnGUI()
		{
			if (!SpyUtilities.BeingSpied)
			{
				foreach (Spy spy in Spy.Notifications)
				{
					spy.Run();
				}
			}
		}

		// Token: 0x0600027A RID: 634 RVA: 0x000160B0 File Offset: 0x000142B0
		public void Run()
		{
			GUI.skin = Asset.Skin;
			if (DateTimeOffset.Now.ToUnixTimeMilliseconds() > this.long_0)
			{
				Spy.Notifications.Remove(this);
			}
			else
			{
				Spy.DrawBorder(Misc.SpyWin, 5f, Color.black);
				GUI.color = new Color(1f, 1f, 1f, 0f);
				Misc.SpyWin = GUILayout.Window(7, Misc.SpyWin, new GUI.WindowFunction(this.method_0), "", Array.Empty<GUILayoutOption>());
				GUI.color = Color.white;
			}
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00016150 File Offset: 0x00014350
		private void method_0(int int_0)
		{
			GUILayout.Space(0f);
			Texture2D texture2D = new Texture2D(345, 355, 3, false);
			ImageConversion.LoadImage(texture2D, SpyUtilities.data, true);
			GUI.DrawTexture(new Rect(0f, 0f, Misc.SpyWin.width, Misc.SpyWin.height), texture2D);
			GUI.DragWindow();
		}

		// Token: 0x0600027C RID: 636 RVA: 0x000161B8 File Offset: 0x000143B8
		public Spy()
		{
			this.long_0 = DateTimeOffset.Now.ToUnixTimeMilliseconds() + 2000L;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x000161EC File Offset: 0x000143EC
		public static void AddNotification()
		{
			Spy item = new Spy();
			Spy.Notifications.Add(item);
		}

		// Token: 0x040002EE RID: 750
		public static List<Spy> Notifications = new List<Spy>();

		// Token: 0x040002EF RID: 751
		private long long_0;
	}
}
