using UnityEngine;
using System.Collections;

public class WinGame : MonoBehaviour {

	public GameObject winSequence;
	public GUITexture fader;
	public AudioClip winClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator GameOver(){
		AudioSource.PlayClipAtPoint(winClip, transform.position);
		Instantiate(winSequence);
		yield return new WaitForSeconds(8.0f);
		Instantiate(fader);
	}

}
