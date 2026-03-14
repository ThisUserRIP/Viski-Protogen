using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Viski
{
	// Token: 0x02000006 RID: 6
	public class OverrideHelper
	{
		// Token: 0x06000012 RID: 18
		[DllImport("mono.dll", CallingConvention = CallingConvention.FastCall)]
		private static extern IntPtr mono_domain_get();

		// Token: 0x06000013 RID: 19
		[DllImport("mono.dll", CallingConvention = CallingConvention.FastCall)]
		private static extern IntPtr mono_method_get_header(IntPtr intptr_0);

		// Token: 0x06000014 RID: 20 RVA: 0x00003D88 File Offset: 0x00001F88
		public static void RedirectCalls(MethodInfo from, MethodInfo to)
		{
			IntPtr functionPointer = from.MethodHandle.GetFunctionPointer();
			IntPtr functionPointer2 = to.MethodHandle.GetFunctionPointer();
			OverrideHelper.smethod_1(functionPointer, functionPointer2);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003DC0 File Offset: 0x00001FC0
		private unsafe static void smethod_0(MethodBase methodBase_0, MethodBase methodBase_1)
		{
			IntPtr value = methodBase_0.MethodHandle.Value;
			IntPtr value2 = methodBase_1.MethodHandle.Value;
			methodBase_0.MethodHandle.GetFunctionPointer();
			methodBase_1.MethodHandle.GetFunctionPointer();
			byte* ptr = (byte*)OverrideHelper.mono_domain_get().ToPointer() + 232;
			long** ptr2 = *(IntPtr*)(ptr + 32);
			uint num = *(uint*)(ptr + 24);
			void* ptr3 = null;
			void* ptr4 = null;
			long num2 = value.ToInt64();
			uint num3 = (uint)num2 >> 3;
			for (long* ptr5 = *(IntPtr*)(ptr2 + (ulong)(num3 % num) * (ulong)((long)sizeof(long*)) / (ulong)sizeof(long*)); ptr5 != null; ptr5 = *(IntPtr*)(ptr5 + 1))
			{
				if (num2 == *ptr5)
				{
					ptr3 = (void*)ptr5;
					break;
				}
			}
			long num4 = value2.ToInt64();
			uint num5 = (uint)num4 >> 3;
			for (long* ptr6 = *(IntPtr*)(ptr2 + (ulong)(num5 % num) * (ulong)((long)sizeof(long*)) / (ulong)sizeof(long*)); ptr6 != null; ptr6 = *(IntPtr*)(ptr6 + 1))
			{
				if (num4 == *ptr6)
				{
					ptr4 = (void*)ptr6;
					break;
				}
			}
			if (ptr3 != null && ptr4 != null)
			{
				ulong* ptr7 = (ulong*)ptr3;
				ulong* ptr8 = (ulong*)ptr4;
				ptr7[2] = ptr8[2];
				ptr7[3] = ptr8[3];
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003F08 File Offset: 0x00002108
		private unsafe static void smethod_1(IntPtr intptr_0, IntPtr intptr_1)
		{
			byte* ptr = (byte*)intptr_0.ToPointer();
			*ptr = 73;
			ptr[1] = 187;
			*(long*)(ptr + 2) = intptr_1.ToInt64();
			ptr[10] = 65;
			ptr[11] = byte.MaxValue;
			ptr[12] = 227;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003F58 File Offset: 0x00002158
		private unsafe static void smethod_2(MethodBase methodBase_0, MethodBase methodBase_1)
		{
			IntPtr value = methodBase_0.MethodHandle.Value;
			IntPtr value2 = methodBase_1.MethodHandle.Value;
			OverrideHelper.mono_method_get_header(value2);
			byte* ptr = (byte*)value.ToPointer();
			byte* ptr2 = (byte*)value2.ToPointer();
			*(IntPtr*)(ptr + 40) = *(IntPtr*)(ptr2 + 40);
		}
	}
}
