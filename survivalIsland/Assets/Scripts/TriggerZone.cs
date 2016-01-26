using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {

	public static Light doorLight;

	public AudioClip lockedSound;

	// Use this for initialization
	void Start () {
		doorLight = GameObject.FindWithTag("doorLight").GetComponent<Light>();
		doorLight.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			if (Inventory.FinishedCollectCharge ()) {
				transform.FindChild ("door").SendMessage ("CheckAndOpenDoor");
				GUIManager.CheackAndDestoryPowerImg();
			}else if(Inventory.AtLeastOneCharge()){
				PlayLockedSound();
				GUIManager.ShowHints("门还不能打开。。。\n\n能源指示器显示能源还未足够。。。\n\n继续收集足够的能源来开启此门。。。");
			}else{
				PlayLockedSound();
				GUIManager.ShowHints("这是一扇锁住的门。。。\n\n门旁边有个能源收集指示器。。。\n\n看来需要收集足够的能源来开启此门。。。");
				GUIManager.CheckAndActivatePowerImg();
			}
		}
	}

	void PlayLockedSound(){
		transform.FindChild("door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
	}

	public static void ChangeDoorLight(Color c){
		doorLight.color = c;
	}

}
