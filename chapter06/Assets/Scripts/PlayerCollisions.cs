using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

	enum DoorState{
		open, 
		shut,
	};

	private bool doorIsOpen = false;
	private float doorTimer = 0.0f;
	private GameObject currentDoor;

	public float doorOpenTime = 3.0f;
	public AudioClip doorOpenSound;
	public AudioClip doorShutSound;

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
		if(doorIsOpen){
			doorTimer += Time.deltaTime;
			if(doorTimer > doorOpenTime){
				MakeDoor(DoorState.shut);
				doorTimer = 0.0f;
			}				
		}
	}

	//Collision detection callback function
	void OnControllerColliderHit(ControllerColliderHit hit){
		GameObject hitObj = hit.gameObject;
		if(IsPlayerDoor(hitObj) && !doorIsOpen){
			currentDoor = hitObj;
			MakeDoor(DoorState.open);
		}
	}

	bool IsPlayerDoor(GameObject hitObj){
		return hitObj.tag == "playerDoor";
	}

	void MakeDoor(DoorState doorState){
		if(doorState == DoorState.open){
			OperateDoor(true, doorOpenSound, "dooropen");
		}else if(doorState == DoorState.shut){
			OperateDoor(false, doorShutSound, "doorshut");
		}
	}

	void OperateDoor(bool openDoor, AudioClip doorSound, string doorAnim){
		doorIsOpen = openDoor;
		currentDoor.GetComponent<AudioSource> ().PlayOneShot (doorSound);
		currentDoor.transform.parent.GetComponent<Animation> ().Play (doorAnim);
	}

}
