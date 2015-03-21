using UnityEngine;
using System.Collections;

public class collider : MonoBehaviour {

	public GameObject baseObj;

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "RollerBall(Clone)") {
			baseObj.GetComponent<changeMaterial>().changeMat(col.gameObject.GetComponent<Renderer>().material);
		}
	}
}
