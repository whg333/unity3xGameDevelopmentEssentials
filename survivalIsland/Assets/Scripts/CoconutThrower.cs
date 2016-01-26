using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class CoconutThrower : MonoBehaviour {

	public const string NAME = "coconut";

	public AudioClip throwSound;
	public Rigidbody coconutPrefab;
	public float throwSpeed = 30.0f;

	private static bool canThrow = false;

	// Use this for initialization
	void Start () {

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
		GUIManager.EnableCrosshairImg();
	}

	public static void CannotThrow(){
		canThrow = false;
		GUIManager.DisableCrosshairImg();
	}

}
