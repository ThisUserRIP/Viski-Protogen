using System;
using System.Collections.Generic;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200002B RID: 43
	public class OtherOptions
	{
		// Token: 0x040000EA RID: 234
		public bool FullGrown = true;

		// Token: 0x040000EB RID: 235
		public bool BedOwner = false;

		// Token: 0x040000EC RID: 236
		public bool Claimed = true;

		// Token: 0x040000ED RID: 237
		public bool OnlyUnclaimed = false;

		// Token: 0x040000EE RID: 238
		public bool filterItems = false;

		// Token: 0x040000EF RID: 239
		public bool allowGun = false;

		// Token: 0x040000F0 RID: 240
		public bool allowMelee = false;

		// Token: 0x040000F1 RID: 241
		public bool allowBackpack = false;

		// Token: 0x040000F2 RID: 242
		public bool allowClothing = false;

		// Token: 0x040000F3 RID: 243
		public bool allowFuel = false;

		// Token: 0x040000F4 RID: 244
		public bool allowFoodWater = false;

		// Token: 0x040000F5 RID: 245
		public bool allowAmmo = false;

		// Token: 0x040000F6 RID: 246
		public bool allowMedical = false;

		// Token: 0x040000F7 RID: 247
		public bool allowThrowable = false;

		// Token: 0x040000F8 RID: 248
		public bool allowAttachments = false;

		// Token: 0x040000F9 RID: 249
		public bool allowExtra = false;

		// Token: 0x040000FA RID: 250
		public bool Weapon = true;

		// Token: 0x040000FB RID: 251
		public bool Skeleton = false;

		// Token: 0x040000FC RID: 252
		public bool ViewHitboxes = true;

		// Token: 0x040000FD RID: 253
		public bool ShowLookDirection = false;

		// Token: 0x040000FE RID: 254
		public bool VehicleLocked = true;

		// Token: 0x040000FF RID: 255
		public bool OnlyUnlocked = false;

		// Token: 0x04000100 RID: 256
		public bool StorageOwner = false;

		// Token: 0x04000101 RID: 257
		public bool ShowLocked = true;

		// Token: 0x04000102 RID: 258
		public Dictionary<string, Color32> GlobalColors = new Dictionary<string, Color32>();

		// Token: 0x04000103 RID: 259
		public bool NoCloud = false;

		// Token: 0x04000104 RID: 260
		public bool NoGrass = false;

		// Token: 0x04000105 RID: 261
		public bool GPS = false;

		// Token: 0x04000106 RID: 262
		public bool NoSnow = false;

		// Token: 0x04000107 RID: 263
		public bool NoRain = false;

		// Token: 0x04000108 RID: 264
		public bool NoTree = false;

		// Token: 0x04000109 RID: 265
		public bool NoFog = false;

		// Token: 0x0400010A RID: 266
		public bool NoFlinch = false;

		// Token: 0x0400010B RID: 267
		public bool NoGrayscale = false;

		// Token: 0x0400010C RID: 268
		public bool ShowPlayerOnMap;

		// Token: 0x0400010D RID: 269
		public bool NightVision = false;

		// Token: 0x0400010E RID: 270
		public bool NightVision2 = false;

		// Token: 0x0400010F RID: 271
		public bool Compass = false;

		// Token: 0x04000110 RID: 272
		public bool AutoWalk = false;

		// Token: 0x04000111 RID: 273
		public Dictionary<string, KeyCode> Hotkeyd = new Dictionary<string, KeyCode>();
	}
}
