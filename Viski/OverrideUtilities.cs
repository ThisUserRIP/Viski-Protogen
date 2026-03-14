using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Viski
{
	// Token: 0x0200000A RID: 10
	public static class OverrideUtilities
	{
		// Token: 0x06000020 RID: 32 RVA: 0x000040C4 File Offset: 0x000022C4
		public static object CallOriginal(object instance = null, params object[] args)
		{
			OverrideUtilities.<>c__DisplayClass0_0 CS$<>8__locals1 = new OverrideUtilities.<>c__DisplayClass0_0();
			OverrideManager overrideManager = new OverrideManager();
			StackTrace stackTrace = new StackTrace(false);
			if (stackTrace.FrameCount < 1)
			{
				throw new Exception("Invalid trace back to the original method! Please provide the methodinfo instead!");
			}
			MethodBase method = stackTrace.GetFrame(1).GetMethod();
			CS$<>8__locals1.methodInfo_0 = null;
			if (!Attribute.IsDefined(method, typeof(OverrideAttribute)))
			{
				method = stackTrace.GetFrame(2).GetMethod();
			}
			OverrideAttribute overrideAttribute = (OverrideAttribute)Attribute.GetCustomAttribute(method, typeof(OverrideAttribute));
			if (overrideAttribute == null)
			{
				throw new Exception("This method can only be called from an overwritten method!");
			}
			if (!overrideAttribute.MethodFound)
			{
				throw new Exception("The original method was never found!");
			}
			CS$<>8__locals1.methodInfo_0 = overrideAttribute.Method;
			if (overrideManager.Overrides.All(new Func<KeyValuePair<OverrideAttribute, OverrideWrapper>, bool>(CS$<>8__locals1.method_0)))
			{
				throw new Exception("The Override specified was not found!");
			}
			OverrideWrapper value = overrideManager.Overrides.First(new Func<KeyValuePair<OverrideAttribute, OverrideWrapper>, bool>(CS$<>8__locals1.method_1)).Value;
			return value.CallOriginal(args, instance);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000041E8 File Offset: 0x000023E8
		public static bool EnableOverride(MethodInfo method)
		{
			OverrideUtilities.<>c__DisplayClass1_0 CS$<>8__locals1 = new OverrideUtilities.<>c__DisplayClass1_0();
			CS$<>8__locals1.methodInfo_0 = method;
			OverrideManager overrideManager = new OverrideManager();
			OverrideWrapper value = overrideManager.Overrides.First(new Func<KeyValuePair<OverrideAttribute, OverrideWrapper>, bool>(CS$<>8__locals1.method_0)).Value;
			return value != null && value.Override();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00004240 File Offset: 0x00002440
		public static bool DisableOverride(MethodInfo method)
		{
			OverrideUtilities.<>c__DisplayClass2_0 CS$<>8__locals1 = new OverrideUtilities.<>c__DisplayClass2_0();
			CS$<>8__locals1.methodInfo_0 = method;
			OverrideManager overrideManager = new OverrideManager();
			OverrideWrapper value = overrideManager.Overrides.First(new Func<KeyValuePair<OverrideAttribute, OverrideWrapper>, bool>(CS$<>8__locals1.method_0)).Value;
			return value != null && value.Revert();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00004298 File Offset: 0x00002498
		public unsafe static bool OverrideFunction(IntPtr ptrOriginal, IntPtr ptrModified)
		{
			bool result;
			try
			{
				int size = IntPtr.Size;
				if (size != 4)
				{
					if (size != 8)
					{
						return false;
					}
					byte* ptr = (byte*)ptrOriginal.ToPointer();
					*ptr = 72;
					ptr[1] = 184;
					*(long*)(ptr + 2) = ptrModified.ToInt64();
					ptr[10] = byte.MaxValue;
					ptr[11] = 224;
				}
				else
				{
					byte* ptr2 = (byte*)ptrOriginal.ToPointer();
					*ptr2 = 104;
					*(int*)(ptr2 + 1) = ptrModified.ToInt32();
					ptr2[5] = 195;
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00004348 File Offset: 0x00002548
		public unsafe static bool RevertOverride(OverrideUtilities.OffsetBackup backup)
		{
			bool result;
			try
			{
				byte* ptr = (byte*)backup.Method.ToPointer();
				*ptr = backup.A;
				ptr[1] = backup.B;
				ptr[10] = backup.C;
				ptr[11] = backup.D;
				ptr[12] = backup.E;
				if (IntPtr.Size != 4)
				{
					*(long*)(ptr + 2) = (long)backup.F64;
				}
				else
				{
					*(int*)(ptr + 1) = (int)backup.F32;
					ptr[5] = backup.G;
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0200000B RID: 11
		public class OffsetBackup
		{
			// Token: 0x06000025 RID: 37 RVA: 0x000043E8 File Offset: 0x000025E8
			public unsafe OffsetBackup(IntPtr method)
			{
				this.Method = method;
				byte* ptr = (byte*)method.ToPointer();
				this.A = *ptr;
				this.B = ptr[1];
				this.C = ptr[10];
				this.D = ptr[11];
				this.E = ptr[12];
				if (IntPtr.Size != 4)
				{
					this.F64 = (ulong)(*(long*)(ptr + 2));
				}
				else
				{
					this.F32 = *(uint*)(ptr + 1);
					this.G = ptr[5];
				}
			}

			// Token: 0x04000010 RID: 16
			public IntPtr Method;

			// Token: 0x04000011 RID: 17
			public byte A;

			// Token: 0x04000012 RID: 18
			public byte B;

			// Token: 0x04000013 RID: 19
			public byte C;

			// Token: 0x04000014 RID: 20
			public byte D;

			// Token: 0x04000015 RID: 21
			public byte E;

			// Token: 0x04000016 RID: 22
			public byte G;

			// Token: 0x04000017 RID: 23
			public ulong F64;

			// Token: 0x04000018 RID: 24
			public uint F32;
		}
	}
}
