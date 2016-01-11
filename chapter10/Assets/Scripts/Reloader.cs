using UnityEngine;
using System.Collections;

public class Reloader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Reload(){
		UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
	}

}
