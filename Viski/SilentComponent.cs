using System;
using System.Collections;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000056 RID: 86
	[DisallowMultipleComponent]
	public class SilentComponent : MonoBehaviour
	{
		// Token: 0x060001F4 RID: 500 RVA: 0x00011E50 File Offset: 0x00010050
		public void Awake()
		{
			base.StartCoroutine(this.RedoSphere());
			base.StartCoroutine(this.CalcSphere());
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00002F23 File Offset: 0x00001123
		public IEnumerator CalcSphere()
		{
			SilentComponent.<CalcSphere>d__1 <CalcSphere>d__ = new SilentComponent.<CalcSphere>d__1(0);
			<CalcSphere>d__.<>4__this = this;
			return <CalcSphere>d__;
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00002F32 File Offset: 0x00001132
		public IEnumerator RedoSphere()
		{
			SilentComponent.<RedoSphere>d__2 <RedoSphere>d__ = new SilentComponent.<RedoSphere>d__2(0);
			<RedoSphere>d__.<>4__this = this;
			return <RedoSphere>d__;
		}

		// Token: 0x0400022A RID: 554
		public GameObject Sphere;
	}
}
