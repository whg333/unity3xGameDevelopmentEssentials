using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class CoconutWin : MonoBehaviour {

	private static int targets;
	private static bool hadWon;

	public AudioClip winSound;
	public Rigidbody cellPrefab;

	// Use this for initialization
	void Start () {
		targets = 0;
		hadWon = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hadWon && targets == 3){
			targets = 0;
			GetComponent<AudioSource>().PlayOneShot(winSound);
			GameObject powerCell = transform.Find("powerCell").gameObject;
			//winCell.transform.Translate(-0.5f, 0, 0);

			//想要是Rigidbody的话，除了确保声明cellPrefab为Rigidbody外，
			//也需要确保Unity检视图上面显示的cellPrefab也是Rigidbody，
			//因为如果最初是GameObject的话中途修改过了不重新赋值是无效的
			Rigidbody winCell = Instantiate(cellPrefab, powerCell.transform.position, transform.rotation) as Rigidbody;
			if (winCell == null) {
				print ("cell is null");
			} else {
				winCell.transform.position = new Vector3 (winCell.transform.position.x - 0.5f, 31.5f, winCell.transform.position.z);
			}

			Destroy(powerCell);
			hadWon = true;
		}
	}

	public static void IncrTargets(){
		targets++;
	}

	public static void DecrTargets(){
		targets--;
	}

	public static void CheckAndHints(){
		if(!hadWon){
			GUIManager.ShowHints("\n\n\n\n\n\n\n\n赢得射击靶心游戏将会获得1个能源\n\n当3个靶都处于被射倒下状态时才算赢");
		}
	}

}
