using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ReverseListTool : MonoBehaviour
{
	public static int[][] temp = new int[5][]
	{
		new [] {2, 3, 8, 2, 8, 10, 0, 1, 8, 1, 10, 8},
		new [] {1, 10, 2},
		new [] {1, 3, 8, 9, 1, 8},
		new [] {0, 9, 1},
		new [] {0, 3, 8},
	};

	void Awake()
	{
		string path = "../../../Desktop/output.txt";
		using (StreamWriter sw = File.CreateText(path))
		{
			foreach (var arr in temp)
			{
				int[] revArr = arr.Reverse().ToArray();
				string revString = "";
				foreach (var num in revArr)
				{
					revString += (num + ", ");
				}
				sw.WriteLine("new [] {" + revString + "},");
			}
		}
	}
}
