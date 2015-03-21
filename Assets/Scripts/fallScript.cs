using UnityEngine;
using System.Collections;

public class fallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -10) {
			transform.position = new Vector3(0,4,-7);
		}
	}
}
