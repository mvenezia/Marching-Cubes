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
		public float X { get { return transform.position.x; } }
		public float Y { get { return transform.position.y; } }
		public float Z { get { return transform.position.z; } }
		public Vector3 Position  { get { return transform.position; } }

		public bool IsBelowOrOnSurface
		{
			get { return isBelowOrOnSurface; }
			set { isBelowOrOnSurface = value; if (value) debugSphere.materials[0].color = Color.black; }
		}

		private bool isBelowOrOnSurface;

		[SerializeField] private MeshRenderer debugSphere;
	}
}
