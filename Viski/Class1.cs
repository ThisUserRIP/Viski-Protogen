using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

// Token: 0x02000087 RID: 135
internal class Class1
{
	// Token: 0x060002D6 RID: 726 RVA: 0x0001D32C File Offset: 0x0001B52C
	static Class1()
	{
		Class1.assembly_0 = typeof(Class1).Assembly;
		Class1.uint_0 = new uint[]
		{
			3614090360U,
			3905402710U,
			606105819U,
			3250441966U,
			4118548399U,
			1200080426U,
			2821735955U,
			4249261313U,
			1770035416U,
			2336552879U,
			4294925233U,
			2304563134U,
			1804603682U,
			4254626195U,
			2792965006U,
			1236535329U,
			4129170786U,
			3225465664U,
			643717713U,
			3921069994U,
			3593408605U,
			38016083U,
			3634488961U,
			3889429448U,
			568446438U,
			3275163606U,
			4107603335U,
			1163531501U,
			2850285829U,
			4243563512U,
			1735328473U,
			2368359562U,
			4294588738U,
			2272392833U,
			1839030562U,
			4259657740U,
			2763975236U,
			1272893353U,
			4139469664U,
			3200236656U,
			681279174U,
			3936430074U,
			3572445317U,
			76029189U,
			3654602809U,
			3873151461U,
			530742520U,
			3299628645U,
			4096336452U,
			1126891415U,
			2878612391U,
			4237533241U,
			1700485571U,
			2399980690U,
			4293915773U,
			2240044497U,
			1873313359U,
			4264355552U,
			2734768916U,
			1309151649U,
			4149444226U,
			3174756917U,
			718787259U,
			3951481745U
		};
		Class1.bool_1 = false;
		Class1.bool_3 = false;
		Class1.rsacryptoServiceProvider_0 = null;
		Class1.dictionary_0 = null;
		Class1.object_0 = new object();
		Class1.int_0 = 0;
		Class1.object_1 = new object();
		Class1.list_0 = null;
		Class1.list_1 = null;
		Class1.byte_0 = new byte[0];
		Class1.byte_1 = new byte[0];
		Class1.intptr_2 = IntPtr.Zero;
		Class1.MnjeHbSuAy = IntPtr.Zero;
		Class1.string_0 = new string[0];
		Class1.int_3 = new int[0];
		Class1.int_5 = 1;
		Class1.bool_0 = false;
		Class1.sortedList_0 = new SortedList();
		Class1.int_2 = 0;
		Class1.long_1 = 0L;
		Class1.delegate2_0 = null;
		Class1.delegate2_1 = null;
		Class1.long_0 = 0L;
		Class1.int_1 = 0;
		Class1.bool_5 = false;
		Class1.bool_4 = false;
		Class1.int_4 = 0;
		Class1.intptr_1 = IntPtr.Zero;
		Class1.bool_6 = false;
		Class1.hashtable_0 = new Hashtable();
		Class1.delegate3_0 = null;
		Class1.delegate4_0 = null;
		Class1.delegate5_0 = null;
		Class1.delegate6_0 = null;
		Class1.delegate7_0 = null;
		Class1.delegate8_0 = null;
		Class1.intptr_0 = IntPtr.Zero;
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x00002258 File Offset: 0x00000458
	private void cWavYlAqpr()
	{
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x0001D4A8 File Offset: 0x0001B6A8
	internal static byte[] smethod_0(object object_2)
	{
		uint[] array = new uint[16];
		uint num = (uint)((448 - object_2.Length * 8 % 512 + 512) % 512);
		if (num == 0U)
		{
			num = 512U;
		}
		uint num2 = (uint)((long)object_2.Length + (long)((ulong)(num / 8U)) + 8L);
		ulong num3 = (ulong)((long)object_2.Length * 8L);
		byte[] array2 = new byte[num2];
		for (int i = 0; i < object_2.Length; i++)
		{
			array2[i] = object_2[i];
		}
		byte[] array3 = array2;
		int num4 = object_2.Length;
		array3[num4] |= 128;
		for (int j = 8; j > 0; j--)
		{
			array2[(int)(checked((IntPtr)(unchecked((ulong)num2 - (ulong)((long)j)))))] = (byte)(num3 >> (8 - j) * 8 & 255UL);
		}
		uint num5 = (uint)(array2.Length * 8 / 32);
		uint num6 = 1732584193U;
		uint num7 = 4023233417U;
		uint num8 = 2562383102U;
		uint num9 = 271733878U;
		for (uint num10 = 0U; num10 < num5 / 16U; num10 += 1U)
		{
			uint num11 = num10 << 6;
			for (uint num12 = 0U; num12 < 61U; num12 += 4U)
			{
				array[(int)(num12 >> 2)] = (uint)((int)array2[(int)(num11 + (num12 + 3U))] << 24 | (int)array2[(int)(num11 + (num12 + 2U))] << 16 | (int)array2[(int)(num11 + (num12 + 1U))] << 8 | (int)array2[(int)(num11 + num12)]);
			}
			uint num13 = num6;
			uint num14 = num7;
			uint num15 = num8;
			uint num16 = num9;
			Class1.smethod_1(ref num6, num7, num8, num9, 0U, 7, 1U, array);
			Class1.smethod_1(ref num9, num6, num7, num8, 1U, 12, 2U, array);
			Class1.smethod_1(ref num8, num9, num6, num7, 2U, 17, 3U, array);
			Class1.smethod_1(ref num7, num8, num9, num6, 3U, 22, 4U, array);
			Class1.smethod_1(ref num6, num7, num8, num9, 4U, 7, 5U, array);
			Class1.smethod_1(ref num9, num6, num7, num8, 5U, 12, 6U, array);
			Class1.smethod_1(ref num8, num9, num6, num7, 6U, 17, 7U, array);
			Class1.smethod_1(ref num7, num8, num9, num6, 7U, 22, 8U, array);
			Class1.smethod_1(ref num6, num7, num8, num9, 8U, 7, 9U, array);
			Class1.smethod_1(ref num9, num6, num7, num8, 9U, 12, 10U, array);
			Class1.smethod_1(ref num8, num9, num6, num7, 10U, 17, 11U, array);
			Class1.smethod_1(ref num7, num8, num9, num6, 11U, 22, 12U, array);
			Class1.smethod_1(ref num6, num7, num8, num9, 12U, 7, 13U, array);
			Class1.smethod_1(ref num9, num6, num7, num8, 13U, 12, 14U, array);
			Class1.smethod_1(ref num8, num9, num6, num7, 14U, 17, 15U, array);
			Class1.smethod_1(ref num7, num8, num9, num6, 15U, 22, 16U, array);
			Class1.smethod_2(ref num6, num7, num8, num9, 1U, 5, 17U, array);
			Class1.smethod_2(ref num9, num6, num7, num8, 6U, 9, 18U, array);
			Class1.smethod_2(ref num8, num9, num6, num7, 11U, 14, 19U, array);
			Class1.smethod_2(ref num7, num8, num9, num6, 0U, 20, 20U, array);
			Class1.smethod_2(ref num6, num7, num8, num9, 5U, 5, 21U, array);
			Class1.smethod_2(ref num9, num6, num7, num8, 10U, 9, 22U, array);
			Class1.smethod_2(ref num8, num9, num6, num7, 15U, 14, 23U, array);
			Class1.smethod_2(ref num7, num8, num9, num6, 4U, 20, 24U, array);
			Class1.smethod_2(ref num6, num7, num8, num9, 9U, 5, 25U, array);
			Class1.smethod_2(ref num9, num6, num7, num8, 14U, 9, 26U, array);
			Class1.smethod_2(ref num8, num9, num6, num7, 3U, 14, 27U, array);
			Class1.smethod_2(ref num7, num8, num9, num6, 8U, 20, 28U, array);
			Class1.smethod_2(ref num6, num7, num8, num9, 13U, 5, 29U, array);
			Class1.smethod_2(ref num9, num6, num7, num8, 2U, 9, 30U, array);
			Class1.smethod_2(ref num8, num9, num6, num7, 7U, 14, 31U, array);
			Class1.smethod_2(ref num7, num8, num9, num6, 12U, 20, 32U, array);
			Class1.smethod_3(ref num6, num7, num8, num9, 5U, 4, 33U, array);
			Class1.smethod_3(ref num9, num6, num7, num8, 8U, 11, 34U, array);
			Class1.smethod_3(ref num8, num9, num6, num7, 11U, 16, 35U, array);
			Class1.smethod_3(ref num7, num8, num9, num6, 14U, 23, 36U, array);
			Class1.smethod_3(ref num6, num7, num8, num9, 1U, 4, 37U, array);
			Class1.smethod_3(ref num9, num6, num7, num8, 4U, 11, 38U, array);
			Class1.smethod_3(ref num8, num9, num6, num7, 7U, 16, 39U, array);
			Class1.smethod_3(ref num7, num8, num9, num6, 10U, 23, 40U, array);
			Class1.smethod_3(ref num6, num7, num8, num9, 13U, 4, 41U, array);
			Class1.smethod_3(ref num9, num6, num7, num8, 0U, 11, 42U, array);
			Class1.smethod_3(ref num8, num9, num6, num7, 3U, 16, 43U, array);
			Class1.smethod_3(ref num7, num8, num9, num6, 6U, 23, 44U, array);
			Class1.smethod_3(ref num6, num7, num8, num9, 9U, 4, 45U, array);
			Class1.smethod_3(ref num9, num6, num7, num8, 12U, 11, 46U, array);
			Class1.smethod_3(ref num8, num9, num6, num7, 15U, 16, 47U, array);
			Class1.smethod_3(ref num7, num8, num9, num6, 2U, 23, 48U, array);
			Class1.smethod_4(ref num6, num7, num8, num9, 0U, 6, 49U, array);
			Class1.smethod_4(ref num9, num6, num7, num8, 7U, 10, 50U, array);
			Class1.smethod_4(ref num8, num9, num6, num7, 14U, 15, 51U, array);
			Class1.smethod_4(ref num7, num8, num9, num6, 5U, 21, 52U, array);
			Class1.smethod_4(ref num6, num7, num8, num9, 12U, 6, 53U, array);
			Class1.smethod_4(ref num9, num6, num7, num8, 3U, 10, 54U, array);
			Class1.smethod_4(ref num8, num9, num6, num7, 10U, 15, 55U, array);
			Class1.smethod_4(ref num7, num8, num9, num6, 1U, 21, 56U, array);
			Class1.smethod_4(ref num6, num7, num8, num9, 8U, 6, 57U, array);
			Class1.smethod_4(ref num9, num6, num7, num8, 15U, 10, 58U, array);
			Class1.smethod_4(ref num8, num9, num6, num7, 6U, 15, 59U, array);
			Class1.smethod_4(ref num7, num8, num9, num6, 13U, 21, 60U, array);
			Class1.smethod_4(ref num6, num7, num8, num9, 4U, 6, 61U, array);
			Class1.smethod_4(ref num9, num6, num7, num8, 11U, 10, 62U, array);
			Class1.smethod_4(ref num8, num9, num6, num7, 2U, 15, 63U, array);
			Class1.smethod_4(ref num7, num8, num9, num6, 9U, 21, 64U, array);
			num6 += num13;
			num7 += num14;
			num8 += num15;
			num9 += num16;
		}
		byte[] array4 = new byte[16];
		Array.Copy(BitConverter.GetBytes(num6), 0, array4, 0, 4);
		Array.Copy(BitConverter.GetBytes(num7), 0, array4, 4, 4);
		Array.Copy(BitConverter.GetBytes(num8), 0, array4, 8, 4);
		Array.Copy(BitConverter.GetBytes(num9), 0, array4, 12, 4);
		return array4;
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x00003078 File Offset: 0x00001278
	private static void smethod_1(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_2)
	{
		uint_1 = uint_2 + Class1.smethod_5(uint_1 + ((uint_2 & uint_3) | (~uint_2 & uint_4)) + object_2[(int)uint_5] + Class1.uint_0[(int)(uint_6 - 1U)], ushort_0);
	}

	// Token: 0x060002DA RID: 730 RVA: 0x000030A1 File Offset: 0x000012A1
	private static void smethod_2(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_2)
	{
		uint_1 = uint_2 + Class1.smethod_5(uint_1 + ((uint_2 & uint_4) | (uint_3 & ~uint_4)) + object_2[(int)uint_5] + Class1.uint_0[(int)(uint_6 - 1U)], ushort_0);
	}

	// Token: 0x060002DB RID: 731 RVA: 0x000030CA File Offset: 0x000012CA
	private static void smethod_3(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_2)
	{
		uint_1 = uint_2 + Class1.smethod_5(uint_1 + (uint_2 ^ uint_3 ^ uint_4) + object_2[(int)uint_5] + Class1.uint_0[(int)(uint_6 - 1U)], ushort_0);
	}

	// Token: 0x060002DC RID: 732 RVA: 0x000030F0 File Offset: 0x000012F0
	private static void smethod_4(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_2)
	{
		uint_1 = uint_2 + Class1.smethod_5(uint_1 + (uint_3 ^ (uint_2 | ~uint_4)) + object_2[(int)uint_5] + Class1.uint_0[(int)(uint_6 - 1U)], ushort_0);
	}

	// Token: 0x060002DD RID: 733 RVA: 0x00003117 File Offset: 0x00001317
	private static uint smethod_5(uint uint_1, ushort ushort_0)
	{
		return uint_1 >> (int)(32 - ushort_0) | uint_1 << (int)ushort_0;
	}

	// Token: 0x060002DE RID: 734 RVA: 0x00003129 File Offset: 0x00001329
	internal static bool smethod_6()
	{
		if (!Class1.bool_1)
		{
			Class1.smethod_8();
			Class1.bool_1 = true;
		}
		return Class1.bool_3;
	}

	// Token: 0x060002DF RID: 735 RVA: 0x00003142 File Offset: 0x00001342
	internal Class1()
	{
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x0001DB08 File Offset: 0x0001BD08
	private void method_0(byte[] byte_2, byte[] byte_3, byte[] byte_4)
	{
		int num = byte_4.Length % 4;
		int num2 = byte_4.Length / 4;
		byte[] array = new byte[byte_4.Length];
		int num3 = byte_2.Length / 4;
		uint num4 = 0U;
		if (num > 0)
		{
			num2++;
		}
		for (int i = 0; i < num2; i++)
		{
			int num5 = i % num3;
			int num6 = i * 4;
			uint num7 = (uint)(num5 * 4);
			uint num8 = (uint)((int)byte_2[(int)(num7 + 3U)] << 24 | (int)byte_2[(int)(num7 + 2U)] << 16 | (int)byte_2[(int)(num7 + 1U)] << 8 | (int)byte_2[(int)num7]);
			uint num9 = 255U;
			int num10 = 0;
			uint num11;
			if (i == num2 - 1 && num > 0)
			{
				num11 = 0U;
				num4 += num8;
				for (int j = 0; j < num; j++)
				{
					if (j > 0)
					{
						num11 <<= 8;
					}
					num11 |= (uint)byte_4[byte_4.Length - (1 + j)];
				}
			}
			else
			{
				num4 += num8;
				num7 = (uint)num6;
				num11 = (uint)((int)byte_4[(int)(num7 + 3U)] << 24 | (int)byte_4[(int)(num7 + 2U)] << 16 | (int)byte_4[(int)(num7 + 1U)] << 8 | (int)byte_4[(int)num7]);
			}
			uint num13;
			uint num12 = num13 = num4;
			uint num14 = (num13 >> 15 | num13 << 17) ^ 2917477082U;
			uint num15 = num14 & 16711935U;
			num14 &= 4278255360U;
			num13 = (num14 >> 8 | num15 << 8);
			num13 ^= num13 >> 15;
			num13 += 253620738U;
			num13 ^= num13 << 17;
			num13 += 977258660U;
			num13 ^= num13 >> 13;
			num13 += num13;
			num13 = 3075844864U - num13;
			num4 = num12 + (uint)num13;
			if (i == num2 - 1 && num > 0)
			{
				uint num16 = num4 ^ num11;
				for (int k = 0; k < num; k++)
				{
					if (k > 0)
					{
						num9 <<= 8;
						num10 += 8;
					}
					array[num6 + k] = (byte)((num16 & num9) >> num10);
				}
			}
			else
			{
				uint num17 = num4 ^ num11;
				array[num6] = (byte)(num17 & 255U);
				array[num6 + 1] = (byte)((num17 & 65280U) >> 8);
				array[num6 + 2] = (byte)((num17 & 16711680U) >> 16);
				array[num6 + 3] = (byte)((num17 & 4278190080U) >> 24);
			}
		}
		Class1.byte_0 = array;
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x0001DD78 File Offset: 0x0001BF78
	internal static SymmetricAlgorithm smethod_7()
	{
		SymmetricAlgorithm result = null;
		if (Class1.smethod_6())
		{
			result = new AesCryptoServiceProvider();
		}
		else
		{
			try
			{
				result = new RijndaelManaged();
			}
			catch
			{
				try
				{
					result = (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
				}
				catch
				{
					result = (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
				}
			}
		}
		return result;
	}

	// Token: 0x060002E2 RID: 738 RVA: 0x0001DDF8 File Offset: 0x0001BFF8
	internal static void smethod_8()
	{
		try
		{
			new MD5CryptoServiceProvider();
		}
		catch
		{
			Class1.bool_3 = true;
			return;
		}
		try
		{
			Class1.bool_3 = CryptoConfig.AllowOnlyFipsAlgorithms;
		}
		catch
		{
		}
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x0000314A File Offset: 0x0000134A
	internal static byte[] smethod_9(byte[] byte_2)
	{
		if (!Class1.smethod_6())
		{
			return new MD5CryptoServiceProvider().ComputeHash(byte_2);
		}
		return Class1.smethod_0(byte_2);
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x0001DE44 File Offset: 0x0001C044
	internal static void smethod_10(HashAlgorithm hashAlgorithm_0, Stream stream_0, uint uint_1, byte[] byte_2)
	{
		while (uint_1 > 0U)
		{
			int num = (uint_1 > (uint)byte_2.Length) ? byte_2.Length : ((int)uint_1);
			stream_0.Read(byte_2, 0, num);
			Class1.smethod_11(hashAlgorithm_0, byte_2, 0, num);
			uint_1 -= (uint)num;
		}
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x00003165 File Offset: 0x00001365
	internal static void smethod_11(HashAlgorithm hashAlgorithm_0, byte[] byte_2, int int_6, int int_7)
	{
		hashAlgorithm_0.TransformBlock(byte_2, int_6, int_7, byte_2, int_6);
	}

	// Token: 0x060002E6 RID: 742 RVA: 0x0001DE80 File Offset: 0x0001C080
	internal static uint smethod_12(uint uint_1, int int_6, long long_2, BinaryReader binaryReader_0)
	{
		for (int i = 0; i < int_6; i++)
		{
			binaryReader_0.BaseStream.Position = long_2 + (long)(i * 40 + 8);
			uint num = binaryReader_0.ReadUInt32();
			uint num2 = binaryReader_0.ReadUInt32();
			binaryReader_0.ReadUInt32();
			uint num3 = binaryReader_0.ReadUInt32();
			if (num2 <= uint_1 && uint_1 < num2 + num)
			{
				return num3 + uint_1 - num2;
			}
		}
		return 0U;
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x00003173 File Offset: 0x00001373
	private static uint smethod_13(uint uint_1)
	{
		return (uint)"{11111-22222-10009-11112}".Length;
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x0001DEDC File Offset: 0x0001C0DC
	private static void smethod_14(object object_2, int int_6)
	{
		Class5.smethod_2(0, new object[]
		{
			object_2,
			int_6
		}, null);
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x0001DF1C File Offset: 0x0001C11C
	internal static string smethod_15(string string_1)
	{
		"{11111-22222-50001-00000}".Trim();
		byte[] array = Convert.FromBase64String(string_1);
		return Encoding.Unicode.GetString(array, 0, array.Length);
	}

	// Token: 0x060002EA RID: 746 RVA: 0x0000317F File Offset: 0x0000137F
	private static int smethod_16()
	{
		return 5;
	}

	// Token: 0x060002EB RID: 747 RVA: 0x0001DF4C File Offset: 0x0001C14C
	private static void smethod_17()
	{
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	// Token: 0x060002EC RID: 748 RVA: 0x0001DF74 File Offset: 0x0001C174
	private static Delegate smethod_18(IntPtr intptr_3, Type type_0)
	{
		return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[]
		{
			typeof(IntPtr),
			typeof(Type)
		}).Invoke(null, new object[]
		{
			intptr_3,
			type_0
		});
	}

	// Token: 0x060002ED RID: 749 RVA: 0x0001DFD4 File Offset: 0x0001C1D4
	internal static object smethod_19(Assembly assembly_1)
	{
		try
		{
			if (File.Exists(((Assembly)assembly_1).Location))
			{
				return ((Assembly)assembly_1).Location;
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(((Assembly)assembly_1).GetName().CodeBase.ToString().Replace("file:///", "")))
			{
				return ((Assembly)assembly_1).GetName().CodeBase.ToString().Replace("file:///", "");
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(assembly_1.GetType().GetProperty("Location").GetValue(assembly_1, new object[0]).ToString()))
			{
				return assembly_1.GetType().GetProperty("Location").GetValue(assembly_1, new object[0]).ToString();
			}
		}
		catch
		{
		}
		return "";
	}

	// Token: 0x060002EE RID: 750
	[DllImport("kernel32")]
	public static extern IntPtr LoadLibrary(string string_1);

	// Token: 0x060002EF RID: 751
	[DllImport("kernel32", CharSet = CharSet.Ansi)]
	public static extern IntPtr GetProcAddress(IntPtr intptr_3, string string_1);

	// Token: 0x060002F0 RID: 752 RVA: 0x0001E0E4 File Offset: 0x0001C2E4
	private static IntPtr smethod_20(IntPtr intptr_3, string string_1, uint uint_1)
	{
		if (Class1.delegate3_0 == null)
		{
			Class1.delegate3_0 = (Class1.Delegate3)Marshal.GetDelegateForFunctionPointer(Class1.GetProcAddress(Class1.smethod_26(), "Find ".Trim() + "ResourceA"), typeof(Class1.Delegate3));
		}
		return Class1.delegate3_0(intptr_3, string_1, uint_1);
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x0001E13C File Offset: 0x0001C33C
	private static IntPtr smethod_21(IntPtr intptr_3, uint uint_1, uint uint_2, uint uint_3)
	{
		if (Class1.delegate4_0 == null)
		{
			Class1.delegate4_0 = (Class1.Delegate4)Marshal.GetDelegateForFunctionPointer(Class1.GetProcAddress(Class1.smethod_26(), "Virtual ".Trim() + "Alloc"), typeof(Class1.Delegate4));
		}
		return Class1.delegate4_0(intptr_3, uint_1, uint_2, uint_3);
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x0001E198 File Offset: 0x0001C398
	private static int smethod_22(IntPtr intptr_3, IntPtr intptr_4, [In] [Out] byte[] byte_2, uint uint_1, out IntPtr intptr_5)
	{
		if (Class1.delegate5_0 == null)
		{
			Class1.delegate5_0 = (Class1.Delegate5)Marshal.GetDelegateForFunctionPointer(Class1.GetProcAddress(Class1.smethod_26(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(Class1.Delegate5));
		}
		return Class1.delegate5_0(intptr_3, intptr_4, byte_2, uint_1, out intptr_5);
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x0001E200 File Offset: 0x0001C400
	private static int smethod_23(IntPtr intptr_3, int int_6, int int_7, ref int int_8)
	{
		if (Class1.delegate6_0 == null)
		{
			Class1.delegate6_0 = (Class1.Delegate6)Marshal.GetDelegateForFunctionPointer(Class1.GetProcAddress(Class1.smethod_26(), "Virtual ".Trim() + "Protect"), typeof(Class1.Delegate6));
		}
		return Class1.delegate6_0(intptr_3, int_6, int_7, ref int_8);
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x0001E25C File Offset: 0x0001C45C
	private static IntPtr smethod_24(uint uint_1, int int_6, uint uint_2)
	{
		if (Class1.delegate7_0 == null)
		{
			Class1.delegate7_0 = (Class1.Delegate7)Marshal.GetDelegateForFunctionPointer(Class1.GetProcAddress(Class1.smethod_26(), "Open ".Trim() + "Process"), typeof(Class1.Delegate7));
		}
		return Class1.delegate7_0(uint_1, int_6, uint_2);
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x0001E2B4 File Offset: 0x0001C4B4
	private static int smethod_25(IntPtr intptr_3)
	{
		if (Class1.delegate8_0 == null)
		{
			Class1.delegate8_0 = (Class1.Delegate8)Marshal.GetDelegateForFunctionPointer(Class1.GetProcAddress(Class1.smethod_26(), "Close ".Trim() + "Handle"), typeof(Class1.Delegate8));
		}
		return Class1.delegate8_0(intptr_3);
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x00003182 File Offset: 0x00001382
	private static IntPtr smethod_26()
	{
		if (Class1.intptr_0 == IntPtr.Zero)
		{
			Class1.intptr_0 = Class1.LoadLibrary("kernel ".Trim() + "32.dll");
		}
		return Class1.intptr_0;
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x0001E30C File Offset: 0x0001C50C
	private static byte[] smethod_27(string string_1)
	{
		byte[] array;
		using (FileStream fileStream = new FileStream(string_1, FileMode.Open, FileAccess.Read, FileShare.Read))
		{
			int num = 0;
			int i = (int)fileStream.Length;
			array = new byte[i];
			while (i > 0)
			{
				int num2 = fileStream.Read(array, num, i);
				num += num2;
				i -= num2;
			}
		}
		return array;
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x000031B8 File Offset: 0x000013B8
	internal static byte[] smethod_28(MemoryStream memoryStream_0)
	{
		return ((MemoryStream)memoryStream_0).ToArray();
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x0001E36C File Offset: 0x0001C56C
	private static byte[] smethod_29(byte[] byte_2)
	{
		Stream stream = new MemoryStream();
		SymmetricAlgorithm symmetricAlgorithm = Class1.smethod_7();
		symmetricAlgorithm.Key = new byte[]
		{
			96,
			206,
			45,
			197,
			124,
			193,
			20,
			116,
			198,
			178,
			148,
			240,
			211,
			59,
			70,
			151,
			102,
			200,
			217,
			112,
			6,
			195,
			15,
			1,
			136,
			17,
			111,
			99,
			229,
			90,
			150,
			225
		};
		symmetricAlgorithm.IV = new byte[]
		{
			229,
			247,
			170,
			32,
			74,
			66,
			195,
			224,
			144,
			170,
			208,
			30,
			64,
			60,
			253,
			40
		};
		CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(byte_2, 0, byte_2.Length);
		cryptoStream.Close();
		return Class1.smethod_28(stream);
	}

	// Token: 0x060002FA RID: 762 RVA: 0x0001E3D8 File Offset: 0x0001C5D8
	private byte[] method_1()
	{
		return null;
	}

	// Token: 0x060002FB RID: 763 RVA: 0x0001E3D8 File Offset: 0x0001C5D8
	private byte[] method_2()
	{
		return null;
	}

	// Token: 0x060002FC RID: 764 RVA: 0x000031C5 File Offset: 0x000013C5
	private byte[] method_3()
	{
		int length = "{11111-22222-20001-00001}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x060002FD RID: 765 RVA: 0x000031E0 File Offset: 0x000013E0
	private byte[] method_4()
	{
		int length = "{11111-22222-20001-00002}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x060002FE RID: 766 RVA: 0x000031FB File Offset: 0x000013FB
	private byte[] method_5()
	{
		int length = "{11111-22222-30001-00001}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x060002FF RID: 767 RVA: 0x00003216 File Offset: 0x00001416
	private byte[] method_6()
	{
		int length = "{11111-22222-30001-00002}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x06000300 RID: 768 RVA: 0x00003231 File Offset: 0x00001431
	internal byte[] method_7()
	{
		int length = "{11111-22222-40001-00001}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x06000301 RID: 769 RVA: 0x0000324C File Offset: 0x0000144C
	internal byte[] method_8()
	{
		int length = "{11111-22222-40001-00002}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x06000302 RID: 770 RVA: 0x00003267 File Offset: 0x00001467
	internal byte[] method_9()
	{
		int length = "{11111-22222-50001-00001}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x06000303 RID: 771 RVA: 0x00003282 File Offset: 0x00001482
	internal byte[] method_10()
	{
		int length = "{11111-22222-50001-00002}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x06000304 RID: 772 RVA: 0x0000329D File Offset: 0x0000149D
	internal static bool smethod_30()
	{
		return null == null;
	}

	// Token: 0x06000305 RID: 773 RVA: 0x000032A3 File Offset: 0x000014A3
	internal static object smethod_31()
	{
		return null;
	}

	// Token: 0x04000350 RID: 848
	internal static Assembly assembly_0;

	// Token: 0x04000351 RID: 849
	internal static RSACryptoServiceProvider rsacryptoServiceProvider_0;

	// Token: 0x04000352 RID: 850
	private static int int_0;

	// Token: 0x04000353 RID: 851
	private static List<string> list_0;

	// Token: 0x04000354 RID: 852
	private static List<int> list_1;

	// Token: 0x04000355 RID: 853
	private static byte[] byte_0;

	// Token: 0x04000356 RID: 854
	private static IntPtr MnjeHbSuAy;

	// Token: 0x04000357 RID: 855
	private static bool bool_0;

	// Token: 0x04000358 RID: 856
	private static int int_1;

	// Token: 0x04000359 RID: 857
	private static Class1.Delegate3 delegate3_0;

	// Token: 0x0400035A RID: 858
	private static Class1.Delegate5 delegate5_0;

	// Token: 0x0400035B RID: 859
	private static Class1.Delegate6 delegate6_0;

	// Token: 0x0400035C RID: 860
	private static Class1.Delegate8 delegate8_0;

	// Token: 0x0400035D RID: 861
	internal static Hashtable hashtable_0;

	// Token: 0x0400035E RID: 862
	internal static Class1.Delegate2 delegate2_0;

	// Token: 0x0400035F RID: 863
	private static bool bool_1;

	// Token: 0x04000360 RID: 864
	private static IntPtr intptr_0;

	// Token: 0x04000361 RID: 865
	private static int int_2;

	// Token: 0x04000362 RID: 866
	private static int[] int_3;

	// Token: 0x04000363 RID: 867
	private static long long_0;

	// Token: 0x04000364 RID: 868
	private static bool bool_2 = false;

	// Token: 0x04000365 RID: 869
	private static long long_1;

	// Token: 0x04000366 RID: 870
	private static Class1.Delegate7 delegate7_0;

	// Token: 0x04000367 RID: 871
	private static Class1.Delegate4 delegate4_0;

	// Token: 0x04000368 RID: 872
	private static int int_4;

	// Token: 0x04000369 RID: 873
	private static SortedList sortedList_0;

	// Token: 0x0400036A RID: 874
	internal static Class1.Delegate2 delegate2_1;

	// Token: 0x0400036B RID: 875
	private static uint[] uint_0;

	// Token: 0x0400036C RID: 876
	private static IntPtr intptr_1;

	// Token: 0x0400036D RID: 877
	private static object object_0;

	// Token: 0x0400036E RID: 878
	private static bool bool_3;

	// Token: 0x0400036F RID: 879
	private static bool bool_4;

	// Token: 0x04000370 RID: 880
	private static object object_1;

	// Token: 0x04000371 RID: 881
	private static Dictionary<int, int> dictionary_0;

	// Token: 0x04000372 RID: 882
	private static int int_5;

	// Token: 0x04000373 RID: 883
	private static string[] string_0;

	// Token: 0x04000374 RID: 884
	private static bool bool_5;

	// Token: 0x04000375 RID: 885
	[Class1.Attribute0(typeof(Class1.Attribute0.Class2<object>[]))]
	private static bool bool_6;

	// Token: 0x04000376 RID: 886
	private static byte[] byte_1;

	// Token: 0x04000377 RID: 887
	private static IntPtr intptr_2;

	// Token: 0x02000088 RID: 136
	// (Invoke) Token: 0x06000307 RID: 775
	private delegate void Delegate1(object o);

	// Token: 0x02000089 RID: 137
	internal class Attribute0 : Attribute
	{
		// Token: 0x0600030A RID: 778 RVA: 0x000032A6 File Offset: 0x000014A6
		public Attribute0(object object_0)
		{
		}

		// Token: 0x0200008A RID: 138
		internal class Class2<T>
		{
			// Token: 0x0600030C RID: 780 RVA: 0x000032AE File Offset: 0x000014AE
			internal static bool smethod_0()
			{
				return Class1.Attribute0.Class2<T>.object_0 == null;
			}

			// Token: 0x0600030D RID: 781 RVA: 0x000032B8 File Offset: 0x000014B8
			internal static object smethod_1()
			{
				return Class1.Attribute0.Class2<T>.object_0;
			}

			// Token: 0x04000378 RID: 888
			internal static object object_0;
		}
	}

	// Token: 0x0200008B RID: 139
	internal class Class3
	{
		// Token: 0x0600030E RID: 782 RVA: 0x0001E3E8 File Offset: 0x0001C5E8
		internal static string smethod_0(string string_0, string string_1)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(string_0);
			byte[] key = new byte[]
			{
				82,
				102,
				104,
				110,
				32,
				77,
				24,
				34,
				118,
				181,
				51,
				17,
				18,
				51,
				12,
				109,
				10,
				32,
				77,
				24,
				34,
				158,
				161,
				41,
				97,
				28,
				118,
				181,
				5,
				25,
				1,
				88
			};
			byte[] iv = Class1.smethod_9(Encoding.Unicode.GetBytes(string_1));
			MemoryStream memoryStream = new MemoryStream();
			SymmetricAlgorithm symmetricAlgorithm = Class1.smethod_7();
			symmetricAlgorithm.Key = key;
			symmetricAlgorithm.IV = iv;
			CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.Close();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
	}

	// Token: 0x0200008C RID: 140
	// (Invoke) Token: 0x06000311 RID: 785
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate uint Delegate2(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

	// Token: 0x0200008D RID: 141
	// (Invoke) Token: 0x06000315 RID: 789
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr xpQievsmwUqeYqxYcuW();

	// Token: 0x0200008E RID: 142
	internal struct Struct1
	{
		// Token: 0x04000379 RID: 889
		internal bool bool_0;

		// Token: 0x0400037A RID: 890
		internal byte[] byte_0;
	}

	// Token: 0x0200008F RID: 143
	internal class Class4
	{
		// Token: 0x06000318 RID: 792 RVA: 0x000032BF File Offset: 0x000014BF
		public Class4(Stream stream_0)
		{
			this.binaryReader_0 = new BinaryReader(stream_0);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x000032D3 File Offset: 0x000014D3
		internal Stream method_0()
		{
			return this.binaryReader_0.BaseStream;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x000032E0 File Offset: 0x000014E0
		internal byte[] method_1(int int_0)
		{
			return this.binaryReader_0.ReadBytes(int_0);
		}

		// Token: 0x0600031B RID: 795 RVA: 0x000032EE File Offset: 0x000014EE
		internal int method_2(byte[] byte_0, int int_0, int int_1)
		{
			return this.binaryReader_0.Read(byte_0, int_0, int_1);
		}

		// Token: 0x0600031C RID: 796 RVA: 0x000032FE File Offset: 0x000014FE
		internal int method_3()
		{
			return this.binaryReader_0.ReadInt32();
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0000330B File Offset: 0x0000150B
		internal void method_4()
		{
			this.binaryReader_0.Close();
		}

		// Token: 0x0400037B RID: 891
		private BinaryReader binaryReader_0;
	}

	// Token: 0x02000090 RID: 144
	// (Invoke) Token: 0x0600031F RID: 799
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private delegate IntPtr Delegate3(IntPtr hModule, string lpName, uint lpType);

	// Token: 0x02000091 RID: 145
	// (Invoke) Token: 0x06000323 RID: 803
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr Delegate4(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

	// Token: 0x02000092 RID: 146
	// (Invoke) Token: 0x06000327 RID: 807
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int Delegate5(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

	// Token: 0x02000093 RID: 147
	// (Invoke) Token: 0x0600032B RID: 811
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int Delegate6(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

	// Token: 0x02000094 RID: 148
	// (Invoke) Token: 0x0600032F RID: 815
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr Delegate7(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

	// Token: 0x02000095 RID: 149
	// (Invoke) Token: 0x06000333 RID: 819
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int Delegate8(IntPtr ptr);

	// Token: 0x02000096 RID: 150
	[Flags]
	private enum Enum0
	{

	}
}
