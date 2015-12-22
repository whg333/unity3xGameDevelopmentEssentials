using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {

	public AudioClip lockedSound;

	private UnityEngine.UI.RawImage powerImg;
	public Light doorLight;

	// Use this for initialization
	void Start () {
		GameObject canvas = GameObject.FindWithTag("Canvas");
		//canvas..transform.FindChild ("powerImg").gameObject;
		powerImg = canvas.GetComponentInChildren<UnityEngine.UI.RawImage> ();
		doorLight.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			if(Inventory.IsFinishedCollect()){
				transform.FindChild("door").SendMessage("CheckAndOpenDoor");
				if(powerImg.enabled){
					Destroy(powerImg);
					doorLight.color = Color.green;
				}
			}else{
				//warn info In Window GUI
				transform.FindChild("door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
				col.gameObject.SendMessage("CheckAndActivatePowerImg");
			}
		}
	}

}
