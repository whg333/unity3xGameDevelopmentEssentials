using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			transform.FindChild("door").SendMessage("CheckAndOpenDoor");
		}
	}

}
