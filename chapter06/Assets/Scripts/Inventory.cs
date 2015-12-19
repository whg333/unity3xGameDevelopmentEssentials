using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	static int charge;

	public AudioClip collectSound;

	// Use this for initialization
	void Start () {
		charge = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PickUpCell(){
		//GetComponent<AudioSource>().PlayOneShot(collectSound);
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		charge++;
	}

	public static bool IsFinishedCollect(){
		//print(charge);
		return charge == 4;
	}

}
