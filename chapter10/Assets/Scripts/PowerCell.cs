using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class PowerCell : MonoBehaviour {

	public float rotationSpeed = 100.0f;

	// Use this for initialization
	void Start () {
		name = "powerCell";
		//transform.position = new Vector3 (transform.position.x, 31.5f, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.SendMessage("PickUpCell");
			Destroy(gameObject);
		}
	}

}
