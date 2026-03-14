using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Viski
{
	// Token: 0x02000035 RID: 53
	public class WbhEmbed
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x0000B198 File Offset: 0x00009398
		internal WbhEmbed(WbhMessage parent)
		{
			this.wbhMessage_0 = parent;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000B1C0 File Offset: 0x000093C0
		public WbhEmbed()
		{
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000B1E0 File Offset: 0x000093E0
		public new WbhMessage Finalize()
		{
			if (this.wbhMessage_0 == null)
			{
				this.wbhMessage_0 = new WbhMessage
				{
					embeds = new List<WbhEmbed>
					{
						this
					}
				};
			}
			return this.wbhMessage_0;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000B220 File Offset: 0x00009420
		public WbhEmbed WithTitle(string title)
		{
			this.title = title;
			return this;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000B23C File Offset: 0x0000943C
		public WbhEmbed WithURL(string value)
		{
			this.url = value;
			return this;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000B258 File Offset: 0x00009458
		public WbhEmbed WithDescription(string value)
		{
			this.description = value;
			return this;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000B274 File Offset: 0x00009474
		public WbhEmbed WithTimestamp(DateTime value)
		{
			this.timestamp = DiscordHelpers.DateTimeToISO(value.ToLocalTime());
			return this;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000B298 File Offset: 0x00009498
		public WbhEmbed WithField(string name, string value, bool inline = true)
		{
			this.fields.Add(new WbhField
			{
				value = value,
				inline = inline,
				name = name
			});
			return this;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000B2D0 File Offset: 0x000094D0
		public WbhEmbed WithImage(string value)
		{
			this.image = new WbhImage
			{
				url = value
			};
			return this;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000B2F4 File Offset: 0x000094F4
		public WbhEmbed WithThumbnail(string value)
		{
			this.thumbnail = new WbhImage
			{
				url = value
			};
			return this;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000B318 File Offset: 0x00009518
		public WbhEmbed WithAuthor(string name, string url = null, string icon = null)
		{
			this.author = new WbhAuthor
			{
				name = name,
				icon_url = icon,
				url = url
			};
			return this;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000B34C File Offset: 0x0000954C
		public WbhEmbed WithColor(EmbedColor color)
		{
			byte[] array = new byte[4];
			array[0] = color.B;
			array[1] = color.G;
			array[2] = color.R;
			this.color = BitConverter.ToInt32(array, 0);
			return this;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000B38C File Offset: 0x0000958C
		private byte method_0(float float_0)
		{
			return (byte)Math.Round((double)(float_0 * 255f), 0);
		}

		// Token: 0x04000138 RID: 312
		[JsonIgnore]
		private WbhMessage wbhMessage_0;

		// Token: 0x04000139 RID: 313
		public int color;

		// Token: 0x0400013A RID: 314
		public WbhAuthor author;

		// Token: 0x0400013B RID: 315
		public string title;

		// Token: 0x0400013C RID: 316
		public string url;

		// Token: 0x0400013D RID: 317
		public string description;

		// Token: 0x0400013E RID: 318
		public List<WbhField> fields = new List<WbhField>();

		// Token: 0x0400013F RID: 319
		public WbhImage image;

		// Token: 0x04000140 RID: 320
		public WbhImage thumbnail;

		// Token: 0x04000141 RID: 321
		public WbhFooter footer;

		// Token: 0x04000142 RID: 322
		public string timestamp;
	}
}
