using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class MainMenuBtns : MonoBehaviour {

	public string levelToLoad;

	public Texture2D normalTexture;
	public Texture2D rollOverTexture;
	public AudioClip beep;

	public bool isQuitBtn = false;

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
		yield return new WaitForSeconds(0.35f);
		if(isQuitBtn){
			//UnityEditor.EditorApplication.isPlaying = false; //编辑器模式下退出
			Application.Quit();
			//print("This print part works!");
			//Debug.Log("This Debug part works!");
		}else{
			//切换场景的时候没有天空盒光线效果，这个问题慢慢寻找解决方案
			//Application.LoadLevelAdditive(levelToLoad);
			//Application.LoadLevel(levelToLoad);
			//Application.LoadLevelAsync(levelToLoad);

			UnityEngine.SceneManagement.SceneManager.LoadScene(levelToLoad);
		}
	}

}
