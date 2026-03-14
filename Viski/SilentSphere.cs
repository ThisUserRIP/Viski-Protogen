using System;
using System.Collections.Generic;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace Viski
{
	// Token: 0x0200005D RID: 93
	public static class SilentSphere
	{
		// Token: 0x0600021B RID: 539 RVA: 0x00012B50 File Offset: 0x00010D50
		public static bool GetRaycast(GameObject Target, Vector3 StartPos, out Vector3 Point)
		{
			Point = Vector3.zero;
			bool result;
			if (Target == null)
			{
				result = false;
			}
			else
			{
				int layer = Target.layer;
				Target.layer = 24;
				Target.GetComponent<SilentComponent>();
				Vector3 vector = Target.transform.position;
				Player component = Target.GetComponent<Player>();
				if (component != null)
				{
					bool flag = false;
					try
					{
						if (component.movement != null)
						{
							Type type = component.movement.GetType();
							FieldInfo field = type.GetField("isCrouching", BindingFlags.Instance | BindingFlags.NonPublic);
							if (field != null)
							{
								flag = (bool)field.GetValue(component.movement);
							}
						}
					}
					catch
					{
						flag = false;
					}
					Vector3 position = Target.transform.position;
					if (!flag)
					{
						vector = position + Vector3.up * 1.8f;
					}
					else
					{
						vector = position + Vector3.up * 1.2f;
					}
					Vector3 forward = component.look.aim.forward;
					Vector3 normalized = Vector3.Cross(forward, Vector3.up).normalized;
					Vector3[] array = new Vector3[]
					{
						vector,
						vector + normalized * 0.4f,
						vector - normalized * 0.4f,
						vector + forward * 0.3f,
						vector + Vector3.up * 0.2f,
						position + Vector3.up * 0.8f,
						position + Vector3.up * 1f,
						position + Vector3.up * 1.5f
					};
					float num = float.MaxValue;
					Vector3 vector2 = vector;
					foreach (Vector3 vector3 in array)
					{
						Vector3 vector4 = VectorUtilities.Normalize(vector3 - StartPos);
						float num2 = (float)VectorUtilities.GetDistance(StartPos, vector3);
						if (!Physics.Raycast(StartPos, vector4, num2, RayMasks.DAMAGE_CLIENT) && num2 < num)
						{
							num = num2;
							vector2 = vector3;
						}
					}
					vector = vector2;
				}
				else
				{
					vector = Target.transform.position + Vector3.up * 0.5f;
				}
				Vector3 vector5 = VectorUtilities.Normalize(vector - StartPos);
				float num3 = (float)VectorUtilities.GetDistance(StartPos, vector);
				if (Physics.Raycast(StartPos, vector5, num3, RayMasks.DAMAGE_CLIENT))
				{
					Vector3 vector6 = Target.transform.position + Vector3.up * 0.5f;
					Vector3 vector7 = VectorUtilities.Normalize(vector6 - StartPos);
					if (Physics.Raycast(StartPos, vector7, num3, RayMasks.DAMAGE_CLIENT))
					{
						Target.layer = layer;
						return false;
					}
					vector = vector6;
				}
				Target.layer = layer;
				Point = vector;
				result = true;
			}
			return result;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00012E80 File Offset: 0x00011080
		public static int GetMiddlePoint(int p1, int p2, ref List<Vector3> vertices, ref Dictionary<long, int> cache, float radius)
		{
			bool flag;
			long num = (long)((flag = (p1 < p2)) ? p1 : p2);
			long num2 = (long)(flag ? p2 : p1);
			long key = (num << 32) + num2;
			int num3;
			int result;
			if (!cache.TryGetValue(key, out num3))
			{
				Vector3 vector = vertices[p1];
				Vector3 vector2 = vertices[p2];
				Vector3 vector3;
				vector3..ctor((vector.x + vector2.x) / 2f, (vector.y + vector2.y) / 2f, (vector.z + vector2.z) / 2f);
				int count = vertices.Count;
				vertices.Add(vector3.normalized * radius);
				cache.Add(key, count);
				result = count;
			}
			else
			{
				result = num3;
			}
			return result;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00012F58 File Offset: 0x00011158
		public static GameObject Create(string name, float radius, float recursionLevel)
		{
			GameObject gameObject = new GameObject(name);
			Mesh mesh = new Mesh
			{
				name = name
			};
			List<Vector3> list = new List<Vector3>();
			Dictionary<long, int> dictionary = new Dictionary<long, int>();
			float num = (1f + Mathf.Sqrt(5f)) / 2f;
			list.Add(new Vector3(-1f, num, 0f).normalized * radius);
			list.Add(new Vector3(1f, num, 0f).normalized * radius);
			list.Add(new Vector3(-1f, -num, 0f).normalized * radius);
			list.Add(new Vector3(1f, -num, 0f).normalized * radius);
			list.Add(new Vector3(0f, -1f, num).normalized * radius);
			list.Add(new Vector3(0f, 1f, num).normalized * radius);
			list.Add(new Vector3(0f, -1f, -num).normalized * radius);
			list.Add(new Vector3(0f, 1f, -num).normalized * radius);
			list.Add(new Vector3(num, 0f, -1f).normalized * radius);
			list.Add(new Vector3(num, 0f, 1f).normalized * radius);
			list.Add(new Vector3(-num, 0f, -1f).normalized * radius);
			list.Add(new Vector3(-num, 0f, 1f).normalized * radius);
			List<SilentSphere.TriangleIndices> list2 = new List<SilentSphere.TriangleIndices>
			{
				new SilentSphere.TriangleIndices(0, 11, 5),
				new SilentSphere.TriangleIndices(0, 5, 1),
				new SilentSphere.TriangleIndices(0, 1, 7),
				new SilentSphere.TriangleIndices(0, 7, 10),
				new SilentSphere.TriangleIndices(0, 10, 11),
				new SilentSphere.TriangleIndices(1, 5, 9),
				new SilentSphere.TriangleIndices(5, 11, 4),
				new SilentSphere.TriangleIndices(11, 10, 2),
				new SilentSphere.TriangleIndices(10, 7, 6),
				new SilentSphere.TriangleIndices(7, 1, 8),
				new SilentSphere.TriangleIndices(3, 9, 4),
				new SilentSphere.TriangleIndices(3, 4, 2),
				new SilentSphere.TriangleIndices(3, 2, 6),
				new SilentSphere.TriangleIndices(3, 6, 8),
				new SilentSphere.TriangleIndices(3, 8, 9),
				new SilentSphere.TriangleIndices(4, 9, 5),
				new SilentSphere.TriangleIndices(2, 4, 11),
				new SilentSphere.TriangleIndices(6, 2, 10),
				new SilentSphere.TriangleIndices(8, 6, 7),
				new SilentSphere.TriangleIndices(9, 8, 1)
			};
			int num2 = 0;
			while ((float)num2 < recursionLevel)
			{
				List<SilentSphere.TriangleIndices> list3 = new List<SilentSphere.TriangleIndices>();
				for (int i = 0; i < list2.Count; i++)
				{
					SilentSphere.TriangleIndices triangleIndices = list2[i];
					int middlePoint = SilentSphere.GetMiddlePoint(triangleIndices.v1, triangleIndices.v2, ref list, ref dictionary, radius);
					int middlePoint2 = SilentSphere.GetMiddlePoint(triangleIndices.v2, triangleIndices.v3, ref list, ref dictionary, radius);
					int middlePoint3 = SilentSphere.GetMiddlePoint(triangleIndices.v3, triangleIndices.v1, ref list, ref dictionary, radius);
					list3.Add(new SilentSphere.TriangleIndices(triangleIndices.v1, middlePoint, middlePoint3));
					list3.Add(new SilentSphere.TriangleIndices(triangleIndices.v2, middlePoint2, middlePoint));
					list3.Add(new SilentSphere.TriangleIndices(triangleIndices.v3, middlePoint3, middlePoint2));
					list3.Add(new SilentSphere.TriangleIndices(middlePoint, middlePoint2, middlePoint3));
				}
				list2 = list3;
				num2++;
			}
			mesh.vertices = list.ToArray();
			List<int> list4 = new List<int>();
			for (int j = 0; j < list2.Count; j++)
			{
				list4.Add(list2[j].v1);
				list4.Add(list2[j].v2);
				list4.Add(list2[j].v3);
			}
			mesh.triangles = list4.ToArray();
			Vector3[] vertices = mesh.vertices;
			Vector2[] array = new Vector2[vertices.Length];
			for (int k = 0; k < vertices.Length; k++)
			{
				Vector3 normalized = vertices[k].normalized;
				Vector2 vector;
				vector..ctor(0f, 0f);
				vector.x = (Mathf.Atan2(normalized.x, normalized.z) + 3.1415927f) / 3.1415927f / 2f;
				vector.y = (Mathf.Acos(normalized.y) + 3.1415927f) / 3.1415927f - 1f;
				Vector2 vector2 = vector;
				array[k] = new Vector2(vector2.x, vector2.y);
			}
			mesh.uv = array;
			Vector3[] array2 = new Vector3[list.Count];
			for (int l = 0; l < array2.Length; l++)
			{
				array2[l] = list[l].normalized;
			}
			mesh.normals = array2;
			mesh.RecalculateBounds();
			gameObject.AddComponent<MeshCollider>().sharedMesh = mesh;
			return gameObject;
		}

		// Token: 0x0200005E RID: 94
		public struct TriangleIndices
		{
			// Token: 0x0600021E RID: 542 RVA: 0x00013544 File Offset: 0x00011744
			public TriangleIndices(int v1, int v2, int v3)
			{
				this.v1 = v1;
				this.v2 = v2;
				this.v3 = v3;
			}

			// Token: 0x04000277 RID: 631
			public int v1;

			// Token: 0x04000278 RID: 632
			public int v2;

			// Token: 0x04000279 RID: 633
			public int v3;
		}
	}
}
