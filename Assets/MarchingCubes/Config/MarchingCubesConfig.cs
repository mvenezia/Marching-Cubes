using UnityEngine;

namespace MarchingCubes.Config
{
	[CreateAssetMenu(fileName = "MarchingCubesConfig", menuName = "ScriptableObjects/MarchingCubesConfig")]
	public class MarchingCubesConfig : ScriptableObject
	{
		// Scalar value that describes the position of mesh surface
		public float SurfaceLevel { get { return _surfaceLevel; } }
		[Tooltip("Scalar value that describes the position of mesh surface")]
		[SerializeField] private float _surfaceLevel;
		
		// Scalar value that describes the x, y, and z dimensions of 
		//   the cubic volume within which voxels are marched.
		public int CubicDimension { get { return _cubicDimension; } }
		[Tooltip("Scalar value that describes the x, y, and z dimensions of cubic volume within which voxels are marched")]
		[SerializeField] private int _cubicDimension;

		// Scalar value that describes the x, y, and z dimensions of a voxel
		public int VoxelDimension { get { return _voxelDimension; }}
		[Tooltip("Scalar value that describes the x, y, and z dimensions of a voxel")]
		[SerializeField] private int _voxelDimension;
	}
}
