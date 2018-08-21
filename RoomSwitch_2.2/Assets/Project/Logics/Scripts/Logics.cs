using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logics : MonoBehaviour {

	public Transform player;
	public Transform fakePlayer;

	void Start () 
	{
		
	}
	
	void Update() 
	{
		//diff = cameraMain.position - portalIn.position;
		//cameraSecond.position = portalExit.position + diff;
		fakePlayer.localPosition = player.localPosition;
		fakePlayer.localRotation = player.localRotation;
		fakePlayer.GetChild(0).localPosition = player.GetChild(0).localPosition;
		fakePlayer.GetChild(0).localRotation = player.GetChild(0).localRotation;
	}
}
