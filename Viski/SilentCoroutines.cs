using System;
using System.Collections;
using System.Collections.Generic;
using SDG.Unturned;

namespace Viski
{
	// Token: 0x02000059 RID: 89
	public class SilentCoroutines
	{
		// Token: 0x06000204 RID: 516 RVA: 0x00002F51 File Offset: 0x00001151
		public static IEnumerator UpdateObjects()
		{
			return new SilentCoroutines.<UpdateObjects>d__1(0);
		}

		// Token: 0x04000237 RID: 567
		public static List<Player> CachedPlayers = new List<Player>();
	}
}
