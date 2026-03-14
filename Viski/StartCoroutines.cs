using System;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000060 RID: 96
	[Component]
	public class StartCoroutines : MonoBehaviour
	{
		// Token: 0x06000226 RID: 550 RVA: 0x00013C28 File Offset: 0x00011E28
		public void Start()
		{
			base.StartCoroutine(SilentCoroutines.UpdateObjects());
		}
	}
}
