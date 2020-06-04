using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarchingCubes
{
	public class Node : MonoBehaviour
	{
		public float density;
		public float X { get { return transform.position.x; } }
		public float Y { get { return transform.position.y; } }
		public float Z { get { return transform.position.z; } }
		public bool isActivated;
	}
}
