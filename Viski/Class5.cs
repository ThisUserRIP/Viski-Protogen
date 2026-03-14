using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

// Token: 0x02000097 RID: 151
internal class Class5
{
	// Token: 0x06000336 RID: 822 RVA: 0x00003318 File Offset: 0x00001518
	internal static object[] smethod_0()
	{
		return new object[1];
	}

	// Token: 0x06000337 RID: 823 RVA: 0x0001E468 File Offset: 0x0001C668
	internal static object[] smethod_1<T>(int int_1, object object_1, object object_2, ref T gparam_0)
	{
		Class5.Class11 @class = null;
		object obj = Class5.object_0;
		lock (obj)
		{
			if (!Class5.bool_0)
			{
				Class5.bool_0 = true;
				Class5.smethod_4();
			}
			if (Class5.class11_0[int_1] != null)
			{
				@class = Class5.class11_0[int_1];
			}
			else
			{
				Class5.binaryReader_0.BaseStream.Position = (long)Class5.int_0[int_1];
				@class = new Class5.Class11();
				Module module = typeof(Class5).Module;
				int metadataToken = Class5.smethod_6(Class5.binaryReader_0);
				int num = Class5.smethod_6(Class5.binaryReader_0);
				int num2 = Class5.smethod_6(Class5.binaryReader_0);
				int num3 = Class5.smethod_6(Class5.binaryReader_0);
				@class.methodBase_0 = module.ResolveMethod(metadataToken);
				ParameterInfo[] parameters = @class.methodBase_0.GetParameters();
				@class.class7_0 = new Class5.Class7[parameters.Length];
				for (int i = 0; i < parameters.Length; i++)
				{
					Type type = parameters[i].ParameterType;
					Class5.Class7 class2 = new Class5.Class7();
					class2.bool_0 = type.IsByRef;
					class2.int_0 = i;
					@class.class7_0[i] = class2;
					if (type.IsByRef)
					{
						type = type.GetElementType();
					}
					Class5.Enum1 enum1_;
					if (type == typeof(string))
					{
						enum1_ = (Class5.Enum1)14;
					}
					else if (type == typeof(byte))
					{
						enum1_ = (Class5.Enum1)2;
					}
					else if (type == typeof(sbyte))
					{
						enum1_ = (Class5.Enum1)1;
					}
					else if (type == typeof(short))
					{
						enum1_ = (Class5.Enum1)3;
					}
					else if (type == typeof(ushort))
					{
						enum1_ = (Class5.Enum1)4;
					}
					else if (type == typeof(int))
					{
						enum1_ = (Class5.Enum1)5;
					}
					else if (type == typeof(uint))
					{
						enum1_ = (Class5.Enum1)6;
					}
					else if (type == typeof(long))
					{
						enum1_ = (Class5.Enum1)7;
					}
					else if (type == typeof(ulong))
					{
						enum1_ = (Class5.Enum1)8;
					}
					else if (type == typeof(float))
					{
						enum1_ = (Class5.Enum1)9;
					}
					else if (type == typeof(double))
					{
						enum1_ = (Class5.Enum1)10;
					}
					else if (type == typeof(bool))
					{
						enum1_ = (Class5.Enum1)11;
					}
					else if (type == typeof(IntPtr))
					{
						enum1_ = (Class5.Enum1)12;
					}
					else if (type == typeof(UIntPtr))
					{
						enum1_ = (Class5.Enum1)13;
					}
					else if (type == typeof(char))
					{
						enum1_ = (Class5.Enum1)15;
					}
					else
					{
						enum1_ = (Class5.Enum1)0;
					}
					class2.enum1_0 = enum1_;
				}
				@class.list_1 = new List<Class5.Class8>(num);
				for (int j = 0; j < num; j++)
				{
					int num4 = Class5.smethod_6(Class5.binaryReader_0);
					Class5.Class8 class3 = new Class5.Class8();
					class3.type_0 = null;
					if (num4 >= 0 && num4 < 50)
					{
						class3.enum1_0 = (Class5.Enum1)(num4 & 31);
						class3.bool_0 = ((num4 & 32) > 0);
					}
					class3.int_0 = j;
					@class.list_1.Add(class3);
				}
				@class.list_2 = new List<Class5.Class9>(num2);
				for (int k = 0; k < num2; k++)
				{
					int num5 = Class5.smethod_6(Class5.binaryReader_0);
					int int_2 = Class5.smethod_6(Class5.binaryReader_0);
					Class5.Class9 class4 = new Class5.Class9();
					class4.int_0 = num5;
					class4.int_1 = int_2;
					Class5.Class10 class5 = new Class5.Class10();
					class4.class10_0 = class5;
					num5 = Class5.smethod_6(Class5.binaryReader_0);
					int_2 = Class5.smethod_6(Class5.binaryReader_0);
					int num6 = Class5.smethod_6(Class5.binaryReader_0);
					class5.int_0 = num5;
					class5.int_1 = int_2;
					class5.int_3 = num6;
					if (num6 == 0)
					{
						class5.type_0 = module.ResolveType(Class5.smethod_6(Class5.binaryReader_0));
					}
					else if (num6 == 1)
					{
						class5.int_2 = Class5.smethod_6(Class5.binaryReader_0);
					}
					else
					{
						Class5.smethod_6(Class5.binaryReader_0);
					}
					@class.list_2.Add(class4);
				}
				@class.list_2.Sort(new Comparison<Class5.Class9>(Class5.Class31<T>.<>9.method_0));
				@class.list_0 = new List<Class5.Class6>(num3);
				for (int l = 0; l < num3; l++)
				{
					Class5.Class6 class6 = new Class5.Class6();
					byte b = Class5.binaryReader_0.ReadByte();
					class6.enum3_0 = (Class5.Enum3)b;
					if (b >= 176)
					{
						throw new Exception();
					}
					int num7 = (int)Class5.byte_0[(int)b];
					if (num7 == 0)
					{
						class6.object_0 = null;
					}
					else
					{
						object obj2;
						switch (num7)
						{
						case 1:
							obj2 = Class5.smethod_6(Class5.binaryReader_0);
							break;
						case 2:
							obj2 = Class5.binaryReader_0.ReadInt64();
							break;
						case 3:
							obj2 = Class5.binaryReader_0.ReadSingle();
							break;
						case 4:
							obj2 = Class5.binaryReader_0.ReadDouble();
							break;
						case 5:
						{
							int num8 = Class5.smethod_6(Class5.binaryReader_0);
							int[] array = new int[num8];
							for (int m = 0; m < num8; m++)
							{
								array[m] = Class5.smethod_6(Class5.binaryReader_0);
							}
							obj2 = array;
							break;
						}
						default:
							throw new Exception();
						}
						class6.object_0 = obj2;
					}
					@class.list_0.Add(class6);
				}
				Class5.class11_0[int_1] = @class;
			}
		}
		Class5.Class14 class7 = new Class5.Class14();
		class7.class11_0 = @class;
		ParameterInfo[] parameters2 = @class.methodBase_0.GetParameters();
		bool flag2 = false;
		int num9 = 0;
		if (@class.methodBase_0 is MethodInfo && ((MethodInfo)@class.methodBase_0).ReturnType != typeof(void))
		{
			flag2 = true;
		}
		if (@class.methodBase_0.IsStatic)
		{
			class7.class16_0 = new Class5.Class16[parameters2.Length];
			for (int n = 0; n < parameters2.Length; n++)
			{
				Type parameterType = parameters2[n].ParameterType;
				class7.class16_0[n] = Class5.Class16.smethod_1(parameterType, object_1[n]);
				if (parameterType.IsByRef)
				{
					num9++;
				}
			}
		}
		else
		{
			class7.class16_0 = new Class5.Class16[parameters2.Length + 1];
			if (@class.methodBase_0.DeclaringType.IsValueType)
			{
				class7.class16_0[0] = new Class5.Class27(new Class5.Class28(object_2), @class.methodBase_0.DeclaringType);
			}
			else
			{
				class7.class16_0[0] = new Class5.Class28(object_2);
			}
			for (int num10 = 0; num10 < parameters2.Length; num10++)
			{
				Type parameterType2 = parameters2[num10].ParameterType;
				if (parameterType2.IsByRef)
				{
					class7.class16_0[num10 + 1] = Class5.Class16.smethod_1(parameterType2, object_1[num10]);
					num9++;
				}
				else
				{
					class7.class16_0[num10 + 1] = Class5.Class16.smethod_1(parameterType2, object_1[num10]);
				}
			}
		}
		class7.class16_1 = new Class5.Class16[@class.list_1.Count];
		for (int num11 = 0; num11 < @class.list_1.Count; num11++)
		{
			Class5.Class8 class8 = @class.list_1[num11];
			switch (class8.enum1_0)
			{
			case (Class5.Enum1)0:
				class7.class16_1[num11] = null;
				break;
			case (Class5.Enum1)1:
			case (Class5.Enum1)2:
			case (Class5.Enum1)3:
			case (Class5.Enum1)4:
			case (Class5.Enum1)5:
			case (Class5.Enum1)6:
			case (Class5.Enum1)11:
			case (Class5.Enum1)15:
				class7.class16_1[num11] = new Class5.Class18(0, class8.enum1_0);
				break;
			case (Class5.Enum1)7:
			case (Class5.Enum1)8:
				class7.class16_1[num11] = new Class5.Class19(0L, class8.enum1_0);
				break;
			case (Class5.Enum1)9:
			case (Class5.Enum1)10:
				class7.class16_1[num11] = new Class5.Class21(0.0, class8.enum1_0);
				break;
			case (Class5.Enum1)12:
				class7.class16_1[num11] = new Class5.Class20(IntPtr.Zero);
				break;
			case (Class5.Enum1)13:
				class7.class16_1[num11] = new Class5.Class20(UIntPtr.Zero);
				break;
			case (Class5.Enum1)14:
				class7.class16_1[num11] = null;
				break;
			case (Class5.Enum1)16:
				class7.class16_1[num11] = new Class5.Class28(null);
				break;
			}
		}
		try
		{
			class7.method_0();
		}
		finally
		{
			class7.method_1();
		}
		int num12 = 0;
		if (flag2)
		{
			num12 = 1;
		}
		num12 += num9;
		object[] array2 = new object[num12];
		if (flag2)
		{
			array2[0] = null;
		}
		if (@class.methodBase_0 is MethodInfo)
		{
			MethodInfo methodInfo = (MethodInfo)@class.methodBase_0;
			if (methodInfo.ReturnType != typeof(void) && class7.class16_2 != null)
			{
				array2[0] = class7.class16_2.vmethod_4(methodInfo.ReturnType);
			}
		}
		if (num9 > 0)
		{
			int num13 = 0;
			if (flag2)
			{
				num13++;
			}
			for (int num14 = 0; num14 < parameters2.Length; num14++)
			{
				Type type2 = parameters2[num14].ParameterType;
				if (type2.IsByRef)
				{
					type2 = type2.GetElementType();
					if (class7.class16_0[num14] != null)
					{
						if (@class.methodBase_0.IsStatic)
						{
							array2[num13] = class7.class16_0[num14].vmethod_4(type2);
						}
						else
						{
							array2[num13] = class7.class16_0[num14 + 1].vmethod_4(type2);
						}
					}
					else
					{
						array2[num13] = null;
					}
					num13++;
				}
			}
		}
		if (!@class.methodBase_0.IsStatic && @class.methodBase_0.DeclaringType.IsValueType)
		{
			gparam_0 = (T)((object)class7.class16_0[0].vmethod_4(@class.methodBase_0.DeclaringType));
		}
		return array2;
	}

	// Token: 0x06000338 RID: 824 RVA: 0x0001EE48 File Offset: 0x0001D048
	internal static object[] smethod_2(int int_1, object object_1, object object_2)
	{
		int num = 0;
		return Class5.smethod_1<int>(int_1, object_1, object_2, ref num);
	}

	// Token: 0x06000339 RID: 825 RVA: 0x00003320 File Offset: 0x00001520
	internal static object[] smethod_3<T>(int int_1, object object_1, ref T gparam_0)
	{
		return Class5.smethod_1<T>(int_1, object_1, gparam_0, ref gparam_0);
	}

	// Token: 0x0600033A RID: 826 RVA: 0x0001EE64 File Offset: 0x0001D064
	internal static void smethod_4()
	{
		if (Class5.int_0 == null)
		{
			BinaryReader binaryReader = new BinaryReader(typeof(Class5).Assembly.GetManifestResourceStream("ngkGgOj1D4nnYZtgiq.IyMdTB2j58qJhAWPiL"));
			binaryReader.BaseStream.Position = 0L;
			byte[] byte_ = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
			binaryReader.Close();
			Class5.smethod_5(byte_);
		}
	}

	// Token: 0x0600033B RID: 827 RVA: 0x0001EECC File Offset: 0x0001D0CC
	internal static void smethod_5(byte[] byte_1)
	{
		Class5.binaryReader_0 = new BinaryReader(new MemoryStream(byte_1));
		Class5.byte_0 = new byte[255];
		int num = Class5.smethod_6(Class5.binaryReader_0);
		for (int i = 0; i < num; i++)
		{
			int num2 = (int)Class5.binaryReader_0.ReadByte();
			Class5.byte_0[num2] = Class5.binaryReader_0.ReadByte();
		}
		num = Class5.smethod_6(Class5.binaryReader_0);
		Class5.list_0 = new List<string>(num);
		for (int j = 0; j < num; j++)
		{
			Class5.list_0.Add(Encoding.Unicode.GetString(Class5.binaryReader_0.ReadBytes(Class5.smethod_6(Class5.binaryReader_0))));
		}
		num = Class5.smethod_6(Class5.binaryReader_0);
		Class5.class11_0 = new Class5.Class11[num];
		Class5.int_0 = new int[num];
		for (int k = 0; k < num; k++)
		{
			Class5.class11_0[k] = null;
			Class5.int_0[k] = Class5.smethod_6(Class5.binaryReader_0);
		}
		int num3 = (int)Class5.binaryReader_0.BaseStream.Position;
		for (int l = 0; l < num; l++)
		{
			int num4 = Class5.int_0[l];
			Class5.int_0[l] = num3;
			num3 += num4;
		}
	}

	// Token: 0x0600033C RID: 828 RVA: 0x0001F014 File Offset: 0x0001D214
	internal static int smethod_6(BinaryReader binaryReader_1)
	{
		bool flag = false;
		uint num = (uint)binaryReader_1.ReadByte();
		uint num2 = 0U | (num & 63U);
		if ((num & 64U) != 0U)
		{
			flag = true;
		}
		if (num >= 128U)
		{
			int num3 = 0;
			for (;;)
			{
				uint num4 = (uint)binaryReader_1.ReadByte();
				num2 |= (num4 & 127U) << 7 * num3 + 6;
				if (num4 < 128U)
				{
					break;
				}
				num3++;
			}
			if (!flag)
			{
				return (int)num2;
			}
			return (int)(~(int)num2);
		}
		else
		{
			if (!flag)
			{
				return (int)num2;
			}
			return (int)(~(int)num2);
		}
	}

	// Token: 0x0400037D RID: 893
	internal static Class5.Class11[] class11_0 = null;

	// Token: 0x0400037E RID: 894
	internal static int[] int_0 = null;

	// Token: 0x0400037F RID: 895
	internal static List<string> list_0;

	// Token: 0x04000380 RID: 896
	private static BinaryReader binaryReader_0;

	// Token: 0x04000381 RID: 897
	private static byte[] byte_0;

	// Token: 0x04000382 RID: 898
	private static bool bool_0 = false;

	// Token: 0x04000383 RID: 899
	private static object object_0 = new object();

	// Token: 0x02000098 RID: 152
	[StructLayout(LayoutKind.Explicit)]
	public struct Struct2
	{
		// Token: 0x04000384 RID: 900
		[FieldOffset(0)]
		public byte byte_0;

		// Token: 0x04000385 RID: 901
		[FieldOffset(0)]
		public sbyte sbyte_0;

		// Token: 0x04000386 RID: 902
		[FieldOffset(0)]
		public ushort ushort_0;

		// Token: 0x04000387 RID: 903
		[FieldOffset(0)]
		public short short_0;

		// Token: 0x04000388 RID: 904
		[FieldOffset(0)]
		public uint uint_0;

		// Token: 0x04000389 RID: 905
		[FieldOffset(0)]
		public int int_0;
	}

	// Token: 0x02000099 RID: 153
	private class Class18 : Class5.Class17
	{
		// Token: 0x0600033F RID: 831 RVA: 0x0001F0BC File Offset: 0x0001D2BC
		internal override void vmethod_10(Class5.Class16 class16_0)
		{
			this.struct2_0 = ((Class5.Class18)class16_0).struct2_0;
			this.enum1_0 = ((Class5.Class18)class16_0).enum1_0;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0001F0EC File Offset: 0x0001D2EC
		internal override void vmethod_2(Class5.Class16 class16_0)
		{
			this.vmethod_10(class16_0);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0001F100 File Offset: 0x0001D300
		public Class18(bool bool_0)
		{
			this.enum4_0 = (Class5.Enum4)1;
			if (!bool_0)
			{
				this.struct2_0.int_0 = 0;
			}
			else
			{
				this.struct2_0.int_0 = 1;
			}
			this.enum1_0 = (Class5.Enum1)11;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0001F140 File Offset: 0x0001D340
		public Class18(Class5.Class18 class18_0)
		{
			this.enum4_0 = class18_0.enum4_0;
			this.struct2_0.int_0 = class18_0.struct2_0.int_0;
			this.enum1_0 = class18_0.enum1_0;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00003335 File Offset: 0x00001535
		public override Class5.Class17 vmethod_74()
		{
			return new Class5.Class18(this);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0001F184 File Offset: 0x0001D384
		public Class18(int int_0)
		{
			this.enum4_0 = (Class5.Enum4)1;
			this.struct2_0.int_0 = int_0;
			this.enum1_0 = (Class5.Enum1)5;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0001F1B4 File Offset: 0x0001D3B4
		public Class18(uint uint_0)
		{
			this.enum4_0 = (Class5.Enum4)1;
			this.struct2_0.uint_0 = uint_0;
			this.enum1_0 = (Class5.Enum1)6;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0001F1E4 File Offset: 0x0001D3E4
		public Class18(int int_0, Class5.Enum1 enum1_1)
		{
			this.enum4_0 = (Class5.Enum4)1;
			this.struct2_0.int_0 = int_0;
			this.enum1_0 = enum1_1;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0001F214 File Offset: 0x0001D414
		public Class18(uint uint_0, Class5.Enum1 enum1_1)
		{
			this.enum4_0 = (Class5.Enum4)1;
			this.struct2_0.uint_0 = uint_0;
			this.enum1_0 = enum1_1;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0001F244 File Offset: 0x0001D444
		public override bool vmethod_11()
		{
			Class5.Enum1 @enum = this.enum1_0;
			switch (@enum)
			{
			case (Class5.Enum1)1:
			case (Class5.Enum1)3:
			case (Class5.Enum1)5:
			case (Class5.Enum1)7:
				goto IL_4A;
			case (Class5.Enum1)2:
			case (Class5.Enum1)4:
			case (Class5.Enum1)6:
				break;
			default:
				if (@enum == (Class5.Enum1)11)
				{
					goto IL_4A;
				}
				if (@enum == (Class5.Enum1)15)
				{
					goto IL_4A;
				}
				break;
			}
			return this.struct2_0.uint_0 == 0U;
			IL_4A:
			return this.struct2_0.int_0 == 0;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000333D File Offset: 0x0000153D
		public override bool vmethod_12()
		{
			return !this.vmethod_11();
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0001F2AC File Offset: 0x0001D4AC
		public override Class5.Class16 vmethod_13(Class5.Enum1 enum1_1)
		{
			switch (enum1_1)
			{
			case (Class5.Enum1)1:
				return this.vmethod_15();
			case (Class5.Enum1)2:
				return this.vmethod_16();
			case (Class5.Enum1)3:
				return this.vmethod_17();
			case (Class5.Enum1)4:
				return this.vmethod_18();
			case (Class5.Enum1)5:
				return this.vmethod_19();
			case (Class5.Enum1)6:
				return this.vmethod_20();
			case (Class5.Enum1)11:
				return this.vmethod_14();
			case (Class5.Enum1)15:
				return this.method_7();
			case (Class5.Enum1)16:
				return this.vmethod_74();
			}
			throw new Exception(((Class5.Enum5)4).ToString());
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0001F358 File Offset: 0x0001D558
		internal override object vmethod_4(Type type_0)
		{
			if (type_0 != null && type_0.IsByRef)
			{
				type_0 = type_0.GetElementType();
			}
			if (type_0 != null && Nullable.GetUnderlyingType(type_0) != null)
			{
				type_0 = Nullable.GetUnderlyingType(type_0);
			}
			if (type_0 == null || type_0 == typeof(object))
			{
				switch (this.enum1_0)
				{
				case (Class5.Enum1)1:
					return this.struct2_0.sbyte_0;
				case (Class5.Enum1)2:
					return this.struct2_0.byte_0;
				case (Class5.Enum1)3:
					return this.struct2_0.short_0;
				case (Class5.Enum1)4:
					return this.struct2_0.ushort_0;
				case (Class5.Enum1)5:
					return this.struct2_0.int_0;
				case (Class5.Enum1)6:
					return this.struct2_0.uint_0;
				case (Class5.Enum1)7:
					return (long)this.struct2_0.int_0;
				case (Class5.Enum1)8:
					return (ulong)this.struct2_0.uint_0;
				case (Class5.Enum1)11:
					return this.vmethod_12();
				case (Class5.Enum1)15:
					return (char)this.struct2_0.int_0;
				}
				return this.struct2_0.int_0;
			}
			if (type_0 == typeof(int))
			{
				return this.struct2_0.int_0;
			}
			if (type_0 == typeof(uint))
			{
				return this.struct2_0.uint_0;
			}
			if (type_0 == typeof(short))
			{
				return this.struct2_0.short_0;
			}
			if (type_0 == typeof(ushort))
			{
				return this.struct2_0.ushort_0;
			}
			if (type_0 == typeof(byte))
			{
				return this.struct2_0.byte_0;
			}
			if (type_0 == typeof(sbyte))
			{
				return this.struct2_0.sbyte_0;
			}
			if (type_0 == typeof(bool))
			{
				return !this.vmethod_11();
			}
			if (type_0 == typeof(long))
			{
				return (long)this.struct2_0.int_0;
			}
			if (type_0 == typeof(ulong))
			{
				return (ulong)this.struct2_0.uint_0;
			}
			if (type_0 == typeof(char))
			{
				return (char)this.struct2_0.int_0;
			}
			if (type_0 == typeof(IntPtr))
			{
				return new IntPtr(this.struct2_0.int_0);
			}
			if (type_0 == typeof(UIntPtr))
			{
				return new UIntPtr(this.struct2_0.uint_0);
			}
			if (type_0.IsEnum)
			{
				return this.method_6(type_0);
			}
			throw new Class5.Exception1();
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0001F6A0 File Offset: 0x0001D8A0
		internal object method_6(Type type_0)
		{
			Type underlyingType = Enum.GetUnderlyingType(type_0);
			if (underlyingType == typeof(int))
			{
				return Enum.ToObject(type_0, this.struct2_0.int_0);
			}
			if (underlyingType == typeof(uint))
			{
				return Enum.ToObject(type_0, this.struct2_0.uint_0);
			}
			if (underlyingType == typeof(short))
			{
				return Enum.ToObject(type_0, this.struct2_0.short_0);
			}
			if (underlyingType == typeof(ushort))
			{
				return Enum.ToObject(type_0, this.struct2_0.ushort_0);
			}
			if (underlyingType == typeof(byte))
			{
				return Enum.ToObject(type_0, this.struct2_0.byte_0);
			}
			if (underlyingType == typeof(sbyte))
			{
				return Enum.ToObject(type_0, this.struct2_0.sbyte_0);
			}
			if (underlyingType == typeof(long))
			{
				return Enum.ToObject(type_0, (long)this.struct2_0.int_0);
			}
			if (underlyingType == typeof(ulong))
			{
				return Enum.ToObject(type_0, (ulong)this.struct2_0.uint_0);
			}
			if (!(underlyingType == typeof(char)))
			{
				return Enum.ToObject(type_0, this.struct2_0.int_0);
			}
			return Enum.ToObject(type_0, (ushort)this.struct2_0.int_0);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0001F81C File Offset: 0x0001DA1C
		public override Class5.Class18 vmethod_14()
		{
			return new Class5.Class18(this.vmethod_11() ? 0 : 1);
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00003348 File Offset: 0x00001548
		internal override bool vmethod_7()
		{
			return this.vmethod_12();
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00003350 File Offset: 0x00001550
		public override Class5.Class18 vmethod_15()
		{
			return new Class5.Class18((int)this.struct2_0.sbyte_0, (Class5.Enum1)1);
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00003363 File Offset: 0x00001563
		public Class5.Class18 method_7()
		{
			return new Class5.Class18(this.struct2_0.int_0, (Class5.Enum1)15);
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00003377 File Offset: 0x00001577
		public override Class5.Class18 vmethod_16()
		{
			return new Class5.Class18((uint)this.struct2_0.byte_0, (Class5.Enum1)2);
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000338A File Offset: 0x0000158A
		public override Class5.Class18 vmethod_17()
		{
			return new Class5.Class18((int)this.struct2_0.short_0, (Class5.Enum1)3);
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000339D File Offset: 0x0000159D
		public override Class5.Class18 vmethod_18()
		{
			return new Class5.Class18((uint)this.struct2_0.ushort_0, (Class5.Enum1)4);
		}

		// Token: 0x06000354 RID: 852 RVA: 0x000033B0 File Offset: 0x000015B0
		public override Class5.Class18 vmethod_19()
		{
			return new Class5.Class18(this.struct2_0.int_0, (Class5.Enum1)5);
		}

		// Token: 0x06000355 RID: 853 RVA: 0x000033C3 File Offset: 0x000015C3
		public override Class5.Class18 vmethod_20()
		{
			return new Class5.Class18(this.struct2_0.uint_0, (Class5.Enum1)6);
		}

		// Token: 0x06000356 RID: 854 RVA: 0x000033D6 File Offset: 0x000015D6
		public override Class5.Class19 vmethod_21()
		{
			return new Class5.Class19((long)this.struct2_0.int_0, (Class5.Enum1)7);
		}

		// Token: 0x06000357 RID: 855 RVA: 0x000033EA File Offset: 0x000015EA
		public override Class5.Class19 vmethod_22()
		{
			return new Class5.Class19((ulong)this.struct2_0.uint_0, (Class5.Enum1)8);
		}

		// Token: 0x06000358 RID: 856 RVA: 0x000033FE File Offset: 0x000015FE
		public override Class5.Class18 vmethod_23()
		{
			return this.vmethod_15();
		}

		// Token: 0x06000359 RID: 857 RVA: 0x00003406 File Offset: 0x00001606
		public override Class5.Class18 vmethod_24()
		{
			return this.vmethod_17();
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000340E File Offset: 0x0000160E
		public override Class5.Class18 vmethod_25()
		{
			return this.vmethod_19();
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00003416 File Offset: 0x00001616
		public override Class5.Class19 vmethod_26()
		{
			return this.vmethod_21();
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000341E File Offset: 0x0000161E
		public override Class5.Class18 vmethod_27()
		{
			return this.vmethod_16();
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00003426 File Offset: 0x00001626
		public override Class5.Class18 vmethod_28()
		{
			return this.vmethod_18();
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000342E File Offset: 0x0000162E
		public override Class5.Class18 vmethod_29()
		{
			return this.vmethod_20();
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00003436 File Offset: 0x00001636
		public override Class5.Class19 vmethod_30()
		{
			return this.vmethod_22();
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0000343E File Offset: 0x0000163E
		public override Class5.Class18 vmethod_31()
		{
			return new Class5.Class18((int)(checked((sbyte)this.struct2_0.int_0)), (Class5.Enum1)1);
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00003452 File Offset: 0x00001652
		public override Class5.Class18 vmethod_32()
		{
			return new Class5.Class18((int)(checked((sbyte)this.struct2_0.uint_0)), (Class5.Enum1)1);
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00003466 File Offset: 0x00001666
		public override Class5.Class18 vmethod_33()
		{
			return new Class5.Class18((int)(checked((short)this.struct2_0.int_0)), (Class5.Enum1)3);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0000347A File Offset: 0x0000167A
		public override Class5.Class18 vmethod_34()
		{
			return new Class5.Class18((int)(checked((short)this.struct2_0.uint_0)), (Class5.Enum1)3);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x000033B0 File Offset: 0x000015B0
		public override Class5.Class18 vmethod_35()
		{
			return new Class5.Class18(this.struct2_0.int_0, (Class5.Enum1)5);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0000348E File Offset: 0x0000168E
		public override Class5.Class18 vmethod_36()
		{
			return new Class5.Class18(checked((int)this.struct2_0.uint_0), (Class5.Enum1)5);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x000033D6 File Offset: 0x000015D6
		public override Class5.Class19 vmethod_37()
		{
			return new Class5.Class19((long)this.struct2_0.int_0, (Class5.Enum1)7);
		}

		// Token: 0x06000367 RID: 871 RVA: 0x000034A2 File Offset: 0x000016A2
		public override Class5.Class19 vmethod_38()
		{
			return new Class5.Class19((long)((ulong)this.struct2_0.uint_0), (Class5.Enum1)7);
		}

		// Token: 0x06000368 RID: 872 RVA: 0x000034B6 File Offset: 0x000016B6
		public override Class5.Class18 vmethod_39()
		{
			return new Class5.Class18((int)(checked((byte)this.struct2_0.int_0)), (Class5.Enum1)2);
		}

		// Token: 0x06000369 RID: 873 RVA: 0x000034CA File Offset: 0x000016CA
		public override Class5.Class18 vmethod_40()
		{
			return new Class5.Class18((int)(checked((byte)this.struct2_0.uint_0)), (Class5.Enum1)2);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x000034DE File Offset: 0x000016DE
		public override Class5.Class18 vmethod_41()
		{
			return new Class5.Class18((int)(checked((ushort)this.struct2_0.int_0)), (Class5.Enum1)4);
		}

		// Token: 0x0600036B RID: 875 RVA: 0x000034F2 File Offset: 0x000016F2
		public override Class5.Class18 vmethod_42()
		{
			return new Class5.Class18((int)(checked((ushort)this.struct2_0.uint_0)), (Class5.Enum1)4);
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00003506 File Offset: 0x00001706
		public override Class5.Class18 vmethod_43()
		{
			return new Class5.Class18(checked((uint)this.struct2_0.int_0), (Class5.Enum1)6);
		}

		// Token: 0x0600036D RID: 877 RVA: 0x000033C3 File Offset: 0x000015C3
		public override Class5.Class18 vmethod_44()
		{
			return new Class5.Class18(this.struct2_0.uint_0, (Class5.Enum1)6);
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0000351A File Offset: 0x0000171A
		public override Class5.Class19 vmethod_45()
		{
			return new Class5.Class19(checked((ulong)this.struct2_0.int_0), (Class5.Enum1)8);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x000033EA File Offset: 0x000015EA
		public override Class5.Class19 vmethod_46()
		{
			return new Class5.Class19((ulong)this.struct2_0.uint_0, (Class5.Enum1)8);
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0000352E File Offset: 0x0000172E
		public override Class5.Class21 vmethod_47()
		{
			return new Class5.Class21((float)this.struct2_0.int_0);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00003541 File Offset: 0x00001741
		public override Class5.Class21 vmethod_48()
		{
			return new Class5.Class21((double)this.struct2_0.int_0);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00003554 File Offset: 0x00001754
		public override Class5.Class21 vmethod_49()
		{
			return new Class5.Class21(this.struct2_0.uint_0);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0001F83C File Offset: 0x0001DA3C
		public override Class5.Class20 vmethod_50()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_26().struct3_0.long_0);
			}
			return new Class5.Class20((long)this.vmethod_25().struct2_0.int_0);
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0001F880 File Offset: 0x0001DA80
		public override Class5.Class20 vmethod_51()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_30().struct3_0.ulong_0);
			}
			return new Class5.Class20((ulong)this.vmethod_29().struct2_0.uint_0);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0001F8C4 File Offset: 0x0001DAC4
		public override Class5.Class20 vmethod_52()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_37().struct3_0.long_0);
			}
			return new Class5.Class20((long)this.vmethod_35().struct2_0.int_0);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0001F908 File Offset: 0x0001DB08
		public override Class5.Class20 vmethod_53()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_45().struct3_0.ulong_0);
			}
			return new Class5.Class20((ulong)this.vmethod_43().struct2_0.uint_0);
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0001F94C File Offset: 0x0001DB4C
		public override Class5.Class20 vmethod_54()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_38().struct3_0.long_0);
			}
			return new Class5.Class20((long)this.vmethod_36().struct2_0.int_0);
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0001F990 File Offset: 0x0001DB90
		public override Class5.Class20 vmethod_55()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_46().struct3_0.ulong_0);
			}
			return new Class5.Class20((ulong)this.vmethod_44().struct2_0.uint_0);
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0001F9D4 File Offset: 0x0001DBD4
		public override Class5.Class16 vmethod_56()
		{
			Class5.Enum1 @enum = this.enum1_0;
			switch (@enum)
			{
			case (Class5.Enum1)1:
			case (Class5.Enum1)3:
			case (Class5.Enum1)5:
				goto IL_47;
			case (Class5.Enum1)2:
			case (Class5.Enum1)4:
				break;
			default:
				if (@enum == (Class5.Enum1)11)
				{
					goto IL_47;
				}
				if (@enum == (Class5.Enum1)15)
				{
					goto IL_47;
				}
				break;
			}
			return new Class5.Class18((int)(-(int)((ulong)this.struct2_0.uint_0)));
			IL_47:
			return new Class5.Class18(-this.struct2_0.int_0);
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0001FA3C File Offset: 0x0001DC3C
		public override Class5.Class16 vmethod_57(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(this.struct2_0.int_0 + ((Class5.Class18)class16_0).struct2_0.int_0);
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).vmethod_57(this);
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0001FAA0 File Offset: 0x0001DCA0
		public override Class5.Class16 vmethod_58(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(checked(this.struct2_0.int_0 + ((Class5.Class18)class16_0).struct2_0.int_0));
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).vmethod_58(this);
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0001FB04 File Offset: 0x0001DD04
		public override Class5.Class16 vmethod_59(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(checked(this.struct2_0.uint_0 + ((Class5.Class18)class16_0).struct2_0.uint_0));
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).vmethod_59(this);
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0001FB68 File Offset: 0x0001DD68
		public override Class5.Class16 vmethod_60(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(this.struct2_0.int_0 - ((Class5.Class18)class16_0).struct2_0.int_0);
			}
			if (class16_0.method_2())
			{
				return ((Class5.Class20)class16_0).method_8(this);
			}
			throw new Class5.Exception1();
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0001FBCC File Offset: 0x0001DDCC
		public override Class5.Class16 vmethod_61(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(checked(this.struct2_0.int_0 - ((Class5.Class18)class16_0).struct2_0.int_0));
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).method_9(this);
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0001FC30 File Offset: 0x0001DE30
		public override Class5.Class16 vmethod_62(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(checked(this.struct2_0.uint_0 - ((Class5.Class18)class16_0).struct2_0.uint_0));
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).method_10(this);
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0001FC94 File Offset: 0x0001DE94
		public override Class5.Class16 vmethod_63(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(this.struct2_0.int_0 * ((Class5.Class18)class16_0).struct2_0.int_0);
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).vmethod_63(this);
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0001FCF8 File Offset: 0x0001DEF8
		public override Class5.Class16 vmethod_64(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(checked(this.struct2_0.int_0 * ((Class5.Class18)class16_0).struct2_0.int_0));
			}
			if (class16_0.method_2())
			{
				return ((Class5.Class20)class16_0).vmethod_64(this);
			}
			throw new Class5.Exception1();
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0001FD5C File Offset: 0x0001DF5C
		public override Class5.Class16 vmethod_65(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(checked(this.struct2_0.uint_0 * ((Class5.Class18)class16_0).struct2_0.uint_0));
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).vmethod_65(this);
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0001FDC0 File Offset: 0x0001DFC0
		public override Class5.Class16 vmethod_66(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(this.struct2_0.int_0 / ((Class5.Class18)class16_0).struct2_0.int_0);
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).method_11(this);
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0001FE24 File Offset: 0x0001E024
		public override Class5.Class16 vmethod_67(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(this.struct2_0.uint_0 / ((Class5.Class18)class16_0).struct2_0.uint_0);
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).method_12(this);
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0001FE88 File Offset: 0x0001E088
		public override Class5.Class16 vmethod_68(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(this.struct2_0.int_0 % ((Class5.Class18)class16_0).struct2_0.int_0);
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).method_13(this);
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0001FEEC File Offset: 0x0001E0EC
		public override Class5.Class16 vmethod_69(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(this.struct2_0.uint_0 % ((Class5.Class18)class16_0).struct2_0.uint_0);
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).method_14(this);
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0001FF50 File Offset: 0x0001E150
		public override Class5.Class16 vmethod_70(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(this.struct2_0.int_0 & ((Class5.Class18)class16_0).struct2_0.int_0);
			}
			if (class16_0.method_2())
			{
				return ((Class5.Class20)class16_0).vmethod_70(this);
			}
			throw new Class5.Exception1();
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0001FFB4 File Offset: 0x0001E1B4
		public override Class5.Class16 vmethod_71(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(this.struct2_0.int_0 | ((Class5.Class18)class16_0).struct2_0.int_0);
			}
			if (class16_0.method_2())
			{
				return ((Class5.Class20)class16_0).vmethod_71(this);
			}
			throw new Class5.Exception1();
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00003568 File Offset: 0x00001768
		public override Class5.Class16 vmethod_72()
		{
			return new Class5.Class18(~this.struct2_0.int_0);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00020018 File Offset: 0x0001E218
		public override Class5.Class16 vmethod_73(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(this.struct2_0.int_0 ^ ((Class5.Class18)class16_0).struct2_0.int_0);
			}
			if (class16_0.method_2())
			{
				return ((Class5.Class20)class16_0).vmethod_73(this);
			}
			throw new Class5.Exception1();
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0002007C File Offset: 0x0001E27C
		public override Class5.Class16 vmethod_75(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(this.struct2_0.int_0 << ((Class5.Class18)class16_0).struct2_0.int_0);
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).method_17(this);
		}

		// Token: 0x0600038C RID: 908 RVA: 0x000200E0 File Offset: 0x0001E2E0
		public override Class5.Class16 vmethod_76(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(this.struct2_0.int_0 >> ((Class5.Class18)class16_0).struct2_0.int_0);
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).method_16(this);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00020144 File Offset: 0x0001E344
		public override Class5.Class16 vmethod_77(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return new Class5.Class18(this.struct2_0.uint_0 >> ((Class5.Class18)class16_0).struct2_0.int_0);
			}
			if (class16_0.method_2())
			{
				return ((Class5.Class20)class16_0).method_15(this);
			}
			throw new Class5.Exception1();
		}

		// Token: 0x0600038E RID: 910 RVA: 0x000201A8 File Offset: 0x0001E3A8
		public override string ToString()
		{
			Class5.Enum1 @enum = this.enum1_0;
			switch (@enum)
			{
			case (Class5.Enum1)1:
			case (Class5.Enum1)3:
			case (Class5.Enum1)5:
				goto IL_3E;
			case (Class5.Enum1)2:
			case (Class5.Enum1)4:
				break;
			default:
				if (@enum == (Class5.Enum1)11)
				{
					goto IL_3E;
				}
				break;
			}
			return this.struct2_0.uint_0.ToString();
			IL_3E:
			return this.struct2_0.int_0.ToString();
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000357B File Offset: 0x0000177B
		internal override Class5.Class16 vmethod_8()
		{
			return this;
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0000357E File Offset: 0x0000177E
		internal override bool vmethod_9()
		{
			return true;
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00020204 File Offset: 0x0001E404
		internal override bool vmethod_5(Class5.Class16 class16_0)
		{
			if (class16_0.method_0())
			{
				return ((Class5.Class28)class16_0).vmethod_5(this);
			}
			if (class16_0.vmethod_0())
			{
				return ((Class5.Class22)class16_0).vmethod_5(this);
			}
			Class5.Class16 @class = class16_0.vmethod_8();
			if (!@class.vmethod_9())
			{
				return false;
			}
			if (@class.method_3())
			{
				return false;
			}
			if (!@class.method_1())
			{
				return ((Class5.Class20)@class).vmethod_5(this);
			}
			return this.struct2_0.int_0 == ((Class5.Class18)@class).struct2_0.int_0;
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00020290 File Offset: 0x0001E490
		private static Class5.Class17 rtKliIjjit(Class5.Class16 class16_0)
		{
			Class5.Class17 @class = class16_0 as Class5.Class17;
			if (@class == null && class16_0.vmethod_0())
			{
				@class = (class16_0.vmethod_8() as Class5.Class17);
			}
			return @class;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x000202C0 File Offset: 0x0001E4C0
		internal override bool vmethod_6(Class5.Class16 class16_0)
		{
			if (class16_0.method_0())
			{
				return false;
			}
			if (class16_0.vmethod_0())
			{
				return ((Class5.Class22)class16_0).vmethod_6(this);
			}
			Class5.Class16 @class = class16_0.vmethod_8();
			if (!@class.vmethod_9())
			{
				return false;
			}
			if (@class.method_3())
			{
				return false;
			}
			if (!@class.method_1())
			{
				return ((Class5.Class20)@class).vmethod_6(this);
			}
			return this.struct2_0.uint_0 != ((Class5.Class18)@class).struct2_0.uint_0;
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00020344 File Offset: 0x0001E544
		public override bool vmethod_78(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return this.struct2_0.int_0 >= ((Class5.Class18)class16_0).struct2_0.int_0;
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).vmethod_82(this);
		}

		// Token: 0x06000395 RID: 917 RVA: 0x000203A4 File Offset: 0x0001E5A4
		public override bool vmethod_79(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return this.struct2_0.uint_0 >= ((Class5.Class18)class16_0).struct2_0.uint_0;
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).vmethod_83(this);
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00020404 File Offset: 0x0001E604
		public override bool vmethod_80(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return this.struct2_0.int_0 > ((Class5.Class18)class16_0).struct2_0.int_0;
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).vmethod_84(this);
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00020464 File Offset: 0x0001E664
		public override bool vmethod_81(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return this.struct2_0.uint_0 > ((Class5.Class18)class16_0).struct2_0.uint_0;
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).vmethod_85(this);
		}

		// Token: 0x06000398 RID: 920 RVA: 0x000204C4 File Offset: 0x0001E6C4
		public override bool vmethod_82(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return this.struct2_0.int_0 <= ((Class5.Class18)class16_0).struct2_0.int_0;
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).vmethod_78(this);
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00020524 File Offset: 0x0001E724
		public override bool vmethod_83(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return this.struct2_0.uint_0 <= ((Class5.Class18)class16_0).struct2_0.uint_0;
			}
			if (class16_0.method_2())
			{
				return ((Class5.Class20)class16_0).vmethod_79(this);
			}
			throw new Class5.Exception1();
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00020584 File Offset: 0x0001E784
		public override bool vmethod_84(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return this.struct2_0.int_0 < ((Class5.Class18)class16_0).struct2_0.int_0;
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).vmethod_80(this);
		}

		// Token: 0x0600039B RID: 923 RVA: 0x000205E4 File Offset: 0x0001E7E4
		public override bool vmethod_85(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				return this.struct2_0.uint_0 < ((Class5.Class18)class16_0).struct2_0.uint_0;
			}
			if (!class16_0.method_2())
			{
				throw new Class5.Exception1();
			}
			return ((Class5.Class20)class16_0).vmethod_81(this);
		}

		// Token: 0x0400038A RID: 906
		public Class5.Struct2 struct2_0;

		// Token: 0x0400038B RID: 907
		public Class5.Enum1 enum1_0;
	}

	// Token: 0x0200009A RID: 154
	[StructLayout(LayoutKind.Explicit)]
	private struct Struct3
	{
		// Token: 0x0400038C RID: 908
		[FieldOffset(0)]
		public byte byte_0;

		// Token: 0x0400038D RID: 909
		[FieldOffset(0)]
		public sbyte sbyte_0;

		// Token: 0x0400038E RID: 910
		[FieldOffset(0)]
		public ushort ushort_0;

		// Token: 0x0400038F RID: 911
		[FieldOffset(0)]
		public short short_0;

		// Token: 0x04000390 RID: 912
		[FieldOffset(0)]
		public uint rcUlderfYf;

		// Token: 0x04000391 RID: 913
		[FieldOffset(0)]
		public int int_0;

		// Token: 0x04000392 RID: 914
		[FieldOffset(0)]
		public ulong ulong_0;

		// Token: 0x04000393 RID: 915
		[FieldOffset(0)]
		public long long_0;
	}

	// Token: 0x0200009B RID: 155
	private class Class19 : Class5.Class17
	{
		// Token: 0x0600039C RID: 924 RVA: 0x00020644 File Offset: 0x0001E844
		internal override void vmethod_10(Class5.Class16 class16_0)
		{
			this.struct3_0 = ((Class5.Class19)class16_0).struct3_0;
			this.enum1_0 = ((Class5.Class19)class16_0).enum1_0;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0001F0EC File Offset: 0x0001D2EC
		internal override void vmethod_2(Class5.Class16 class16_0)
		{
			this.vmethod_10(class16_0);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00020674 File Offset: 0x0001E874
		public Class19(long long_0)
		{
			this.enum4_0 = (Class5.Enum4)2;
			this.struct3_0.long_0 = long_0;
			this.enum1_0 = (Class5.Enum1)7;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x000206A4 File Offset: 0x0001E8A4
		public Class19(Class5.Class19 class19_0)
		{
			this.enum4_0 = class19_0.enum4_0;
			this.struct3_0.long_0 = class19_0.struct3_0.long_0;
			this.enum1_0 = class19_0.enum1_0;
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x00003581 File Offset: 0x00001781
		public override Class5.Class17 vmethod_74()
		{
			return new Class5.Class19(this);
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x000206E8 File Offset: 0x0001E8E8
		public Class19(long long_0, Class5.Enum1 enum1_1)
		{
			this.enum4_0 = (Class5.Enum4)2;
			this.struct3_0.long_0 = long_0;
			this.enum1_0 = enum1_1;
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00020718 File Offset: 0x0001E918
		public Class19(ulong ulong_0)
		{
			this.enum4_0 = (Class5.Enum4)2;
			this.struct3_0.ulong_0 = ulong_0;
			this.enum1_0 = (Class5.Enum1)8;
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00020748 File Offset: 0x0001E948
		public Class19(ulong ulong_0, Class5.Enum1 enum1_1)
		{
			this.enum4_0 = (Class5.Enum4)2;
			this.struct3_0.ulong_0 = ulong_0;
			this.enum1_0 = enum1_1;
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00020778 File Offset: 0x0001E978
		public override bool vmethod_11()
		{
			if (this.enum1_0 == (Class5.Enum1)7)
			{
				return this.struct3_0.long_0 == 0L;
			}
			return this.struct3_0.ulong_0 == 0UL;
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x0000333D File Offset: 0x0000153D
		public override bool vmethod_12()
		{
			return !this.vmethod_11();
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x000207BC File Offset: 0x0001E9BC
		public override Class5.Class16 vmethod_13(Class5.Enum1 enum1_1)
		{
			switch (enum1_1)
			{
			case (Class5.Enum1)1:
				return this.vmethod_15();
			case (Class5.Enum1)2:
				return this.vmethod_16();
			case (Class5.Enum1)3:
				return this.vmethod_17();
			case (Class5.Enum1)4:
				return this.vmethod_18();
			case (Class5.Enum1)5:
				return this.vmethod_19();
			case (Class5.Enum1)6:
				return this.vmethod_20();
			case (Class5.Enum1)7:
				return this.vmethod_21();
			case (Class5.Enum1)8:
				return this.vmethod_22();
			case (Class5.Enum1)11:
				return this.vmethod_14();
			case (Class5.Enum1)15:
				return this.method_7();
			case (Class5.Enum1)16:
				return this.vmethod_74();
			}
			throw new Exception(((Class5.Enum5)4).ToString());
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00020878 File Offset: 0x0001EA78
		internal override object vmethod_4(Type type_0)
		{
			if (type_0 != null && type_0.IsByRef)
			{
				type_0 = type_0.GetElementType();
			}
			if (type_0 == null || type_0 == typeof(object))
			{
				switch (this.enum1_0)
				{
				case (Class5.Enum1)1:
					return this.struct3_0.sbyte_0;
				case (Class5.Enum1)2:
					return this.struct3_0.byte_0;
				case (Class5.Enum1)3:
					return this.struct3_0.short_0;
				case (Class5.Enum1)4:
					return this.struct3_0.ushort_0;
				case (Class5.Enum1)5:
					return this.struct3_0.int_0;
				case (Class5.Enum1)6:
					return this.struct3_0.rcUlderfYf;
				case (Class5.Enum1)7:
					return this.struct3_0.long_0;
				case (Class5.Enum1)8:
					return this.struct3_0.ulong_0;
				case (Class5.Enum1)11:
					return this.vmethod_12();
				case (Class5.Enum1)15:
					return (char)this.struct3_0.int_0;
				}
				return this.struct3_0.long_0;
			}
			if (type_0 == typeof(int))
			{
				return this.struct3_0.int_0;
			}
			if (type_0 == typeof(uint))
			{
				return this.struct3_0.rcUlderfYf;
			}
			if (type_0 == typeof(short))
			{
				return this.struct3_0.short_0;
			}
			if (type_0 == typeof(ushort))
			{
				return this.struct3_0.ushort_0;
			}
			if (type_0 == typeof(byte))
			{
				return this.struct3_0.byte_0;
			}
			if (type_0 == typeof(sbyte))
			{
				return this.struct3_0.sbyte_0;
			}
			if (type_0 == typeof(bool))
			{
				return !this.vmethod_11();
			}
			if (type_0 == typeof(long))
			{
				return this.struct3_0.long_0;
			}
			if (type_0 == typeof(ulong))
			{
				return this.struct3_0.ulong_0;
			}
			if (type_0 == typeof(char))
			{
				return (char)this.struct3_0.long_0;
			}
			if (type_0.IsEnum)
			{
				return this.method_6(type_0);
			}
			throw new Class5.Exception1();
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00020B4C File Offset: 0x0001ED4C
		internal object method_6(Type type_0)
		{
			Type underlyingType = Enum.GetUnderlyingType(type_0);
			if (underlyingType == typeof(int))
			{
				return Enum.ToObject(type_0, this.struct3_0.int_0);
			}
			if (underlyingType == typeof(uint))
			{
				return Enum.ToObject(type_0, this.struct3_0.rcUlderfYf);
			}
			if (underlyingType == typeof(short))
			{
				return Enum.ToObject(type_0, this.struct3_0.short_0);
			}
			if (underlyingType == typeof(ushort))
			{
				return Enum.ToObject(type_0, this.struct3_0.ushort_0);
			}
			if (underlyingType == typeof(byte))
			{
				return Enum.ToObject(type_0, this.struct3_0.byte_0);
			}
			if (underlyingType == typeof(sbyte))
			{
				return Enum.ToObject(type_0, this.struct3_0.sbyte_0);
			}
			if (underlyingType == typeof(long))
			{
				return Enum.ToObject(type_0, this.struct3_0.long_0);
			}
			if (underlyingType == typeof(ulong))
			{
				return Enum.ToObject(type_0, this.struct3_0.ulong_0);
			}
			if (underlyingType == typeof(char))
			{
				return Enum.ToObject(type_0, (ushort)this.struct3_0.int_0);
			}
			return Enum.ToObject(type_0, this.struct3_0.long_0);
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00020CD0 File Offset: 0x0001EED0
		public override Class5.Class18 vmethod_14()
		{
			return new Class5.Class18((!this.vmethod_11()) ? 1 : 0);
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00003348 File Offset: 0x00001548
		internal override bool vmethod_7()
		{
			return this.vmethod_12();
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00003589 File Offset: 0x00001789
		public Class5.Class18 method_7()
		{
			return new Class5.Class18((int)this.struct3_0.sbyte_0, (Class5.Enum1)15);
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0000359D File Offset: 0x0000179D
		public override Class5.Class18 vmethod_15()
		{
			return new Class5.Class18((int)this.struct3_0.sbyte_0, (Class5.Enum1)1);
		}

		// Token: 0x060003AD RID: 941 RVA: 0x000035B0 File Offset: 0x000017B0
		public override Class5.Class18 vmethod_16()
		{
			return new Class5.Class18((uint)this.struct3_0.byte_0, (Class5.Enum1)2);
		}

		// Token: 0x060003AE RID: 942 RVA: 0x000035C3 File Offset: 0x000017C3
		public override Class5.Class18 vmethod_17()
		{
			return new Class5.Class18((int)this.struct3_0.short_0, (Class5.Enum1)3);
		}

		// Token: 0x060003AF RID: 943 RVA: 0x000035D6 File Offset: 0x000017D6
		public override Class5.Class18 vmethod_18()
		{
			return new Class5.Class18((uint)this.struct3_0.ushort_0, (Class5.Enum1)4);
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x000035E9 File Offset: 0x000017E9
		public override Class5.Class18 vmethod_19()
		{
			return new Class5.Class18(this.struct3_0.int_0, (Class5.Enum1)5);
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x000035FC File Offset: 0x000017FC
		public override Class5.Class18 vmethod_20()
		{
			return new Class5.Class18(this.struct3_0.rcUlderfYf, (Class5.Enum1)6);
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0000360F File Offset: 0x0000180F
		public override Class5.Class19 vmethod_21()
		{
			return new Class5.Class19(this.struct3_0.long_0, (Class5.Enum1)7);
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00003622 File Offset: 0x00001822
		public override Class5.Class19 vmethod_22()
		{
			return new Class5.Class19(this.struct3_0.ulong_0, (Class5.Enum1)8);
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x000033FE File Offset: 0x000015FE
		public override Class5.Class18 vmethod_23()
		{
			return this.vmethod_15();
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00003406 File Offset: 0x00001606
		public override Class5.Class18 vmethod_24()
		{
			return this.vmethod_17();
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000340E File Offset: 0x0000160E
		public override Class5.Class18 vmethod_25()
		{
			return this.vmethod_19();
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00003416 File Offset: 0x00001616
		public override Class5.Class19 vmethod_26()
		{
			return this.vmethod_21();
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000341E File Offset: 0x0000161E
		public override Class5.Class18 vmethod_27()
		{
			return this.vmethod_16();
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00003426 File Offset: 0x00001626
		public override Class5.Class18 vmethod_28()
		{
			return this.vmethod_18();
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0000342E File Offset: 0x0000162E
		public override Class5.Class18 vmethod_29()
		{
			return this.vmethod_20();
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00003436 File Offset: 0x00001636
		public override Class5.Class19 vmethod_30()
		{
			return this.vmethod_22();
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00003635 File Offset: 0x00001835
		public override Class5.Class18 vmethod_31()
		{
			return new Class5.Class18((int)(checked((sbyte)this.struct3_0.long_0)), (Class5.Enum1)1);
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00003649 File Offset: 0x00001849
		public override Class5.Class18 vmethod_32()
		{
			return new Class5.Class18((int)(checked((sbyte)this.struct3_0.ulong_0)), (Class5.Enum1)1);
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0000365D File Offset: 0x0000185D
		public override Class5.Class18 vmethod_33()
		{
			return new Class5.Class18((int)(checked((short)this.struct3_0.long_0)), (Class5.Enum1)3);
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00003671 File Offset: 0x00001871
		public override Class5.Class18 vmethod_34()
		{
			return new Class5.Class18((int)(checked((short)this.struct3_0.ulong_0)), (Class5.Enum1)3);
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00003685 File Offset: 0x00001885
		public override Class5.Class18 vmethod_35()
		{
			return new Class5.Class18(checked((int)this.struct3_0.long_0), (Class5.Enum1)5);
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00003699 File Offset: 0x00001899
		public override Class5.Class18 vmethod_36()
		{
			return new Class5.Class18(checked((int)this.struct3_0.ulong_0), (Class5.Enum1)5);
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0000360F File Offset: 0x0000180F
		public override Class5.Class19 vmethod_37()
		{
			return new Class5.Class19(this.struct3_0.long_0, (Class5.Enum1)7);
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x000036AD File Offset: 0x000018AD
		public override Class5.Class19 vmethod_38()
		{
			return new Class5.Class19(checked((long)this.struct3_0.ulong_0), (Class5.Enum1)7);
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x000036C1 File Offset: 0x000018C1
		public override Class5.Class18 vmethod_39()
		{
			return new Class5.Class18((int)(checked((byte)this.struct3_0.long_0)), (Class5.Enum1)2);
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x000036D5 File Offset: 0x000018D5
		public override Class5.Class18 vmethod_40()
		{
			return new Class5.Class18((int)(checked((byte)this.struct3_0.ulong_0)), (Class5.Enum1)2);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x000036E9 File Offset: 0x000018E9
		public override Class5.Class18 vmethod_41()
		{
			return new Class5.Class18((int)(checked((ushort)this.struct3_0.long_0)), (Class5.Enum1)4);
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x000036FD File Offset: 0x000018FD
		public override Class5.Class18 vmethod_42()
		{
			return new Class5.Class18((int)(checked((ushort)this.struct3_0.ulong_0)), (Class5.Enum1)4);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00003711 File Offset: 0x00001911
		public override Class5.Class18 vmethod_43()
		{
			return new Class5.Class18(checked((uint)this.struct3_0.long_0), (Class5.Enum1)6);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00003725 File Offset: 0x00001925
		public override Class5.Class18 vmethod_44()
		{
			return new Class5.Class18(checked((uint)this.struct3_0.ulong_0), (Class5.Enum1)6);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00003739 File Offset: 0x00001939
		public override Class5.Class19 vmethod_45()
		{
			return new Class5.Class19(checked((ulong)this.struct3_0.long_0), (Class5.Enum1)8);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00003622 File Offset: 0x00001822
		public override Class5.Class19 vmethod_46()
		{
			return new Class5.Class19(this.struct3_0.ulong_0, (Class5.Enum1)8);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0000374D File Offset: 0x0000194D
		public override Class5.Class21 vmethod_47()
		{
			return new Class5.Class21((float)this.struct3_0.long_0);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00003760 File Offset: 0x00001960
		public override Class5.Class21 vmethod_48()
		{
			return new Class5.Class21((double)this.struct3_0.long_0);
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00003773 File Offset: 0x00001973
		public override Class5.Class21 vmethod_49()
		{
			return new Class5.Class21(this.struct3_0.ulong_0);
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0001F83C File Offset: 0x0001DA3C
		public override Class5.Class20 vmethod_50()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_26().struct3_0.long_0);
			}
			return new Class5.Class20((long)this.vmethod_25().struct2_0.int_0);
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0001F880 File Offset: 0x0001DA80
		public override Class5.Class20 vmethod_51()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_30().struct3_0.ulong_0);
			}
			return new Class5.Class20((ulong)this.vmethod_29().struct2_0.uint_0);
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0001F8C4 File Offset: 0x0001DAC4
		public override Class5.Class20 vmethod_52()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_37().struct3_0.long_0);
			}
			return new Class5.Class20((long)this.vmethod_35().struct2_0.int_0);
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0001F908 File Offset: 0x0001DB08
		public override Class5.Class20 vmethod_53()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_45().struct3_0.ulong_0);
			}
			return new Class5.Class20((ulong)this.vmethod_43().struct2_0.uint_0);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0001F94C File Offset: 0x0001DB4C
		public override Class5.Class20 vmethod_54()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_38().struct3_0.long_0);
			}
			return new Class5.Class20((long)this.vmethod_36().struct2_0.int_0);
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00020CF0 File Offset: 0x0001EEF0
		public override Class5.Class20 vmethod_55()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.struct3_0.ulong_0);
			}
			return new Class5.Class20((ulong)(checked((uint)this.struct3_0.ulong_0)));
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00003787 File Offset: 0x00001987
		public override Class5.Class16 vmethod_56()
		{
			return new Class5.Class19(-this.struct3_0.long_0);
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00020D28 File Offset: 0x0001EF28
		public override Class5.Class16 vmethod_57(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(this.struct3_0.long_0 + ((Class5.Class19)class16_0).struct3_0.long_0);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00020D74 File Offset: 0x0001EF74
		public override Class5.Class16 vmethod_58(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(checked(this.struct3_0.long_0 + ((Class5.Class19)class16_0).struct3_0.long_0));
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00020DC0 File Offset: 0x0001EFC0
		public override Class5.Class16 vmethod_59(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(checked(this.struct3_0.ulong_0 + ((Class5.Class19)class16_0).struct3_0.ulong_0));
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00020E0C File Offset: 0x0001F00C
		public override Class5.Class16 vmethod_60(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(this.struct3_0.long_0 - ((Class5.Class19)class16_0).struct3_0.long_0);
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00020E58 File Offset: 0x0001F058
		public override Class5.Class16 vmethod_61(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(checked(this.struct3_0.long_0 - ((Class5.Class19)class16_0).struct3_0.long_0));
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00020EA4 File Offset: 0x0001F0A4
		public override Class5.Class16 vmethod_62(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(checked(this.struct3_0.ulong_0 - ((Class5.Class19)class16_0).struct3_0.ulong_0));
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00020EF0 File Offset: 0x0001F0F0
		public override Class5.Class16 vmethod_63(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(this.struct3_0.long_0 * ((Class5.Class19)class16_0).struct3_0.long_0);
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00020F3C File Offset: 0x0001F13C
		public override Class5.Class16 vmethod_64(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(checked(this.struct3_0.long_0 * ((Class5.Class19)class16_0).struct3_0.long_0));
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00020F88 File Offset: 0x0001F188
		public override Class5.Class16 vmethod_65(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(checked(this.struct3_0.ulong_0 * ((Class5.Class19)class16_0).struct3_0.ulong_0));
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00020FD4 File Offset: 0x0001F1D4
		public override Class5.Class16 vmethod_66(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(this.struct3_0.long_0 / ((Class5.Class19)class16_0).struct3_0.long_0);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00021020 File Offset: 0x0001F220
		public override Class5.Class16 vmethod_67(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(this.struct3_0.ulong_0 / ((Class5.Class19)class16_0).struct3_0.ulong_0);
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0002106C File Offset: 0x0001F26C
		public override Class5.Class16 vmethod_68(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(this.struct3_0.long_0 % ((Class5.Class19)class16_0).struct3_0.long_0);
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x000210B8 File Offset: 0x0001F2B8
		public override Class5.Class16 vmethod_69(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(this.struct3_0.ulong_0 % ((Class5.Class19)class16_0).struct3_0.ulong_0);
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00021104 File Offset: 0x0001F304
		public override Class5.Class16 vmethod_70(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(this.struct3_0.long_0 & ((Class5.Class19)class16_0).struct3_0.long_0);
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00021150 File Offset: 0x0001F350
		public override Class5.Class16 vmethod_71(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(this.struct3_0.long_0 | ((Class5.Class19)class16_0).struct3_0.long_0);
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x0000379A File Offset: 0x0000199A
		public override Class5.Class16 vmethod_72()
		{
			return new Class5.Class19(~this.struct3_0.long_0);
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0002119C File Offset: 0x0001F39C
		public override Class5.Class16 vmethod_73(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(this.struct3_0.long_0 ^ ((Class5.Class19)class16_0).struct3_0.long_0);
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x000211E8 File Offset: 0x0001F3E8
		public override Class5.Class16 vmethod_75(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_3())
			{
				return new Class5.Class19(this.struct3_0.long_0 << ((Class5.Class19)class16_0).struct3_0.int_0);
			}
			if (!class16_0.vmethod_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(this.struct3_0.long_0 << ((Class5.Class17)class16_0).vmethod_19().struct2_0.int_0);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0002126C File Offset: 0x0001F46C
		public override Class5.Class16 vmethod_76(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_3())
			{
				return new Class5.Class19(this.struct3_0.long_0 >> ((Class5.Class19)class16_0).struct3_0.int_0);
			}
			if (!class16_0.vmethod_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(this.struct3_0.long_0 >> ((Class5.Class17)class16_0).vmethod_19().struct2_0.int_0);
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x000212F0 File Offset: 0x0001F4F0
		public override Class5.Class16 vmethod_77(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_3())
			{
				return new Class5.Class19(this.struct3_0.ulong_0 >> ((Class5.Class19)class16_0).struct3_0.int_0);
			}
			if (!class16_0.vmethod_3())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class19(this.struct3_0.ulong_0 >> ((Class5.Class17)class16_0).vmethod_19().struct2_0.int_0);
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00021374 File Offset: 0x0001F574
		public override string ToString()
		{
			if (this.enum1_0 == (Class5.Enum1)7)
			{
				return this.struct3_0.long_0.ToString();
			}
			return this.struct3_0.ulong_0.ToString();
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0000357B File Offset: 0x0000177B
		internal override Class5.Class16 vmethod_8()
		{
			return this;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0000357E File Offset: 0x0000177E
		internal override bool vmethod_9()
		{
			return true;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x000213AC File Offset: 0x0001F5AC
		internal override bool vmethod_5(Class5.Class16 class16_0)
		{
			if (class16_0.method_0())
			{
				return ((Class5.Class28)class16_0).vmethod_5(this);
			}
			if (class16_0.vmethod_0())
			{
				return ((Class5.Class22)class16_0).vmethod_5(this);
			}
			Class5.Class16 @class = class16_0.vmethod_8();
			return @class.method_3() && this.struct3_0.long_0 == ((Class5.Class19)@class).struct3_0.long_0;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00020290 File Offset: 0x0001E490
		private static Class5.Class17 smethod_4(Class5.Class16 class16_0)
		{
			Class5.Class17 @class = class16_0 as Class5.Class17;
			if (@class == null && class16_0.vmethod_0())
			{
				@class = (class16_0.vmethod_8() as Class5.Class17);
			}
			return @class;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00021414 File Offset: 0x0001F614
		internal override bool vmethod_6(Class5.Class16 class16_0)
		{
			if (class16_0.method_0())
			{
				return false;
			}
			if (class16_0.vmethod_0())
			{
				return ((Class5.Class22)class16_0).vmethod_6(this);
			}
			Class5.Class16 @class = class16_0.vmethod_8();
			return @class.method_3() && this.struct3_0.ulong_0 != ((Class5.Class19)@class).struct3_0.ulong_0;
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00021474 File Offset: 0x0001F674
		public override bool vmethod_78(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return this.struct3_0.long_0 >= ((Class5.Class19)class16_0).struct3_0.long_0;
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x000214C0 File Offset: 0x0001F6C0
		public override bool vmethod_79(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return this.struct3_0.ulong_0 >= ((Class5.Class19)class16_0).struct3_0.ulong_0;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0002150C File Offset: 0x0001F70C
		public override bool vmethod_80(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return this.struct3_0.long_0 > ((Class5.Class19)class16_0).struct3_0.long_0;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00021554 File Offset: 0x0001F754
		public override bool vmethod_81(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return this.struct3_0.ulong_0 > ((Class5.Class19)class16_0).struct3_0.ulong_0;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0002159C File Offset: 0x0001F79C
		public override bool vmethod_82(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return this.struct3_0.long_0 <= ((Class5.Class19)class16_0).struct3_0.long_0;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x000215E8 File Offset: 0x0001F7E8
		public override bool vmethod_83(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return this.struct3_0.ulong_0 <= ((Class5.Class19)class16_0).struct3_0.ulong_0;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00021634 File Offset: 0x0001F834
		public override bool vmethod_84(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return this.struct3_0.long_0 < ((Class5.Class19)class16_0).struct3_0.long_0;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0002167C File Offset: 0x0001F87C
		public override bool vmethod_85(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_3())
			{
				throw new Class5.Exception1();
			}
			return this.struct3_0.ulong_0 < ((Class5.Class19)class16_0).struct3_0.ulong_0;
		}

		// Token: 0x04000394 RID: 916
		public Class5.Struct3 struct3_0;

		// Token: 0x04000395 RID: 917
		public Class5.Enum1 enum1_0;
	}

	// Token: 0x0200009C RID: 156
	private class Class20 : Class5.Class17
	{
		// Token: 0x060003F8 RID: 1016 RVA: 0x000216C4 File Offset: 0x0001F8C4
		internal void method_6(Class5.Class16 class16_0)
		{
			if (class16_0.method_2())
			{
				this.class17_0 = ((Class5.Class20)class16_0).class17_0;
				this.enum1_0 = ((Class5.Class20)class16_0).enum1_0;
				return;
			}
			this.vmethod_10(class16_0);
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00021704 File Offset: 0x0001F904
		internal unsafe override void vmethod_10(Class5.Class16 class16_0)
		{
			if (class16_0.method_2())
			{
				if (IntPtr.Size == 8)
				{
					IntPtr value = new IntPtr(((Class5.Class19)this.class17_0).struct3_0.long_0);
					IntPtr intPtr = new IntPtr(((Class5.Class19)((Class5.Class20)class16_0).class17_0).struct3_0.long_0);
					*(long*)((void*)value) = intPtr.ToInt64();
					return;
				}
				IntPtr value2 = new IntPtr(((Class5.Class18)this.class17_0).struct2_0.int_0);
				IntPtr intPtr2 = new IntPtr(((Class5.Class18)((Class5.Class20)class16_0).class17_0).struct2_0.int_0);
				*(int*)((void*)value2) = intPtr2.ToInt32();
				return;
			}
			else
			{
				object obj = class16_0.vmethod_4(null);
				if (obj == null)
				{
					return;
				}
				IntPtr value3;
				if (IntPtr.Size == 8)
				{
					value3 = new IntPtr(((Class5.Class19)this.class17_0).struct3_0.long_0);
				}
				else
				{
					value3 = new IntPtr(((Class5.Class18)this.class17_0).struct2_0.int_0);
				}
				Type type = obj.GetType();
				if (type == typeof(string))
				{
					return;
				}
				if (type == typeof(byte))
				{
					*(byte*)((void*)value3) = (byte)obj;
					return;
				}
				if (type == typeof(sbyte))
				{
					*(byte*)((void*)value3) = (byte)((sbyte)obj);
					return;
				}
				if (type == typeof(short))
				{
					*(short*)((void*)value3) = (short)obj;
					return;
				}
				if (type == typeof(ushort))
				{
					*(short*)((void*)value3) = (short)((ushort)obj);
					return;
				}
				if (type == typeof(int))
				{
					*(int*)((void*)value3) = (int)obj;
					return;
				}
				if (type == typeof(uint))
				{
					*(int*)((void*)value3) = (int)((uint)obj);
					return;
				}
				if (type == typeof(long))
				{
					*(long*)((void*)value3) = (long)obj;
					return;
				}
				if (type == typeof(ulong))
				{
					*(long*)((void*)value3) = (long)((ulong)obj);
					return;
				}
				if (type == typeof(float))
				{
					*(float*)((void*)value3) = (float)obj;
					return;
				}
				if (type == typeof(double))
				{
					*(double*)((void*)value3) = (double)obj;
					return;
				}
				if (type == typeof(bool))
				{
					*(byte*)((void*)value3) = (((bool)obj) ? 1 : 0);
					return;
				}
				if (type == typeof(IntPtr))
				{
					*(IntPtr*)((void*)value3) = (IntPtr)obj;
					return;
				}
				if (type == typeof(UIntPtr))
				{
					*(IntPtr*)((void*)value3) = (IntPtr)((UIntPtr)obj);
					return;
				}
				if (type == typeof(char))
				{
					*(short*)((void*)value3) = (short)((char)obj);
					return;
				}
				throw new Class5.Exception1();
			}
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0001F0EC File Offset: 0x0001D2EC
		internal override void vmethod_2(Class5.Class16 class16_0)
		{
			this.vmethod_10(class16_0);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00021A1C File Offset: 0x0001FC1C
		public Class20(IntPtr intptr_0)
		{
			this.enum4_0 = (Class5.Enum4)3;
			if (IntPtr.Size == 8)
			{
				this.class17_0 = new Class5.Class19(intptr_0.ToInt64());
				this.enum1_0 = (Class5.Enum1)12;
				return;
			}
			this.class17_0 = new Class5.Class18(intptr_0.ToInt32());
			this.enum1_0 = (Class5.Enum1)12;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00021A74 File Offset: 0x0001FC74
		public Class20(UIntPtr uintptr_0)
		{
			this.enum4_0 = (Class5.Enum4)3;
			if (IntPtr.Size == 8)
			{
				this.class17_0 = new Class5.Class19(uintptr_0.ToUInt64());
				this.enum1_0 = (Class5.Enum1)12;
				return;
			}
			this.class17_0 = new Class5.Class18(uintptr_0.ToUInt32());
			this.enum1_0 = (Class5.Enum1)12;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00021ACC File Offset: 0x0001FCCC
		public Class20()
		{
			this.enum4_0 = (Class5.Enum4)3;
			if (IntPtr.Size == 8)
			{
				this.class17_0 = new Class5.Class19(0L);
				this.enum1_0 = (Class5.Enum1)12;
				return;
			}
			this.class17_0 = new Class5.Class18(0);
			this.enum1_0 = (Class5.Enum1)12;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x000037AD File Offset: 0x000019AD
		public override Class5.Class17 vmethod_74()
		{
			return new Class5.Class20
			{
				class17_0 = this.class17_0.vmethod_74(),
				enum1_0 = this.enum1_0
			};
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00021B20 File Offset: 0x0001FD20
		public Class20(long long_0)
		{
			this.enum4_0 = (Class5.Enum4)3;
			if (IntPtr.Size == 8)
			{
				this.class17_0 = new Class5.Class19(long_0);
				this.enum1_0 = (Class5.Enum1)12;
				return;
			}
			this.class17_0 = new Class5.Class18((int)long_0);
			this.enum1_0 = (Class5.Enum1)12;
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00021B70 File Offset: 0x0001FD70
		public Class20(long long_0, Class5.Enum1 enum1_1)
		{
			this.enum4_0 = (Class5.Enum4)3;
			if (IntPtr.Size == 8)
			{
				this.class17_0 = new Class5.Class19(long_0);
				this.enum1_0 = enum1_1;
				return;
			}
			this.class17_0 = new Class5.Class18((int)long_0);
			this.enum1_0 = enum1_1;
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x00021BBC File Offset: 0x0001FDBC
		public Class20(ulong ulong_0)
		{
			this.enum4_0 = (Class5.Enum4)4;
			if (IntPtr.Size == 8)
			{
				this.class17_0 = new Class5.Class19(ulong_0);
				this.enum1_0 = (Class5.Enum1)13;
				return;
			}
			this.class17_0 = new Class5.Class18((uint)ulong_0);
			this.enum1_0 = (Class5.Enum1)13;
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00021C0C File Offset: 0x0001FE0C
		public Class20(ulong ulong_0, Class5.Enum1 enum1_1)
		{
			this.enum4_0 = (Class5.Enum4)4;
			if (IntPtr.Size == 8)
			{
				this.class17_0 = new Class5.Class19(ulong_0);
				this.enum1_0 = enum1_1;
				return;
			}
			this.class17_0 = new Class5.Class18((uint)ulong_0);
			this.enum1_0 = enum1_1;
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x000037D1 File Offset: 0x000019D1
		public override bool vmethod_11()
		{
			return this.class17_0.vmethod_11();
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0000333D File Offset: 0x0000153D
		public override bool vmethod_12()
		{
			return !this.vmethod_11();
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00003348 File Offset: 0x00001548
		internal override bool vmethod_7()
		{
			return this.vmethod_12();
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0000357E File Offset: 0x0000177E
		internal override bool vmethod_1()
		{
			return true;
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00021C58 File Offset: 0x0001FE58
		public override Class5.Class16 vmethod_13(Class5.Enum1 enum1_1)
		{
			switch (enum1_1)
			{
			case (Class5.Enum1)1:
				return this.vmethod_15();
			case (Class5.Enum1)2:
				return this.vmethod_16();
			case (Class5.Enum1)3:
				return this.vmethod_17();
			case (Class5.Enum1)4:
				return this.vmethod_18();
			case (Class5.Enum1)5:
				return this.vmethod_19();
			case (Class5.Enum1)6:
				return this.vmethod_20();
			case (Class5.Enum1)7:
				return this.vmethod_21();
			case (Class5.Enum1)8:
				return this.vmethod_22();
			case (Class5.Enum1)11:
				return this.vmethod_14();
			case (Class5.Enum1)12:
				return this;
			case (Class5.Enum1)13:
				return this;
			case (Class5.Enum1)16:
				return this.vmethod_74();
			}
			throw new Exception(((Class5.Enum5)4).ToString());
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00021D10 File Offset: 0x0001FF10
		internal IntPtr method_7()
		{
			if (IntPtr.Size == 8)
			{
				return new IntPtr(((Class5.Class19)this.class17_0).struct3_0.long_0);
			}
			return new IntPtr(((Class5.Class18)this.class17_0).struct2_0.int_0);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00021D5C File Offset: 0x0001FF5C
		internal override object vmethod_4(Type type_0)
		{
			if (type_0 != null && type_0.IsByRef)
			{
				type_0 = type_0.GetElementType();
			}
			if (type_0 == typeof(IntPtr))
			{
				if (IntPtr.Size == 8)
				{
					return new IntPtr(((Class5.Class19)this.class17_0).struct3_0.long_0);
				}
				return new IntPtr(((Class5.Class18)this.class17_0).struct2_0.int_0);
			}
			else if (!(type_0 == typeof(UIntPtr)))
			{
				if (!(type_0 == null) && !(type_0 == typeof(object)))
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					if (this.enum1_0 == (Class5.Enum1)12)
					{
						return new IntPtr(((Class5.Class19)this.class17_0).struct3_0.long_0);
					}
					return new UIntPtr(((Class5.Class19)this.class17_0).struct3_0.ulong_0);
				}
				else
				{
					if (this.enum1_0 == (Class5.Enum1)12)
					{
						return new IntPtr(((Class5.Class19)this.class17_0).struct3_0.int_0);
					}
					return new UIntPtr(((Class5.Class18)this.class17_0).struct2_0.uint_0);
				}
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new UIntPtr(((Class5.Class19)this.class17_0).struct3_0.ulong_0);
				}
				return new UIntPtr(((Class5.Class18)this.class17_0).struct2_0.uint_0);
			}
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x000037DE File Offset: 0x000019DE
		public override Class5.Class18 vmethod_14()
		{
			return this.class17_0.vmethod_14();
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x000037EB File Offset: 0x000019EB
		public override Class5.Class18 vmethod_15()
		{
			return this.class17_0.vmethod_15();
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x000037F8 File Offset: 0x000019F8
		public override Class5.Class18 vmethod_16()
		{
			return this.class17_0.vmethod_16();
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00003805 File Offset: 0x00001A05
		public override Class5.Class18 vmethod_17()
		{
			return this.class17_0.vmethod_17();
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00003812 File Offset: 0x00001A12
		public override Class5.Class18 vmethod_18()
		{
			return this.class17_0.vmethod_18();
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0000381F File Offset: 0x00001A1F
		public override Class5.Class18 vmethod_19()
		{
			return this.class17_0.vmethod_19();
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0000382C File Offset: 0x00001A2C
		public override Class5.Class18 vmethod_20()
		{
			return this.class17_0.vmethod_20();
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00003839 File Offset: 0x00001A39
		public override Class5.Class19 vmethod_21()
		{
			return this.class17_0.vmethod_21();
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00003846 File Offset: 0x00001A46
		public override Class5.Class19 vmethod_22()
		{
			return this.class17_0.vmethod_22();
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x000033FE File Offset: 0x000015FE
		public override Class5.Class18 vmethod_23()
		{
			return this.vmethod_15();
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00003406 File Offset: 0x00001606
		public override Class5.Class18 vmethod_24()
		{
			return this.vmethod_17();
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0000340E File Offset: 0x0000160E
		public override Class5.Class18 vmethod_25()
		{
			return this.vmethod_19();
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00003416 File Offset: 0x00001616
		public override Class5.Class19 vmethod_26()
		{
			return this.vmethod_21();
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x0000341E File Offset: 0x0000161E
		public override Class5.Class18 vmethod_27()
		{
			return this.vmethod_16();
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00003426 File Offset: 0x00001626
		public override Class5.Class18 vmethod_28()
		{
			return this.vmethod_18();
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x0000342E File Offset: 0x0000162E
		public override Class5.Class18 vmethod_29()
		{
			return this.vmethod_20();
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00003436 File Offset: 0x00001636
		public override Class5.Class19 vmethod_30()
		{
			return this.vmethod_22();
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00003853 File Offset: 0x00001A53
		public override Class5.Class18 vmethod_31()
		{
			return this.class17_0.vmethod_31();
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00003860 File Offset: 0x00001A60
		public override Class5.Class18 vmethod_32()
		{
			return this.class17_0.vmethod_32();
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0000386D File Offset: 0x00001A6D
		public override Class5.Class18 vmethod_33()
		{
			return this.class17_0.vmethod_33();
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0000387A File Offset: 0x00001A7A
		public override Class5.Class18 vmethod_34()
		{
			return this.class17_0.vmethod_34();
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00003887 File Offset: 0x00001A87
		public override Class5.Class18 vmethod_35()
		{
			return this.class17_0.vmethod_35();
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00003894 File Offset: 0x00001A94
		public override Class5.Class18 vmethod_36()
		{
			return this.class17_0.vmethod_36();
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x000038A1 File Offset: 0x00001AA1
		public override Class5.Class19 vmethod_37()
		{
			return this.class17_0.vmethod_37();
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x000038AE File Offset: 0x00001AAE
		public override Class5.Class19 vmethod_38()
		{
			return this.class17_0.vmethod_38();
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x000038BB File Offset: 0x00001ABB
		public override Class5.Class18 vmethod_39()
		{
			return this.class17_0.vmethod_39();
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x000038C8 File Offset: 0x00001AC8
		public override Class5.Class18 vmethod_40()
		{
			return this.class17_0.vmethod_40();
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x000038D5 File Offset: 0x00001AD5
		public override Class5.Class18 vmethod_41()
		{
			return this.class17_0.vmethod_41();
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x000038E2 File Offset: 0x00001AE2
		public override Class5.Class18 vmethod_42()
		{
			return this.class17_0.vmethod_42();
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x000038EF File Offset: 0x00001AEF
		public override Class5.Class18 vmethod_43()
		{
			return this.class17_0.vmethod_43();
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x000038FC File Offset: 0x00001AFC
		public override Class5.Class18 vmethod_44()
		{
			return this.class17_0.vmethod_44();
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00003909 File Offset: 0x00001B09
		public override Class5.Class19 vmethod_45()
		{
			return this.class17_0.vmethod_45();
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00003916 File Offset: 0x00001B16
		public override Class5.Class19 vmethod_46()
		{
			return this.class17_0.vmethod_46();
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00003923 File Offset: 0x00001B23
		public override Class5.Class21 vmethod_47()
		{
			return this.class17_0.vmethod_47();
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x00003930 File Offset: 0x00001B30
		public override Class5.Class21 vmethod_48()
		{
			return this.class17_0.vmethod_48();
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0000393D File Offset: 0x00001B3D
		public override Class5.Class21 vmethod_49()
		{
			return this.class17_0.vmethod_49();
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0001F83C File Offset: 0x0001DA3C
		public override Class5.Class20 vmethod_50()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_26().struct3_0.long_0);
			}
			return new Class5.Class20((long)this.vmethod_25().struct2_0.int_0);
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0001F880 File Offset: 0x0001DA80
		public override Class5.Class20 vmethod_51()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_30().struct3_0.ulong_0);
			}
			return new Class5.Class20((ulong)this.vmethod_29().struct2_0.uint_0);
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0001F8C4 File Offset: 0x0001DAC4
		public override Class5.Class20 vmethod_52()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_37().struct3_0.long_0);
			}
			return new Class5.Class20((long)this.vmethod_35().struct2_0.int_0);
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x0001F908 File Offset: 0x0001DB08
		public override Class5.Class20 vmethod_53()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_45().struct3_0.ulong_0);
			}
			return new Class5.Class20((ulong)this.vmethod_43().struct2_0.uint_0);
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x0001F94C File Offset: 0x0001DB4C
		public override Class5.Class20 vmethod_54()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_38().struct3_0.long_0);
			}
			return new Class5.Class20((long)this.vmethod_36().struct2_0.int_0);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0001F990 File Offset: 0x0001DB90
		public override Class5.Class20 vmethod_55()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_46().struct3_0.ulong_0);
			}
			return new Class5.Class20((ulong)this.vmethod_44().struct2_0.uint_0);
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00021EF8 File Offset: 0x000200F8
		public override Class5.Class16 vmethod_56()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(-((Class5.Class19)this.class17_0).struct3_0.long_0);
			}
			return new Class5.Class20((long)(-(long)((Class5.Class18)this.class17_0).struct2_0.int_0));
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00021F48 File Offset: 0x00020148
		public override Class5.Class16 vmethod_57(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 + ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 + ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 + ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 + ((Class5.Class18)class16_0).struct2_0.int_0));
			}
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00022038 File Offset: 0x00020238
		public override Class5.Class16 vmethod_58(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(this.vmethod_21().struct3_0.long_0 + ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0));
				}
				return new Class5.Class20((long)(checked(this.vmethod_19().struct2_0.int_0 + ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0)));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(this.vmethod_21().struct3_0.long_0 + ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0));
				}
				return new Class5.Class20((long)(checked(this.vmethod_19().struct2_0.int_0 + ((Class5.Class18)class16_0).struct2_0.int_0)));
			}
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00022128 File Offset: 0x00020328
		public override Class5.Class16 vmethod_59(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(this.vmethod_21().struct3_0.ulong_0 + ((Class5.Class20)class16_0).vmethod_21().struct3_0.ulong_0));
				}
				return new Class5.Class20((ulong)(checked(this.vmethod_19().struct2_0.uint_0 + ((Class5.Class20)class16_0).vmethod_19().struct2_0.uint_0)));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(this.vmethod_21().struct3_0.ulong_0 + unchecked((ulong)((Class5.Class18)class16_0).struct2_0.uint_0)));
				}
				return new Class5.Class20((long)((ulong)(checked(this.vmethod_19().struct2_0.uint_0 + ((Class5.Class18)class16_0).struct2_0.uint_0))));
			}
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00022214 File Offset: 0x00020414
		public override Class5.Class16 vmethod_60(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 - ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 - ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 - ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 - ((Class5.Class18)class16_0).struct2_0.int_0));
			}
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00022304 File Offset: 0x00020504
		public Class5.Class16 method_8(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0 - this.vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(((Class5.Class18)class16_0).struct2_0.int_0 - this.vmethod_19().struct2_0.int_0));
			}
			else
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0 - this.vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0 - this.vmethod_19().struct2_0.int_0));
			}
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x000223F4 File Offset: 0x000205F4
		public override Class5.Class16 vmethod_61(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(this.vmethod_21().struct3_0.long_0 - ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0));
				}
				return new Class5.Class20((long)(checked(this.vmethod_19().struct2_0.int_0 - ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0)));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(this.vmethod_21().struct3_0.long_0 - ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0));
				}
				return new Class5.Class20((long)(checked(this.vmethod_19().struct2_0.int_0 - ((Class5.Class18)class16_0).struct2_0.int_0)));
			}
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x000224E4 File Offset: 0x000206E4
		public Class5.Class16 method_9(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0 - this.vmethod_21().struct3_0.long_0));
				}
				return new Class5.Class20((long)(checked(((Class5.Class18)class16_0).struct2_0.int_0 - this.vmethod_19().struct2_0.int_0)));
			}
			else
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0 - this.vmethod_21().struct3_0.long_0));
				}
				return new Class5.Class20((long)(checked(((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0 - this.vmethod_19().struct2_0.int_0)));
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x000225D4 File Offset: 0x000207D4
		public override Class5.Class16 vmethod_62(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(this.vmethod_21().struct3_0.ulong_0 - ((Class5.Class20)class16_0).vmethod_21().struct3_0.ulong_0));
				}
				return new Class5.Class20((ulong)(checked(this.vmethod_19().struct2_0.uint_0 - ((Class5.Class20)class16_0).vmethod_19().struct2_0.uint_0)));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(this.vmethod_21().struct3_0.ulong_0 - unchecked((ulong)((Class5.Class18)class16_0).struct2_0.uint_0)));
				}
				return new Class5.Class20((long)((ulong)(checked(this.vmethod_19().struct2_0.uint_0 - ((Class5.Class18)class16_0).struct2_0.uint_0))));
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x000226C0 File Offset: 0x000208C0
		public Class5.Class16 method_10(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(((Class5.Class20)class16_0).vmethod_21().struct3_0.ulong_0 - this.vmethod_21().struct3_0.ulong_0));
				}
				return new Class5.Class20((ulong)(checked(((Class5.Class20)class16_0).vmethod_19().struct2_0.uint_0 - this.vmethod_19().struct2_0.uint_0)));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(unchecked((ulong)((Class5.Class18)class16_0).struct2_0.uint_0) - this.vmethod_21().struct3_0.ulong_0));
				}
				return new Class5.Class20((long)((ulong)(checked(((Class5.Class18)class16_0).struct2_0.uint_0 - this.vmethod_19().struct2_0.uint_0))));
			}
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x000227AC File Offset: 0x000209AC
		public override Class5.Class16 vmethod_63(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 * ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 * ((Class5.Class18)class16_0).struct2_0.int_0));
			}
			else
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 * ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 * ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0));
			}
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0002289C File Offset: 0x00020A9C
		public override Class5.Class16 vmethod_64(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(this.vmethod_21().struct3_0.long_0 * ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0));
				}
				return new Class5.Class20((long)(checked(this.vmethod_19().struct2_0.int_0 * ((Class5.Class18)class16_0).struct2_0.int_0)));
			}
			else
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(this.vmethod_21().struct3_0.long_0 * ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0));
				}
				return new Class5.Class20((long)(checked(this.vmethod_19().struct2_0.int_0 * ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0)));
			}
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x0002298C File Offset: 0x00020B8C
		public override Class5.Class16 vmethod_65(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(this.vmethod_21().struct3_0.ulong_0 * ((Class5.Class20)class16_0).vmethod_21().struct3_0.ulong_0));
				}
				return new Class5.Class20((ulong)(checked(this.vmethod_19().struct2_0.uint_0 * ((Class5.Class20)class16_0).vmethod_19().struct2_0.uint_0)));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(checked(this.vmethod_21().struct3_0.ulong_0 * unchecked((ulong)((Class5.Class18)class16_0).struct2_0.uint_0)));
				}
				return new Class5.Class20((long)((ulong)(checked(this.vmethod_19().struct2_0.uint_0 * ((Class5.Class18)class16_0).struct2_0.uint_0))));
			}
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00022A78 File Offset: 0x00020C78
		public override Class5.Class16 vmethod_66(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 / ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 / ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 / ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 / ((Class5.Class18)class16_0).struct2_0.int_0));
			}
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00022B68 File Offset: 0x00020D68
		public Class5.Class16 method_11(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0 / this.vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0 / this.vmethod_19().struct2_0.int_0));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0 / this.vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(((Class5.Class18)class16_0).struct2_0.int_0 / this.vmethod_19().struct2_0.int_0));
			}
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00022C58 File Offset: 0x00020E58
		public override Class5.Class16 vmethod_67(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.ulong_0 / ((Class5.Class18)class16_0).vmethod_21().struct3_0.ulong_0);
				}
				return new Class5.Class20((long)((ulong)(this.vmethod_19().struct2_0.uint_0 / ((Class5.Class18)class16_0).struct2_0.uint_0)));
			}
			else
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.ulong_0 / ((Class5.Class20)class16_0).vmethod_21().struct3_0.ulong_0);
				}
				return new Class5.Class20((ulong)(this.vmethod_19().struct2_0.uint_0 / ((Class5.Class20)class16_0).vmethod_19().struct2_0.uint_0));
			}
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00022D48 File Offset: 0x00020F48
		public Class5.Class16 method_12(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(((Class5.Class20)class16_0).vmethod_21().struct3_0.ulong_0 / this.vmethod_21().struct3_0.ulong_0);
				}
				return new Class5.Class20((ulong)(((Class5.Class20)class16_0).vmethod_19().struct2_0.uint_0 / this.vmethod_19().struct2_0.uint_0));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(((Class5.Class18)class16_0).vmethod_21().struct3_0.ulong_0 / this.vmethod_21().struct3_0.ulong_0);
				}
				return new Class5.Class20((long)((ulong)(((Class5.Class18)class16_0).struct2_0.uint_0 / this.vmethod_19().struct2_0.uint_0)));
			}
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00022E38 File Offset: 0x00021038
		public override Class5.Class16 vmethod_68(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 % ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 % ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 % ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 % ((Class5.Class18)class16_0).struct2_0.int_0));
			}
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00022F28 File Offset: 0x00021128
		public Class5.Class16 method_13(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0 % this.vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0 % this.vmethod_19().struct2_0.int_0));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0 % this.vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(((Class5.Class18)class16_0).struct2_0.int_0 % this.vmethod_19().struct2_0.int_0));
			}
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00023018 File Offset: 0x00021218
		public override Class5.Class16 vmethod_69(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.ulong_0 % ((Class5.Class20)class16_0).vmethod_21().struct3_0.ulong_0);
				}
				return new Class5.Class20((ulong)(this.vmethod_19().struct2_0.uint_0 % ((Class5.Class20)class16_0).vmethod_19().struct2_0.uint_0));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.ulong_0 % ((Class5.Class18)class16_0).vmethod_21().struct3_0.ulong_0);
				}
				return new Class5.Class20((long)((ulong)(this.vmethod_19().struct2_0.uint_0 % ((Class5.Class18)class16_0).struct2_0.uint_0)));
			}
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00023108 File Offset: 0x00021308
		public Class5.Class16 method_14(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(((Class5.Class18)class16_0).vmethod_21().struct3_0.ulong_0 % this.vmethod_21().struct3_0.ulong_0);
				}
				return new Class5.Class20((long)((ulong)(((Class5.Class18)class16_0).struct2_0.uint_0 % this.vmethod_19().struct2_0.uint_0)));
			}
			else
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(((Class5.Class20)class16_0).vmethod_21().struct3_0.ulong_0 % this.vmethod_21().struct3_0.ulong_0);
				}
				return new Class5.Class20((ulong)(((Class5.Class20)class16_0).vmethod_19().struct2_0.uint_0 % this.vmethod_19().struct2_0.uint_0));
			}
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x000231F8 File Offset: 0x000213F8
		public override Class5.Class16 vmethod_70(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 & ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 & ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 & ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 & ((Class5.Class18)class16_0).struct2_0.int_0));
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x000232E8 File Offset: 0x000214E8
		public override Class5.Class16 vmethod_71(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 | ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 | ((Class5.Class18)class16_0).struct2_0.int_0));
			}
			else
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 | ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 | ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0));
			}
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x000233D8 File Offset: 0x000215D8
		public override Class5.Class16 vmethod_72()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(~this.vmethod_21().struct3_0.long_0);
			}
			return new Class5.Class20((long)(~(long)this.vmethod_19().struct2_0.int_0));
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0002341C File Offset: 0x0002161C
		public override Class5.Class16 vmethod_73(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 ^ ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 ^ ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 ^ ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 ^ ((Class5.Class18)class16_0).struct2_0.int_0));
			}
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0002350C File Offset: 0x0002170C
		public override Class5.Class16 vmethod_75(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 << ((Class5.Class20)class16_0).vmethod_21().struct3_0.int_0);
				}
				return new Class5.Class20((long)((long)this.vmethod_19().struct2_0.int_0 << ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0));
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 << ((Class5.Class18)class16_0).struct2_0.int_0);
				}
				return new Class5.Class20((long)((long)this.vmethod_19().struct2_0.int_0 << ((Class5.Class18)class16_0).struct2_0.int_0));
			}
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00023604 File Offset: 0x00021804
		public override Class5.Class16 vmethod_76(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 >> ((Class5.Class18)class16_0).struct2_0.int_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 >> ((Class5.Class18)class16_0).struct2_0.int_0));
			}
			else
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.long_0 >> ((Class5.Class20)class16_0).vmethod_21().struct3_0.int_0);
				}
				return new Class5.Class20((long)(this.vmethod_19().struct2_0.int_0 >> ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0));
			}
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x000236FC File Offset: 0x000218FC
		public override Class5.Class16 vmethod_77(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.ulong_0 >> ((Class5.Class18)class16_0).struct2_0.int_0);
				}
				return new Class5.Class20((long)((ulong)(this.vmethod_19().struct2_0.uint_0 >> ((Class5.Class18)class16_0).struct2_0.int_0)));
			}
			else
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class5.Class20(this.vmethod_21().struct3_0.ulong_0 >> ((Class5.Class20)class16_0).vmethod_21().struct3_0.int_0);
				}
				return new Class5.Class20((long)((ulong)(this.vmethod_19().struct2_0.uint_0 >> ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0)));
			}
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0000394A File Offset: 0x00001B4A
		public Class5.Class16 method_15(Class5.Class18 class18_0)
		{
			return new Class5.Class20((long)((ulong)(class18_0.struct2_0.uint_0 >> this.vmethod_19().struct2_0.int_0)));
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00003971 File Offset: 0x00001B71
		public Class5.Class16 method_16(Class5.Class18 class18_0)
		{
			return new Class5.Class20((long)(class18_0.struct2_0.int_0 >> this.vmethod_21().struct3_0.int_0));
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00003998 File Offset: 0x00001B98
		public Class5.Class16 method_17(Class5.Class18 class18_0)
		{
			return new Class5.Class20((long)((long)class18_0.struct2_0.int_0 << this.vmethod_21().struct3_0.int_0));
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x000039BF File Offset: 0x00001BBF
		public override string ToString()
		{
			return this.class17_0.ToString();
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x0000357B File Offset: 0x0000177B
		internal override Class5.Class16 vmethod_8()
		{
			return this;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0000357E File Offset: 0x0000177E
		internal override bool vmethod_9()
		{
			return true;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x000237F4 File Offset: 0x000219F4
		internal override bool vmethod_5(Class5.Class16 class16_0)
		{
			if (class16_0.method_0())
			{
				return false;
			}
			if (class16_0.vmethod_0())
			{
				return ((Class5.Class22)class16_0).vmethod_5(this);
			}
			Class5.Class16 @class = class16_0.vmethod_8();
			if (!@class.vmethod_9())
			{
				return false;
			}
			if (@class.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.long_0 == ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0;
				}
				return this.vmethod_19().struct2_0.int_0 == ((Class5.Class18)class16_0).struct2_0.int_0;
			}
			else
			{
				if (@class.method_2())
				{
					int size = IntPtr.Size;
					return this.vmethod_21().struct3_0.long_0 == ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0;
				}
				return false;
			}
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x000238CC File Offset: 0x00021ACC
		internal override bool vmethod_6(Class5.Class16 class16_0)
		{
			if (class16_0.method_0())
			{
				return false;
			}
			if (class16_0.vmethod_0())
			{
				return ((Class5.Class22)class16_0).vmethod_6(this);
			}
			Class5.Class16 @class = class16_0.vmethod_8();
			if (!@class.vmethod_9())
			{
				return false;
			}
			if (!@class.method_1())
			{
				if (@class.method_2())
				{
					int size = IntPtr.Size;
					return this.vmethod_21().struct3_0.ulong_0 != ((Class5.Class20)class16_0).vmethod_21().struct3_0.ulong_0;
				}
				return false;
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.ulong_0 != ((Class5.Class18)class16_0).vmethod_21().struct3_0.ulong_0;
				}
				return this.vmethod_19().struct2_0.uint_0 != ((Class5.Class18)class16_0).struct2_0.uint_0;
			}
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x000239A8 File Offset: 0x00021BA8
		public override bool vmethod_78(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.long_0 >= ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0;
				}
				return this.vmethod_19().struct2_0.int_0 >= ((Class5.Class18)class16_0).struct2_0.int_0;
			}
			else
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.long_0 >= ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0;
				}
				return this.vmethod_19().struct2_0.int_0 >= ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0;
			}
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00023A94 File Offset: 0x00021C94
		public override bool vmethod_79(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.ulong_0 >= ((Class5.Class18)class16_0).vmethod_21().struct3_0.ulong_0;
				}
				return this.vmethod_19().struct2_0.uint_0 >= ((Class5.Class18)class16_0).struct2_0.uint_0;
			}
			else
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.ulong_0 >= ((Class5.Class20)class16_0).vmethod_21().struct3_0.ulong_0;
				}
				return this.vmethod_19().struct2_0.uint_0 >= ((Class5.Class20)class16_0).vmethod_19().struct2_0.uint_0;
			}
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00023B80 File Offset: 0x00021D80
		public override bool vmethod_80(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.long_0 > ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0;
				}
				return this.vmethod_19().struct2_0.int_0 > ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0;
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.long_0 > ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0;
				}
				return this.vmethod_19().struct2_0.int_0 > ((Class5.Class18)class16_0).struct2_0.int_0;
			}
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00023C60 File Offset: 0x00021E60
		public override bool vmethod_81(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.ulong_0 > ((Class5.Class18)class16_0).vmethod_21().struct3_0.ulong_0;
				}
				return this.vmethod_19().struct2_0.uint_0 > ((Class5.Class18)class16_0).struct2_0.uint_0;
			}
			else
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.ulong_0 > ((Class5.Class20)class16_0).vmethod_21().struct3_0.ulong_0;
				}
				return this.vmethod_19().struct2_0.uint_0 > ((Class5.Class20)class16_0).vmethod_19().struct2_0.uint_0;
			}
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00023D40 File Offset: 0x00021F40
		public override bool vmethod_82(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.long_0 <= ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0;
				}
				return this.vmethod_19().struct2_0.int_0 <= ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0;
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.long_0 <= ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0;
				}
				return this.vmethod_19().struct2_0.int_0 <= ((Class5.Class18)class16_0).struct2_0.int_0;
			}
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00023E2C File Offset: 0x0002202C
		public override bool vmethod_83(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.ulong_0 <= ((Class5.Class20)class16_0).vmethod_21().struct3_0.ulong_0;
				}
				return this.vmethod_19().struct2_0.uint_0 <= ((Class5.Class20)class16_0).vmethod_19().struct2_0.uint_0;
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.ulong_0 <= ((Class5.Class18)class16_0).vmethod_21().struct3_0.ulong_0;
				}
				return this.vmethod_19().struct2_0.uint_0 <= ((Class5.Class18)class16_0).struct2_0.uint_0;
			}
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00023F18 File Offset: 0x00022118
		public override bool vmethod_84(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (class16_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.long_0 < ((Class5.Class18)class16_0).vmethod_21().struct3_0.long_0;
				}
				return this.vmethod_19().struct2_0.int_0 < ((Class5.Class18)class16_0).struct2_0.int_0;
			}
			else
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.long_0 < ((Class5.Class20)class16_0).vmethod_21().struct3_0.long_0;
				}
				return this.vmethod_19().struct2_0.int_0 < ((Class5.Class20)class16_0).vmethod_19().struct2_0.int_0;
			}
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00023FF8 File Offset: 0x000221F8
		public override bool vmethod_85(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_1())
			{
				if (!class16_0.method_2())
				{
					throw new Class5.Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.ulong_0 < ((Class5.Class20)class16_0).vmethod_21().struct3_0.ulong_0;
				}
				return this.vmethod_19().struct2_0.uint_0 < ((Class5.Class20)class16_0).vmethod_19().struct2_0.uint_0;
			}
			else
			{
				if (IntPtr.Size == 8)
				{
					return this.vmethod_21().struct3_0.ulong_0 < ((Class5.Class18)class16_0).vmethod_21().struct3_0.ulong_0;
				}
				return this.vmethod_19().struct2_0.uint_0 < ((Class5.Class18)class16_0).struct2_0.uint_0;
			}
		}

		// Token: 0x04000396 RID: 918
		public Class5.Class17 class17_0;

		// Token: 0x04000397 RID: 919
		public Class5.Enum1 enum1_0;
	}

	// Token: 0x0200009D RID: 157
	private abstract class Class17 : Class5.Class16
	{
		// Token: 0x06000460 RID: 1120
		public abstract bool vmethod_11();

		// Token: 0x06000461 RID: 1121
		public abstract bool vmethod_12();

		// Token: 0x06000462 RID: 1122
		public abstract Class5.Class16 vmethod_13(Class5.Enum1 enum1_0);

		// Token: 0x06000463 RID: 1123
		public abstract Class5.Class18 vmethod_14();

		// Token: 0x06000464 RID: 1124
		public abstract Class5.Class18 vmethod_15();

		// Token: 0x06000465 RID: 1125
		public abstract Class5.Class18 vmethod_16();

		// Token: 0x06000466 RID: 1126
		public abstract Class5.Class18 vmethod_17();

		// Token: 0x06000467 RID: 1127
		public abstract Class5.Class18 vmethod_18();

		// Token: 0x06000468 RID: 1128
		public abstract Class5.Class18 vmethod_19();

		// Token: 0x06000469 RID: 1129
		public abstract Class5.Class18 vmethod_20();

		// Token: 0x0600046A RID: 1130
		public abstract Class5.Class19 vmethod_21();

		// Token: 0x0600046B RID: 1131
		public abstract Class5.Class19 vmethod_22();

		// Token: 0x0600046C RID: 1132
		public abstract Class5.Class18 vmethod_23();

		// Token: 0x0600046D RID: 1133
		public abstract Class5.Class18 vmethod_24();

		// Token: 0x0600046E RID: 1134
		public abstract Class5.Class18 vmethod_25();

		// Token: 0x0600046F RID: 1135
		public abstract Class5.Class19 vmethod_26();

		// Token: 0x06000470 RID: 1136
		public abstract Class5.Class18 vmethod_27();

		// Token: 0x06000471 RID: 1137
		public abstract Class5.Class18 vmethod_28();

		// Token: 0x06000472 RID: 1138
		public abstract Class5.Class18 vmethod_29();

		// Token: 0x06000473 RID: 1139
		public abstract Class5.Class19 vmethod_30();

		// Token: 0x06000474 RID: 1140
		public abstract Class5.Class18 vmethod_31();

		// Token: 0x06000475 RID: 1141
		public abstract Class5.Class18 vmethod_32();

		// Token: 0x06000476 RID: 1142
		public abstract Class5.Class18 vmethod_33();

		// Token: 0x06000477 RID: 1143
		public abstract Class5.Class18 vmethod_34();

		// Token: 0x06000478 RID: 1144
		public abstract Class5.Class18 vmethod_35();

		// Token: 0x06000479 RID: 1145
		public abstract Class5.Class18 vmethod_36();

		// Token: 0x0600047A RID: 1146
		public abstract Class5.Class19 vmethod_37();

		// Token: 0x0600047B RID: 1147
		public abstract Class5.Class19 vmethod_38();

		// Token: 0x0600047C RID: 1148
		public abstract Class5.Class18 vmethod_39();

		// Token: 0x0600047D RID: 1149
		public abstract Class5.Class18 vmethod_40();

		// Token: 0x0600047E RID: 1150
		public abstract Class5.Class18 vmethod_41();

		// Token: 0x0600047F RID: 1151
		public abstract Class5.Class18 vmethod_42();

		// Token: 0x06000480 RID: 1152
		public abstract Class5.Class18 vmethod_43();

		// Token: 0x06000481 RID: 1153
		public abstract Class5.Class18 vmethod_44();

		// Token: 0x06000482 RID: 1154
		public abstract Class5.Class19 vmethod_45();

		// Token: 0x06000483 RID: 1155
		public abstract Class5.Class19 vmethod_46();

		// Token: 0x06000484 RID: 1156
		public abstract Class5.Class21 vmethod_47();

		// Token: 0x06000485 RID: 1157
		public abstract Class5.Class21 vmethod_48();

		// Token: 0x06000486 RID: 1158
		public abstract Class5.Class21 vmethod_49();

		// Token: 0x06000487 RID: 1159
		public abstract Class5.Class20 vmethod_50();

		// Token: 0x06000488 RID: 1160
		public abstract Class5.Class20 vmethod_51();

		// Token: 0x06000489 RID: 1161
		public abstract Class5.Class20 vmethod_52();

		// Token: 0x0600048A RID: 1162
		public abstract Class5.Class20 vmethod_53();

		// Token: 0x0600048B RID: 1163
		public abstract Class5.Class20 vmethod_54();

		// Token: 0x0600048C RID: 1164
		public abstract Class5.Class20 vmethod_55();

		// Token: 0x0600048D RID: 1165
		public abstract Class5.Class16 vmethod_56();

		// Token: 0x0600048E RID: 1166
		public abstract Class5.Class16 vmethod_57(Class5.Class16 class16_0);

		// Token: 0x0600048F RID: 1167
		public abstract Class5.Class16 vmethod_58(Class5.Class16 class16_0);

		// Token: 0x06000490 RID: 1168
		public abstract Class5.Class16 vmethod_59(Class5.Class16 class16_0);

		// Token: 0x06000491 RID: 1169
		public abstract Class5.Class16 vmethod_60(Class5.Class16 class16_0);

		// Token: 0x06000492 RID: 1170
		public abstract Class5.Class16 vmethod_61(Class5.Class16 class16_0);

		// Token: 0x06000493 RID: 1171
		public abstract Class5.Class16 vmethod_62(Class5.Class16 class16_0);

		// Token: 0x06000494 RID: 1172
		public abstract Class5.Class16 vmethod_63(Class5.Class16 class16_0);

		// Token: 0x06000495 RID: 1173
		public abstract Class5.Class16 vmethod_64(Class5.Class16 class16_0);

		// Token: 0x06000496 RID: 1174
		public abstract Class5.Class16 vmethod_65(Class5.Class16 class16_0);

		// Token: 0x06000497 RID: 1175
		public abstract Class5.Class16 vmethod_66(Class5.Class16 class16_0);

		// Token: 0x06000498 RID: 1176
		public abstract Class5.Class16 vmethod_67(Class5.Class16 class16_0);

		// Token: 0x06000499 RID: 1177
		public abstract Class5.Class16 vmethod_68(Class5.Class16 class16_0);

		// Token: 0x0600049A RID: 1178
		public abstract Class5.Class16 vmethod_69(Class5.Class16 class16_0);

		// Token: 0x0600049B RID: 1179
		public abstract Class5.Class16 vmethod_70(Class5.Class16 class16_0);

		// Token: 0x0600049C RID: 1180
		public abstract Class5.Class16 vmethod_71(Class5.Class16 class16_0);

		// Token: 0x0600049D RID: 1181
		public abstract Class5.Class16 vmethod_72();

		// Token: 0x0600049E RID: 1182
		public abstract Class5.Class16 vmethod_73(Class5.Class16 class16_0);

		// Token: 0x0600049F RID: 1183
		public abstract Class5.Class17 vmethod_74();

		// Token: 0x060004A0 RID: 1184
		public abstract Class5.Class16 vmethod_75(Class5.Class16 class16_0);

		// Token: 0x060004A1 RID: 1185
		public abstract Class5.Class16 vmethod_76(Class5.Class16 class16_0);

		// Token: 0x060004A2 RID: 1186
		public abstract Class5.Class16 vmethod_77(Class5.Class16 class16_0);

		// Token: 0x060004A3 RID: 1187
		public abstract bool vmethod_78(Class5.Class16 class16_0);

		// Token: 0x060004A4 RID: 1188
		public abstract bool vmethod_79(Class5.Class16 class16_0);

		// Token: 0x060004A5 RID: 1189
		public abstract bool vmethod_80(Class5.Class16 class16_0);

		// Token: 0x060004A6 RID: 1190
		public abstract bool vmethod_81(Class5.Class16 class16_0);

		// Token: 0x060004A7 RID: 1191
		public abstract bool vmethod_82(Class5.Class16 class16_0);

		// Token: 0x060004A8 RID: 1192
		public abstract bool vmethod_83(Class5.Class16 class16_0);

		// Token: 0x060004A9 RID: 1193
		public abstract bool vmethod_84(Class5.Class16 class16_0);

		// Token: 0x060004AA RID: 1194
		public abstract bool vmethod_85(Class5.Class16 class16_0);

		// Token: 0x060004AB RID: 1195 RVA: 0x0000357E File Offset: 0x0000177E
		internal override bool vmethod_3()
		{
			return true;
		}
	}

	// Token: 0x0200009E RID: 158
	private class Class21 : Class5.Class17
	{
		// Token: 0x060004AD RID: 1197 RVA: 0x000240EC File Offset: 0x000222EC
		internal override void vmethod_10(Class5.Class16 class16_0)
		{
			this.double_0 = ((Class5.Class21)class16_0).double_0;
			this.enum1_0 = ((Class5.Class21)class16_0).enum1_0;
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0001F0EC File Offset: 0x0001D2EC
		internal override void vmethod_2(Class5.Class16 class16_0)
		{
			this.vmethod_10(class16_0);
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0002411C File Offset: 0x0002231C
		public Class21(double double_1)
		{
			this.enum4_0 = (Class5.Enum4)5;
			this.enum1_0 = (Class5.Enum1)10;
			this.double_0 = double_1;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00024148 File Offset: 0x00022348
		public Class21(Class5.Class21 class21_0)
		{
			this.enum4_0 = class21_0.enum4_0;
			this.enum1_0 = class21_0.enum1_0;
			this.double_0 = class21_0.double_0;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x000039CC File Offset: 0x00001BCC
		public override Class5.Class17 vmethod_74()
		{
			return new Class5.Class21(this);
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00024180 File Offset: 0x00022380
		public Class21(double double_1, Class5.Enum1 enum1_1)
		{
			this.enum4_0 = (Class5.Enum4)5;
			this.double_0 = double_1;
			this.enum1_0 = enum1_1;
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x000241AC File Offset: 0x000223AC
		public Class21(float float_0)
		{
			this.enum4_0 = (Class5.Enum4)5;
			this.double_0 = (double)float_0;
			this.enum1_0 = (Class5.Enum1)9;
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x000241D8 File Offset: 0x000223D8
		public Class21(float float_0, Class5.Enum1 enum1_1)
		{
			this.enum4_0 = (Class5.Enum4)5;
			this.double_0 = (double)float_0;
			this.enum1_0 = enum1_1;
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x000039D4 File Offset: 0x00001BD4
		public override bool vmethod_11()
		{
			return this.double_0 == 0.0;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0000333D File Offset: 0x0000153D
		public override bool vmethod_12()
		{
			return !this.vmethod_11();
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x000039E7 File Offset: 0x00001BE7
		public override string ToString()
		{
			return this.double_0.ToString();
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00024204 File Offset: 0x00022404
		public override Class5.Class16 vmethod_13(Class5.Enum1 enum1_1)
		{
			switch (enum1_1)
			{
			case (Class5.Enum1)1:
				return this.vmethod_15();
			case (Class5.Enum1)2:
				return this.vmethod_16();
			case (Class5.Enum1)3:
				return this.vmethod_17();
			case (Class5.Enum1)4:
				return this.vmethod_18();
			case (Class5.Enum1)5:
				return this.vmethod_19();
			case (Class5.Enum1)6:
				return this.vmethod_20();
			case (Class5.Enum1)7:
				return this.vmethod_21();
			case (Class5.Enum1)8:
				return this.vmethod_22();
			case (Class5.Enum1)9:
				return this.vmethod_47();
			case (Class5.Enum1)10:
				return this.vmethod_48();
			case (Class5.Enum1)11:
				return this.vmethod_14();
			default:
				throw new Exception(((Class5.Enum5)4).ToString());
			}
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x000242A8 File Offset: 0x000224A8
		internal override object vmethod_4(Type type_0)
		{
			if (type_0 != null && type_0.IsByRef)
			{
				type_0 = type_0.GetElementType();
			}
			if (type_0 == typeof(float))
			{
				return (float)this.double_0;
			}
			if (type_0 == typeof(double))
			{
				return this.double_0;
			}
			if ((type_0 == null || type_0 == typeof(object)) && this.enum1_0 == (Class5.Enum1)9)
			{
				return (float)this.double_0;
			}
			return this.double_0;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00024348 File Offset: 0x00022548
		public override Class5.Class18 vmethod_14()
		{
			return new Class5.Class18(this.vmethod_11() ? 1 : 0);
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00003348 File Offset: 0x00001548
		internal override bool vmethod_7()
		{
			return this.vmethod_12();
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x000039F4 File Offset: 0x00001BF4
		public override Class5.Class18 vmethod_15()
		{
			return new Class5.Class18((int)((sbyte)this.double_0), (Class5.Enum1)1);
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x00003A03 File Offset: 0x00001C03
		public override Class5.Class18 vmethod_16()
		{
			return new Class5.Class18((uint)((byte)this.double_0), (Class5.Enum1)2);
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00003A12 File Offset: 0x00001C12
		public override Class5.Class18 vmethod_17()
		{
			return new Class5.Class18((int)((short)this.double_0), (Class5.Enum1)3);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00003A21 File Offset: 0x00001C21
		public override Class5.Class18 vmethod_18()
		{
			return new Class5.Class18((uint)((ushort)this.double_0), (Class5.Enum1)4);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00003A30 File Offset: 0x00001C30
		public override Class5.Class18 vmethod_19()
		{
			return new Class5.Class18((int)this.double_0, (Class5.Enum1)5);
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00003A3F File Offset: 0x00001C3F
		public override Class5.Class18 vmethod_20()
		{
			return new Class5.Class18((uint)this.double_0, (Class5.Enum1)6);
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00003A4E File Offset: 0x00001C4E
		public override Class5.Class19 vmethod_21()
		{
			return new Class5.Class19((long)this.double_0, (Class5.Enum1)7);
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00003A5D File Offset: 0x00001C5D
		public override Class5.Class19 vmethod_22()
		{
			return new Class5.Class19((ulong)this.double_0, (Class5.Enum1)8);
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x000033FE File Offset: 0x000015FE
		public override Class5.Class18 vmethod_23()
		{
			return this.vmethod_15();
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00003406 File Offset: 0x00001606
		public override Class5.Class18 vmethod_24()
		{
			return this.vmethod_17();
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0000340E File Offset: 0x0000160E
		public override Class5.Class18 vmethod_25()
		{
			return this.vmethod_19();
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00003416 File Offset: 0x00001616
		public override Class5.Class19 vmethod_26()
		{
			return this.vmethod_21();
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0000341E File Offset: 0x0000161E
		public override Class5.Class18 vmethod_27()
		{
			return this.vmethod_16();
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00003426 File Offset: 0x00001626
		public override Class5.Class18 vmethod_28()
		{
			return this.vmethod_18();
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0000342E File Offset: 0x0000162E
		public override Class5.Class18 vmethod_29()
		{
			return this.vmethod_20();
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x00003436 File Offset: 0x00001636
		public override Class5.Class19 vmethod_30()
		{
			return this.vmethod_22();
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00003A6C File Offset: 0x00001C6C
		public override Class5.Class18 vmethod_31()
		{
			return new Class5.Class18((int)(checked((sbyte)this.double_0)), (Class5.Enum1)1);
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00003A6C File Offset: 0x00001C6C
		public override Class5.Class18 vmethod_32()
		{
			return new Class5.Class18((int)(checked((sbyte)this.double_0)), (Class5.Enum1)1);
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00003A7B File Offset: 0x00001C7B
		public override Class5.Class18 vmethod_33()
		{
			return new Class5.Class18((int)(checked((short)this.double_0)), (Class5.Enum1)3);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00003A7B File Offset: 0x00001C7B
		public override Class5.Class18 vmethod_34()
		{
			return new Class5.Class18((int)(checked((short)this.double_0)), (Class5.Enum1)3);
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00003A8A File Offset: 0x00001C8A
		public override Class5.Class18 vmethod_35()
		{
			return new Class5.Class18(checked((int)this.double_0), (Class5.Enum1)5);
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00003A8A File Offset: 0x00001C8A
		public override Class5.Class18 vmethod_36()
		{
			return new Class5.Class18(checked((int)this.double_0), (Class5.Enum1)5);
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00003A99 File Offset: 0x00001C99
		public override Class5.Class19 vmethod_37()
		{
			return new Class5.Class19(checked((long)this.double_0), (Class5.Enum1)7);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00003A99 File Offset: 0x00001C99
		public override Class5.Class19 vmethod_38()
		{
			return new Class5.Class19(checked((long)this.double_0), (Class5.Enum1)7);
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00003AA8 File Offset: 0x00001CA8
		public override Class5.Class18 vmethod_39()
		{
			return new Class5.Class18((int)(checked((byte)this.double_0)), (Class5.Enum1)2);
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00003AA8 File Offset: 0x00001CA8
		public override Class5.Class18 vmethod_40()
		{
			return new Class5.Class18((int)(checked((byte)this.double_0)), (Class5.Enum1)2);
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x00003AB7 File Offset: 0x00001CB7
		public override Class5.Class18 vmethod_41()
		{
			return new Class5.Class18((int)(checked((ushort)this.double_0)), (Class5.Enum1)4);
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00003AB7 File Offset: 0x00001CB7
		public override Class5.Class18 vmethod_42()
		{
			return new Class5.Class18((int)(checked((ushort)this.double_0)), (Class5.Enum1)4);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00003AC6 File Offset: 0x00001CC6
		public override Class5.Class18 vmethod_43()
		{
			return new Class5.Class18(checked((uint)this.double_0), (Class5.Enum1)6);
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00003AC6 File Offset: 0x00001CC6
		public override Class5.Class18 vmethod_44()
		{
			return new Class5.Class18(checked((uint)this.double_0), (Class5.Enum1)6);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00003AD5 File Offset: 0x00001CD5
		public override Class5.Class19 vmethod_45()
		{
			return new Class5.Class19(checked((ulong)this.double_0), (Class5.Enum1)8);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00003AD5 File Offset: 0x00001CD5
		public override Class5.Class19 vmethod_46()
		{
			return new Class5.Class19(checked((ulong)this.double_0), (Class5.Enum1)8);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00003AE4 File Offset: 0x00001CE4
		public override Class5.Class21 vmethod_47()
		{
			return new Class5.Class21((float)this.double_0, (Class5.Enum1)9);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00003AF4 File Offset: 0x00001CF4
		public override Class5.Class21 vmethod_48()
		{
			return new Class5.Class21(this.double_0, (Class5.Enum1)10);
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00003B04 File Offset: 0x00001D04
		public override Class5.Class21 vmethod_49()
		{
			return new Class5.Class21(this.double_0);
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x0001F83C File Offset: 0x0001DA3C
		public override Class5.Class20 vmethod_50()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_26().struct3_0.long_0);
			}
			return new Class5.Class20((long)this.vmethod_25().struct2_0.int_0);
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x0001F880 File Offset: 0x0001DA80
		public override Class5.Class20 vmethod_51()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_30().struct3_0.ulong_0);
			}
			return new Class5.Class20((ulong)this.vmethod_29().struct2_0.uint_0);
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x0001F8C4 File Offset: 0x0001DAC4
		public override Class5.Class20 vmethod_52()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_37().struct3_0.long_0);
			}
			return new Class5.Class20((long)this.vmethod_35().struct2_0.int_0);
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0001F908 File Offset: 0x0001DB08
		public override Class5.Class20 vmethod_53()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_45().struct3_0.ulong_0);
			}
			return new Class5.Class20((ulong)this.vmethod_43().struct2_0.uint_0);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0001F94C File Offset: 0x0001DB4C
		public override Class5.Class20 vmethod_54()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_38().struct3_0.long_0);
			}
			return new Class5.Class20((long)this.vmethod_36().struct2_0.int_0);
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x0001F990 File Offset: 0x0001DB90
		public override Class5.Class20 vmethod_55()
		{
			if (IntPtr.Size == 8)
			{
				return new Class5.Class20(this.vmethod_46().struct3_0.ulong_0);
			}
			return new Class5.Class20((ulong)this.vmethod_44().struct2_0.uint_0);
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00024368 File Offset: 0x00022568
		public override Class5.Class16 vmethod_56()
		{
			if (this.enum1_0 == (Class5.Enum1)9)
			{
				return new Class5.Class21((float)(-(float)this.double_0));
			}
			return new Class5.Class21(-this.double_0);
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x0002439C File Offset: 0x0002259C
		public override Class5.Class16 vmethod_57(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class21(this.double_0 + ((Class5.Class21)class16_0).double_0);
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x0002439C File Offset: 0x0002259C
		public override Class5.Class16 vmethod_58(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class21(this.double_0 + ((Class5.Class21)class16_0).double_0);
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x0002439C File Offset: 0x0002259C
		public override Class5.Class16 vmethod_59(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class21(this.double_0 + ((Class5.Class21)class16_0).double_0);
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x000243E0 File Offset: 0x000225E0
		public override Class5.Class16 vmethod_60(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class21(this.double_0 - ((Class5.Class21)class16_0).double_0);
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x000243E0 File Offset: 0x000225E0
		public override Class5.Class16 vmethod_61(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class21(this.double_0 - ((Class5.Class21)class16_0).double_0);
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x000243E0 File Offset: 0x000225E0
		public override Class5.Class16 vmethod_62(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class21(this.double_0 - ((Class5.Class21)class16_0).double_0);
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00024424 File Offset: 0x00022624
		public override Class5.Class16 vmethod_63(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4() || !class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class21(this.double_0 * ((Class5.Class21)class16_0).double_0);
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x00024470 File Offset: 0x00022670
		public override Class5.Class16 vmethod_64(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class21(this.double_0 * ((Class5.Class21)class16_0).double_0);
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00024470 File Offset: 0x00022670
		public override Class5.Class16 vmethod_65(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class21(this.double_0 * ((Class5.Class21)class16_0).double_0);
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x000244B4 File Offset: 0x000226B4
		public override Class5.Class16 vmethod_66(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class21(this.double_0 / ((Class5.Class21)class16_0).double_0);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x000244B4 File Offset: 0x000226B4
		public override Class5.Class16 vmethod_67(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class21(this.double_0 / ((Class5.Class21)class16_0).double_0);
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x000244F8 File Offset: 0x000226F8
		public override Class5.Class16 vmethod_68(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class21(this.double_0 % ((Class5.Class21)class16_0).double_0);
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x000244F8 File Offset: 0x000226F8
		public override Class5.Class16 vmethod_69(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return new Class5.Class21(this.double_0 % ((Class5.Class21)class16_0).double_0);
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00003B12 File Offset: 0x00001D12
		public override Class5.Class16 vmethod_70(Class5.Class16 class16_0)
		{
			throw new Class5.Exception1();
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00003B12 File Offset: 0x00001D12
		public override Class5.Class16 vmethod_71(Class5.Class16 class16_0)
		{
			throw new Class5.Exception1();
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00003B12 File Offset: 0x00001D12
		public override Class5.Class16 vmethod_72()
		{
			throw new Class5.Exception1();
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00003B12 File Offset: 0x00001D12
		public override Class5.Class16 vmethod_73(Class5.Class16 class16_0)
		{
			throw new Class5.Exception1();
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00003B12 File Offset: 0x00001D12
		public override Class5.Class16 vmethod_75(Class5.Class16 class16_0)
		{
			throw new Class5.Exception1();
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00003B12 File Offset: 0x00001D12
		public override Class5.Class16 vmethod_76(Class5.Class16 class16_0)
		{
			throw new Class5.Exception1();
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00003B12 File Offset: 0x00001D12
		public override Class5.Class16 vmethod_77(Class5.Class16 class16_0)
		{
			throw new Class5.Exception1();
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0000357B File Offset: 0x0000177B
		internal override Class5.Class16 vmethod_8()
		{
			return this;
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0002453C File Offset: 0x0002273C
		internal override bool vmethod_5(Class5.Class16 class16_0)
		{
			if (class16_0.method_0())
			{
				return false;
			}
			if (!class16_0.vmethod_0())
			{
				Class5.Class16 @class = class16_0.vmethod_8();
				return @class.method_4() && this.double_0 == ((Class5.Class21)@class).double_0;
			}
			return ((Class5.Class22)class16_0).vmethod_5(this);
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00024590 File Offset: 0x00022790
		internal override bool vmethod_6(Class5.Class16 class16_0)
		{
			if (class16_0.method_0())
			{
				return false;
			}
			if (!class16_0.vmethod_0())
			{
				Class5.Class16 @class = class16_0.vmethod_8();
				return @class.method_4() && this.double_0 != ((Class5.Class21)@class).double_0;
			}
			return ((Class5.Class22)class16_0).vmethod_6(this);
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x000245E8 File Offset: 0x000227E8
		public override bool vmethod_78(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return this.double_0 >= ((Class5.Class21)class16_0).double_0;
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x000245E8 File Offset: 0x000227E8
		public override bool vmethod_79(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return this.double_0 >= ((Class5.Class21)class16_0).double_0;
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0002462C File Offset: 0x0002282C
		public override bool vmethod_80(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return this.double_0 > ((Class5.Class21)class16_0).double_0;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0002462C File Offset: 0x0002282C
		public override bool vmethod_81(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return this.double_0 > ((Class5.Class21)class16_0).double_0;
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0002466C File Offset: 0x0002286C
		public override bool vmethod_82(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return this.double_0 <= ((Class5.Class21)class16_0).double_0;
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0002466C File Offset: 0x0002286C
		public override bool vmethod_83(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return this.double_0 <= ((Class5.Class21)class16_0).double_0;
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x000246B0 File Offset: 0x000228B0
		public override bool vmethod_84(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return this.double_0 < ((Class5.Class21)class16_0).double_0;
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x000246B0 File Offset: 0x000228B0
		public override bool vmethod_85(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				class16_0 = class16_0.vmethod_8();
			}
			if (!class16_0.method_4())
			{
				throw new Class5.Exception1();
			}
			return this.double_0 < ((Class5.Class21)class16_0).double_0;
		}

		// Token: 0x04000398 RID: 920
		public double double_0;

		// Token: 0x04000399 RID: 921
		public Class5.Enum1 enum1_0;
	}

	// Token: 0x0200009F RID: 159
	internal enum Enum1 : byte
	{

	}

	// Token: 0x020000A0 RID: 160
	internal enum Enum2 : byte
	{

	}

	// Token: 0x020000A1 RID: 161
	private class Exception0 : Exception
	{
		// Token: 0x06000505 RID: 1285 RVA: 0x000246F0 File Offset: 0x000228F0
		public Exception0(string string_0) : base(string_0)
		{
		}
	}

	// Token: 0x020000A2 RID: 162
	private class Exception1 : Exception
	{
		// Token: 0x06000506 RID: 1286 RVA: 0x00024708 File Offset: 0x00022908
		public Exception1()
		{
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x000246F0 File Offset: 0x000228F0
		public Exception1(string string_0) : base(string_0)
		{
		}
	}

	// Token: 0x020000A3 RID: 163
	internal class Class6
	{
		// Token: 0x06000508 RID: 1288 RVA: 0x0002471C File Offset: 0x0002291C
		public override string ToString()
		{
			object obj = this.enum3_0;
			if (this.object_0 != null)
			{
				return obj.ToString() + 'H'.ToString() + this.object_0.ToString();
			}
			return obj.ToString();
		}

		// Token: 0x0400039C RID: 924
		internal Class5.Enum3 enum3_0 = (Class5.Enum3)126;

		// Token: 0x0400039D RID: 925
		internal object object_0;
	}

	// Token: 0x020000A4 RID: 164
	internal abstract class Class22 : Class5.Class16
	{
		// Token: 0x0600050A RID: 1290 RVA: 0x000240D8 File Offset: 0x000222D8
		public Class22()
		{
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0000357E File Offset: 0x0000177E
		internal override bool vmethod_0()
		{
			return true;
		}

		// Token: 0x0600050C RID: 1292
		internal abstract IntPtr vmethod_11();

		// Token: 0x0600050D RID: 1293
		internal abstract void vmethod_12(Class5.Class16 class16_0);

		// Token: 0x0600050E RID: 1294 RVA: 0x0000357E File Offset: 0x0000177E
		internal override bool vmethod_1()
		{
			return true;
		}
	}

	// Token: 0x020000A5 RID: 165
	internal class Class23 : Class5.Class22
	{
		// Token: 0x0600050F RID: 1295 RVA: 0x00024784 File Offset: 0x00022984
		public Class23(int int_1, Class5.Class14 class14_1)
		{
			this.class14_0 = class14_1;
			this.int_0 = int_1;
			this.enum4_0 = (Class5.Enum4)7;
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x000247B0 File Offset: 0x000229B0
		internal override void vmethod_10(Class5.Class16 class16_0)
		{
			if (class16_0 is Class5.Class23)
			{
				this.class14_0 = ((Class5.Class23)class16_0).class14_0;
				this.int_0 = ((Class5.Class23)class16_0).int_0;
				return;
			}
			Class5.Class8 @class = this.class14_0.class11_0.list_1[this.int_0];
			if (class16_0 is Class5.Class22 && (@class.enum1_0 & (Class5.Enum1)226) > (Class5.Enum1)0)
			{
				Class5.Class16 class16_ = (class16_0 as Class5.Class22).vmethod_8();
				this.vmethod_12(class16_);
				return;
			}
			this.vmethod_12(class16_0);
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x0002483C File Offset: 0x00022A3C
		internal override void vmethod_2(Class5.Class16 class16_0)
		{
			this.vmethod_12(class16_0);
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x00003B19 File Offset: 0x00001D19
		internal override IntPtr vmethod_11()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x00024850 File Offset: 0x00022A50
		internal override void vmethod_12(Class5.Class16 class16_0)
		{
			this.class14_0.class16_1[this.int_0] = class16_0;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00024870 File Offset: 0x00022A70
		internal override object vmethod_4(Type type_0)
		{
			if (this.class14_0.class16_1[this.int_0] == null)
			{
				return null;
			}
			return this.vmethod_8().vmethod_4(type_0);
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x000248A0 File Offset: 0x00022AA0
		internal override Class5.Class16 vmethod_8()
		{
			if (this.class14_0.class16_1[this.int_0] == null)
			{
				return new Class5.Class28(null);
			}
			return this.class14_0.class16_1[this.int_0].vmethod_8();
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x00003B20 File Offset: 0x00001D20
		internal override bool vmethod_9()
		{
			return this.vmethod_8().vmethod_9();
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x000248E0 File Offset: 0x00022AE0
		internal override bool vmethod_5(Class5.Class16 class16_0)
		{
			return class16_0.vmethod_0() && class16_0 is Class5.Class23 && ((Class5.Class23)class16_0).int_0 == this.int_0;
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00024918 File Offset: 0x00022B18
		internal override bool vmethod_6(Class5.Class16 class16_0)
		{
			return !class16_0.vmethod_0() || !(class16_0 is Class5.Class23) || ((Class5.Class23)class16_0).int_0 != this.int_0;
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00003B2D File Offset: 0x00001D2D
		internal override bool vmethod_7()
		{
			return this.vmethod_8().vmethod_7();
		}

		// Token: 0x0400039E RID: 926
		private Class5.Class14 class14_0;

		// Token: 0x0400039F RID: 927
		internal int int_0;
	}

	// Token: 0x020000A6 RID: 166
	internal class Class24 : Class5.Class22
	{
		// Token: 0x0600051A RID: 1306 RVA: 0x00024950 File Offset: 0x00022B50
		public Class24(int int_1, Array array_1)
		{
			this.array_0 = array_1;
			this.int_0 = int_1;
			this.enum4_0 = (Class5.Enum4)7;
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x00003B19 File Offset: 0x00001D19
		internal override IntPtr vmethod_11()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x0002497C File Offset: 0x00022B7C
		internal override void vmethod_10(Class5.Class16 class16_0)
		{
			if (class16_0 is Class5.Class24)
			{
				this.array_0 = ((Class5.Class24)class16_0).array_0;
				this.int_0 = ((Class5.Class24)class16_0).int_0;
				return;
			}
			this.vmethod_12(class16_0);
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0002483C File Offset: 0x00022A3C
		internal override void vmethod_2(Class5.Class16 class16_0)
		{
			this.vmethod_12(class16_0);
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x000249BC File Offset: 0x00022BBC
		internal override void vmethod_12(Class5.Class16 class16_0)
		{
			this.array_0.SetValue(class16_0.vmethod_4(null), this.int_0);
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00003B3A File Offset: 0x00001D3A
		internal override object vmethod_4(Type type_0)
		{
			return this.vmethod_8().vmethod_4(type_0);
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00003B48 File Offset: 0x00001D48
		internal override Class5.Class16 vmethod_8()
		{
			return Class5.Class16.smethod_1(this.array_0.GetType().GetElementType(), this.array_0.GetValue(this.int_0));
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00003B20 File Offset: 0x00001D20
		internal override bool vmethod_9()
		{
			return this.vmethod_8().vmethod_9();
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x000249E4 File Offset: 0x00022BE4
		internal override bool vmethod_5(Class5.Class16 class16_0)
		{
			if (!class16_0.vmethod_0())
			{
				return false;
			}
			if (class16_0 is Class5.Class24)
			{
				Class5.Class24 @class = (Class5.Class24)class16_0;
				return @class.int_0 == this.int_0 && @class.array_0 == this.array_0;
			}
			return false;
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x00024A30 File Offset: 0x00022C30
		internal override bool vmethod_6(Class5.Class16 class16_0)
		{
			if (!class16_0.vmethod_0())
			{
				return true;
			}
			if (!(class16_0 is Class5.Class24))
			{
				return true;
			}
			Class5.Class24 @class = (Class5.Class24)class16_0;
			return @class.int_0 != this.int_0 || @class.array_0 != this.array_0;
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x00003B2D File Offset: 0x00001D2D
		internal override bool vmethod_7()
		{
			return this.vmethod_8().vmethod_7();
		}

		// Token: 0x040003A0 RID: 928
		private Array array_0;

		// Token: 0x040003A1 RID: 929
		internal int int_0;
	}

	// Token: 0x020000A7 RID: 167
	internal class Class25 : Class5.Class22
	{
		// Token: 0x06000525 RID: 1317 RVA: 0x00024A7C File Offset: 0x00022C7C
		public Class25(FieldInfo fieldInfo_1, object object_1)
		{
			this.fieldInfo_0 = fieldInfo_1;
			this.object_0 = object_1;
			this.enum4_0 = (Class5.Enum4)7;
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x00003B19 File Offset: 0x00001D19
		internal override IntPtr vmethod_11()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x00024AA8 File Offset: 0x00022CA8
		internal override void vmethod_12(Class5.Class16 class16_0)
		{
			if (this.object_0 != null && this.object_0 is Class5.Class16)
			{
				this.fieldInfo_0.SetValue(((Class5.Class16)this.object_0).vmethod_4(null), class16_0.vmethod_4(null));
				return;
			}
			this.fieldInfo_0.SetValue(this.object_0, class16_0.vmethod_4(null));
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x00024B08 File Offset: 0x00022D08
		internal override void vmethod_10(Class5.Class16 class16_0)
		{
			if (!(class16_0 is Class5.Class25))
			{
				this.vmethod_12(class16_0);
				return;
			}
			this.fieldInfo_0 = ((Class5.Class25)class16_0).fieldInfo_0;
			this.object_0 = ((Class5.Class25)class16_0).object_0;
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0002483C File Offset: 0x00022A3C
		internal override void vmethod_2(Class5.Class16 class16_0)
		{
			this.vmethod_12(class16_0);
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x00003B3A File Offset: 0x00001D3A
		internal override object vmethod_4(Type type_0)
		{
			return this.vmethod_8().vmethod_4(type_0);
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x00024B48 File Offset: 0x00022D48
		internal override Class5.Class16 vmethod_8()
		{
			if (this.object_0 != null && this.object_0 is Class5.Class16)
			{
				return Class5.Class16.smethod_1(this.fieldInfo_0.FieldType, this.fieldInfo_0.GetValue(((Class5.Class16)this.object_0).vmethod_4(null)));
			}
			return Class5.Class16.smethod_1(this.fieldInfo_0.FieldType, this.fieldInfo_0.GetValue(this.object_0));
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00003B20 File Offset: 0x00001D20
		internal override bool vmethod_9()
		{
			return this.vmethod_8().vmethod_9();
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x00024BB8 File Offset: 0x00022DB8
		internal override bool vmethod_5(Class5.Class16 class16_0)
		{
			if (!class16_0.vmethod_0())
			{
				return false;
			}
			if (class16_0 is Class5.Class25)
			{
				Class5.Class25 @class = (Class5.Class25)class16_0;
				return !(@class.fieldInfo_0 != this.fieldInfo_0) && @class.object_0 == this.object_0;
			}
			return false;
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x00024C0C File Offset: 0x00022E0C
		internal override bool vmethod_6(Class5.Class16 class16_0)
		{
			if (!class16_0.vmethod_0())
			{
				return true;
			}
			if (class16_0 is Class5.Class25)
			{
				Class5.Class25 @class = (Class5.Class25)class16_0;
				return @class.fieldInfo_0 != this.fieldInfo_0 || @class.object_0 != this.object_0;
			}
			return true;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00003B2D File Offset: 0x00001D2D
		internal override bool vmethod_7()
		{
			return this.vmethod_8().vmethod_7();
		}

		// Token: 0x040003A2 RID: 930
		internal FieldInfo fieldInfo_0;

		// Token: 0x040003A3 RID: 931
		internal object object_0;
	}

	// Token: 0x020000A8 RID: 168
	internal class Class26 : Class5.Class22
	{
		// Token: 0x06000530 RID: 1328 RVA: 0x00024C60 File Offset: 0x00022E60
		public Class26(int int_1, Class5.Class14 class14_1)
		{
			this.class14_0 = class14_1;
			this.int_0 = int_1;
			this.enum4_0 = (Class5.Enum4)7;
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x00003B19 File Offset: 0x00001D19
		internal override IntPtr vmethod_11()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00024C8C File Offset: 0x00022E8C
		internal override void vmethod_10(Class5.Class16 class16_0)
		{
			if (class16_0 is Class5.Class26)
			{
				this.class14_0 = ((Class5.Class26)class16_0).class14_0;
				this.int_0 = ((Class5.Class26)class16_0).int_0;
				return;
			}
			this.vmethod_12(class16_0);
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0002483C File Offset: 0x00022A3C
		internal override void vmethod_2(Class5.Class16 class16_0)
		{
			this.vmethod_12(class16_0);
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x00024CCC File Offset: 0x00022ECC
		internal override void vmethod_12(Class5.Class16 class16_0)
		{
			this.class14_0.class16_0[this.int_0] = class16_0;
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00024CEC File Offset: 0x00022EEC
		internal override object vmethod_4(Type type_0)
		{
			if (this.class14_0.class16_0[this.int_0] != null)
			{
				return this.vmethod_8().vmethod_4(type_0);
			}
			return null;
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x00024D1C File Offset: 0x00022F1C
		internal override Class5.Class16 vmethod_8()
		{
			if (this.class14_0.class16_0[this.int_0] == null)
			{
				return new Class5.Class28(null);
			}
			return this.class14_0.class16_0[this.int_0].vmethod_8();
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00003B20 File Offset: 0x00001D20
		internal override bool vmethod_9()
		{
			return this.vmethod_8().vmethod_9();
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00024D5C File Offset: 0x00022F5C
		internal override bool vmethod_5(Class5.Class16 class16_0)
		{
			return class16_0.vmethod_0() && class16_0 is Class5.Class26 && ((Class5.Class26)class16_0).int_0 == this.int_0;
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00024D90 File Offset: 0x00022F90
		internal override bool vmethod_6(Class5.Class16 class16_0)
		{
			return !class16_0.vmethod_0() || !(class16_0 is Class5.Class26) || ((Class5.Class26)class16_0).int_0 != this.int_0;
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00003B2D File Offset: 0x00001D2D
		internal override bool vmethod_7()
		{
			return this.vmethod_8().vmethod_7();
		}

		// Token: 0x040003A4 RID: 932
		private Class5.Class14 class14_0;

		// Token: 0x040003A5 RID: 933
		internal int int_0;
	}

	// Token: 0x020000A9 RID: 169
	internal class Class27 : Class5.Class22
	{
		// Token: 0x0600053B RID: 1339 RVA: 0x00024DC8 File Offset: 0x00022FC8
		public Class27(Class5.Class16 class16_1, Type type_1)
		{
			this.class16_0 = class16_1;
			this.type_0 = type_1;
			this.enum4_0 = (Class5.Enum4)7;
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00003B19 File Offset: 0x00001D19
		internal override IntPtr vmethod_11()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00024DF4 File Offset: 0x00022FF4
		internal override void vmethod_10(Class5.Class16 class16_1)
		{
			if (class16_1 is Class5.Class27)
			{
				this.type_0 = ((Class5.Class27)class16_1).type_0;
				this.class16_0 = ((Class5.Class27)class16_1).class16_0;
				return;
			}
			this.class16_0.vmethod_10(class16_1);
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0002483C File Offset: 0x00022A3C
		internal override void vmethod_2(Class5.Class16 class16_1)
		{
			this.vmethod_12(class16_1);
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x00024E38 File Offset: 0x00023038
		internal override void vmethod_12(Class5.Class16 class16_1)
		{
			this.class16_0 = class16_1;
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x00024E4C File Offset: 0x0002304C
		internal override object vmethod_4(Type type_1)
		{
			if (this.class16_0 == null)
			{
				return new Class5.Class28(null);
			}
			if (!(type_1 == null) && !(type_1 == typeof(object)))
			{
				return this.class16_0.vmethod_4(type_1);
			}
			return this.class16_0.vmethod_4(this.type_0);
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00024EA4 File Offset: 0x000230A4
		internal override Class5.Class16 vmethod_8()
		{
			if (this.class16_0 == null)
			{
				return new Class5.Class28(null);
			}
			return this.class16_0.vmethod_8();
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00003B20 File Offset: 0x00001D20
		internal override bool vmethod_9()
		{
			return this.vmethod_8().vmethod_9();
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x00024ECC File Offset: 0x000230CC
		internal override bool vmethod_5(Class5.Class16 class16_1)
		{
			if (!class16_1.vmethod_0())
			{
				return false;
			}
			if (!(class16_1 is Class5.Class27))
			{
				return false;
			}
			Class5.Class27 @class = (Class5.Class27)class16_1;
			if (@class.type_0 != this.type_0)
			{
				return false;
			}
			if (this.class16_0 == null)
			{
				return @class.class16_0 == null;
			}
			return this.class16_0.vmethod_5(@class.class16_0);
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x00024F34 File Offset: 0x00023134
		internal override bool vmethod_6(Class5.Class16 class16_1)
		{
			if (!class16_1.vmethod_0())
			{
				return true;
			}
			if (!(class16_1 is Class5.Class27))
			{
				return true;
			}
			Class5.Class27 @class = (Class5.Class27)class16_1;
			if (@class.type_0 != this.type_0)
			{
				return true;
			}
			if (this.class16_0 != null)
			{
				return this.class16_0.vmethod_6(@class.class16_0);
			}
			return @class.class16_0 != null;
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00003B2D File Offset: 0x00001D2D
		internal override bool vmethod_7()
		{
			return this.vmethod_8().vmethod_7();
		}

		// Token: 0x040003A6 RID: 934
		private Class5.Class16 class16_0;

		// Token: 0x040003A7 RID: 935
		private Type type_0;
	}

	// Token: 0x020000AA RID: 170
	internal class Class7
	{
		// Token: 0x040003A8 RID: 936
		public int int_0;

		// Token: 0x040003A9 RID: 937
		public bool bool_0;

		// Token: 0x040003AA RID: 938
		public Class5.Enum1 enum1_0;
	}

	// Token: 0x020000AB RID: 171
	internal class Class8
	{
		// Token: 0x040003AB RID: 939
		public int int_0;

		// Token: 0x040003AC RID: 940
		public Class5.Enum1 enum1_0;

		// Token: 0x040003AD RID: 941
		public bool bool_0;

		// Token: 0x040003AE RID: 942
		public Type type_0 = typeof(object);
	}

	// Token: 0x020000AC RID: 172
	internal class Class9
	{
		// Token: 0x040003AF RID: 943
		public int int_0;

		// Token: 0x040003B0 RID: 944
		public int int_1;

		// Token: 0x040003B1 RID: 945
		public Class5.Class10 class10_0;
	}

	// Token: 0x020000AD RID: 173
	internal class Class10
	{
		// Token: 0x040003B2 RID: 946
		public int int_0;

		// Token: 0x040003B3 RID: 947
		public int int_1;

		// Token: 0x040003B4 RID: 948
		public byte byte_0;

		// Token: 0x040003B5 RID: 949
		public Type type_0;

		// Token: 0x040003B6 RID: 950
		public int int_2;

		// Token: 0x040003B7 RID: 951
		public int int_3;
	}

	// Token: 0x020000AE RID: 174
	internal class Class11
	{
		// Token: 0x040003B8 RID: 952
		internal MethodBase methodBase_0;

		// Token: 0x040003B9 RID: 953
		internal List<Class5.Class6> list_0;

		// Token: 0x040003BA RID: 954
		internal Class5.Class7[] class7_0;

		// Token: 0x040003BB RID: 955
		internal List<Class5.Class8> list_1;

		// Token: 0x040003BC RID: 956
		internal List<Class5.Class9> list_2;
	}

	// Token: 0x020000AF RID: 175
	private class Class12
	{
		// Token: 0x0600054B RID: 1355 RVA: 0x00024FC0 File Offset: 0x000231C0
		public Class12(FieldInfo fieldInfo_1, int int_1)
		{
			this.fieldInfo_0 = fieldInfo_1;
			this.int_0 = int_1;
		}

		// Token: 0x040003BD RID: 957
		internal FieldInfo fieldInfo_0;

		// Token: 0x040003BE RID: 958
		internal int int_0;
	}

	// Token: 0x020000B0 RID: 176
	private class Class13
	{
		// Token: 0x0600054C RID: 1356 RVA: 0x00003B70 File Offset: 0x00001D70
		public Class13(MethodBase methodBase_1, List<Class5.Class12> list_1)
		{
			this.list_0 = list_1;
			this.methodBase_0 = methodBase_1;
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x00024FE4 File Offset: 0x000231E4
		public Class13(MethodBase methodBase_1, Class5.Class12[] class12_0)
		{
			this.list_0.AddRange(class12_0);
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x00025010 File Offset: 0x00023210
		public override bool Equals(object obj)
		{
			Class5.Class13 @class = obj as Class5.Class13;
			if (obj == null)
			{
				return false;
			}
			if (this.methodBase_0 != @class.methodBase_0)
			{
				return false;
			}
			if (this.list_0.Count != @class.list_0.Count)
			{
				return false;
			}
			for (int i = 0; i < this.list_0.Count; i++)
			{
				if (this.list_0[i].fieldInfo_0 != @class.list_0[i].fieldInfo_0)
				{
					return false;
				}
				if (this.list_0[i].int_0 != @class.list_0[i].int_0)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x000250D4 File Offset: 0x000232D4
		public override int GetHashCode()
		{
			int num = this.methodBase_0.GetHashCode();
			foreach (Class5.Class12 @class in this.list_0)
			{
				int num2 = @class.fieldInfo_0.GetHashCode() + @class.int_0;
				num = (num ^ num2) + num2;
			}
			return num;
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x00025154 File Offset: 0x00023354
		public Class5.Class12 method_0(int int_0)
		{
			foreach (Class5.Class12 @class in this.list_0)
			{
				if (@class.int_0 == int_0)
				{
					return @class;
				}
			}
			return null;
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x000251BC File Offset: 0x000233BC
		public bool method_1(int int_0)
		{
			using (List<Class5.Class12>.Enumerator enumerator = this.list_0.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.int_0 == int_0)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x040003BF RID: 959
		private List<Class5.Class12> list_0 = new List<Class5.Class12>();

		// Token: 0x040003C0 RID: 960
		private MethodBase methodBase_0;
	}

	// Token: 0x020000B1 RID: 177
	// (Invoke) Token: 0x06000553 RID: 1363
	private delegate object Delegate9(object target, object[] paramters);

	// Token: 0x020000B2 RID: 178
	// (Invoke) Token: 0x06000557 RID: 1367
	private delegate object Delegate10(object target);

	// Token: 0x020000B3 RID: 179
	// (Invoke) Token: 0x0600055B RID: 1371
	private delegate void Delegate11(IntPtr a, byte b, int c);

	// Token: 0x020000B4 RID: 180
	// (Invoke) Token: 0x0600055F RID: 1375
	private delegate void Delegate12(IntPtr s, IntPtr t, uint c);

	// Token: 0x020000B5 RID: 181
	internal class Class14
	{
		// Token: 0x06000562 RID: 1378 RVA: 0x0002521C File Offset: 0x0002341C
		internal void method_0()
		{
			bool flag = false;
			this.method_2(ref flag);
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x00025234 File Offset: 0x00023434
		internal void method_1()
		{
			this.class30_0.method_1();
			this.class16_1 = null;
			if (this.list_0 != null)
			{
				foreach (IntPtr hglobal in this.list_0)
				{
					try
					{
						Marshal.FreeHGlobal(hglobal);
					}
					catch
					{
					}
				}
				this.list_0.Clear();
				this.list_0 = null;
			}
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x000252C8 File Offset: 0x000234C8
		internal void method_2(ref bool bool_4)
		{
			while (this.int_0 > -2)
			{
				if (this.bool_0)
				{
					this.bool_0 = false;
					int num = this.int_1;
					int num2 = this.int_0;
					this.method_4(this.int_1, this.int_0);
					this.int_0 = num2;
					this.int_1 = num;
				}
				if (this.bool_2)
				{
					this.bool_2 = false;
					return;
				}
				if (!this.bool_1)
				{
					this.int_1 = this.int_0;
					Class5.Class6 @class = this.class11_0.list_0[this.int_0];
					this.object_0 = @class.object_0;
					try
					{
						this.method_7(@class);
					}
					catch (Exception innerException)
					{
						if (innerException is TargetInvocationException)
						{
							TargetInvocationException ex = (TargetInvocationException)innerException;
							if (ex.InnerException != null)
							{
								innerException = ex.InnerException;
							}
						}
						this.exception_0 = innerException;
						bool_4 = true;
						this.class30_0.method_1();
						int int_ = this.int_1;
						Class5.Class9 class2 = this.method_5(int_, innerException);
						List<Class5.Class9> list = this.method_6(int_, false);
						List<Class5.Class9> list2 = new List<Class5.Class9>();
						if (class2 != null)
						{
							list2.Add(class2);
						}
						if (list != null && list.Count > 0)
						{
							list2.AddRange(list);
						}
						list2.Sort(new Comparison<Class5.Class9>(Class5.Class14.Class15.<>9.method_0));
						Class5.Class9 class3 = null;
						foreach (Class5.Class9 class4 in list2)
						{
							if (class4.class10_0.int_3 != 0)
							{
								this.class30_0.method_2(new Class5.Class28(innerException));
								this.int_1 = class4.class10_0.int_2;
								this.int_0 = this.int_1;
								this.method_0();
								if (!this.bool_3)
								{
									continue;
								}
								this.bool_3 = false;
								class3 = class4;
							}
							else
							{
								class3 = class4;
							}
							break;
						}
						if (class3 == null)
						{
							throw innerException;
						}
						this.int_2 = class3.class10_0.int_0;
						this.method_3(int_, class3.class10_0.int_0);
						if (this.int_2 >= 0)
						{
							this.class30_0.method_2(new Class5.Class28(innerException));
							this.int_1 = this.int_2;
							this.int_0 = this.int_1;
							this.int_2 = -1;
							this.method_0();
						}
						return;
					}
					this.int_0++;
					continue;
				}
				this.bool_1 = false;
				return;
			}
			this.class30_0.method_1();
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00025584 File Offset: 0x00023784
		internal void method_3(int int_3, int int_4)
		{
			if (this.class11_0.list_2 != null)
			{
				foreach (Class5.Class9 @class in this.class11_0.list_2)
				{
					if ((@class.class10_0.int_3 == 4 || @class.class10_0.int_3 == 2) && @class.class10_0.int_0 >= int_3 && @class.class10_0.int_1 <= int_4)
					{
						this.int_1 = @class.class10_0.int_0;
						this.int_0 = this.int_1;
						bool flag = false;
						this.method_2(ref flag);
						if (flag)
						{
							break;
						}
					}
				}
			}
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x00025654 File Offset: 0x00023854
		internal void method_4(int int_3, int int_4)
		{
			if (this.class11_0.list_2 != null)
			{
				foreach (Class5.Class9 @class in this.class11_0.list_2)
				{
					if (@class.class10_0.int_3 == 2 && @class.class10_0.int_0 >= int_3 && @class.class10_0.int_1 <= int_4)
					{
						this.int_1 = @class.class10_0.int_0;
						this.int_0 = this.int_1;
						bool flag = false;
						this.method_2(ref flag);
						if (flag)
						{
							break;
						}
					}
				}
			}
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00025714 File Offset: 0x00023914
		internal Class5.Class9 method_5(int int_3, Exception exception_1)
		{
			Class5.Class9 @class = null;
			if (this.class11_0.list_2 != null)
			{
				foreach (Class5.Class9 class2 in this.class11_0.list_2)
				{
					if (class2.class10_0 != null && class2.class10_0.int_3 == 0 && (class2.class10_0.type_0 == exception_1.GetType() || (class2.class10_0.type_0 != null && (class2.class10_0.type_0.FullName == exception_1.GetType().FullName || class2.class10_0.type_0.FullName == typeof(object).FullName || class2.class10_0.type_0.FullName == typeof(Exception).FullName))) && int_3 >= class2.int_0 && int_3 <= class2.int_1)
					{
						if (@class == null)
						{
							@class = class2;
						}
						else if (class2.class10_0.int_0 < @class.class10_0.int_0)
						{
							@class = class2;
						}
					}
				}
			}
			return @class;
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x0002588C File Offset: 0x00023A8C
		internal List<Class5.Class9> method_6(int int_3, bool bool_4)
		{
			if (this.class11_0.list_2 == null)
			{
				return null;
			}
			List<Class5.Class9> list = new List<Class5.Class9>();
			foreach (Class5.Class9 @class in this.class11_0.list_2)
			{
				if ((@class.class10_0.int_3 & 1) == 1 && int_3 >= @class.int_0 && int_3 <= @class.int_1)
				{
					list.Add(@class);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			return list;
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x00025928 File Offset: 0x00023B28
		private unsafe void method_7(Class5.Class6 class6_0)
		{
			switch (class6_0.enum3_0)
			{
			case (Class5.Enum3)0:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_63(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)1:
			{
				Class5.Class16 class3 = Class5.Class14.smethod_6(this.class30_0.method_4());
				Class5.Class16 class4 = Class5.Class14.smethod_6(this.class30_0.method_4());
				if (class3.vmethod_5(class4))
				{
					this.class30_0.method_2(new Class5.Class18(1));
					return;
				}
				this.class30_0.method_2(new Class5.Class18(0));
				return;
			}
			case (Class5.Enum3)2:
				this.class30_0.method_2(new Class5.Class23((int)this.object_0, this));
				return;
			case (Class5.Enum3)3:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				Class5.Class17 @class = Class5.Class14.smethod_1(class4);
				if (class4 != null && class4.vmethod_0() && @class != null)
				{
					this.class30_0.method_2(@class.vmethod_47());
					return;
				}
				if (@class != null && @class.method_2())
				{
					IntPtr intPtr = ((Class5.Class20)@class).method_7();
					this.class30_0.method_2(new Class5.Class21(*(float*)((void*)intPtr), (Class5.Enum1)9));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)4:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null)
				{
					this.class30_0.method_2(@class.vmethod_44());
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)5:
			case (Class5.Enum3)8:
			case (Class5.Enum3)79:
			case (Class5.Enum3)86:
			case (Class5.Enum3)123:
			case (Class5.Enum3)131:
			case (Class5.Enum3)140:
			case (Class5.Enum3)163:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Array array = (Array)this.class30_0.method_4().vmethod_4(null);
				Type type = array.GetType().GetElementType();
				array.SetValue(class4.vmethod_4(type), @class.vmethod_19().struct2_0.int_0);
				return;
			}
			case (Class5.Enum3)6:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				object obj = ((Array)this.class30_0.method_4().vmethod_4(null)).GetValue(@class.vmethod_19().struct2_0.int_0);
				this.class30_0.method_2(Class5.Class16.smethod_1(typeof(long), obj));
				return;
			}
			case (Class5.Enum3)7:
			{
				int num = (int)this.object_0;
				FieldInfo fieldInfo = typeof(Class5).Module.ResolveField(num);
				this.class30_0.method_2(Class5.Class16.smethod_1(fieldInfo.FieldType, fieldInfo.GetValue(null)));
				return;
			}
			case (Class5.Enum3)9:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = (Class5.Class17)this.class30_0.method_4();
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_61(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)10:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_46());
				return;
			}
			case (Class5.Enum3)11:
			{
				int num = (int)this.object_0;
				typeof(Class5).Module.ResolveType(num);
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Array array2 = (Array)this.class30_0.method_4().vmethod_4(null);
				this.class30_0.method_2(new Class5.Class24(@class.vmethod_19().struct2_0.int_0, array2));
				return;
			}
			case (Class5.Enum3)12:
				this.class30_0.method_2(this.class30_0.method_3());
				return;
			case (Class5.Enum3)13:
				return;
			case (Class5.Enum3)14:
				this.class30_0.method_2(new Class5.Class19((long)this.object_0));
				return;
			case (Class5.Enum3)15:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_26());
				return;
			}
			case (Class5.Enum3)16:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				object obj = ((Array)this.class30_0.method_4().vmethod_4(null)).GetValue(@class.vmethod_19().struct2_0.int_0);
				this.class30_0.method_2(Class5.Class16.smethod_1(typeof(int), obj));
				return;
			}
			case (Class5.Enum3)17:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null)
				{
					this.class30_0.method_2(@class.vmethod_48());
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)18:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				object obj = ((Array)this.class30_0.method_4().vmethod_4(null)).GetValue(@class.vmethod_19().struct2_0.int_0);
				this.class30_0.method_2(Class5.Class16.smethod_1(typeof(ushort), obj));
				return;
			}
			case (Class5.Enum3)19:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null)
				{
					this.class30_0.method_2(@class.vmethod_28());
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)20:
			case (Class5.Enum3)25:
			case (Class5.Enum3)78:
			case (Class5.Enum3)90:
			case (Class5.Enum3)125:
			case (Class5.Enum3)138:
				return;
			case (Class5.Enum3)21:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				Class5.Class17 @class = Class5.Class14.smethod_1(class4);
				if (class4 != null && class4.vmethod_0() && @class != null)
				{
					this.class30_0.method_2(@class.vmethod_48());
					return;
				}
				if (@class != null && @class.method_2())
				{
					IntPtr intPtr = ((Class5.Class20)@class).method_7();
					this.class30_0.method_2(new Class5.Class21(*(double*)((void*)intPtr), (Class5.Enum1)10));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)22:
			{
				Class5.Class17 @class = this.class30_0.method_4() as Class5.Class17;
				IntPtr intPtr = Class5.Class14.smethod_8(this.class30_0.method_4());
				IntPtr intPtr2 = Class5.Class14.smethod_8(this.class30_0.method_4());
				if (intPtr != IntPtr.Zero && intPtr2 != IntPtr.Zero)
				{
					uint num2 = @class.vmethod_20().struct2_0.uint_0;
					Class5.Class14.smethod_11(intPtr2, intPtr, num2);
				}
				return;
			}
			case (Class5.Enum3)23:
			{
				IntPtr intPtr = Marshal.AllocHGlobal((this.class30_0.method_4() as Class5.Class17).vmethod_19().struct2_0.int_0);
				if (this.list_0 == null)
				{
					this.list_0 = new List<IntPtr>();
				}
				this.list_0.Add(intPtr);
				this.class30_0.method_2(new Class5.Class20(intPtr));
				return;
			}
			case (Class5.Enum3)24:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_67(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)26:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_65(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)27:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				Class5.Class17 @class = Class5.Class14.smethod_1(class4);
				if (class4 != null && class4.vmethod_0() && @class != null)
				{
					this.class30_0.method_2(@class.vmethod_26());
					return;
				}
				if (@class != null && @class.method_2())
				{
					IntPtr intPtr = ((Class5.Class20)@class).method_7();
					this.class30_0.method_2(new Class5.Class19(*(long*)((void*)intPtr), (Class5.Enum1)7));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)28:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_45());
				return;
			}
			case (Class5.Enum3)29:
				this.class30_0.method_2(this.class30_0.method_4().vmethod_8());
				return;
			case (Class5.Enum3)30:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (class4.vmethod_3())
				{
					class4 = ((Class5.Class17)class4).vmethod_25();
				}
				this.class30_0.method_4().vmethod_2(class4);
				return;
			}
			case (Class5.Enum3)31:
				this.class30_0.method_2(new Class5.Class21((double)this.object_0));
				return;
			case (Class5.Enum3)32:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null)
				{
					this.class30_0.method_2(@class.vmethod_35());
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)33:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_62(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)34:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_47());
				return;
			}
			case (Class5.Enum3)35:
			{
				int num = (int)this.object_0;
				ConstructorInfo constructorInfo = (ConstructorInfo)typeof(Class5).Module.ResolveMethod(num);
				ParameterInfo[] parameters = constructorInfo.GetParameters();
				object[] array3 = new object[parameters.Length];
				Class5.Class16[] array4 = new Class5.Class16[parameters.Length];
				List<Class5.Class12> list = null;
				Class5.Class13 class5 = null;
				for (int i = 0; i < parameters.Length; i++)
				{
					Class5.Class16 class4 = this.class30_0.method_4();
					Type type = parameters[parameters.Length - 1 - i].ParameterType;
					object obj2 = null;
					bool flag = false;
					if (type.IsByRef)
					{
						Class5.Class25 class6 = class4 as Class5.Class25;
						if (class6 != null)
						{
							if (list == null)
							{
								list = new List<Class5.Class12>();
							}
							list.Add(new Class5.Class12(class6.fieldInfo_0, parameters.Length - 1 - i));
							obj2 = class6.object_0;
							if (!(obj2 is Class5.Class16))
							{
								flag = true;
							}
							else
							{
								class4 = (obj2 as Class5.Class16);
							}
						}
					}
					if (!flag)
					{
						if (class4 != null)
						{
							obj2 = class4.vmethod_4(type);
						}
						if (obj2 == null)
						{
							if (type.IsByRef)
							{
								type = type.GetElementType();
							}
							if (type.IsValueType)
							{
								obj2 = Activator.CreateInstance(type);
								if (class4 is Class5.Class23)
								{
									((Class5.Class22)class4).vmethod_12(Class5.Class16.smethod_1(type, obj2));
								}
							}
						}
					}
					array4[array3.Length - 1 - i] = class4;
					array3[array3.Length - 1 - i] = obj2;
				}
				Class5.Delegate9 @delegate = null;
				if (list != null)
				{
					class5 = new Class5.Class13(constructorInfo, list);
					@delegate = Class5.Class14.smethod_4(constructorInfo, true, class5);
				}
				object obj = null;
				if (@delegate == null)
				{
					obj = constructorInfo.Invoke(array3);
				}
				else
				{
					obj = @delegate(null, array3);
				}
				for (int j = 0; j < parameters.Length; j++)
				{
					if (parameters[j].ParameterType.IsByRef && (class5 == null || !class5.method_1(j)))
					{
						if (!array4[j].method_2())
						{
							if (!(array4[j] is Class5.Class23))
							{
								array4[j].vmethod_10(Class5.Class16.smethod_1(parameters[j].ParameterType, array3[j]));
							}
							else
							{
								array4[j].vmethod_10(Class5.Class16.smethod_1(parameters[j].ParameterType.GetElementType(), array3[j]));
							}
						}
						else
						{
							((Class5.Class20)array4[j]).method_6(Class5.Class16.smethod_1(parameters[j].ParameterType, array3[j]));
						}
					}
				}
				this.class30_0.method_2(Class5.Class16.smethod_1(constructorInfo.DeclaringType, obj));
				return;
			}
			case (Class5.Enum3)36:
			{
				int num = (int)this.object_0;
				Type type = typeof(Class5).Module.ResolveType(num);
				object obj = this.class30_0.method_4().vmethod_8().vmethod_4(type);
				Class5.Class16 class4 = Class5.Class16.smethod_1(type, obj);
				this.class30_0.method_2(class4);
				return;
			}
			case (Class5.Enum3)37:
			{
				int num = (int)this.object_0;
				Type type = typeof(Class5).Module.ResolveType(num);
				Class5.Class16 class4 = this.class30_0.method_4();
				object obj = class4.vmethod_4(null);
				if (obj == null)
				{
					this.class30_0.method_2(new Class5.Class28(null));
					return;
				}
				if (type.IsAssignableFrom(obj.GetType()))
				{
					this.class30_0.method_2(class4);
					return;
				}
				this.class30_0.method_2(new Class5.Class28(null));
				return;
			}
			case (Class5.Enum3)38:
			{
				object obj = Class5.Class14.object_2;
				lock (obj)
				{
					Class5.Class16 class4 = this.class30_0.method_4();
					object obj2 = this.class30_0.method_4().vmethod_4(null);
					Class5.Class14.dictionary_1[obj2] = class4;
				}
				return;
			}
			case (Class5.Enum3)39:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null)
				{
					this.class30_0.method_2(@class.vmethod_42());
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)40:
			{
				int num = (int)this.object_0;
				Module module = typeof(Class5).Module;
				object obj = null;
				try
				{
					obj = module.ResolveType(num);
				}
				catch
				{
					try
					{
						obj = module.ResolveMethod(num);
					}
					catch
					{
						try
						{
							obj = module.ResolveField(num);
						}
						catch
						{
							obj = module.ResolveMember(num);
						}
					}
				}
				this.class30_0.method_2(new Class5.Class28(obj));
				return;
			}
			case (Class5.Enum3)41:
				throw this.exception_0;
			case (Class5.Enum3)42:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_49());
				return;
			}
			case (Class5.Enum3)43:
			{
				int num = (int)this.object_0;
				FieldInfo fieldInfo = typeof(Class5).Module.ResolveField(num);
				object obj = this.class30_0.method_4().vmethod_4(null);
				this.class30_0.method_2(Class5.Class16.smethod_1(fieldInfo.FieldType, fieldInfo.GetValue(obj)));
				return;
			}
			case (Class5.Enum3)44:
			{
				Class5.Class16 class4 = this.class16_1[(int)this.object_0];
				this.class30_0.method_2(class4);
				return;
			}
			case (Class5.Enum3)45:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_55());
				return;
			}
			case (Class5.Enum3)46:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null)
				{
					this.class30_0.method_2(@class.vmethod_43());
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)47:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_30());
				return;
			}
			case (Class5.Enum3)48:
				this.method_12(true);
				return;
			case (Class5.Enum3)49:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_34());
				return;
			}
			case (Class5.Enum3)50:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (Class5.Class14.smethod_1(this.class30_0.method_4()).vmethod_80(class4))
				{
					this.int_0 = (int)this.object_0 - 1;
				}
				return;
			}
			case (Class5.Enum3)51:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_75(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)52:
			{
				int num = (int)this.object_0;
				Type type = typeof(Class5).Module.ResolveType(num);
				Class5.Class22 class7 = this.class30_0.method_4() as Class5.Class22;
				if (class7 == null)
				{
					throw new Class5.Exception1();
				}
				if (type.IsValueType)
				{
					object obj = Activator.CreateInstance(type);
					class7.vmethod_12(Class5.Class16.smethod_1(type, obj));
					return;
				}
				class7.vmethod_12(new Class5.Class28(null));
				return;
			}
			case (Class5.Enum3)53:
			case (Class5.Enum3)92:
			{
				int num = (int)this.object_0;
				Type type = typeof(Class5).Module.ResolveType(num);
				Class5.Class16 class4 = this.class30_0.method_4();
				object obj = class4.vmethod_4(type);
				if (obj == null)
				{
					if (type.IsValueType)
					{
						obj = Activator.CreateInstance(type);
						class4 = Class5.Class16.smethod_1(type, obj);
					}
					else
					{
						class4 = new Class5.Class28(null);
					}
				}
				else
				{
					if (type.IsValueType)
					{
						obj = Class5.Class14.smethod_9(obj);
					}
					class4 = Class5.Class16.smethod_1(type, obj);
				}
				Class5.Class22 class8 = this.class30_0.method_4() as Class5.Class22;
				if (class8 != null)
				{
					class8.vmethod_10(class4);
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)54:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_77(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)55:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_31());
				return;
			}
			case (Class5.Enum3)56:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_23());
				return;
			}
			case (Class5.Enum3)57:
			case (Class5.Enum3)63:
			case (Class5.Enum3)100:
			case (Class5.Enum3)126:
			case (Class5.Enum3)132:
			case (Class5.Enum3)142:
				throw new Class5.Exception1();
			case (Class5.Enum3)58:
				throw (Exception)this.class30_0.method_4().vmethod_4(null);
			case (Class5.Enum3)59:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (class4.vmethod_3())
				{
					class4 = ((Class5.Class17)class4).vmethod_50();
				}
				this.class30_0.method_4().vmethod_2(class4);
				return;
			}
			case (Class5.Enum3)60:
			{
				int num = (int)this.object_0;
				this.class16_1[num] = this.method_8(this.class30_0.method_4(), this.class11_0.list_1[num].enum1_0, this.class11_0.list_1[num].bool_0);
				return;
			}
			case (Class5.Enum3)61:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_54());
				return;
			}
			case (Class5.Enum3)62:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (Class5.Class14.smethod_1(this.class30_0.method_4()).vmethod_82(class4))
				{
					this.int_0 = (int)this.object_0 - 1;
				}
				return;
			}
			case (Class5.Enum3)64:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				bool flag2 = Class5.Class14.smethod_1(this.class30_0.method_4()).vmethod_85(class4);
				if (!flag2)
				{
					this.class30_0.method_2(new Class5.Class18(0));
				}
				else
				{
					this.class30_0.method_2(new Class5.Class18(1));
				}
				if (flag2)
				{
					this.int_0 = (int)this.object_0 - 1;
				}
				return;
			}
			case (Class5.Enum3)65:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (Class5.Class14.smethod_1(this.class30_0.method_4()).vmethod_79(class4))
				{
					this.int_0 = (int)this.object_0 - 1;
				}
				return;
			}
			case (Class5.Enum3)66:
			{
				Class5.Class16 class9 = this.class30_0.method_4();
				Class5.Class16 class4 = this.class30_0.method_4();
				if (class9.vmethod_5(class4))
				{
					this.int_0 = (int)this.object_0 - 1;
				}
				return;
			}
			case (Class5.Enum3)67:
				this.int_0 = (int)this.object_0 - 1;
				this.bool_0 = true;
				return;
			case (Class5.Enum3)68:
				if (this.class30_0.method_4().vmethod_6(this.class30_0.method_4()))
				{
					this.int_0 = (int)this.object_0 - 1;
				}
				return;
			case (Class5.Enum3)69:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				Class5.Class17 @class = Class5.Class14.smethod_1(class4);
				if (class4 != null && class4.vmethod_0() && @class != null)
				{
					this.class30_0.method_2(@class.vmethod_24());
					return;
				}
				if (@class != null && @class.method_2())
				{
					IntPtr intPtr = ((Class5.Class20)@class).method_7();
					this.class30_0.method_2(new Class5.Class18((int)(*(short*)((void*)intPtr)), (Class5.Enum1)3));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)70:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (Class5.Class14.smethod_1(this.class30_0.method_4()).vmethod_85(class4))
				{
					this.class30_0.method_2(new Class5.Class18(1));
					return;
				}
				this.class30_0.method_2(new Class5.Class18(0));
				return;
			}
			case (Class5.Enum3)71:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				object obj = ((Array)this.class30_0.method_4().vmethod_4(null)).GetValue(@class.vmethod_19().struct2_0.int_0);
				this.class30_0.method_2(Class5.Class16.smethod_1(typeof(uint), obj));
				return;
			}
			case (Class5.Enum3)72:
			{
				int num = (int)this.object_0;
				Type type = typeof(Class5).Module.ResolveType(num);
				Class5.Class16 class4 = this.class30_0.method_4();
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				((Array)this.class30_0.method_4().vmethod_4(null)).SetValue(class4.vmethod_4(type), @class.vmethod_19().struct2_0.int_0);
				return;
			}
			case (Class5.Enum3)73:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Array array5 = (Array)this.class30_0.method_4().vmethod_4(null);
				object obj = array5.GetValue(@class.vmethod_19().struct2_0.int_0);
				Type type = array5.GetType().GetElementType();
				this.class30_0.method_2(Class5.Class16.smethod_1(type, obj));
				return;
			}
			case (Class5.Enum3)74:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (class4.vmethod_3())
				{
					class4 = ((Class5.Class17)class4).vmethod_48();
				}
				this.class30_0.method_4().vmethod_2(class4);
				return;
			}
			case (Class5.Enum3)75:
			{
				Type type = typeof(Class5).Module.ResolveType((int)this.object_0);
				object obj = this.class30_0.method_4().vmethod_4(type);
				if (obj == null)
				{
					obj = Activator.CreateInstance(type);
				}
				Class5.Class28 class10 = new Class5.Class28(Class5.Class16.smethod_1(type, Class5.Class14.smethod_9(obj)));
				this.class30_0.method_2(class10);
				return;
			}
			case (Class5.Enum3)76:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				object obj = ((Array)this.class30_0.method_4().vmethod_4(null)).GetValue(@class.vmethod_19().struct2_0.int_0);
				this.class30_0.method_2(Class5.Class16.smethod_1(typeof(double), obj));
				return;
			}
			case (Class5.Enum3)77:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_64(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)80:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (Class5.Class14.smethod_1(this.class30_0.method_4()).vmethod_83(class4))
				{
					this.int_0 = (int)this.object_0 - 1;
				}
				return;
			}
			case (Class5.Enum3)81:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (class4.vmethod_3())
				{
					class4 = ((Class5.Class17)class4).vmethod_47();
				}
				this.class30_0.method_4().vmethod_2(class4);
				return;
			}
			case (Class5.Enum3)82:
				this.class30_0.method_2(((Class5.Class17)this.class30_0.method_4()).vmethod_56());
				return;
			case (Class5.Enum3)83:
				this.bool_2 = true;
				return;
			case (Class5.Enum3)84:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null)
				{
					this.class30_0.method_2(@class.vmethod_24());
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)85:
			{
				int num = (int)this.object_0;
				uint num2 = (uint)Class5.Class14.smethod_0(typeof(Class5).Module.ResolveType(num));
				this.class30_0.method_2(new Class5.Class18(num2, (Class5.Enum1)6));
				return;
			}
			case (Class5.Enum3)87:
			{
				Class5.Class17 class11 = Class5.Class14.smethod_1(this.class30_0.method_3());
				if (class11 != null)
				{
					Class5.Class21 class12 = class11 as Class5.Class21;
					if (class12 != null)
					{
						if (double.IsNaN(class12.double_0))
						{
							throw new OverflowException(((Class5.Enum5)2).ToString());
						}
						if (double.IsInfinity(class12.double_0))
						{
							throw new OverflowException(((Class5.Enum5)1).ToString());
						}
					}
					return;
				}
				throw new ArithmeticException(((Class5.Enum5)0).ToString());
			}
			case (Class5.Enum3)88:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_40());
				return;
			}
			case (Class5.Enum3)89:
				this.bool_3 = (bool)this.class30_0.method_4().vmethod_4(typeof(bool));
				this.bool_1 = true;
				return;
			case (Class5.Enum3)91:
			{
				if (Class5.list_0.Count != 0)
				{
					this.class30_0.method_2(new Class5.Class29(Class5.list_0[(int)this.object_0]));
					return;
				}
				Module module = typeof(Class5).Module;
				this.class30_0.method_2(new Class5.Class29(module.ResolveString((int)this.object_0 | 1879048192)));
				return;
			}
			case (Class5.Enum3)93:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_25());
				return;
			}
			case (Class5.Enum3)94:
				this.method_12(false);
				return;
			case (Class5.Enum3)95:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null)
				{
					this.class30_0.method_2(@class.vmethod_32());
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)96:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				object obj = ((Array)this.class30_0.method_4().vmethod_4(null)).GetValue(@class.vmethod_19().struct2_0.int_0);
				this.class30_0.method_2(Class5.Class16.smethod_1(typeof(byte), obj));
				return;
			}
			case (Class5.Enum3)97:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null)
				{
					this.class30_0.method_2(@class.vmethod_27());
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)98:
				this.class30_0.method_2(new Class5.Class18((int)this.object_0));
				return;
			case (Class5.Enum3)99:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_29());
				return;
			}
			case (Class5.Enum3)101:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null && class2 != null)
				{
					this.class30_0.method_2(@class.vmethod_73(class2));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)102:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null && class2 != null)
				{
					this.class30_0.method_2(@class.vmethod_71(class2));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)103:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				Class5.Class17 @class = Class5.Class14.smethod_1(class4);
				if (class4 != null && class4.vmethod_0() && @class != null)
				{
					this.class30_0.method_2(@class.vmethod_29());
					return;
				}
				if (@class != null && @class.method_2())
				{
					IntPtr intPtr = ((Class5.Class20)@class).method_7();
					this.class30_0.method_2(new Class5.Class18(*(uint*)((void*)intPtr), (Class5.Enum1)6));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)104:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				Class5.Class17 @class = Class5.Class14.smethod_1(class4);
				if (class4 != null && class4.vmethod_0() && @class != null)
				{
					this.class30_0.method_2(@class.vmethod_28());
					return;
				}
				if (@class != null && @class.method_2())
				{
					IntPtr intPtr = ((Class5.Class20)@class).method_7();
					this.class30_0.method_2(new Class5.Class18((int)(*(ushort*)((void*)intPtr)), (Class5.Enum1)4));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)105:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				Class5.Class17 @class = Class5.Class14.smethod_1(class4);
				if (class4 != null && class4.vmethod_0() && @class != null)
				{
					this.class30_0.method_2(@class.vmethod_23());
					return;
				}
				if (@class != null && @class.method_2())
				{
					IntPtr intPtr = ((Class5.Class20)@class).method_7();
					this.class30_0.method_2(new Class5.Class18((int)(*(sbyte*)((void*)intPtr)), (Class5.Enum1)1));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)106:
				this.class30_0.method_4();
				return;
			case (Class5.Enum3)107:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (class4.vmethod_3())
				{
					class4 = ((Class5.Class17)class4).vmethod_23();
				}
				this.class30_0.method_4().vmethod_2(class4);
				return;
			}
			case (Class5.Enum3)108:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_33());
				return;
			}
			case (Class5.Enum3)109:
			{
				Array array2 = (Array)this.class30_0.method_4().vmethod_4(null);
				this.class30_0.method_2(new Class5.Class18(array2.Length, (Class5.Enum1)5));
				return;
			}
			case (Class5.Enum3)110:
			{
				int num = (int)this.object_0;
				Module module = typeof(Class5).Module;
				this.class30_0.method_2(new Class5.Class20(module.ResolveMethod(num).MethodHandle.GetFunctionPointer()));
				return;
			}
			case (Class5.Enum3)111:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_58(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)112:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_50());
				return;
			}
			case (Class5.Enum3)113:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (Class5.Class14.smethod_1(this.class30_0.method_4()).vmethod_84(class4))
				{
					this.class30_0.method_2(new Class5.Class18(1));
					return;
				}
				this.class30_0.method_2(new Class5.Class18(0));
				return;
			}
			case (Class5.Enum3)114:
			{
				int num = (int)this.object_0;
				Type type = typeof(Class5).Module.ResolveType(num);
				Class5.Class22 class13 = this.class30_0.method_4() as Class5.Class22;
				if (class13 != null)
				{
					object obj = class13.vmethod_4(type);
					Class5.Class16 class4;
					if (obj != null)
					{
						if (type.IsValueType)
						{
							obj = Class5.Class14.smethod_9(obj);
						}
						class4 = Class5.Class16.smethod_1(type, obj);
					}
					else if (!type.IsValueType)
					{
						class4 = new Class5.Class28(null);
					}
					else
					{
						obj = Activator.CreateInstance(type);
						class4 = Class5.Class16.smethod_1(type, obj);
					}
					this.class30_0.method_2(class4);
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)115:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null)
				{
					this.class30_0.method_2(@class.vmethod_53());
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)116:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_66(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)117:
				this.int_0 = -3;
				if (this.class30_0.method_0() > 0)
				{
					this.class16_2 = this.class30_0.method_4();
				}
				return;
			case (Class5.Enum3)118:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_51());
				return;
			}
			case (Class5.Enum3)119:
			{
				int[] array6 = (int[])this.object_0;
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				long num3 = @class.vmethod_21().struct3_0.long_0;
				if ((num3 < 0L || @class.method_4()) && IntPtr.Size == 4)
				{
					num3 = (long)((int)num3);
				}
				if (@class.method_1())
				{
					Class5.Class18 class14 = (Class5.Class18)@class;
					if (class14.enum1_0 == (Class5.Enum1)6)
					{
						num3 = (long)((ulong)class14.struct2_0.uint_0);
					}
				}
				if (num3 < (long)array6.Length && num3 >= 0L)
				{
					this.int_0 = array6[(int)(checked((IntPtr)num3))] - 1;
				}
				return;
			}
			case (Class5.Enum3)120:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (!Class5.Class14.smethod_1(this.class30_0.method_4()).vmethod_80(class4))
				{
					this.class30_0.method_2(new Class5.Class18(0));
					return;
				}
				this.class30_0.method_2(new Class5.Class18(1));
				return;
			}
			case (Class5.Enum3)121:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				object obj = ((Array)this.class30_0.method_4().vmethod_4(null)).GetValue(@class.vmethod_19().struct2_0.int_0);
				this.class30_0.method_2(Class5.Class16.smethod_1(typeof(IntPtr), obj));
				return;
			}
			case (Class5.Enum3)122:
				this.class30_0.method_2(new Class5.Class21((float)this.object_0));
				return;
			case (Class5.Enum3)124:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null)
				{
					this.class30_0.method_2(@class.vmethod_41());
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)127:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				object obj = ((Array)this.class30_0.method_4().vmethod_4(null)).GetValue(@class.vmethod_19().struct2_0.int_0);
				this.class30_0.method_2(Class5.Class16.smethod_1(typeof(sbyte), obj));
				return;
			}
			case (Class5.Enum3)128:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_52());
				return;
			}
			case (Class5.Enum3)129:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_38());
				return;
			}
			case (Class5.Enum3)130:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (!class4.vmethod_0())
				{
					throw new Class5.Exception1();
				}
				object obj = class4.vmethod_4(null);
				if (obj == null)
				{
					class4 = new Class5.Class28(null);
				}
				else
				{
					class4 = Class5.Class16.smethod_1(obj.GetType(), obj);
				}
				this.class30_0.method_2(class4);
				return;
			}
			case (Class5.Enum3)133:
			{
				int num = (int)this.object_0;
				if (!this.class11_0.methodBase_0.IsStatic)
				{
					this.class16_0[num] = this.method_8(this.class30_0.method_4(), this.class11_0.class7_0[num - 1].enum1_0, false);
					return;
				}
				this.class16_0[num] = this.method_8(this.class30_0.method_4(), this.class11_0.class7_0[num].enum1_0, false);
				return;
			}
			case (Class5.Enum3)134:
			{
				int num = (int)this.object_0;
				FieldInfo fieldInfo = typeof(Class5).Module.ResolveField(num);
				object obj = this.class30_0.method_4().vmethod_4(fieldInfo.FieldType);
				Class5.Class16 class4 = this.class30_0.method_4();
				object obj2 = class4.vmethod_4(null);
				if (obj2 == null)
				{
					Type type = fieldInfo.DeclaringType;
					if (type.IsByRef)
					{
						type = type.GetElementType();
					}
					if (!type.IsValueType)
					{
						throw new NullReferenceException();
					}
					obj2 = Activator.CreateInstance(type);
					if (class4 is Class5.Class23)
					{
						((Class5.Class22)class4).vmethod_12(Class5.Class16.smethod_1(type, obj2));
					}
				}
				fieldInfo.SetValue(obj2, obj);
				return;
			}
			case (Class5.Enum3)135:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				this.class30_0.method_4().vmethod_2(class4);
				return;
			}
			case (Class5.Enum3)136:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				object obj = ((Array)this.class30_0.method_4().vmethod_4(null)).GetValue(@class.vmethod_19().struct2_0.int_0);
				this.class30_0.method_2(Class5.Class16.smethod_1(typeof(short), obj));
				return;
			}
			case (Class5.Enum3)137:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class == null)
				{
					throw new Class5.Exception1();
				}
				this.class30_0.method_2(@class.vmethod_36());
				return;
			}
			case (Class5.Enum3)139:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_68(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)141:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (class4.vmethod_3())
				{
					class4 = ((Class5.Class17)class4).vmethod_26();
				}
				this.class30_0.method_4().vmethod_2(class4);
				return;
			}
			case (Class5.Enum3)143:
			{
				int num = (int)this.object_0;
				Type type = typeof(Class5).Module.ResolveType(num);
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				object obj = ((Array)this.class30_0.method_4().vmethod_4(null)).GetValue(@class.vmethod_19().struct2_0.int_0);
				this.class30_0.method_2(Class5.Class16.smethod_1(type, obj));
				return;
			}
			case (Class5.Enum3)144:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				Class5.Class17 @class = Class5.Class14.smethod_1(class4);
				if (class4 != null && class4.vmethod_0() && @class != null)
				{
					this.class30_0.method_2(@class.vmethod_50());
					return;
				}
				if (@class == null || !@class.method_2())
				{
					throw new Class5.Exception1();
				}
				IntPtr intPtr = ((Class5.Class20)@class).method_7();
				if (IntPtr.Size == 8)
				{
					long num3 = *(long*)((void*)intPtr);
					this.class30_0.method_2(new Class5.Class20(num3, (Class5.Enum1)12));
					return;
				}
				int num = *(int*)((void*)intPtr);
				this.class30_0.method_2(new Class5.Class20((long)num, (Class5.Enum1)12));
				return;
			}
			case (Class5.Enum3)145:
				this.class30_0.method_2(new Class5.Class28(null));
				return;
			case (Class5.Enum3)146:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (class4.vmethod_3())
				{
					class4 = ((Class5.Class17)class4).vmethod_24();
				}
				this.class30_0.method_4().vmethod_2(class4);
				return;
			}
			case (Class5.Enum3)147:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_69(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)148:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_59(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)149:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_60(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)150:
			{
				int num = (int)this.object_0;
				Type elementType = typeof(Class5).Module.ResolveType(num);
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Array array2 = Array.CreateInstance(elementType, @class.vmethod_19().struct2_0.int_0);
				this.class30_0.method_2(new Class5.Class28(array2));
				return;
			}
			case (Class5.Enum3)151:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				Class5.Class17 @class = Class5.Class14.smethod_1(class4);
				if (class4 != null && class4.vmethod_0() && @class != null)
				{
					this.class30_0.method_2(@class.vmethod_27());
					return;
				}
				if (@class != null && @class.method_2())
				{
					IntPtr intPtr = ((Class5.Class20)@class).method_7();
					this.class30_0.method_2(new Class5.Class18((int)(*(byte*)((void*)intPtr)), (Class5.Enum1)2));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)152:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				Class5.Class17 @class = Class5.Class14.smethod_1(class4);
				Class5.Class16 class16_ = this.class30_0.method_4();
				Class5.Class17 class2 = Class5.Class14.smethod_1(class16_);
				if (class2 != null && @class != null)
				{
					if (class2.vmethod_81(class4))
					{
						this.class30_0.method_2(new Class5.Class18(1));
						return;
					}
					this.class30_0.method_2(new Class5.Class18(0));
					return;
				}
				else
				{
					if (!class4.vmethod_6(class16_))
					{
						this.class30_0.method_2(new Class5.Class18(0));
						return;
					}
					this.class30_0.method_2(new Class5.Class18(1));
					return;
				}
				break;
			}
			case (Class5.Enum3)153:
			{
				int num = (int)this.object_0;
				FieldInfo fieldInfo = typeof(Class5).Module.ResolveField(num);
				Class5.Class16 class15 = this.class30_0.method_4();
				class15.vmethod_8();
				object obj = class15.vmethod_4(null);
				this.class30_0.method_2(new Class5.Class25(fieldInfo, obj));
				return;
			}
			case (Class5.Enum3)154:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (Class5.Class14.smethod_1(this.class30_0.method_4()).vmethod_78(class4))
				{
					this.int_0 = (int)this.object_0 - 1;
				}
				return;
			}
			case (Class5.Enum3)155:
				this.class30_0.method_2(this.class16_0[(int)this.object_0]);
				return;
			case (Class5.Enum3)156:
			{
				int num = (int)this.object_0;
				FieldInfo fieldInfo = typeof(Class5).Module.ResolveField(num);
				object obj = this.class30_0.method_4().vmethod_4(fieldInfo.FieldType);
				fieldInfo.SetValue(null, obj);
				return;
			}
			case (Class5.Enum3)157:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				object obj = ((Array)this.class30_0.method_4().vmethod_4(null)).GetValue(@class.vmethod_19().struct2_0.int_0);
				this.class30_0.method_2(Class5.Class16.smethod_1(typeof(float), obj));
				return;
			}
			case (Class5.Enum3)158:
			{
				int num = (int)this.object_0;
				MethodBase methodBase = typeof(Class5).Module.ResolveMethod(num);
				Type type = this.class30_0.method_4().vmethod_4(null).GetType();
				List<Type> list2 = new List<Type>();
				do
				{
					list2.Add(type);
					type = type.BaseType;
				}
				while (type != null && type != methodBase.DeclaringType);
				list2.Reverse();
				MethodBase methodBase2 = methodBase;
				foreach (Type type2 in list2)
				{
					foreach (MethodInfo methodInfo in type2.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
					{
						if (methodInfo.GetBaseDefinition() == methodBase2)
						{
							methodBase2 = methodInfo;
							break;
						}
					}
				}
				this.class30_0.method_2(new Class5.Class20(methodBase2.MethodHandle.GetFunctionPointer()));
				return;
			}
			case (Class5.Enum3)159:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null)
				{
					this.class30_0.method_2(@class.vmethod_39());
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)160:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null)
				{
					this.class30_0.method_2(@class.vmethod_72());
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)161:
			{
				bool flag = false;
				Class5.Class16 class4 = this.class30_0.method_4();
				flag = (class4 == null || !class4.vmethod_7());
				if (flag)
				{
					this.int_0 = (int)this.object_0 - 1;
				}
				return;
			}
			case (Class5.Enum3)162:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				Class5.Class17 @class = Class5.Class14.smethod_1(class4);
				if (class4 != null && class4.vmethod_0() && @class != null)
				{
					this.class30_0.method_2(@class.vmethod_25());
					return;
				}
				if (@class != null && @class.method_2())
				{
					IntPtr intPtr = ((Class5.Class20)@class).method_7();
					this.class30_0.method_2(new Class5.Class18(*(int*)((void*)intPtr), (Class5.Enum1)5));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)164:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_76(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)165:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (class4 != null && class4.vmethod_7())
				{
					this.int_0 = (int)this.object_0 - 1;
				}
				return;
			}
			case (Class5.Enum3)166:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null)
				{
					this.class30_0.method_2(@class.vmethod_37());
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)167:
			{
				object obj = Class5.Class14.object_2;
				lock (obj)
				{
					object obj2 = this.class30_0.method_4().vmethod_4(null);
					Class5.Class16 class4 = null;
					if (Class5.Class14.dictionary_1.TryGetValue(obj2, out class4))
					{
						this.class30_0.method_2(class4);
					}
					else
					{
						this.class30_0.method_2(new Class5.Class28(null));
					}
				}
				return;
			}
			case (Class5.Enum3)168:
			{
				int num = (int)this.object_0;
				FieldInfo fieldInfo = typeof(Class5).Module.ResolveField(num);
				this.class30_0.method_2(new Class5.Class25(fieldInfo, null));
				return;
			}
			case (Class5.Enum3)169:
			{
				Class5.Class17 @class = this.class30_0.method_4() as Class5.Class17;
				Class5.Class17 class2 = this.class30_0.method_4() as Class5.Class17;
				IntPtr intPtr = Class5.Class14.smethod_8(this.class30_0.method_4());
				if (intPtr != IntPtr.Zero)
				{
					byte byte_ = class2.vmethod_16().struct2_0.byte_0;
					uint num2 = @class.vmethod_20().struct2_0.uint_0;
					Class5.Class14.smethod_10(intPtr, byte_, (int)num2);
				}
				return;
			}
			case (Class5.Enum3)170:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (@class != null && class2 != null)
				{
					this.class30_0.method_2(@class.vmethod_70(class2));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)171:
			{
				Class5.Class17 @class = Class5.Class14.smethod_1(this.class30_0.method_4());
				Class5.Class17 class2 = Class5.Class14.smethod_1(this.class30_0.method_4());
				if (class2 != null && @class != null)
				{
					this.class30_0.method_2(class2.vmethod_57(@class));
					return;
				}
				throw new Class5.Exception1();
			}
			case (Class5.Enum3)172:
				this.int_0 = (int)this.object_0 - 1;
				return;
			case (Class5.Enum3)173:
				this.class30_0.method_2(new Class5.Class26((int)this.object_0, this));
				return;
			case (Class5.Enum3)174:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				Class5.Class17 @class = Class5.Class14.smethod_1(class4);
				Class5.Class16 class16_ = this.class30_0.method_4();
				Class5.Class17 class2 = Class5.Class14.smethod_1(class16_);
				if (class2 != null && @class != null)
				{
					if (class2.vmethod_81(class4))
					{
						this.int_0 = (int)this.object_0 - 1;
					}
					return;
				}
				if (class4.vmethod_6(class16_))
				{
					this.int_0 = (int)this.object_0 - 1;
				}
				return;
			}
			case (Class5.Enum3)175:
			{
				Class5.Class16 class4 = this.class30_0.method_4();
				if (Class5.Class14.smethod_1(this.class30_0.method_4()).vmethod_84(class4))
				{
					this.int_0 = (int)this.object_0 - 1;
				}
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x000289B0 File Offset: 0x00026BB0
		private Class5.Class16 method_8(Class5.Class16 class16_3, Class5.Enum1 enum1_0, bool bool_4 = false)
		{
			if (!bool_4 && class16_3.vmethod_0())
			{
				class16_3 = class16_3.vmethod_8();
			}
			if (class16_3.method_1())
			{
				return ((Class5.Class18)class16_3).vmethod_13(enum1_0);
			}
			if (class16_3.method_3())
			{
				return ((Class5.Class19)class16_3).vmethod_13(enum1_0);
			}
			if (class16_3.method_4())
			{
				return ((Class5.Class21)class16_3).vmethod_13(enum1_0);
			}
			if (class16_3.method_2())
			{
				return ((Class5.Class20)class16_3).vmethod_13(enum1_0);
			}
			return class16_3;
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x00003B92 File Offset: 0x00001D92
		private Class5.Class16 method_9(int int_3)
		{
			return this.class16_1[int_3];
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x00028A28 File Offset: 0x00026C28
		private void method_10(int int_3)
		{
			this.method_11(int_3, this.class30_0.method_4());
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x00028A48 File Offset: 0x00026C48
		private static int smethod_0(Type type_0)
		{
			object obj = Class5.Class14.object_1;
			int result;
			lock (obj)
			{
				if (Class5.Class14.dictionary_0 == null)
				{
					Class5.Class14.dictionary_0 = new Dictionary<Type, int>();
				}
				try
				{
					int num = 0;
					if (!Class5.Class14.dictionary_0.TryGetValue(type_0, out num))
					{
						DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(int), Type.EmptyTypes, true);
						ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
						ilgenerator.Emit(OpCodes.Sizeof, type_0);
						ilgenerator.Emit(OpCodes.Ret);
						num = (int)dynamicMethod.Invoke(null, null);
						Class5.Class14.dictionary_0[type_0] = num;
						result = num;
					}
					else
					{
						result = num;
					}
				}
				catch
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x00028B1C File Offset: 0x00026D1C
		private void method_11(int int_3, Class5.Class16 class16_3)
		{
			this.class16_1[int_3] = this.method_8(class16_3, this.class11_0.list_1[int_3].enum1_0, this.class11_0.list_1[int_3].bool_0);
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x00028B64 File Offset: 0x00026D64
		private static Class5.Class17 smethod_1(Class5.Class16 class16_3)
		{
			Class5.Class17 @class = class16_3 as Class5.Class17;
			if (@class == null && class16_3.vmethod_0())
			{
				@class = (class16_3.vmethod_8() as Class5.Class17);
			}
			return @class;
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x00028B94 File Offset: 0x00026D94
		private void method_12(bool bool_4)
		{
			int metadataToken = (int)this.object_0;
			MethodBase methodBase = typeof(Class5).Module.ResolveMethod(metadataToken);
			MethodInfo methodInfo = methodBase as MethodInfo;
			ParameterInfo[] parameters = methodBase.GetParameters();
			object[] array = new object[parameters.Length];
			Class5.Class16[] array2 = new Class5.Class16[parameters.Length];
			List<Class5.Class12> list = null;
			Class5.Class13 @class = null;
			for (int i = 0; i < parameters.Length; i++)
			{
				Class5.Class16 class2 = this.class30_0.method_4();
				Type type = parameters[parameters.Length - 1 - i].ParameterType;
				object obj = null;
				bool flag = false;
				if (type.IsByRef)
				{
					Class5.Class25 class3 = class2 as Class5.Class25;
					if (class3 != null)
					{
						if (list == null)
						{
							list = new List<Class5.Class12>();
						}
						list.Add(new Class5.Class12(class3.fieldInfo_0, parameters.Length - 1 - i));
						obj = class3.object_0;
						if (!(obj is Class5.Class16))
						{
							flag = true;
							if (obj == null)
							{
								if (type.IsByRef)
								{
									type = type.GetElementType();
								}
								if (type.IsValueType)
								{
									if (!class3.fieldInfo_0.IsStatic)
									{
										obj = Activator.CreateInstance(type);
									}
									else
									{
										obj = class3.fieldInfo_0.GetValue(null);
									}
									if (class2 is Class5.Class23)
									{
										((Class5.Class22)class2).vmethod_12(Class5.Class16.smethod_1(type, obj));
									}
								}
							}
						}
						else
						{
							class2 = (obj as Class5.Class16);
						}
					}
				}
				if (!flag)
				{
					if (class2 != null)
					{
						obj = class2.vmethod_4(type);
					}
					if (obj == null)
					{
						if (type.IsByRef)
						{
							type = type.GetElementType();
						}
						if (type.IsValueType)
						{
							obj = Activator.CreateInstance(type);
							if (class2 is Class5.Class23)
							{
								((Class5.Class22)class2).vmethod_12(Class5.Class16.smethod_1(type, obj));
							}
						}
					}
				}
				array2[array.Length - 1 - i] = class2;
				array[array.Length - 1 - i] = obj;
			}
			Class5.Delegate9 @delegate = null;
			if (list == null)
			{
				if (methodInfo != null && methodInfo.ReturnType.IsByRef)
				{
					@delegate = Class5.Class14.smethod_2(methodBase, bool_4);
				}
			}
			else
			{
				@class = new Class5.Class13(methodBase, list);
				@delegate = Class5.Class14.smethod_3(methodBase, bool_4, @class);
			}
			object obj2 = null;
			Class5.Class16 class4 = null;
			if (!methodBase.IsStatic)
			{
				class4 = this.class30_0.method_4();
				if (class4 != null)
				{
					obj2 = class4.vmethod_4(methodBase.DeclaringType);
				}
				if (obj2 == null)
				{
					Type type2 = methodBase.DeclaringType;
					if (type2.IsByRef)
					{
						type2 = type2.GetElementType();
					}
					if (!type2.IsValueType)
					{
						throw new NullReferenceException();
					}
					obj2 = Activator.CreateInstance(type2);
					if (obj2 == null && Nullable.GetUnderlyingType(type2) != null)
					{
						obj2 = FormatterServices.GetUninitializedObject(type2);
					}
					if (class4 is Class5.Class23)
					{
						((Class5.Class22)class4).vmethod_12(Class5.Class16.smethod_1(type2, obj2));
					}
				}
			}
			object obj3;
			if (methodBase is ConstructorInfo && Nullable.GetUnderlyingType(methodBase.DeclaringType) != null)
			{
				obj3 = array[0];
				if (class4 != null && class4 is Class5.Class23)
				{
					((Class5.Class22)class4).vmethod_12(Class5.Class16.smethod_1(Nullable.GetUnderlyingType(methodBase.DeclaringType), obj3));
				}
			}
			else if (@delegate == null)
			{
				obj3 = methodBase.Invoke(obj2, array);
			}
			else
			{
				obj3 = @delegate(obj2, array);
			}
			for (int j = 0; j < parameters.Length; j++)
			{
				if (parameters[j].ParameterType.IsByRef && (@class == null || !@class.method_1(j)))
				{
					if (!array2[j].method_2())
					{
						if (!(array2[j] is Class5.Class23))
						{
							array2[j].vmethod_10(Class5.Class16.smethod_1(parameters[j].ParameterType, array[j]));
						}
						else
						{
							array2[j].vmethod_10(Class5.Class16.smethod_1(parameters[j].ParameterType.GetElementType(), array[j]));
						}
					}
					else
					{
						((Class5.Class20)array2[j]).method_6(Class5.Class16.smethod_1(parameters[j].ParameterType, array[j]));
					}
				}
			}
			if (methodInfo != null && methodInfo.ReturnType != typeof(void))
			{
				this.class30_0.method_2(Class5.Class16.smethod_1(methodInfo.ReturnType, obj3));
			}
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x00028FC4 File Offset: 0x000271C4
		private static Class5.Delegate9 smethod_2(object object_7, bool bool_4)
		{
			object obj = Class5.Class14.object_3;
			Class5.Delegate9 result2;
			lock (obj)
			{
				Class5.Delegate9 result = null;
				if (!bool_4)
				{
					if (Class5.Class14.dictionary_3.TryGetValue(object_7, out result))
					{
						return result;
					}
				}
				else if (Class5.Class14.dictionary_2.TryGetValue(object_7, out result))
				{
					return result;
				}
				MethodInfo methodInfo = object_7 as MethodInfo;
				DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[]
				{
					typeof(object),
					typeof(object[])
				}, true);
				ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
				ParameterInfo[] parameters = object_7.GetParameters();
				Type[] array = new Type[parameters.Length];
				for (int i = 0; i < array.Length; i++)
				{
					if (parameters[i].ParameterType.IsByRef)
					{
						array[i] = parameters[i].ParameterType.GetElementType();
					}
					else
					{
						array[i] = parameters[i].ParameterType;
					}
				}
				int num = array.Length;
				if (object_7.DeclaringType.IsValueType)
				{
					num++;
				}
				LocalBuilder[] array2 = new LocalBuilder[num];
				for (int j = 0; j < array.Length; j++)
				{
					array2[j] = ilgenerator.DeclareLocal(array[j]);
				}
				if (object_7.DeclaringType.IsValueType)
				{
					array2[array2.Length - 1] = ilgenerator.DeclareLocal(object_7.DeclaringType.MakeByRefType());
				}
				for (int k = 0; k < array.Length; k++)
				{
					ilgenerator.Emit(OpCodes.Ldarg_1);
					Class5.Class14.smethod_5(ilgenerator, k);
					ilgenerator.Emit(OpCodes.Ldelem_Ref);
					if (array[k].IsValueType)
					{
						ilgenerator.Emit(OpCodes.Unbox_Any, array[k]);
					}
					else if (array[k] != typeof(object))
					{
						ilgenerator.Emit(OpCodes.Castclass, array[k]);
					}
					ilgenerator.Emit(OpCodes.Stloc, array2[k]);
				}
				if (!object_7.IsStatic)
				{
					ilgenerator.Emit(OpCodes.Ldarg_0);
					if (!object_7.DeclaringType.IsValueType)
					{
						ilgenerator.Emit(OpCodes.Castclass, object_7.DeclaringType);
					}
					else
					{
						ilgenerator.Emit(OpCodes.Unbox, object_7.DeclaringType);
						ilgenerator.Emit(OpCodes.Stloc, array2[array2.Length - 1]);
						ilgenerator.Emit(OpCodes.Ldloc_S, array2[array2.Length - 1]);
					}
				}
				for (int l = 0; l < array.Length; l++)
				{
					if (parameters[l].ParameterType.IsByRef)
					{
						ilgenerator.Emit(OpCodes.Ldloca_S, array2[l]);
					}
					else
					{
						ilgenerator.Emit(OpCodes.Ldloc, array2[l]);
					}
				}
				if (bool_4)
				{
					if (methodInfo != null)
					{
						ilgenerator.EmitCall(OpCodes.Call, methodInfo, null);
					}
					else
					{
						ilgenerator.Emit(OpCodes.Call, object_7 as ConstructorInfo);
					}
				}
				else if (!(methodInfo != null))
				{
					ilgenerator.Emit(OpCodes.Callvirt, object_7 as ConstructorInfo);
				}
				else
				{
					ilgenerator.EmitCall(OpCodes.Callvirt, methodInfo, null);
				}
				if (!(methodInfo == null) && !(methodInfo.ReturnType == typeof(void)))
				{
					if (methodInfo.ReturnType.IsByRef)
					{
						Type elementType = methodInfo.ReturnType.GetElementType();
						if (!elementType.IsValueType)
						{
							ilgenerator.Emit(OpCodes.Ldind_Ref, elementType);
						}
						else
						{
							ilgenerator.Emit(OpCodes.Ldobj, elementType);
						}
						if (elementType.IsValueType)
						{
							ilgenerator.Emit(OpCodes.Box, elementType);
						}
					}
					else if (methodInfo.ReturnType.IsValueType)
					{
						ilgenerator.Emit(OpCodes.Box, methodInfo.ReturnType);
					}
				}
				else
				{
					ilgenerator.Emit(OpCodes.Ldnull);
				}
				for (int m = 0; m < array.Length; m++)
				{
					if (parameters[m].ParameterType.IsByRef)
					{
						ilgenerator.Emit(OpCodes.Ldarg_1);
						Class5.Class14.smethod_5(ilgenerator, m);
						ilgenerator.Emit(OpCodes.Ldloc, array2[m]);
						if (array2[m].LocalType.IsValueType)
						{
							ilgenerator.Emit(OpCodes.Box, array2[m].LocalType);
						}
						ilgenerator.Emit(OpCodes.Stelem_Ref);
					}
				}
				ilgenerator.Emit(OpCodes.Ret);
				Class5.Delegate9 @delegate = (Class5.Delegate9)dynamicMethod.CreateDelegate(typeof(Class5.Delegate9));
				if (bool_4)
				{
					Class5.Class14.dictionary_2.Add(object_7, @delegate);
				}
				else
				{
					Class5.Class14.dictionary_3.Add(object_7, @delegate);
				}
				result2 = @delegate;
			}
			return result2;
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00029474 File Offset: 0x00027674
		private static Class5.Delegate9 smethod_3(object object_7, bool bool_4, Class5.Class13 class13_0)
		{
			object obj = Class5.Class14.object_4;
			Class5.Delegate9 result2;
			lock (obj)
			{
				Class5.Delegate9 result = null;
				if (bool_4)
				{
					if (Class5.Class14.dictionary_4.TryGetValue(class13_0, out result))
					{
						return result;
					}
				}
				else if (Class5.Class14.dictionary_5.TryGetValue(class13_0, out result))
				{
					return result;
				}
				MethodInfo methodInfo = object_7 as MethodInfo;
				DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[]
				{
					typeof(object),
					typeof(object[])
				}, typeof(Class5), true);
				ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
				ParameterInfo[] parameters = object_7.GetParameters();
				Type[] array = new Type[parameters.Length];
				for (int i = 0; i < array.Length; i++)
				{
					if (!parameters[i].ParameterType.IsByRef)
					{
						array[i] = parameters[i].ParameterType;
					}
					else
					{
						array[i] = parameters[i].ParameterType.GetElementType();
					}
				}
				int num = array.Length;
				if (object_7.DeclaringType.IsValueType)
				{
					num++;
				}
				LocalBuilder[] array2 = new LocalBuilder[num];
				for (int j = 0; j < array.Length; j++)
				{
					if (!class13_0.method_1(j))
					{
						array2[j] = ilgenerator.DeclareLocal(array[j]);
					}
					else
					{
						array2[j] = ilgenerator.DeclareLocal(typeof(object));
					}
				}
				if (object_7.DeclaringType.IsValueType)
				{
					array2[array2.Length - 1] = ilgenerator.DeclareLocal(object_7.DeclaringType.MakeByRefType());
				}
				for (int k = 0; k < array.Length; k++)
				{
					ilgenerator.Emit(OpCodes.Ldarg_1);
					Class5.Class14.smethod_5(ilgenerator, k);
					ilgenerator.Emit(OpCodes.Ldelem_Ref);
					if (!class13_0.method_1(k))
					{
						if (!array[k].IsValueType)
						{
							if (array[k] != typeof(object))
							{
								ilgenerator.Emit(OpCodes.Castclass, array[k]);
							}
						}
						else
						{
							ilgenerator.Emit(OpCodes.Unbox_Any, array[k]);
						}
					}
					ilgenerator.Emit(OpCodes.Stloc, array2[k]);
				}
				if (!object_7.IsStatic)
				{
					ilgenerator.Emit(OpCodes.Ldarg_0);
					if (object_7.DeclaringType.IsValueType)
					{
						ilgenerator.Emit(OpCodes.Unbox, object_7.DeclaringType);
						ilgenerator.Emit(OpCodes.Stloc, array2[array2.Length - 1]);
						ilgenerator.Emit(OpCodes.Ldloc_S, array2[array2.Length - 1]);
					}
					else
					{
						ilgenerator.Emit(OpCodes.Castclass, object_7.DeclaringType);
					}
				}
				for (int l = 0; l < array.Length; l++)
				{
					if (class13_0.method_1(l))
					{
						Class5.Class12 @class = class13_0.method_0(l);
						if (!@class.fieldInfo_0.IsStatic)
						{
							if (!@class.fieldInfo_0.DeclaringType.IsValueType)
							{
								ilgenerator.Emit(OpCodes.Ldloc, array2[l]);
								ilgenerator.Emit(OpCodes.Castclass, @class.fieldInfo_0.DeclaringType);
								ilgenerator.Emit(OpCodes.Ldflda, @class.fieldInfo_0);
							}
							else
							{
								ilgenerator.Emit(OpCodes.Ldloc, array2[l]);
								ilgenerator.Emit(OpCodes.Unbox, @class.fieldInfo_0.DeclaringType);
								ilgenerator.Emit(OpCodes.Ldflda, @class.fieldInfo_0);
							}
						}
						else
						{
							ilgenerator.Emit(OpCodes.Ldsflda, @class.fieldInfo_0);
						}
					}
					else if (parameters[l].ParameterType.IsByRef)
					{
						ilgenerator.Emit(OpCodes.Ldloca_S, array2[l]);
					}
					else
					{
						ilgenerator.Emit(OpCodes.Ldloc, array2[l]);
					}
				}
				if (bool_4)
				{
					if (!(methodInfo != null))
					{
						ilgenerator.Emit(OpCodes.Call, object_7 as ConstructorInfo);
					}
					else
					{
						ilgenerator.EmitCall(OpCodes.Call, methodInfo, null);
					}
				}
				else if (!(methodInfo != null))
				{
					ilgenerator.Emit(OpCodes.Callvirt, object_7 as ConstructorInfo);
				}
				else
				{
					ilgenerator.EmitCall(OpCodes.Callvirt, methodInfo, null);
				}
				if (!(methodInfo == null) && !(methodInfo.ReturnType == typeof(void)))
				{
					if (!methodInfo.ReturnType.IsByRef)
					{
						if (methodInfo.ReturnType.IsValueType)
						{
							ilgenerator.Emit(OpCodes.Box, methodInfo.ReturnType);
						}
					}
					else
					{
						Type elementType = methodInfo.ReturnType.GetElementType();
						if (!elementType.IsValueType)
						{
							ilgenerator.Emit(OpCodes.Ldind_Ref, elementType);
						}
						else
						{
							ilgenerator.Emit(OpCodes.Ldobj, elementType);
						}
						if (elementType.IsValueType)
						{
							ilgenerator.Emit(OpCodes.Box, elementType);
						}
					}
				}
				else
				{
					ilgenerator.Emit(OpCodes.Ldnull);
				}
				for (int m = 0; m < array.Length; m++)
				{
					if (parameters[m].ParameterType.IsByRef)
					{
						if (!class13_0.method_1(m))
						{
							ilgenerator.Emit(OpCodes.Ldarg_1);
							Class5.Class14.smethod_5(ilgenerator, m);
							ilgenerator.Emit(OpCodes.Ldloc, array2[m]);
							if (array2[m].LocalType.IsValueType)
							{
								ilgenerator.Emit(OpCodes.Box, array2[m].LocalType);
							}
							ilgenerator.Emit(OpCodes.Stelem_Ref);
						}
						else
						{
							Class5.Class12 class2 = class13_0.method_0(m);
							if (!class2.fieldInfo_0.IsStatic)
							{
								ilgenerator.Emit(OpCodes.Ldarg_1);
								Class5.Class14.smethod_5(ilgenerator, m);
								ilgenerator.Emit(OpCodes.Ldloc, array2[m]);
								if (array2[m].LocalType.IsValueType)
								{
									ilgenerator.Emit(OpCodes.Box, class2.fieldInfo_0.FieldType);
								}
								ilgenerator.Emit(OpCodes.Stelem_Ref);
							}
							else
							{
								ilgenerator.Emit(OpCodes.Ldarg_1);
								Class5.Class14.smethod_5(ilgenerator, m);
								ilgenerator.Emit(OpCodes.Ldsfld, class2.fieldInfo_0);
								if (class2.fieldInfo_0.FieldType.IsValueType)
								{
									ilgenerator.Emit(OpCodes.Box, class2.fieldInfo_0.FieldType);
								}
								ilgenerator.Emit(OpCodes.Stelem_Ref);
							}
						}
					}
				}
				ilgenerator.Emit(OpCodes.Ret);
				Class5.Delegate9 @delegate = (Class5.Delegate9)dynamicMethod.CreateDelegate(typeof(Class5.Delegate9));
				if (!bool_4)
				{
					Class5.Class14.dictionary_5.Add(class13_0, @delegate);
				}
				else
				{
					Class5.Class14.dictionary_4.Add(class13_0, @delegate);
				}
				result2 = @delegate;
			}
			return result2;
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x00029B1C File Offset: 0x00027D1C
		private static Class5.Delegate9 smethod_4(object object_7, bool bool_4, Class5.Class13 class13_0)
		{
			object obj = Class5.Class14.object_5;
			Class5.Delegate9 result;
			lock (obj)
			{
				Class5.Delegate9 @delegate = null;
				if (Class5.Class14.dictionary_6.TryGetValue(class13_0, out @delegate))
				{
					result = @delegate;
				}
				else
				{
					ConstructorInfo constructorInfo = object_7 as ConstructorInfo;
					DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[]
					{
						typeof(object),
						typeof(object[])
					}, typeof(Class5), true);
					ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
					ParameterInfo[] parameters = object_7.GetParameters();
					Type[] array = new Type[parameters.Length];
					for (int i = 0; i < array.Length; i++)
					{
						if (!parameters[i].ParameterType.IsByRef)
						{
							array[i] = parameters[i].ParameterType;
						}
						else
						{
							array[i] = parameters[i].ParameterType.GetElementType();
						}
					}
					int num = array.Length;
					if (object_7.DeclaringType.IsValueType)
					{
						num++;
					}
					LocalBuilder[] array2 = new LocalBuilder[num];
					for (int j = 0; j < array.Length; j++)
					{
						if (class13_0.method_1(j))
						{
							array2[j] = ilgenerator.DeclareLocal(typeof(object));
						}
						else
						{
							array2[j] = ilgenerator.DeclareLocal(array[j]);
						}
					}
					if (object_7.DeclaringType.IsValueType)
					{
						array2[array2.Length - 1] = ilgenerator.DeclareLocal(object_7.DeclaringType.MakeByRefType());
					}
					for (int k = 0; k < array.Length; k++)
					{
						ilgenerator.Emit(OpCodes.Ldarg_1);
						Class5.Class14.smethod_5(ilgenerator, k);
						ilgenerator.Emit(OpCodes.Ldelem_Ref);
						if (!class13_0.method_1(k))
						{
							if (array[k].IsValueType)
							{
								ilgenerator.Emit(OpCodes.Unbox_Any, array[k]);
							}
							else if (array[k] != typeof(object))
							{
								ilgenerator.Emit(OpCodes.Castclass, array[k]);
							}
						}
						ilgenerator.Emit(OpCodes.Stloc, array2[k]);
					}
					for (int l = 0; l < array.Length; l++)
					{
						if (class13_0.method_1(l))
						{
							Class5.Class12 @class = class13_0.method_0(l);
							if (@class.fieldInfo_0.IsStatic)
							{
								ilgenerator.Emit(OpCodes.Ldsflda, @class.fieldInfo_0);
							}
							else if (!@class.fieldInfo_0.DeclaringType.IsValueType)
							{
								ilgenerator.Emit(OpCodes.Ldloc, array2[l]);
								ilgenerator.Emit(OpCodes.Castclass, @class.fieldInfo_0.DeclaringType);
								ilgenerator.Emit(OpCodes.Ldflda, @class.fieldInfo_0);
							}
							else
							{
								ilgenerator.Emit(OpCodes.Ldloc, array2[l]);
								ilgenerator.Emit(OpCodes.Unbox, @class.fieldInfo_0.DeclaringType);
								ilgenerator.Emit(OpCodes.Ldflda, @class.fieldInfo_0);
							}
						}
						else if (parameters[l].ParameterType.IsByRef)
						{
							ilgenerator.Emit(OpCodes.Ldloca_S, array2[l]);
						}
						else
						{
							ilgenerator.Emit(OpCodes.Ldloc, array2[l]);
						}
					}
					ilgenerator.Emit(OpCodes.Newobj, object_7 as ConstructorInfo);
					if (constructorInfo.DeclaringType.IsValueType)
					{
						ilgenerator.Emit(OpCodes.Box, constructorInfo.DeclaringType);
					}
					for (int m = 0; m < array.Length; m++)
					{
						if (parameters[m].ParameterType.IsByRef)
						{
							if (class13_0.method_1(m))
							{
								Class5.Class12 class2 = class13_0.method_0(m);
								if (class2.fieldInfo_0.IsStatic)
								{
									ilgenerator.Emit(OpCodes.Ldarg_1);
									Class5.Class14.smethod_5(ilgenerator, m);
									ilgenerator.Emit(OpCodes.Ldsfld, class2.fieldInfo_0);
									if (class2.fieldInfo_0.FieldType.IsValueType)
									{
										ilgenerator.Emit(OpCodes.Box, array2[m].LocalType);
									}
									ilgenerator.Emit(OpCodes.Stelem_Ref);
								}
								else
								{
									ilgenerator.Emit(OpCodes.Ldarg_1);
									Class5.Class14.smethod_5(ilgenerator, m);
									ilgenerator.Emit(OpCodes.Ldloc, array2[m]);
									if (array2[m].LocalType.IsValueType)
									{
										ilgenerator.Emit(OpCodes.Box, array2[m].LocalType);
									}
									ilgenerator.Emit(OpCodes.Stelem_Ref);
								}
							}
							else
							{
								ilgenerator.Emit(OpCodes.Ldarg_1);
								Class5.Class14.smethod_5(ilgenerator, m);
								ilgenerator.Emit(OpCodes.Ldloc, array2[m]);
								if (array2[m].LocalType.IsValueType)
								{
									ilgenerator.Emit(OpCodes.Box, array2[m].LocalType);
								}
								ilgenerator.Emit(OpCodes.Stelem_Ref);
							}
						}
					}
					ilgenerator.Emit(OpCodes.Ret);
					Class5.Delegate9 delegate2 = (Class5.Delegate9)dynamicMethod.CreateDelegate(typeof(Class5.Delegate9));
					Class5.Class14.dictionary_6.Add(class13_0, delegate2);
					result = delegate2;
				}
			}
			return result;
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0002A048 File Offset: 0x00028248
		private static void smethod_5(ILGenerator ilgenerator_0, int int_3)
		{
			switch (int_3)
			{
			case -1:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_M1);
				return;
			case 0:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_0);
				return;
			case 1:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_1);
				return;
			case 2:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_2);
				return;
			case 3:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_3);
				return;
			case 4:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_4);
				return;
			case 5:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_5);
				return;
			case 6:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_6);
				return;
			case 7:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_7);
				return;
			case 8:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_8);
				return;
			default:
				if (int_3 > -129 && int_3 < 128)
				{
					ilgenerator_0.Emit(OpCodes.Ldc_I4_S, (sbyte)int_3);
					return;
				}
				ilgenerator_0.Emit(OpCodes.Ldc_I4, int_3);
				return;
			}
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0002A128 File Offset: 0x00028328
		private static Class5.Class16 smethod_6(Class5.Class16 class16_3)
		{
			if (class16_3.vmethod_8().method_0())
			{
				object obj = class16_3.vmethod_4(null);
				if (obj != null && obj.GetType().IsEnum)
				{
					Type underlyingType = Enum.GetUnderlyingType(obj.GetType());
					object obj2 = Convert.ChangeType(obj, underlyingType);
					Class5.Class16 @class = Class5.Class14.smethod_7(Class5.Class16.smethod_1(underlyingType, obj2));
					if (@class != null)
					{
						return @class as Class5.Class17;
					}
				}
			}
			return class16_3;
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x00020290 File Offset: 0x0001E490
		private static Class5.Class17 smethod_7(Class5.Class16 class16_3)
		{
			Class5.Class17 @class = class16_3 as Class5.Class17;
			if (@class == null && class16_3.vmethod_0())
			{
				@class = (class16_3.vmethod_8() as Class5.Class17);
			}
			return @class;
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0002A194 File Offset: 0x00028394
		private static IntPtr smethod_8(object object_7)
		{
			if (object_7 == null)
			{
				return IntPtr.Zero;
			}
			if (object_7.method_2())
			{
				return ((Class5.Class20)object_7).method_7();
			}
			if (object_7.vmethod_0())
			{
				Class5.Class22 @class = (Class5.Class22)object_7;
				IntPtr result;
				try
				{
					result = @class.vmethod_11();
				}
				catch
				{
					goto IL_38;
				}
				return result;
			}
			IL_38:
			object obj = object_7.vmethod_4(typeof(IntPtr));
			if (obj != null && obj.GetType() == typeof(IntPtr))
			{
				return (IntPtr)obj;
			}
			throw new Class5.Exception1();
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0002A22C File Offset: 0x0002842C
		private static object smethod_9(object object_7)
		{
			object obj = Class5.Class14.object_6;
			object result;
			lock (obj)
			{
				if (Class5.Class14.dictionary_7 == null)
				{
					Class5.Class14.dictionary_7 = new Dictionary<Type, Class5.Delegate10>();
				}
				if (object_7 != null)
				{
					try
					{
						Type type = object_7.GetType();
						Class5.Delegate10 @delegate;
						if (!Class5.Class14.dictionary_7.TryGetValue(type, out @delegate))
						{
							DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[]
							{
								typeof(object)
							}, true);
							ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
							ilgenerator.Emit(OpCodes.Ldarg_0);
							ilgenerator.Emit(OpCodes.Unbox_Any, type);
							ilgenerator.Emit(OpCodes.Box, type);
							ilgenerator.Emit(OpCodes.Ret);
							Class5.Delegate10 delegate2 = (Class5.Delegate10)dynamicMethod.CreateDelegate(typeof(Class5.Delegate10));
							Class5.Class14.dictionary_7.Add(type, delegate2);
							return delegate2(object_7);
						}
						return @delegate(object_7);
					}
					catch
					{
						return null;
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0002A350 File Offset: 0x00028550
		private static void smethod_10(IntPtr intptr_0, byte byte_0, int int_3)
		{
			object obj = Class5.Class14.object_6;
			lock (obj)
			{
				if (Class5.Class14.delegate11_0 == null)
				{
					DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(void), new Type[]
					{
						typeof(IntPtr),
						typeof(byte),
						typeof(int)
					}, typeof(Class5), true);
					ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
					ilgenerator.Emit(OpCodes.Ldarg_0);
					ilgenerator.Emit(OpCodes.Ldarg_1);
					ilgenerator.Emit(OpCodes.Ldarg_2);
					ilgenerator.Emit(OpCodes.Initblk);
					ilgenerator.Emit(OpCodes.Ret);
					Class5.Class14.delegate11_0 = (Class5.Delegate11)dynamicMethod.CreateDelegate(typeof(Class5.Delegate11));
				}
				Class5.Class14.delegate11_0(intptr_0, byte_0, int_3);
			}
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0002A448 File Offset: 0x00028648
		private static void smethod_11(IntPtr intptr_0, IntPtr intptr_1, uint uint_0)
		{
			if (Class5.Class14.delegate12_0 == null)
			{
				DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(void), new Type[]
				{
					typeof(IntPtr),
					typeof(IntPtr),
					typeof(uint)
				}, typeof(Class5), true);
				ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
				ilgenerator.Emit(OpCodes.Ldarg_0);
				ilgenerator.Emit(OpCodes.Ldarg_1);
				ilgenerator.Emit(OpCodes.Ldarg_2);
				ilgenerator.Emit(OpCodes.Cpblk);
				ilgenerator.Emit(OpCodes.Ret);
				Class5.Class14.delegate12_0 = (Class5.Delegate12)dynamicMethod.CreateDelegate(typeof(Class5.Delegate12));
			}
			Class5.Class14.delegate12_0(intptr_0, intptr_1, uint_0);
		}

		// Token: 0x040003C1 RID: 961
		internal Class5.Class11 class11_0;

		// Token: 0x040003C2 RID: 962
		internal Class5.Class16[] class16_0 = new Class5.Class16[0];

		// Token: 0x040003C3 RID: 963
		internal Class5.Class16[] class16_1 = new Class5.Class16[0];

		// Token: 0x040003C4 RID: 964
		internal Class5.Class30 class30_0 = new Class5.Class30();

		// Token: 0x040003C5 RID: 965
		internal Class5.Class16 class16_2;

		// Token: 0x040003C6 RID: 966
		internal Exception exception_0;

		// Token: 0x040003C7 RID: 967
		internal List<IntPtr> list_0;

		// Token: 0x040003C8 RID: 968
		private int int_0;

		// Token: 0x040003C9 RID: 969
		private int int_1;

		// Token: 0x040003CA RID: 970
		private int int_2 = -1;

		// Token: 0x040003CB RID: 971
		private object object_0;

		// Token: 0x040003CC RID: 972
		private bool bool_0;

		// Token: 0x040003CD RID: 973
		private bool bool_1;

		// Token: 0x040003CE RID: 974
		private bool bool_2;

		// Token: 0x040003CF RID: 975
		private bool bool_3;

		// Token: 0x040003D0 RID: 976
		private static Dictionary<Type, int> dictionary_0;

		// Token: 0x040003D1 RID: 977
		private static object object_1 = new object();

		// Token: 0x040003D2 RID: 978
		private static Dictionary<object, Class5.Class16> dictionary_1 = new Dictionary<object, Class5.Class16>();

		// Token: 0x040003D3 RID: 979
		private static object object_2 = new object();

		// Token: 0x040003D4 RID: 980
		private static Dictionary<MethodBase, Class5.Delegate9> dictionary_2 = new Dictionary<MethodBase, Class5.Delegate9>();

		// Token: 0x040003D5 RID: 981
		private static Dictionary<MethodBase, Class5.Delegate9> dictionary_3 = new Dictionary<MethodBase, Class5.Delegate9>();

		// Token: 0x040003D6 RID: 982
		private static object object_3 = new object();

		// Token: 0x040003D7 RID: 983
		private static Dictionary<Class5.Class13, Class5.Delegate9> dictionary_4 = new Dictionary<Class5.Class13, Class5.Delegate9>();

		// Token: 0x040003D8 RID: 984
		private static Dictionary<Class5.Class13, Class5.Delegate9> dictionary_5 = new Dictionary<Class5.Class13, Class5.Delegate9>();

		// Token: 0x040003D9 RID: 985
		private static object object_4 = new object();

		// Token: 0x040003DA RID: 986
		private static Dictionary<Class5.Class13, Class5.Delegate9> dictionary_6 = new Dictionary<Class5.Class13, Class5.Delegate9>();

		// Token: 0x040003DB RID: 987
		private static object object_5 = new object();

		// Token: 0x040003DC RID: 988
		private static Dictionary<Type, Class5.Delegate10> dictionary_7;

		// Token: 0x040003DD RID: 989
		private static object object_6 = new object();

		// Token: 0x040003DE RID: 990
		private static Class5.Delegate11 delegate11_0;

		// Token: 0x040003DF RID: 991
		private static Class5.Delegate12 delegate12_0;

		// Token: 0x020000B6 RID: 182
		[CompilerGenerated]
		[Serializable]
		private sealed class Class15
		{
			// Token: 0x0600057F RID: 1407 RVA: 0x00003B9C File Offset: 0x00001D9C
			internal int method_0(Class5.Class9 x, Class5.Class9 y)
			{
				return x.class10_0.int_0.CompareTo(y.class10_0.int_0);
			}

			// Token: 0x040003E0 RID: 992
			public static readonly Class5.Class14.Class15 <>9 = new Class5.Class14.Class15();

			// Token: 0x040003E1 RID: 993
			public static Comparison<Class5.Class9> <>9__12_0;
		}
	}

	// Token: 0x020000B7 RID: 183
	internal enum Enum3 : byte
	{

	}

	// Token: 0x020000B8 RID: 184
	internal enum Enum4 : byte
	{

	}

	// Token: 0x020000B9 RID: 185
	internal abstract class Class16
	{
		// Token: 0x06000580 RID: 1408 RVA: 0x00003D74 File Offset: 0x00001F74
		public Class16()
		{
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x00003BB9 File Offset: 0x00001DB9
		internal bool method_0()
		{
			return this.enum4_0 == (Class5.Enum4)0;
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x00003BC4 File Offset: 0x00001DC4
		internal bool method_1()
		{
			return this.enum4_0 == (Class5.Enum4)1;
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0002A5F0 File Offset: 0x000287F0
		internal bool method_2()
		{
			return this.enum4_0 == (Class5.Enum4)3 || this.enum4_0 == (Class5.Enum4)4;
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00003BCF File Offset: 0x00001DCF
		internal bool method_3()
		{
			return this.enum4_0 == (Class5.Enum4)2;
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00003BDA File Offset: 0x00001DDA
		internal bool method_4()
		{
			return this.enum4_0 == (Class5.Enum4)5;
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x00003BE5 File Offset: 0x00001DE5
		internal bool method_5()
		{
			return this.enum4_0 == (Class5.Enum4)6;
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00003BF0 File Offset: 0x00001DF0
		internal virtual bool vmethod_0()
		{
			return false;
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00003BF0 File Offset: 0x00001DF0
		internal virtual bool vmethod_1()
		{
			return false;
		}

		// Token: 0x06000589 RID: 1417
		internal abstract void vmethod_2(Class5.Class16 class16_0);

		// Token: 0x0600058A RID: 1418 RVA: 0x00003BF0 File Offset: 0x00001DF0
		internal virtual bool vmethod_3()
		{
			return false;
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x0002A614 File Offset: 0x00028814
		internal Class16(Class5.Enum4 enum4_1)
		{
			this.enum4_0 = enum4_1;
		}

		// Token: 0x0600058C RID: 1420
		internal abstract object vmethod_4(Type type_0);

		// Token: 0x0600058D RID: 1421
		internal abstract bool vmethod_5(Class5.Class16 class16_0);

		// Token: 0x0600058E RID: 1422
		internal abstract bool vmethod_6(Class5.Class16 class16_0);

		// Token: 0x0600058F RID: 1423
		internal abstract bool vmethod_7();

		// Token: 0x06000590 RID: 1424
		internal abstract Class5.Class16 vmethod_8();

		// Token: 0x06000591 RID: 1425 RVA: 0x00003BF0 File Offset: 0x00001DF0
		internal virtual bool vmethod_9()
		{
			return false;
		}

		// Token: 0x06000592 RID: 1426
		internal abstract void vmethod_10(Class5.Class16 class16_0);

		// Token: 0x06000593 RID: 1427 RVA: 0x0002A630 File Offset: 0x00028830
		internal static Class5.Enum2 smethod_0(Type type_0)
		{
			Type type = type_0;
			if (!(type != null))
			{
				return (Class5.Enum2)18;
			}
			if (type.IsByRef)
			{
				type = type.GetElementType();
			}
			if (type != null && Nullable.GetUnderlyingType(type) != null)
			{
				type = Nullable.GetUnderlyingType(type);
			}
			if (type == typeof(string))
			{
				return (Class5.Enum2)14;
			}
			if (type == typeof(byte))
			{
				return (Class5.Enum2)2;
			}
			if (type == typeof(sbyte))
			{
				return (Class5.Enum2)1;
			}
			if (type == typeof(short))
			{
				return (Class5.Enum2)3;
			}
			if (type == typeof(ushort))
			{
				return (Class5.Enum2)4;
			}
			if (type == typeof(int))
			{
				return (Class5.Enum2)5;
			}
			if (type == typeof(uint))
			{
				return (Class5.Enum2)6;
			}
			if (type == typeof(long))
			{
				return (Class5.Enum2)7;
			}
			if (type == typeof(ulong))
			{
				return (Class5.Enum2)8;
			}
			if (type == typeof(float))
			{
				return (Class5.Enum2)9;
			}
			if (type == typeof(double))
			{
				return (Class5.Enum2)10;
			}
			if (type == typeof(bool))
			{
				return (Class5.Enum2)11;
			}
			if (type == typeof(IntPtr))
			{
				return (Class5.Enum2)12;
			}
			if (type == typeof(UIntPtr))
			{
				return (Class5.Enum2)13;
			}
			if (type == typeof(char))
			{
				return (Class5.Enum2)15;
			}
			if (type == typeof(object))
			{
				return (Class5.Enum2)0;
			}
			if (!type.IsEnum)
			{
				return (Class5.Enum2)17;
			}
			return (Class5.Enum2)16;
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x0002A7F8 File Offset: 0x000289F8
		internal static Class5.Class16 smethod_1(Type type_0, object object_0)
		{
			Class5.Enum2 @enum = Class5.Class16.smethod_0(type_0);
			Class5.Enum2 enum2 = (Class5.Enum2)18;
			if (object_0 != null)
			{
				enum2 = Class5.Class16.smethod_0(object_0.GetType());
			}
			Class5.Class16 @class = null;
			switch (@enum)
			{
			case (Class5.Enum2)0:
				if (enum2 == (Class5.Enum2)15)
				{
					@class = new Class5.Class28(object_0);
				}
				else
				{
					@class = Class5.Class16.smethod_2(object_0);
				}
				break;
			case (Class5.Enum2)1:
				if (enum2 <= (Class5.Enum2)2)
				{
					if (enum2 == (Class5.Enum2)1)
					{
						@class = new Class5.Class18((int)((sbyte)object_0), (Class5.Enum1)1);
						break;
					}
					if (enum2 == (Class5.Enum2)2)
					{
						@class = new Class5.Class18((int)((sbyte)((byte)object_0)), (Class5.Enum1)1);
						break;
					}
				}
				else if (enum2 != (Class5.Enum2)11)
				{
					if (enum2 == (Class5.Enum2)15)
					{
						@class = new Class5.Class18((int)((sbyte)((char)object_0)), (Class5.Enum1)1);
						break;
					}
				}
				else
				{
					if ((bool)object_0)
					{
						@class = new Class5.Class18(1, (Class5.Enum1)1);
						break;
					}
					@class = new Class5.Class18(0, (Class5.Enum1)1);
					break;
				}
				throw new InvalidCastException();
			case (Class5.Enum2)2:
				if (enum2 <= (Class5.Enum2)2)
				{
					if (enum2 == (Class5.Enum2)1)
					{
						@class = new Class5.Class18((int)((byte)((sbyte)object_0)), (Class5.Enum1)2);
						break;
					}
					if (enum2 == (Class5.Enum2)2)
					{
						@class = new Class5.Class18((int)((byte)object_0), (Class5.Enum1)2);
						break;
					}
				}
				else if (enum2 != (Class5.Enum2)11)
				{
					if (enum2 == (Class5.Enum2)15)
					{
						@class = new Class5.Class18((int)((byte)((char)object_0)), (Class5.Enum1)2);
						break;
					}
				}
				else
				{
					if ((bool)object_0)
					{
						@class = new Class5.Class18(1, (Class5.Enum1)2);
						break;
					}
					@class = new Class5.Class18(0, (Class5.Enum1)2);
					break;
				}
				throw new InvalidCastException();
			case (Class5.Enum2)3:
				if (enum2 != (Class5.Enum2)3)
				{
					if (enum2 != (Class5.Enum2)11)
					{
						if (enum2 != (Class5.Enum2)15)
						{
							throw new InvalidCastException();
						}
						@class = new Class5.Class18((int)((short)((char)object_0)), (Class5.Enum1)3);
					}
					else if ((bool)object_0)
					{
						@class = new Class5.Class18(1, (Class5.Enum1)3);
					}
					else
					{
						@class = new Class5.Class18(0, (Class5.Enum1)3);
					}
				}
				else
				{
					@class = new Class5.Class18((int)((short)object_0), (Class5.Enum1)3);
				}
				break;
			case (Class5.Enum2)4:
				if (enum2 != (Class5.Enum2)4)
				{
					if (enum2 != (Class5.Enum2)11)
					{
						if (enum2 != (Class5.Enum2)15)
						{
							throw new InvalidCastException();
						}
						@class = new Class5.Class18((int)((char)object_0), (Class5.Enum1)4);
					}
					else if ((bool)object_0)
					{
						@class = new Class5.Class18(1, (Class5.Enum1)4);
					}
					else
					{
						@class = new Class5.Class18(0, (Class5.Enum1)4);
					}
				}
				else
				{
					@class = new Class5.Class18((int)((ushort)object_0), (Class5.Enum1)4);
				}
				break;
			case (Class5.Enum2)5:
				if (enum2 != (Class5.Enum2)5)
				{
					if (enum2 != (Class5.Enum2)11)
					{
						if (enum2 != (Class5.Enum2)15)
						{
							throw new InvalidCastException();
						}
						@class = new Class5.Class18((int)((char)object_0), (Class5.Enum1)5);
					}
					else if ((bool)object_0)
					{
						@class = new Class5.Class18(1, (Class5.Enum1)5);
					}
					else
					{
						@class = new Class5.Class18(0, (Class5.Enum1)5);
					}
				}
				else
				{
					@class = new Class5.Class18((int)object_0, (Class5.Enum1)5);
				}
				break;
			case (Class5.Enum2)6:
				if (enum2 != (Class5.Enum2)6)
				{
					if (enum2 != (Class5.Enum2)11)
					{
						if (enum2 != (Class5.Enum2)15)
						{
							throw new InvalidCastException();
						}
						@class = new Class5.Class18((uint)((char)object_0), (Class5.Enum1)6);
					}
					else if (!(bool)object_0)
					{
						@class = new Class5.Class18(0U, (Class5.Enum1)6);
					}
					else
					{
						@class = new Class5.Class18(1U, (Class5.Enum1)6);
					}
				}
				else
				{
					@class = new Class5.Class18((uint)object_0, (Class5.Enum1)6);
				}
				break;
			case (Class5.Enum2)7:
				if (enum2 != (Class5.Enum2)7)
				{
					if (enum2 != (Class5.Enum2)11)
					{
						if (enum2 != (Class5.Enum2)15)
						{
							throw new InvalidCastException();
						}
						@class = new Class5.Class19((long)((ulong)((char)object_0)), (Class5.Enum1)7);
					}
					else if (!(bool)object_0)
					{
						@class = new Class5.Class19(0L, (Class5.Enum1)7);
					}
					else
					{
						@class = new Class5.Class19(1L, (Class5.Enum1)7);
					}
				}
				else
				{
					@class = new Class5.Class19((long)object_0, (Class5.Enum1)7);
				}
				break;
			case (Class5.Enum2)8:
				if (enum2 != (Class5.Enum2)8)
				{
					if (enum2 != (Class5.Enum2)11)
					{
						if (enum2 != (Class5.Enum2)15)
						{
							throw new InvalidCastException();
						}
						@class = new Class5.Class19((ulong)((char)object_0), (Class5.Enum1)8);
					}
					else if (!(bool)object_0)
					{
						@class = new Class5.Class19(0UL, (Class5.Enum1)8);
					}
					else
					{
						@class = new Class5.Class19(1UL, (Class5.Enum1)8);
					}
				}
				else
				{
					@class = new Class5.Class19((ulong)object_0, (Class5.Enum1)8);
				}
				break;
			case (Class5.Enum2)9:
				if (enum2 != (Class5.Enum2)9)
				{
					throw new InvalidCastException();
				}
				@class = new Class5.Class21((float)object_0);
				break;
			case (Class5.Enum2)10:
				if (enum2 != (Class5.Enum2)10)
				{
					throw new InvalidCastException();
				}
				@class = new Class5.Class21((double)object_0);
				break;
			case (Class5.Enum2)11:
				switch (enum2)
				{
				case (Class5.Enum2)1:
					@class = new Class5.Class18((sbyte)object_0 != 0);
					goto IL_67D;
				case (Class5.Enum2)2:
					@class = new Class5.Class18((byte)object_0 > 0);
					goto IL_67D;
				case (Class5.Enum2)3:
					@class = new Class5.Class18((short)object_0 != 0);
					goto IL_67D;
				case (Class5.Enum2)4:
					@class = new Class5.Class18((ushort)object_0 > 0);
					goto IL_67D;
				case (Class5.Enum2)5:
					@class = new Class5.Class18((int)object_0 != 0);
					goto IL_67D;
				case (Class5.Enum2)6:
					@class = new Class5.Class18((uint)object_0 > 0U);
					goto IL_67D;
				case (Class5.Enum2)7:
					@class = new Class5.Class18((long)object_0 != 0L);
					goto IL_67D;
				case (Class5.Enum2)8:
					@class = new Class5.Class18((ulong)object_0 > 0UL);
					goto IL_67D;
				case (Class5.Enum2)9:
				case (Class5.Enum2)10:
				case (Class5.Enum2)12:
				case (Class5.Enum2)13:
				case (Class5.Enum2)14:
				case (Class5.Enum2)15:
				case (Class5.Enum2)16:
					throw new InvalidCastException();
				case (Class5.Enum2)11:
					@class = new Class5.Class18((bool)object_0);
					goto IL_67D;
				case (Class5.Enum2)18:
					@class = new Class5.Class18(false);
					goto IL_67D;
				}
				@class = new Class5.Class18(object_0 != null);
				break;
			case (Class5.Enum2)12:
				if (enum2 != (Class5.Enum2)12)
				{
					throw new InvalidCastException();
				}
				@class = new Class5.Class20((IntPtr)object_0);
				break;
			case (Class5.Enum2)13:
				if (enum2 != (Class5.Enum2)13)
				{
					throw new InvalidCastException();
				}
				@class = new Class5.Class20((UIntPtr)object_0);
				break;
			case (Class5.Enum2)14:
				@class = new Class5.Class29(object_0 as string);
				break;
			case (Class5.Enum2)15:
				switch (enum2)
				{
				case (Class5.Enum2)1:
					@class = new Class5.Class18((int)((sbyte)object_0), (Class5.Enum1)15);
					break;
				case (Class5.Enum2)2:
					@class = new Class5.Class18((int)((byte)object_0), (Class5.Enum1)15);
					break;
				case (Class5.Enum2)3:
					@class = new Class5.Class18((int)((short)object_0), (Class5.Enum1)15);
					break;
				case (Class5.Enum2)4:
					@class = new Class5.Class18((int)((ushort)object_0), (Class5.Enum1)15);
					break;
				case (Class5.Enum2)5:
					@class = new Class5.Class18((int)object_0, (Class5.Enum1)15);
					break;
				case (Class5.Enum2)6:
					@class = new Class5.Class18((int)((uint)object_0), (Class5.Enum1)15);
					break;
				default:
					if (enum2 != (Class5.Enum2)15)
					{
						throw new InvalidCastException();
					}
					@class = new Class5.Class18((int)((char)object_0), (Class5.Enum1)15);
					break;
				}
				break;
			case (Class5.Enum2)16:
			case (Class5.Enum2)17:
				@class = Class5.Class16.smethod_2(object_0);
				break;
			case (Class5.Enum2)18:
				throw new InvalidCastException();
			}
			IL_67D:
			if (type_0.IsByRef)
			{
				@class = new Class5.Class27(@class, type_0.GetElementType());
			}
			return @class;
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x0002AEA4 File Offset: 0x000290A4
		private static Class5.Class16 smethod_2(object object_0)
		{
			if (object_0 != null && object_0.GetType().IsEnum)
			{
				Type underlyingType = Enum.GetUnderlyingType(object_0.GetType());
				object object_ = Convert.ChangeType(object_0, underlyingType);
				Class5.Class16 @class = Class5.Class16.smethod_3(Class5.Class16.smethod_1(underlyingType, object_));
				if (@class != null)
				{
					return @class as Class5.Class17;
				}
			}
			return new Class5.Class28(object_0);
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x00028B64 File Offset: 0x00026D64
		private static Class5.Class17 smethod_3(Class5.Class16 class16_0)
		{
			Class5.Class17 @class = class16_0 as Class5.Class17;
			if (@class == null && class16_0.vmethod_0())
			{
				@class = (class16_0.vmethod_8() as Class5.Class17);
			}
			return @class;
		}

		// Token: 0x040003E4 RID: 996
		internal Class5.Enum4 enum4_0;
	}

	// Token: 0x020000BA RID: 186
	private class Class28 : Class5.Class16
	{
		// Token: 0x06000597 RID: 1431 RVA: 0x0002AEFC File Offset: 0x000290FC
		public Class28() : this(null)
		{
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0002AF14 File Offset: 0x00029114
		internal override void vmethod_10(Class5.Class16 class16_1)
		{
			if (!(class16_1 is Class5.Class28))
			{
				this.class16_0 = class16_1.vmethod_8();
				return;
			}
			this.class16_0 = ((Class5.Class28)class16_1).class16_0;
			this.type_0 = ((Class5.Class28)class16_1).type_0;
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x0001F0EC File Offset: 0x0001D2EC
		internal override void vmethod_2(Class5.Class16 class16_1)
		{
			this.vmethod_10(class16_1);
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x0002AF58 File Offset: 0x00029158
		public Class28(object object_0) : base((Class5.Enum4)0)
		{
			this.class16_0 = object_0;
			this.type_0 = null;
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0002AF7C File Offset: 0x0002917C
		public Class28(object object_0, Type type_1) : base((Class5.Enum4)0)
		{
			this.class16_0 = object_0;
			this.type_0 = type_1;
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0002AFA0 File Offset: 0x000291A0
		public override string ToString()
		{
			if (this.class16_0 == null)
			{
				return ((Class5.Enum5)5).ToString();
			}
			return this.class16_0.ToString();
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x0002AFD4 File Offset: 0x000291D4
		internal override object vmethod_4(Type type_1)
		{
			if (this.class16_0 == null)
			{
				return null;
			}
			if (type_1 != null && type_1.IsByRef)
			{
				type_1 = type_1.GetElementType();
			}
			if (!(this.class16_0 is Class5.Class16))
			{
				object obj = this.class16_0;
				if (obj != null && type_1 != null && obj.GetType() != type_1)
				{
					if (type_1 == typeof(RuntimeFieldHandle) && obj is FieldInfo)
					{
						obj = ((FieldInfo)obj).FieldHandle;
					}
					else if (type_1 == typeof(RuntimeTypeHandle) && obj is Type)
					{
						obj = ((Type)obj).TypeHandle;
					}
					else if (type_1 == typeof(RuntimeMethodHandle) && obj is MethodBase)
					{
						obj = ((MethodBase)obj).MethodHandle;
					}
				}
				return obj;
			}
			if (this.type_0 != null)
			{
				return ((Class5.Class16)this.class16_0).vmethod_4(this.type_0);
			}
			object obj2 = ((Class5.Class16)this.class16_0).vmethod_4(type_1);
			if (obj2 != null && type_1 != null && obj2.GetType() != type_1)
			{
				if (type_1 == typeof(RuntimeFieldHandle) && obj2 is FieldInfo)
				{
					obj2 = ((FieldInfo)obj2).FieldHandle;
				}
				else if (type_1 == typeof(RuntimeTypeHandle) && obj2 is Type)
				{
					obj2 = ((Type)obj2).TypeHandle;
				}
				else if (type_1 == typeof(RuntimeMethodHandle) && obj2 is MethodBase)
				{
					obj2 = ((MethodBase)obj2).MethodHandle;
				}
			}
			return obj2;
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0002B1C0 File Offset: 0x000293C0
		internal override bool vmethod_5(Class5.Class16 class16_1)
		{
			if (class16_1.vmethod_0())
			{
				return ((Class5.Class22)class16_1).vmethod_5(this);
			}
			object obj = this.vmethod_4(null);
			object obj2 = class16_1.vmethod_4(null);
			return obj == obj2;
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0002B1F8 File Offset: 0x000293F8
		internal override bool vmethod_6(Class5.Class16 class16_1)
		{
			if (class16_1.vmethod_0())
			{
				return ((Class5.Class22)class16_1).vmethod_6(this);
			}
			object obj = this.vmethod_4(null);
			object obj2 = class16_1.vmethod_4(null);
			return obj != obj2;
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x0002B234 File Offset: 0x00029434
		internal override Class5.Class16 vmethod_8()
		{
			Class5.Class16 @class = this.class16_0 as Class5.Class16;
			if (@class == null)
			{
				return this;
			}
			return @class.vmethod_8();
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x0002B25C File Offset: 0x0002945C
		internal override bool vmethod_7()
		{
			if (this.class16_0 != null)
			{
				Class5.Class16 @class = this.class16_0 as Class5.Class16;
				return @class == null || @class.vmethod_4(null) != null;
			}
			return false;
		}

		// Token: 0x040003E5 RID: 997
		public Class5.Class16 class16_0;

		// Token: 0x040003E6 RID: 998
		public Type type_0;
	}

	// Token: 0x020000BB RID: 187
	private class Class29 : Class5.Class16
	{
		// Token: 0x060005A2 RID: 1442 RVA: 0x0002B294 File Offset: 0x00029494
		public Class29(string string_1) : base((Class5.Enum4)6)
		{
			this.string_0 = string_1;
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x0002B2B0 File Offset: 0x000294B0
		internal override void vmethod_10(Class5.Class16 class16_0)
		{
			this.string_0 = ((Class5.Class29)class16_0).string_0;
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x0001F0EC File Offset: 0x0001D2EC
		internal override void vmethod_2(Class5.Class16 class16_0)
		{
			this.vmethod_10(class16_0);
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x0002B2D0 File Offset: 0x000294D0
		public override string ToString()
		{
			if (this.string_0 == null)
			{
				return ((Class5.Enum5)5).ToString();
			}
			return '*'.ToString() + this.string_0 + '*'.ToString();
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x00003BF3 File Offset: 0x00001DF3
		internal override bool vmethod_7()
		{
			return this.string_0 != null;
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x00003BFE File Offset: 0x00001DFE
		internal override object vmethod_4(Type type_0)
		{
			return this.string_0;
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x0002B318 File Offset: 0x00029518
		internal override bool vmethod_5(Class5.Class16 class16_0)
		{
			if (class16_0.vmethod_0())
			{
				return ((Class5.Class22)class16_0).vmethod_5(this);
			}
			object obj = this.string_0;
			object obj2 = class16_0.vmethod_4(null);
			return obj == obj2;
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x0002B350 File Offset: 0x00029550
		internal override bool vmethod_6(Class5.Class16 class16_0)
		{
			if (!class16_0.vmethod_0())
			{
				object obj = this.string_0;
				object obj2 = class16_0.vmethod_4(null);
				return obj != obj2;
			}
			return ((Class5.Class22)class16_0).vmethod_6(this);
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x0000357B File Offset: 0x0000177B
		internal override Class5.Class16 vmethod_8()
		{
			return this;
		}

		// Token: 0x040003E7 RID: 999
		public string string_0;
	}

	// Token: 0x020000BC RID: 188
	internal class Class30
	{
		// Token: 0x060005AB RID: 1451 RVA: 0x00003C06 File Offset: 0x00001E06
		public int method_0()
		{
			return this.list_0.Count;
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0002B388 File Offset: 0x00029588
		public void method_1()
		{
			this.list_0.Clear();
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0002B3A0 File Offset: 0x000295A0
		public void method_2(Class5.Class16 class16_0)
		{
			this.list_0.Add(class16_0);
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x00003C13 File Offset: 0x00001E13
		public Class5.Class16 method_3()
		{
			return this.list_0[this.list_0.Count - 1];
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00003C2D File Offset: 0x00001E2D
		public Class5.Class16 method_4()
		{
			Class5.Class16 result = this.method_3();
			if (this.list_0.Count != 0)
			{
				this.list_0.RemoveAt(this.list_0.Count - 1);
			}
			return result;
		}

		// Token: 0x040003E8 RID: 1000
		private List<Class5.Class16> list_0 = new List<Class5.Class16>();
	}

	// Token: 0x020000BD RID: 189
	internal enum Enum5
	{

	}

	// Token: 0x020000BE RID: 190
	[CompilerGenerated]
	[Serializable]
	private sealed class Class31<T>
	{
		// Token: 0x060005B3 RID: 1459 RVA: 0x00003B9C File Offset: 0x00001D9C
		internal int method_0(Class5.Class9 x, Class5.Class9 y)
		{
			return x.class10_0.int_0.CompareTo(y.class10_0.int_0);
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x00003C5A File Offset: 0x00001E5A
		internal static bool smethod_0()
		{
			return Class5.Class31<T>.object_0 == null;
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x00003C64 File Offset: 0x00001E64
		internal static object smethod_1()
		{
			return Class5.Class31<T>.object_0;
		}

		// Token: 0x040003EA RID: 1002
		public static readonly Class5.Class31<T> <>9 = new Class5.Class31<T>();

		// Token: 0x040003EB RID: 1003
		public static Comparison<Class5.Class9> <>9__45_0;

		// Token: 0x040003EC RID: 1004
		internal static object object_0;
	}
}
