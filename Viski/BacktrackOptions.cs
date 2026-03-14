using System;

namespace Viski
{
	// Token: 0x0200001E RID: 30
	public class BacktrackOptions
	{
		// Token: 0x06000082 RID: 130 RVA: 0x00005C20 File Offset: 0x00003E20
		public void ResetToDefaults()
		{
			this.Enabled = false;
			this.BacktrackDelay = 3f;
			this.MaxPositions = 100;
			this.BacktrackUpdateRate = 0.02f;
		}

		// Token: 0x0400006E RID: 110
		public bool Enabled = false;

		// Token: 0x0400006F RID: 111
		public float BacktrackDelay = 3f;

		// Token: 0x04000070 RID: 112
		public int MaxPositions = 100;

		// Token: 0x04000071 RID: 113
		public float BacktrackUpdateRate = 0.02f;
	}
}
