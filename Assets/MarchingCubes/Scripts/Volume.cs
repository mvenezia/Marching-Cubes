using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingCubes
{
	public class Volume : MonoBehaviour
	{
		private List<Voxel> _voxels = new List<Voxel>();
		

		private void Awake()
		{
			InitializeVoxels();
		}

		public void March()
		{
			foreach (var voxel in _voxels)
			{
				voxel.March();
			}
		}

		private void InitializeVoxels()
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				Voxel voxel = transform.GetChild(i).GetComponent<Voxel>();
				if (voxel == null)
				{
					Debug.LogError("All children of a volume must have a Voxel component.");
					return;
				}

				_voxels.Add(voxel);
			}
		}
	}	
}