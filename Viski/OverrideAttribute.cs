using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Viski
{
	// Token: 0x02000004 RID: 4
	[AttributeUsage(AttributeTargets.Method)]
	public class OverrideAttribute : Attribute
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x0000225D File Offset: 0x0000045D
		// (set) Token: 0x06000006 RID: 6 RVA: 0x00003C80 File Offset: 0x00001E80
		public Type Class { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002265 File Offset: 0x00000465
		// (set) Token: 0x06000008 RID: 8 RVA: 0x00003C94 File Offset: 0x00001E94
		public string MethodName { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000009 RID: 9 RVA: 0x0000226D File Offset: 0x0000046D
		// (set) Token: 0x0600000A RID: 10 RVA: 0x00003CA8 File Offset: 0x00001EA8
		public MethodInfo Method { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000B RID: 11 RVA: 0x00002275 File Offset: 0x00000475
		// (set) Token: 0x0600000C RID: 12 RVA: 0x00003CBC File Offset: 0x00001EBC
		public BindingFlags Flags { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000D RID: 13 RVA: 0x0000227D File Offset: 0x0000047D
		// (set) Token: 0x0600000E RID: 14 RVA: 0x00003CD0 File Offset: 0x00001ED0
		public bool MethodFound { get; private set; }

		// Token: 0x0600000F RID: 15 RVA: 0x00003CE4 File Offset: 0x00001EE4
		public OverrideAttribute(Type tClass, string method, BindingFlags flags, int index = 0)
		{
			OverrideAttribute.<>c__DisplayClass20_0 CS$<>8__locals1 = new OverrideAttribute.<>c__DisplayClass20_0();
			CS$<>8__locals1.string_0 = method;
			base..ctor();
			this.Class = tClass;
			this.MethodName = CS$<>8__locals1.string_0;
			this.Flags = flags;
			try
			{
				this.Method = this.Class.GetMethods(flags).Where(new Func<MethodInfo, bool>(CS$<>8__locals1.method_0)).ToArray<MethodInfo>()[index];
				this.MethodFound = true;
			}
			catch (Exception)
			{
				this.MethodFound = false;
			}
		}

		// Token: 0x04000002 RID: 2
		[CompilerGenerated]
		private Type type_0;

		// Token: 0x04000003 RID: 3
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04000004 RID: 4
		[CompilerGenerated]
		private MethodInfo methodInfo_0;

		// Token: 0x04000005 RID: 5
		[CompilerGenerated]
		private BindingFlags bindingFlags_0;

		// Token: 0x04000006 RID: 6
		[CompilerGenerated]
		private bool bool_0;
	}
}
