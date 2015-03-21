using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {
			// Do Nothing -- the character motor / input is movin us
		} else {
			transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f); //TODO 0.1 makes movement little bit diferent between my client side vs other players
			transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f); //TODO 0.1 makes movement ...
		}
	}

	void OnPhotonSerializeView(PhotonStream stream , PhotonMessageInfo info) {

		if(stream.isWriting) {
			// This is OUR player.  We send our actual position to the network
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		}
		else {
				// This is other's players position. we receive it and update it
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();
		}
	}
}
