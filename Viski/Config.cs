using System;
using System.Collections.Generic;

namespace Viski
{
	// Token: 0x02000028 RID: 40
	public class Config
	{
		// Token: 0x040000CF RID: 207
		public VisualOptions BedOptions = new VisualOptions();

		// Token: 0x040000D0 RID: 208
		public VisualOptions PlayerOptions = new VisualOptions();

		// Token: 0x040000D1 RID: 209
		public VisualOptions ItemOptions = new VisualOptions();

		// Token: 0x040000D2 RID: 210
		public VisualOptions StorageOptions = new VisualOptions();

		// Token: 0x040000D3 RID: 211
		public VisualOptions VehicleOptions = new VisualOptions();

		// Token: 0x040000D4 RID: 212
		public VisualOptions AirdropOptions = new VisualOptions();

		// Token: 0x040000D5 RID: 213
		public VisualOptions SentryOptions = new VisualOptions();

		// Token: 0x040000D6 RID: 214
		public VisualOptions ZombieOptions = new VisualOptions();

		// Token: 0x040000D7 RID: 215
		public VisualOptions FlagOptions = new VisualOptions();

		// Token: 0x040000D8 RID: 216
		public VisualOptions visualOptions_0 = new VisualOptions();

		// Token: 0x040000D9 RID: 217
		public VisualOptions FarmOptions = new VisualOptions();

		// Token: 0x040000DA RID: 218
		public VisualOptions ResourcesOptions = new VisualOptions();

		// Token: 0x040000DB RID: 219
		public OtherOptions GlobalOptions = new OtherOptions();

		// Token: 0x040000DC RID: 220
		public SilentOptions SilentOptions = new SilentOptions();

		// Token: 0x040000DD RID: 221
		public AimbotOptions AimbotOptions = new AimbotOptions();

		// Token: 0x040000DE RID: 222
		public MiscOptions MiscOptions = new MiscOptions();

		// Token: 0x040000DF RID: 223
		public BacktrackOptions BacktrackOptions = new BacktrackOptions();

		// Token: 0x040000E0 RID: 224
		public Dictionary<ulong, Visual.Priority> Priority = new Dictionary<ulong, Visual.Priority>();
	}
}
