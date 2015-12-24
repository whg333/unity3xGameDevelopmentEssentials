using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {

	public AudioClip lockedSound;

	private UnityEngine.UI.RawImage powerImg;
	public Light doorLight;

	public UnityEngine.UI.Text hintsText;
	private float hintsTimer = 0.0f;

	// Use this for initialization
	void Start () {
		//需要了解一下引擎类的继承体系结构了，否则都是靠猜测和查API去写代码
		GameObject canvas = GameObject.FindWithTag("Canvas");
		//canvas..transform.FindChild ("powerImg").gameObject;
		powerImg = canvas.GetComponentInChildren<UnityEngine.UI.RawImage>();
		hintsText = canvas.GetComponentInChildren<UnityEngine.UI.Text>();
		doorLight.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		if(hintsText.enabled){
			hintsTimer += Time.deltaTime;
			if(hintsTimer >= 4){
				hintsText.enabled = false;
				hintsTimer = 0.0f;
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			if (Inventory.FinishedCollectCharge ()) {
				transform.FindChild ("door").SendMessage ("CheckAndOpenDoor");
				if (powerImg != null && powerImg.enabled) {
					Destroy (powerImg);
					doorLight.color = Color.green;
				}
			}else if(Inventory.AtLeastOneCharge()){
				PlayLockedSound();
				ShowHints("门还不能打开。。。\n\n能源指示器显示能源还未足够。。。\n\n继续收集足够的能源来开启此门。。。");
			}else{
				PlayLockedSound();
				ShowHints("这是一扇锁住的门。。。\n\n门旁边有个能源收集指示器。。。\n\n看来需要收集足够的能源来开启此门。。。");
				col.gameObject.SendMessage("CheckAndActivatePowerImg");
			}
		}
	}

	void PlayLockedSound(){
		transform.FindChild("door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
	}

	void ShowHints(string hints){
		hintsText.text = hints;
		if(!hintsText.enabled){
			hintsText.enabled = true;
		}
	}

}
