using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	bool isMenuVisible = false;

	// Use this for initialization
	void Start () {
		Connect ();
	}
	
	void Connect() {
		PhotonNetwork.ConnectUsingSettings("1.0.0");

	}

	void MyJoinRoom() {
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed() {
		Debug.Log("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom(null);
	}

	void OnGUI() {
		GUILayout.Label( PhotonNetwork.connectionState.ToString() );
		if (isMenuVisible) {
			if(GUILayout.Button("Join a Random Room")) {
				MyJoinRoom();
				isMenuVisible = false;
			}
		}
	}

	void OnJoinedLobby() {
		Debug.Log("OnJoinedLobby");

		bool showAButton = false;
		if (showAButton) {
			isMenuVisible = true;
		}
		else {
			MyJoinRoom();
		}

	}

	void OnJoinedRoom() {
		Debug.Log ("OnJoinedRoom");
		SpawnMyPlayer();
	}

	void SpawnMyPlayer() {
		GameObject spawnLocationObject = GameObject.Find ("SpawnLocation");
		GameObject player = PhotonNetwork.Instantiate("RollerBall", spawnLocationObject.transform.position, spawnLocationObject.transform.rotation, 0);

		//Esto creo que no va: player.GetComponent<NetworkCharacter>().enabled = false;

		player.GetComponent<UnityStandardAssets.Vehicles.Ball.BallUserControl>().enabled = true;

		float myrand = Random.Range(0.0f,1.0f);
		if(myrand < 0.33f){
			player.GetComponent<Renderer>().material.mainTexture = (Texture2D)Resources.Load("img/blue");
		} else if( myrand < 0.66f) {
			player.GetComponent<Renderer>().material.mainTexture = (Texture2D)Resources.Load("img/red");
		} else {
			player.GetComponent<Renderer>().material.mainTexture = (Texture2D)Resources.Load("img/green");
		}
	}
}
