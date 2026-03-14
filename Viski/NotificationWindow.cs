using System;
using System.Collections.Generic;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000071 RID: 113
	public class NotificationWindow
	{
		// Token: 0x06000272 RID: 626 RVA: 0x00015CE0 File Offset: 0x00013EE0
		public void Run()
		{
			GUI.skin = Asset.Skin;
			if (DateTimeOffset.Now.ToUnixTimeMilliseconds() <= this.long_0)
			{
				if (100L > this.long_0 - DateTimeOffset.Now.ToUnixTimeMilliseconds())
				{
					long num = (this.long_0 - DateTimeOffset.Now.ToUnixTimeMilliseconds()) * 3L;
					GUI.Window(this.NotificationNum + 10, new Rect((float)((long)Screen.width - num), (float)(250 + 70 * this.NotificationNum), (float)num, 60f), new GUI.WindowFunction(this.method_0), "", "verticalsliderthumb");
				}
				else
				{
					GUI.Window(this.NotificationNum + 10, new Rect((float)(Screen.width - 250), (float)(250 + 70 * this.NotificationNum), 300f, 60f), new GUI.WindowFunction(this.method_0), "", "verticalsliderthumb");
				}
			}
			else
			{
				NotificationWindow.Notifications.Remove(this);
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00015E10 File Offset: 0x00014010
		private void method_0(int int_0)
		{
			GUI.Label(new Rect(25f, 25f, 260f, 70f), "<size=20>" + this.info + "</size>");
			GUI.DrawTexture(new Rect(300f - (float)(this.long_0 - DateTimeOffset.Now.ToUnixTimeMilliseconds() - 100L) / 9900f * 300f, 50f, 300f, 10f), Asset.Skin.verticalScrollbar.normal.background, 0);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00015EB4 File Offset: 0x000140B4
		public NotificationWindow()
		{
			this.long_0 = DateTimeOffset.Now.ToUnixTimeMilliseconds() + 3000L;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00015EF8 File Offset: 0x000140F8
		public static void AddNotification(string text)
		{
			NotificationWindow notificationWindow = new NotificationWindow();
			notificationWindow.info = text;
			NotificationWindow.Notifications.Add(notificationWindow);
		}

		// Token: 0x040002EA RID: 746
		public string info;

		// Token: 0x040002EB RID: 747
		private long long_0;

		// Token: 0x040002EC RID: 748
		public static List<NotificationWindow> Notifications = new List<NotificationWindow>();

		// Token: 0x040002ED RID: 749
		public int NotificationNum = NotificationWindow.Notifications.Count + 1;
	}
}
