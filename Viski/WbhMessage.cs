using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Viski
{
	// Token: 0x02000039 RID: 57
	public class WbhMessage
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00002410 File Offset: 0x00000610
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x0000B3CC File Offset: 0x000095CC
		public bool tts { get; set; }

		// Token: 0x060000E2 RID: 226 RVA: 0x0000B3E0 File Offset: 0x000095E0
		public WbhMessage WithEmbed(WbhEmbed embed)
		{
			this.embeds.Add(embed);
			return this;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000B400 File Offset: 0x00009600
		public WbhEmbed PassEmbed()
		{
			WbhEmbed wbhEmbed = new WbhEmbed(this);
			this.embeds.Add(wbhEmbed);
			return wbhEmbed;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000B428 File Offset: 0x00009628
		public WbhMessage WithUsername(string un)
		{
			this.username = un;
			return this;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000B444 File Offset: 0x00009644
		public WbhMessage WithAvatar(string avatar)
		{
			this.avatar_url = avatar;
			return this;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000B460 File Offset: 0x00009660
		public WbhMessage WithContent(string c)
		{
			this.content = c;
			return this;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000B47C File Offset: 0x0000967C
		public WbhMessage WithTTS()
		{
			this.tts = true;
			return this;
		}

		// Token: 0x04000149 RID: 329
		public string username;

		// Token: 0x0400014A RID: 330
		public string avatar_url;

		// Token: 0x0400014B RID: 331
		public string content = "";

		// Token: 0x0400014C RID: 332
		public List<WbhEmbed> embeds = new List<WbhEmbed>();

		// Token: 0x0400014D RID: 333
		[CompilerGenerated]
		private bool bool_0;
	}
}
