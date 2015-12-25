using UnityEngine;
using System.Collections;

public class ThrowTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(CollidePlayer(col)){
			CoconutThrower.CanThrow();
			CoconutWin.CheckAndHints();
		}
	}

	void OnTriggerExit(Collider col){
		if(CollidePlayer(col)){
			CoconutThrower.CannotThrow();
		}
	}

	bool CollidePlayer(Collider col){
		return col.gameObject.tag == "Player";
	}

}
