using UnityEngine;
using System.Collections;

public class FadeWhite : MonoBehaviour{

	// Use this for initialization
	void Start(){
		Rect currentRect = new Rect(
			-Screen.width * 0.5f, 
			-Screen.height * 0.5f,
			Screen.width,
			Screen.height
		);
		GetComponent<GUITexture>().pixelInset = currentRect;
	}
	
	// Update is called once per frame
	void Update(){
	
	}
}

