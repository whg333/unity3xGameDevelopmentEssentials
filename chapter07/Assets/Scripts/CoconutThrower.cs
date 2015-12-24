using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class CoconutThrower : MonoBehaviour {

	public AudioClip throwSound;
	public Rigidbody coconutPrefab;
	public float throwSpeed = 30.0f;

	public static string NAME = "coconut";

	private static bool canThrow = false;
	private static UnityEngine.UI.RawImage crosshairImg;

	// Use this for initialization
	void Start () {
		GameObject canvas = GameObject.FindWithTag("Canvas");
		crosshairImg = canvas.GetComponentsInChildren<UnityEngine.UI.RawImage>()[1];
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp("Fire1") && canThrow){
			GetComponent<AudioSource>().PlayOneShot(throwSound);
			ThrowCoconut();
		}
	}

	void ThrowCoconut(){
		Rigidbody newCoconut = Instantiate(coconutPrefab, transform.position, transform.rotation) as Rigidbody;
		newCoconut.name = NAME;
		newCoconut.velocity = transform.forward * throwSpeed;
	}

	public static void CanThrow(){
		canThrow = true;
		crosshairImg.enabled = true;
	}

	public static void CannotThrow(){
		canThrow = false;
		crosshairImg.enabled = false;
	}

}
