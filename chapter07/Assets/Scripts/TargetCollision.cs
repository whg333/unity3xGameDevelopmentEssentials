using UnityEngine;
using System.Collections;

public class TargetCollision : MonoBehaviour {

	private bool beenHit = false;
	private Animation targetRoot;
	public AudioClip hitSound;
	public AudioClip resetSound;
	public float resetTime = 3.0f;

	// Use this for initialization
	void Start () {
		targetRoot = transform.parent.transform.parent.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if(!beenHit && col.gameObject.name == CoconutThrower.NAME){

		}
	}

	//IEnumerator targetHit(){

	//}

}
