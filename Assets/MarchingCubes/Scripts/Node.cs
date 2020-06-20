using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingCubes
{
	
	// Can prob not inherit monoB once we drop use of Node GOs and
	// calculate positions instead.
	public class Node : MonoBehaviour
	{
		[HideInInspector] public float density;
		public Vector3 Position  { get { return transform.position; } }

		public bool IsBelowOrOnSurface
		{
			get { return _isBelowOrOnSurface; }
			set { _isBelowOrOnSurface = value; if (value) debugSphere.materials[0].color = Color.black; }
		}

		private bool _isBelowOrOnSurface;

		[SerializeField] private MeshRenderer debugSphere;
	}
}
