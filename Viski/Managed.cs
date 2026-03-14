using System;
using System.Reflection;
using System.Threading;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200006C RID: 108
	public class Managed : MonoBehaviour
	{
		// Token: 0x06000265 RID: 613 RVA: 0x00014FC8 File Offset: 0x000131C8
		public void Start()
		{
			Managed.DrawMaterial = new Material(Shader.Find("Hidden/Internal-Colored"))
			{
				hideFlags = 61
			};
			Managed.DrawMaterial.SetInt("_SrcBlend", 5);
			Managed.DrawMaterial.SetInt("_DstBlend", 10);
			Managed.DrawMaterial.SetInt("_Cull", 0);
			Managed.DrawMaterial.SetInt("_ZWrite", 0);
			Asset.Get();
			Hotkeys.AddKey();
			C.AddColors();
			foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (type.IsDefined(typeof(ComponentAttribute), false))
				{
					Viski1.xyz.AddComponent(type);
				}
				MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				for (int j = 0; j < methods.Length; j++)
				{
					Managed.<>c__DisplayClass1_0 CS$<>8__locals1 = new Managed.<>c__DisplayClass1_0();
					CS$<>8__locals1.methodInfo_0 = methods[j];
					if (CS$<>8__locals1.methodInfo_0.IsDefined(typeof(InitializerAttribute), false))
					{
						CS$<>8__locals1.methodInfo_0.Invoke(null, null);
					}
					if (CS$<>8__locals1.methodInfo_0.IsDefined(typeof(OverrideAttribute), false))
					{
						OverrideManager overrideManager = new OverrideManager();
						overrideManager.LoadOverride(CS$<>8__locals1.methodInfo_0);
					}
					if (CS$<>8__locals1.methodInfo_0.IsDefined(typeof(ThreadAttribute), false))
					{
						new Thread(new ThreadStart(CS$<>8__locals1.method_0)).Start();
					}
				}
			}
			ConfigUtilities.CreateEnvironment();
		}

		// Token: 0x040002B8 RID: 696
		public static Material DrawMaterial;
	}
}
