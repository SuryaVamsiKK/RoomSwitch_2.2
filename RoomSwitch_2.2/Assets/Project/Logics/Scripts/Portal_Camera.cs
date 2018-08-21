using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Camera : MonoBehaviour {

	public Transform playerCam;
	public Transform portalExit;
	public Transform portalEntry;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		Vector3 playerOffsetFromPortal = playerCam.position - portalEntry.position;
		transform.position = portalExit.position + playerOffsetFromPortal;

		float angularDiffBwPortalRots = Quaternion.Angle(portalExit.rotation, portalEntry.rotation);

		Quaternion portalRotDiff = Quaternion.AngleAxis(angularDiffBwPortalRots, Vector3.up);
		Vector3 newCamDirection = portalRotDiff * playerCam.forward;
		transform.rotation = Quaternion.LookRotation(newCamDirection, Vector3.up);
	}
}
