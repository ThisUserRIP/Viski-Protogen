using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Viski
{
	// Token: 0x02000007 RID: 7
	public class OverrideManager
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000019 RID: 25 RVA: 0x00002298 File Offset: 0x00000498
		public Dictionary<OverrideAttribute, OverrideWrapper> Overrides
		{
			get
			{
				return OverrideManager._overrides;
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003FB0 File Offset: 0x000021B0
		public void OffHook()
		{
			foreach (OverrideWrapper overrideWrapper in this.Overrides.Values)
			{
				overrideWrapper.Revert();
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000400C File Offset: 0x0000220C
		public void LoadOverride(MethodInfo method)
		{
			try
			{
				OverrideManager.<>c__DisplayClass3_0 CS$<>8__locals1 = new OverrideManager.<>c__DisplayClass3_0();
				CS$<>8__locals1.overrideAttribute_0 = (OverrideAttribute)Attribute.GetCustomAttribute(method, typeof(OverrideAttribute));
				if (this.Overrides.Count(new Func<KeyValuePair<OverrideAttribute, OverrideWrapper>, bool>(CS$<>8__locals1.method_0)) <= 0)
				{
					OverrideWrapper overrideWrapper = new OverrideWrapper(CS$<>8__locals1.overrideAttribute_0.Method, method, CS$<>8__locals1.overrideAttribute_0, null);
					overrideWrapper.Override();
					this.Overrides.Add(CS$<>8__locals1.overrideAttribute_0, overrideWrapper);
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000008 RID: 8
		public static Dictionary<OverrideAttribute, OverrideWrapper> _overrides = new Dictionary<OverrideAttribute, OverrideWrapper>();
	}
}
