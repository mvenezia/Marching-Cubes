using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingCubes
{
	public class MarchingCubesController : MonoBehaviour
	{
		public static MarchingCubesConfig Config { get { return _config; } }
		[SerializeField] private static MarchingCubesConfig _config;

		public static int CalculateDensity(Node[] nodes)
		{
			int triangulationIndex = 0;
			for (int i = 0; i < nodes.Length; i++)
			{
				var node = nodes[i];
				node.density = node.X; // stub
				if (node.density < _config.SurfaceLevel)
				{
					triangulationIndex |= 1 << i;
					node.isActivated = true;
				}
			}
			Debug.Log("triangulationIndex: " + triangulationIndex); // DEBUG
			return triangulationIndex;
		}
	}
}
