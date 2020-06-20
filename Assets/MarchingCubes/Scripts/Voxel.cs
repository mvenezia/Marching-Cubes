using System;
using System.Collections.Generic;
using UnityEngine;
using MarchingCubes.Config;

namespace MarchingCubes
{
	public class Voxel : MonoBehaviour
	{
		private Node[] _nodes = new Node[8];
		private int _voxelCase;
		private List<Vector3> _vertices;

		private void Awake()
		{
			InitializeNodes();
		}

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

		private void InitializeNodes()
		{
			if (transform.childCount != 8)
			{
				Debug.LogError("There must be precisely 8 children (Nodes) to a voxel.");
				return;
			}
			
			for (int i = 0; i < 8; i++)
			{
				Node node = transform.GetChild(i).GetComponent<Node>();
				if (node == null)
				{
					Debug.LogError("All children of a voxel must have a Node component.");
					return;
				}
				
				_nodes[i]= node;
			}
		}
	}		
}
