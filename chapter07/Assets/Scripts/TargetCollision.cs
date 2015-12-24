using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class TargetCollision : MonoBehaviour {

	private bool beenHit = false;
	private Animation targetRoot;
	public AudioClip hitSound;
	public AudioClip resetSound;
	public float resetTime = 3.0f;

	private AudioSource iAudio;

	// Use this for initialization
	void Start () {
		targetRoot = transform.parent.transform.parent.GetComponent<Animation>();
		iAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if(!beenHit && col.gameObject.name == CoconutThrower.NAME){
			StartCoroutine("targetHit");
		}
	}

	IEnumerator targetHit(){
		iAudio.PlayOneShot(hitSound);
		targetRoot.Play("down");
		beenHit = true;
		CoconutWin.IncrTargets();

		yield return new WaitForSeconds(resetTime);

		iAudio.PlayOneShot(resetSound);
		targetRoot.Play("up");
		beenHit = false;
		CoconutWin.DecrTargets();
	}

}
