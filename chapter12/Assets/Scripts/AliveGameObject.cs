using UnityEngine;
using System.Collections;

//用于标记当切换场景的时候需要保留的对象
public class AliveGameObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
		
	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
