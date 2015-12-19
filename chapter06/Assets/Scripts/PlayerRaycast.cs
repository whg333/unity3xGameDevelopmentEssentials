using UnityEngine;
using System.Collections;

public class PlayerRaycast : MonoBehaviour {

	private GameObject currentDoor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, 3)){
			GameObject hitObj = hit.collider.gameObject;
			if(IsPlayerDoor(hitObj)){
				currentDoor = hitObj;
				currentDoor.SendMessage("CheckAndOpenDoor");
			}
		}
	}

	bool IsPlayerDoor(GameObject hitObj){
		return hitObj.tag == "playerDoor";
	}

}
