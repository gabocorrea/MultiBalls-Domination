using UnityEngine;
using System.Collections;

public class changeMaterial : MonoBehaviour {


	public void changeMat(Material mat)
	{
		GetComponent<Renderer> ().material = mat;
	}
}
