using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {

	public AudioClip lockedSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			if(Inventory.IsFinishedCollect()){
				transform.FindChild("door").SendMessage("CheckAndOpenDoor");
			}else{
				//warn info In Window GUI
				transform.FindChild("door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
				col.gameObject.SendMessage("CheckAndActivatePowerImg");
			}
		}
	}

}
