using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	static int charge;

	public AudioClip collectSound;

	//HUD——代表电力的纹理图片数组
	public Texture2D[] hudCharge;

	//去除掉chargeHudGUI，因为按照书上的去添加GUITexture纹理图片不显示
	//public GUITexture chargeHudGUI;

	public Texture2D[] meterCharge;
	public Renderer meter;

	//Use this for initialization
	void Start () {
		charge = 0;
	}
	
	//Update is called once per frame
	void Update () {
	
	}

	void PickUpCell(){
		UIManager.CheckAndActivatePowerImg();

		//GetComponent<AudioSource>().PlayOneShot(collectSound);
		AudioSource.PlayClipAtPoint(collectSound, transform.position);

		charge++;

		UIManager.ChangePowerImg(hudCharge[charge]);
		meter.material.mainTexture = meterCharge[charge];

		if(FinishedCollectCharge()){
			TriggerZone.ChangeDoorLight(Color.green);
		}
	}

	public static bool FinishedCollectCharge(){
		//print(charge);
		return charge == 4;
	}

	public static bool AtLeastOneCharge(){
		return charge > 0 && charge < 4;
	}

}
