using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {

	enum DoorState{
		open, 
		shut,
	};

	private bool doorIsOpen = false;
	private float doorTimer = 0.0f;

	public float doorOpenTime = 3.0f;
	public AudioClip doorOpenSound;
	public AudioClip doorShutSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(doorIsOpen){
			doorTimer += Time.deltaTime;
			if(doorTimer > doorOpenTime){
				MakeDoor(DoorState.shut);
				doorTimer = 0.0f;
			}				
		}
	}

	void CheckAndOpenDoor(){
		if(!doorIsOpen){
			MakeDoor(DoorState.open);
		}
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
		GetComponent<AudioSource>().PlayOneShot (doorSound);
		transform.parent.GetComponent<Animation>().Play(doorAnim);
	}

}
