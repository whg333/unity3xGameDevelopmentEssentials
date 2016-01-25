using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public GUITexture faderWhite;

	public GUIText key;
	public GUIText info;

	// Use this for initialization
	void Start () {
		Instantiate(info);
		Instantiate(key);
		Instantiate(faderWhite);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
