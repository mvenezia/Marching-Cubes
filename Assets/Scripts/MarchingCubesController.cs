using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingCubes
{
	public class MarchingCubesController : MonoBehaviour
	{
		public GameObject voxelPrefab;
		public GameObject vertDebugPrefab;
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
				node.density = node.X; // stub
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
		}

		public void Start()
		{
			var voxel = Instantiate(voxelPrefab).GetComponent<Voxel>();
			var voxel2 = Instantiate(voxelPrefab).GetComponent<Voxel>();
			var voxel3 = Instantiate(voxelPrefab).GetComponent<Voxel>();
			voxel2.transform.position = new Vector3(0, 0, 1);
			voxel3.transform.position = new Vector3(0, 0, 2);
			
			voxel.March();
			voxel2.March();
			voxel3.March();

			Mesh mesh = new Mesh();
			GetComponent<MeshFilter>().mesh = mesh;
			mesh.vertices = _meshVertices.ToArray();
			mesh.triangles = _meshTriangles.ToArray();
			mesh.RecalculateNormals();
		}
	}
}
