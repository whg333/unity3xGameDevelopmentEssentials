#pragma strict

private var doorIsOpen : boolean = false;
private var doorTimer : float = 0.0;
private var currentDoor : GameObject;

var doorOpenTime : float = 3.0;
var doorOpenSound : AudioClip;
var doorShutSound : AudioClip;

function Start () {

}

function Update () {

}

function OnControllerColliderHit(hit : ControllerColliderHit){
	if(hit.gameObject.tag == "playerDoor" && !doorIsOpen){

	}
}