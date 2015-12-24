using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	static int charge;

	public AudioClip collectSound;

	//HUD——代表电力的纹理图片数组
	public Texture2D[] hudCharge;

	//去除掉chargeHudGUI，因为按照书上的去添加GUITexture纹理图片不显示
	//public GUITexture chargeHudGUI;

	//powerImg
	private UnityEngine.UI.RawImage powerImg;

	public Texture2D[] meterCharge;
	public Renderer meter;

	//Use this for initialization
	void Start () {
		charge = 0;

		//需要了解一下引擎类的继承体系结构了，否则都是靠猜测和查API去写代码
		GameObject canvas = GameObject.FindWithTag("Canvas");
		//canvas..transform.FindChild ("powerImg").gameObject;
		powerImg = canvas.GetComponentInChildren<UnityEngine.UI.RawImage> ();
	}
	
	//Update is called once per frame
	void Update () {
	
	}

	void PickUpCell(){
		CheckAndActivatePowerImg ();

		//GetComponent<AudioSource>().PlayOneShot(collectSound);
		AudioSource.PlayClipAtPoint(collectSound, transform.position);

		charge++;

		//chargeHudGUI.texture = hudCharge[charge];
		//print(powerImg);
		//下面不能写成powerImg.material.mainTexture
		powerImg.texture = hudCharge[charge];

		meter.material.mainTexture = meterCharge[charge];
	}

	public static bool FinishedCollectCharge(){
		//print(charge);
		return charge == 4;
	}

	public static bool AtLeastOneCharge(){
		return charge > 0 && charge < 4;
	}

	void CheckAndActivatePowerImg(){
		if(!powerImg.enabled){
			powerImg.enabled = true;
		}
	}

}
