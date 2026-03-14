using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Viski
{
	// Token: 0x0200000F RID: 15
	public class OverrideWrapper
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002321 File Offset: 0x00000521
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00004474 File Offset: 0x00002674
		public MethodInfo Original { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002329 File Offset: 0x00000529
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00004488 File Offset: 0x00002688
		public MethodInfo Modified { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002331 File Offset: 0x00000531
		// (set) Token: 0x06000032 RID: 50 RVA: 0x0000449C File Offset: 0x0000269C
		public IntPtr PtrOriginal { get; private set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00002339 File Offset: 0x00000539
		// (set) Token: 0x06000034 RID: 52 RVA: 0x000044B0 File Offset: 0x000026B0
		public IntPtr PtrModified { get; private set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002341 File Offset: 0x00000541
		// (set) Token: 0x06000036 RID: 54 RVA: 0x000044C4 File Offset: 0x000026C4
		public OverrideUtilities.OffsetBackup OffsetBackup { get; private set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002349 File Offset: 0x00000549
		// (set) Token: 0x06000038 RID: 56 RVA: 0x000044D8 File Offset: 0x000026D8
		public OverrideAttribute Attribute { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002351 File Offset: 0x00000551
		// (set) Token: 0x0600003A RID: 58 RVA: 0x000044EC File Offset: 0x000026EC
		public bool Detoured { get; private set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002359 File Offset: 0x00000559
		public object Instance { get; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002361 File Offset: 0x00000561
		// (set) Token: 0x0600003D RID: 61 RVA: 0x00004500 File Offset: 0x00002700
		public bool Local { get; private set; }

		// Token: 0x0600003E RID: 62 RVA: 0x00004514 File Offset: 0x00002714
		public OverrideWrapper(MethodInfo original, MethodInfo modified, OverrideAttribute attribute, object instance = null)
		{
			try
			{
				this.Original = original;
				this.Modified = modified;
				this.Instance = instance;
				this.Attribute = attribute;
				this.Local = (this.Modified.DeclaringType.Assembly == Assembly.GetExecutingAssembly());
				RuntimeHelpers.PrepareMethod(original.MethodHandle);
				RuntimeHelpers.PrepareMethod(modified.MethodHandle);
				this.PtrOriginal = this.Original.MethodHandle.GetFunctionPointer();
				this.PtrModified = this.Modified.MethodHandle.GetFunctionPointer();
				this.OffsetBackup = new OverrideUtilities.OffsetBackup(this.PtrOriginal);
				this.Detoured = false;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000045DC File Offset: 0x000027DC
		public bool Override()
		{
			bool result;
			if (!this.Detoured)
			{
				bool flag;
				if (flag = OverrideUtilities.OverrideFunction(this.PtrOriginal, this.PtrModified))
				{
					this.Detoured = true;
				}
				result = flag;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000461C File Offset: 0x0000281C
		public bool Revert()
		{
			bool result;
			if (this.Detoured)
			{
				bool flag;
				if (flag = OverrideUtilities.RevertOverride(this.OffsetBackup))
				{
					this.Detoured = false;
				}
				result = flag;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00004658 File Offset: 0x00002858
		public object CallOriginal(object[] args, object instance = null)
		{
			this.Revert();
			object result = this.Original.Invoke(instance ?? this.Instance, args);
			this.Override();
			return result;
		}

		// Token: 0x0400001C RID: 28
		[CompilerGenerated]
		private MethodInfo methodInfo_0;

		// Token: 0x0400001D RID: 29
		[CompilerGenerated]
		private MethodInfo methodInfo_1;

		// Token: 0x0400001E RID: 30
		[CompilerGenerated]
		private IntPtr intptr_0;

		// Token: 0x0400001F RID: 31
		[CompilerGenerated]
		private IntPtr intptr_1;

		// Token: 0x04000020 RID: 32
		[CompilerGenerated]
		private OverrideUtilities.OffsetBackup offsetBackup_0;

		// Token: 0x04000021 RID: 33
		[CompilerGenerated]
		private OverrideAttribute overrideAttribute_0;

		// Token: 0x04000022 RID: 34
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000023 RID: 35
		[CompilerGenerated]
		private readonly object object_0;

		// Token: 0x04000024 RID: 36
		[CompilerGenerated]
		private bool bool_1;
	}
}
