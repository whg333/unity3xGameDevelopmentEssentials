using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class CoconutWin : MonoBehaviour {

	private static int targets = 0;
	private static bool hadWon = false;

	public AudioClip winSound;
	public GameObject cellPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!hadWon && targets == 3){
			targets = 0;
			GetComponent<AudioSource>().PlayOneShot(winSound);
			GameObject winCell = transform.Find("powerCell").gameObject;
			winCell.transform.Translate(-1, 0, 0);
			Instantiate(cellPrefab, winCell.transform.position, transform.rotation);
			Destroy(winCell);
			hadWon = true;
		}
	}

	public static void IncrTargets(){
		targets++;
	}

	public static void DecrTargets(){
		targets--;
	}

}
