using System;
using System.Reflection;
using SDG.NetPak;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x02000051 RID: 81
	public class VehicleSpinbot : PlayerInputPacket
	{
		// Token: 0x060001E6 RID: 486 RVA: 0x0001139C File Offset: 0x0000F59C
		[Initializer]
		public static void a()
		{
			VehicleSpinbot.positionF = typeof(DrivingPlayerInputPacket).GetField("position", BindingFlags.Instance | BindingFlags.Public);
			VehicleSpinbot.rotationF = typeof(DrivingPlayerInputPacket).GetField("rotation", BindingFlags.Instance | BindingFlags.Public);
			VehicleSpinbot.speedF = typeof(DrivingPlayerInputPacket).GetField("speed", BindingFlags.Instance | BindingFlags.Public);
			VehicleSpinbot.forwardVelocityF = typeof(DrivingPlayerInputPacket).GetField("forwardVelocity", BindingFlags.Instance | BindingFlags.Public);
			VehicleSpinbot.steeringInputF = typeof(DrivingPlayerInputPacket).GetField("steeringInput", BindingFlags.Instance | BindingFlags.Public);
			VehicleSpinbot.velocityInputF = typeof(DrivingPlayerInputPacket).GetField("velocityInput", BindingFlags.Instance | BindingFlags.Public);
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00011454 File Offset: 0x0000F654
		[Override(typeof(DrivingPlayerInputPacket), "write", BindingFlags.Instance | BindingFlags.Public, 0)]
		public void OV_write(NetPakWriter writer)
		{
			base.write(writer);
			if (!G.Settings.MiscOptions.VehicleSpinbot)
			{
				UnityNetPakWriterEx.WriteClampedVector3(writer, (Vector3)VehicleSpinbot.positionF.GetValue(this), 13, 8);
				UnityNetPakWriterEx.WriteQuaternion(writer, (Quaternion)VehicleSpinbot.rotationF.GetValue(this), 11);
				SystemNetPakWriterEx.WriteUnsignedClampedFloat(writer, (float)VehicleSpinbot.speedF.GetValue(this), 8, 2);
				SystemNetPakWriterEx.WriteClampedFloat(writer, (float)VehicleSpinbot.forwardVelocityF.GetValue(this), 9, 2);
				SystemNetPakWriterEx.WriteSignedNormalizedFloat(writer, (float)VehicleSpinbot.steeringInputF.GetValue(this), 2);
				SystemNetPakWriterEx.WriteClampedFloat(writer, (float)VehicleSpinbot.velocityInputF.GetValue(this), 9, 2);
			}
			else
			{
				UnityNetPakWriterEx.WriteClampedVector3(writer, (Vector3)VehicleSpinbot.positionF.GetValue(this), 13, 8);
				UnityNetPakWriterEx.WriteQuaternion(writer, new Quaternion((float)Random.Range(10, 280), (float)Random.Range(10, 280), (float)Random.Range(10, 280), (float)Random.Range(10, 280)), 11);
				SystemNetPakWriterEx.WriteUnsignedClampedFloat(writer, (float)VehicleSpinbot.speedF.GetValue(this), 8, 2);
				SystemNetPakWriterEx.WriteClampedFloat(writer, (float)VehicleSpinbot.forwardVelocityF.GetValue(this), 9, 2);
				SystemNetPakWriterEx.WriteSignedNormalizedFloat(writer, (float)VehicleSpinbot.steeringInputF.GetValue(this), 2);
				SystemNetPakWriterEx.WriteClampedFloat(writer, (float)VehicleSpinbot.velocityInputF.GetValue(this), 9, 2);
			}
		}

		// Token: 0x04000220 RID: 544
		public static FieldInfo positionF;

		// Token: 0x04000221 RID: 545
		public static FieldInfo rotationF;

		// Token: 0x04000222 RID: 546
		public static FieldInfo speedF;

		// Token: 0x04000223 RID: 547
		public static FieldInfo forwardVelocityF;

		// Token: 0x04000224 RID: 548
		public static FieldInfo steeringInputF;

		// Token: 0x04000225 RID: 549
		public static FieldInfo velocityInputF;
	}
}
