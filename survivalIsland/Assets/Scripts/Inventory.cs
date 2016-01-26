using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class Inventory : MonoBehaviour {

	static int charge;

	public AudioClip collectSound;

	//HUD——代表电力的纹理图片数组
	public Texture2D[] hudCharge;

	//去除掉chargeHudGUI，因为按照书上的去添加GUITexture纹理图片不显示
	//public GUITexture chargeHudGUI;

	public Texture2D[] meterCharge;
	public Renderer meter;

	private bool hadMatch = false;
	private bool hadLightFire = false;

	public GameObject winObj;

	//Use this for initialization
	void Start () {
		charge = 0;
	}
	
	//Update is called once per frame
	void Update () {
	
	}

	void PickUpCell(){
		GUIManager.CheckAndActivatePowerImg();

		//GetComponent<AudioSource>().PlayOneShot(collectSound);
		AudioSource.PlayClipAtPoint(collectSound, transform.position);

		charge++;

		GUIManager.ChangePowerImg(hudCharge[charge]);
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

	void PickUpMatch(){
		hadMatch = true;
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		GUIManager.EnableMatchImg();
	}

	void OnControllerColliderHit(ControllerColliderHit col){
		if(col.gameObject.name == "campfire"){
			if(!hadLightFire){
				if (hadMatch) {
					LightFire (col.gameObject);
				} else {
					GUIManager.ShowHints ("不能点燃火把。。。\n\n因为没有找到火柴。。。\n\n继续寻找火柴来点燃火把求救。。。");
				}
			}
		}
	}

	void LightFire(GameObject campfire){
		ParticleSystem[] particleSystems = campfire.GetComponentsInChildren<ParticleSystem>();
		foreach(ParticleSystem particleSystem in particleSystems){
			//这里必须保存ParticleSystem.EmissionModule在一个临时变量（例如下例em）里面，否则Unity会报CS1612错
			ParticleSystem.EmissionModule em = particleSystem.emission;
			em.enabled = true;
		}
		campfire.GetComponent<AudioSource>().Play();
		GUIManager.DestoryMatchImg();
		hadMatch = false;
		hadLightFire = true;
		winObj.SendMessage("GameOver");
	}

}
