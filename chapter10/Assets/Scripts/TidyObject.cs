using UnityEngine;
using System.Collections;

public class TidyObject : MonoBehaviour {

	public float removeTime = 3.0f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, removeTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
