using System;
using System.Reflection;

// Token: 0x02000085 RID: 133
internal class Class0
{
	// Token: 0x060002CF RID: 719 RVA: 0x0001D28C File Offset: 0x0001B48C
	internal static void smethod_0(int typemdt)
	{
		Type type = Class0.module_0.ResolveType(33554432 + typemdt);
		foreach (FieldInfo fieldInfo in type.GetFields())
		{
			MethodInfo method = (MethodInfo)Class0.module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	// Token: 0x0400034F RID: 847
	internal static Module module_0 = typeof(Class0).Assembly.ManifestModule;

	// Token: 0x02000086 RID: 134
	// (Invoke) Token: 0x060002D3 RID: 723
	internal delegate void Delegate0(object o);
}
