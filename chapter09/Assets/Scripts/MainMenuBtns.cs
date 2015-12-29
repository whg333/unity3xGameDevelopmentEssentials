using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class MainMenuBtns : MonoBehaviour {

	public string levelToLoad;
	public Texture2D normalTexture;
	public Texture2D rollOverTexture;
	public AudioClip beep;

	// Use this for initialization
	void Start () {
		//print("MainMenuBtns Start...");
	}

	void OnMouseEnter(){
		//print("MainMenuBtns OnMouseEnter...");
		GetComponent<GUITexture>().texture = rollOverTexture;
	}

	void OnMouseExit(){
		//print("MainMenuBtns OnMouseExit...");
		GetComponent<GUITexture>().texture = normalTexture;
	}

	IEnumerator OnMouseUp(){
		GetComponent<AudioSource>().PlayOneShot(beep);
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevelAdditive(levelToLoad);
	}

}
