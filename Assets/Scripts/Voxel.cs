using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO Need func that will appropriately orient Nodes 0-8 in proper relation with each other before any calculations.
// 		this func will likely be called externally as part of a dynamic calculation of voxels.

namespace MarchingCubes
{
	public class Voxel : MonoBehaviour
	{
		// Nodes MUST be stored in ASC order of vertex id as CalculateDensity
		// assumes the node at _nodes[0] is vertex 0 and therefore has a relationship
		// with certain edges.
		[SerializeField] private Node[] _nodes = new Node[8];
		private int _voxelCase;
		private List<Vector3> _vertices;

		public void March()
		{
			CalculateVoxelCase();
			
			Debug.Log("_voxelCase..." + _voxelCase);
			
			CalculateMeshVertices();
		}

		private void CalculateVoxelCase()
		{
			_voxelCase = MarchingCubesController.Instance.CalculateDensity(_nodes);
		}

		private void CalculateMeshVertices()
		{
			int[] edgesToIntersect = Table.TriTable[_voxelCase];

			foreach (int edge in edgesToIntersect)
			{
				if (edge == -1)
					return;
				
				int[] cornerNodeIndices = Table.EdgeToCorners[edge];
				Vector3 cornerPositionA = _nodes[cornerNodeIndices[0]].Position;
				Vector3 cornerPositionB = _nodes[cornerNodeIndices[1]].Position;
				Vector3 intersectionPosition = (cornerPositionA + cornerPositionB) / 2;

				MarchingCubesController.MeshVertices.Add(intersectionPosition);
				
				var vertDebug = Instantiate(MarchingCubesController.Instance.vertDebugPrefab);
				vertDebug.transform.position = intersectionPosition;
				vertDebug.transform.GetChild(0).gameObject.GetComponent<Text>().text =
					(MarchingCubesController.MeshVertices.Count - 1).ToString();
				
				MarchingCubesController.MeshTriangles.Add(MarchingCubesController.MeshVertices.Count - 1);
			}
		}

		private Vector3 InterpolateToIntersection(int[] cornerNodeIndices)
		{
			Node cornerNodeA = _nodes[cornerNodeIndices[0]];
			Node cornerNodeB = _nodes[cornerNodeIndices[1]];
			
			Node belowSurface;
			Node aboveSurface;

			if (cornerNodeA.IsBelowOrOnSurface)
			{
					belowSurface = cornerNodeA;
					aboveSurface = cornerNodeB;
			}
			else
			{
					belowSurface = cornerNodeB;
					aboveSurface = cornerNodeA;
			}
			
			float interpolant = (MarchingCubesController.Instance.Config.SurfaceLevel - belowSurface.density) / (aboveSurface.density - belowSurface.density);
			return Vector3.Lerp(belowSurface.Position, aboveSurface.Position, interpolant);
		}
	}		
}
