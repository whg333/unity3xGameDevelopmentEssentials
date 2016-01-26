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
	private string menuPage = "main";
	public Rect instructions;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

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
		//print("MainMenuGUI OnGUI...");
		GUI.skin = menuSkin;
		GUI.BeginGroup(menuAreaNormalized);

		if(menuPage == "main"){
			if(Application.CanStreamedLevelBeLoaded ("IsLand")){
				if (GUI.Button (new Rect(playBtn), "开始")) {
					StartCoroutine("ButtonAction", "Island");
				}
			}else{
				float percentLoaded = Application.GetStreamProgressForLevel(1) * 100;
				GUI.Box (new Rect (playBtn), "Loading..." + percentLoaded + "% Loaded");
			}

			if(Application.platform != RuntimePlatform.OSXWebPlayer
				&& Application.platform != RuntimePlatform.WindowsWebPlayer){
				if(GUI.Button(new Rect(quitBtn), "退出")){
					StartCoroutine("ButtonAction", "quit");
				}
			}

			if(GUI.Button(new Rect(instBtn), "游戏说明")){
				PlayBeepSound();
				menuPage = "inst";
			}
		}else if(menuPage == "inst"){
			GUI.Label(
				new Rect(instructions), 
				"你醒来后发现自己身处荒岛上。。。" +
				"唯一逃离荒岛的方式是想方设法点燃火把冒烟发出求救信号！"
			);
			if(GUI.Button(new Rect(quitBtn), "返回")){
				PlayBeepSound();
				menuPage = "main";
			}
		}

		GUI.EndGroup();
	}

	IEnumerator ButtonAction(string levelName){
		PlayBeepSound();
		yield return new WaitForSeconds(0.35f);

		if (levelName == "quit") {
			//UnityEditor.EditorApplication.isPlaying = false; //编辑器模式下退出
			Application.Quit();
		} else {
			//Application.LoadLevel(levelName);
			UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
		}
	}

	void PlayBeepSound(){
		GetComponent<AudioSource>().PlayOneShot(beep);
	}

}
