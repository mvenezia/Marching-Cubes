using System.Collections.Generic;
using UnityEngine;
using MarchingCubes.Config;

namespace MarchingCubes
{
	public class MarchingCubesController : MonoBehaviour
	{
		public GameObject volumePrefab;
		public MarchingCubesConfig Config { get { return _config; } }
		[SerializeField] private MarchingCubesConfig _config;

		public static List<Vector3> MeshVertices
		{
			get { return _meshVertices; }
		}
		private static List<Vector3> _meshVertices = new List<Vector3>();

		public static List<int> MeshTriangles
		{
			get { return _meshTriangles; }
		}
		private static List<int> _meshTriangles = new List<int>();

		public static MarchingCubesController Instance { get { return _instance; } }
		private static MarchingCubesController _instance;

		public int CalculateDensity(Node[] nodes)
		{
			int voxelCase = 0;
			for (int i = 0; i < nodes.Length; i++)
			{
				var node = nodes[i];
				node.density = DensityFunction(node.Position);
				if (node.density <= _config.SurfaceLevel)
				{
					voxelCase |= 1 << i;
					node.IsBelowOrOnSurface = true;
				}
			}
			return voxelCase;
		}

		public void Awake()
		{
			if (_instance != null && _instance != this)
			{
				Destroy(_instance);
			}
			else
			{
				_instance = this;
			}

			InitializeVolume();
		}

		private void InitializeVolume()
		{
			var volume = Instantiate(volumePrefab).GetComponent<Volume>();
			volume.March();
			Mesh mesh = new Mesh();
			mesh.vertices = _meshVertices.ToArray();
			mesh.triangles = _meshTriangles.ToArray();
			GetComponent<MeshFilter>().mesh = mesh;
		}

		private float DensityFunction(Vector3 nodePos)
		{
			return nodePos.y + nodePos.x;
		}
	}
}
