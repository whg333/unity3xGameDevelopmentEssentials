using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class MainMenuGUI : MonoBehaviour {

	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect playBtn;
	public Rect quitBtn;
	public Rect instBtn;

	private Rect menuAreaNormalized;

	// Use this for initialization
	void Start () {
		menuAreaNormalized = new Rect( 
			menuArea.x*Screen.width - (menuArea.width*0.5f),
			menuArea.y*Screen.height - (menuArea.height*0.5f),
			menuArea.width, 
			menuArea.height
		);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.skin = menuSkin;
		GUI.BeginGroup(menuAreaNormalized);
		if(GUI.Button(new Rect(playBtn), "Play")){
			StartCoroutine("ButtonAction", "Island");
		}
		if(GUI.Button(new Rect(quitBtn), "Quit")){
			StartCoroutine("ButtonAction", "quit");
		}
		if(GUI.Button(new Rect(instBtn), "Instructions")){
			
		}
		GUI.EndGroup();
	}

	IEnumerator ButtonAction(string levelName){
		GetComponent<AudioSource>().PlayOneShot(beep);
		yield return new WaitForSeconds(0.35f);

		if (levelName == "quit") {
			UnityEditor.EditorApplication.isPlaying = false; //编辑器模式下退出
			Application.Quit();
		} else {
			Application.LoadLevel(levelName);
		}
	}

}
