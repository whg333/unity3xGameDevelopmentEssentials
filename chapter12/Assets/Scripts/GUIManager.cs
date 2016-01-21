using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	private static GUITexture powerImg;
	private static GUITexture crosshairImg;
	private static GUITexture matchImg;

	private float hintsTimer = 0.0f;
	private static GUIText hintsText;

	// Use this for initialization
	void Start () {
		GUITexture[] hudGUIs = GetComponentsInChildren<GUITexture>();
		powerImg = hudGUIs[0];
		crosshairImg = hudGUIs[1];
		matchImg = hudGUIs[2];
		hintsText = GetComponentInChildren<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		CheckAndDisableHintsText();
	}

	private void CheckAndDisableHintsText(){
		if(hintsText.enabled){
			hintsTimer += Time.deltaTime;
			if(hintsTimer >= 4){
				hintsText.enabled = false;
				hintsTimer = 0.0f;
			}
		}
	}

	public static void CheckAndActivatePowerImg(){
		if(!powerImg.enabled){
			powerImg.enabled = true;
		}
	}

	public static void CheackAndDestoryPowerImg(){
		if (powerImg != null && powerImg.enabled) {
			Destroy(powerImg);
			//应该在收集完毕能源后门上的灯直接变绿，而不是等等碰撞的时候才变绿
			//TriggerZone.ChangeDoorLight(Color.green);
		}
	}

	public static void ChangePowerImg(Texture2D texture){
		//chargeHudGUI.texture = hudCharge[charge];
		//print(powerImg);
		//下面不能写成powerImg.material.mainTexture
		powerImg.texture = texture;
	}

	public static void ShowHints(string hints){
		hintsText.text = hints;
		if(!hintsText.enabled){
			hintsText.enabled = true;
		}
	}

	public static void EnableCrosshairImg(){
		crosshairImg.enabled = true;
	}

	public static void DisableCrosshairImg(){
		crosshairImg.enabled = false;
	}

	public static void EnableMatchImg(){
		matchImg.enabled = true;
	}

	public static void DestoryMatchImg(){
		Destroy(matchImg);
	}
}

