using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingCubes
{
	[CreateAssetMenu(fileName = "MarchingCubesConfig", menuName = "ScriptableObjects/MarchingCubesConfig")]
	public class MarchingCubesConfig : ScriptableObject
	{
		public float SurfaceLevel { get { return _surfaceLevel; } }
		[SerializeField] private float _surfaceLevel;


		public int CubicDimension { get { return _cubicDimension; } }
		[SerializeField] private int _cubicDimension;

		public int VoxelDimension { get { return _voxelDimension; }}
		[SerializeField] private int _voxelDimension;
	}
}
