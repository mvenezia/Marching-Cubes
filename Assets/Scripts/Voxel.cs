using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO Need func that will appropriately orient Nodes 0-8 in proper relation with each other before any calculations.
// 		this func will likely be called externally as part of a dynamic calculation of voxels.

namespace MarchingCubes
{
	public class Voxel : MonoBehaviour
	{
		[SerializeField] private Node[] _nodes = new Node[8];
		private int _voxelCase = 0;
		private List<Vector3> _vertices;

		public void CalculateVoxelCase()
		{
			foreach (Node node in _nodes)
			{
				_voxelCase = MarchingCubesController.CalculateDensity(_nodes);
			}
		}

		// Potentially outsource code logic to controller
		public void CalculateFacets()
		{
			Vector3[] vertices = new Vector3[12];
			int edgeCase = Table.EdgeTable[_voxelCase];

			if (edgeCase == 0)
			{
				return;
			}
			if ((edgeCase & 1) == 1) // TODO associate proper nodes to edges
			{
				vertices[0] = new Vector3(); // stub
			}
			if ((edgeCase & 2) == 1)
			{
				vertices[1] = new Vector3(); // stub
			}
			if ((edgeCase & 4) == 1)
			{
				vertices[2] = new Vector3(); // stub
			}
			if ((edgeCase & 8) == 1)
			{
				vertices[3] = new Vector3(); // stub
			}
			if ((edgeCase & 16) == 1)
			{
				vertices[4] = new Vector3(); // stub
			}
			if ((edgeCase & 32) == 1)
			{
				vertices[5] = new Vector3(); // stub
			}
			if ((edgeCase & 64) == 1)
			{
				vertices[6] = new Vector3(); // stub
			}
			if ((edgeCase & 128) == 1)
			{
				vertices[7] = new Vector3(); // stub
			}
			if ((edgeCase & 256) == 1)
			{
				vertices[8] = new Vector3(); // stub
			}
			if ((edgeCase & 512) == 1)
			{
				vertices[9] = new Vector3(); // stub
			}
			if ((edgeCase & 1024) == 1)
			{
				vertices[10] = new Vector3(); // stub
			}
			if ((edgeCase & 2048) == 1)
			{	
				vertices[11] = new Vector3(); // stub
			}

			// TODO replace above if garbage with single lookup to tri table
			// and map edges to node corners. Calculate positions per edge by
			// node corners and append Vector3 to some list of vertices.
		}

		/*
		foreach (int edgeIndex in triangulation)
		{
			int[] cornerNodeIndices = Table.edgeIndexToNodeIndices[edgeIndex];
			Vector3 surfaceIntersection = (edgeNodeIndices[0] + edgeNodeIndices[1]) / 2;
			
			// Node belowSurface;
			// Node aboveSurface;
			// Node[] cornerNodes = { Table.nodeIndexToNode[cornerNodeIndices[0]], Table.nodeIndexToNode[cornerNodeIndices[1]] };
			//
			// if (cornerNodes[0].isActivated)
			// {
			//		belowSurface = cornerNodes[0];
			//		aboveSurface = cornerNodes[1];
			// }
			// else
			// {
			// 		belowSurface = cornerNodes[1];
			//		aboveSurface = cornerNodes[0];
			// }
			//
			// float interpolant = (MarchingCubesConfig.SurfaceLevel - belowSurface.density) / (aboveSurface.density - belowSurface.density);
			// Vector3 surfaceIntersection = Vector3.Lerp(belowSurface, aboveSurface, interpolant);
		}

		_vertices.Add(surfaceIntersection);
		*/
	
		
	}		
}
