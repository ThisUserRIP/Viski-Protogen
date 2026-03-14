using System;
using System.Reflection;
using SDG.NetPak;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000050 RID: 80
	public class Spinbot : PlayerInputPacket
	{
		// Token: 0x060001DF RID: 479 RVA: 0x00002EFF File Offset: 0x000010FF
		public static int GetInputX(PlayerMovement movement)
		{
			return (int)Spinbot.fieldInfo_0.GetValue(movement);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00002F11 File Offset: 0x00001111
		public static int GetInputY(PlayerMovement movement)
		{
			return (int)Spinbot.fieldInfo_1.GetValue(movement);
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00011180 File Offset: 0x0000F380
		public static float NextSpinbotYaw(float increment)
		{
			Spinbot.spinbotYaw += increment;
			if (Spinbot.spinbotYaw >= 360f)
			{
				Spinbot.spinbotYaw -= 360f;
			}
			return Spinbot.spinbotYaw;
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x000111C4 File Offset: 0x0000F3C4
		[Initializer]
		public static void a()
		{
			Spinbot.analogF = typeof(WalkingPlayerInputPacket).GetField("analog", BindingFlags.Instance | BindingFlags.Public);
			Spinbot.clientPositionF = typeof(WalkingPlayerInputPacket).GetField("clientPosition", BindingFlags.Instance | BindingFlags.Public);
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0001120C File Offset: 0x0000F40C
		[Override(typeof(WalkingPlayerInputPacket), "write", BindingFlags.Instance | BindingFlags.Public, 0)]
		public void OV_write(NetPakWriter writer)
		{
			base.write(writer);
			if (G.Settings.MiscOptions.Spinbot)
			{
				int num = Spinbot.GetInputX(Player.player.movement);
				int num2 = Spinbot.GetInputY(Player.player.movement);
				if (num == 0 && num2 == 0)
				{
					SystemNetPakWriterEx.WriteUInt8(writer, (byte)Spinbot.analogF.GetValue(this));
					UnityNetPakWriterEx.WriteClampedVector3(writer, (Vector3)Spinbot.clientPositionF.GetValue(this), 13, 7);
				}
				else if (Spinbot.walkSpin)
				{
					SystemNetPakWriterEx.WriteUInt8(writer, (byte)Spinbot.analogF.GetValue(this));
					UnityNetPakWriterEx.WriteClampedVector3(writer, (Vector3)Spinbot.clientPositionF.GetValue(this), 13, 7);
					Spinbot.walkSpin = false;
				}
				else
				{
					num2 *= -1;
					num *= -1;
					SystemNetPakWriterEx.WriteUInt8(writer, (byte)((int)((byte)(num + 1)) << 4 | (int)((byte)(num2 + 1))));
					UnityNetPakWriterEx.WriteClampedVector3(writer, (Vector3)Spinbot.clientPositionF.GetValue(this), 13, 7);
					Spinbot.walkSpin = true;
				}
			}
			else
			{
				SystemNetPakWriterEx.WriteUInt8(writer, (byte)Spinbot.analogF.GetValue(this));
				UnityNetPakWriterEx.WriteClampedVector3(writer, (Vector3)Spinbot.clientPositionF.GetValue(this), 13, 7);
			}
		}

		// Token: 0x04000218 RID: 536
		public static FieldInfo analogF;

		// Token: 0x04000219 RID: 537
		public static FieldInfo clientPositionF;

		// Token: 0x0400021A RID: 538
		public static bool walkSpin;

		// Token: 0x0400021B RID: 539
		public static float spinbotYaw;

		// Token: 0x0400021C RID: 540
		public static float spinbotPitch;

		// Token: 0x0400021D RID: 541
		public static FieldInfo fieldInfo_0 = typeof(PlayerMovement).GetField("input_x", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x0400021E RID: 542
		public static FieldInfo fieldInfo_1 = typeof(PlayerMovement).GetField("input_y", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x0400021F RID: 543
		public static byte step;
	}
}
