using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	public Transform player;
	public Transform Fakeplayer;
	public Transform reciver;

	private bool playerIsOverlapping = false;


	void Update () 
	{
		if (playerIsOverlapping)
		{
			Vector3 portalToPlayer = player.position - transform.position;
			float dotproduct = Vector3.Dot(transform.forward, portalToPlayer);

			if (dotproduct < 0f)
			{
				float rotationDiff = -Quaternion.Angle(transform.rotation, reciver.rotation);
				rotationDiff += 180f;
				player.Rotate(Vector3.up, rotationDiff);

				Vector3 posOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
				player.position = reciver.position + posOffset;
				playerIsOverlapping = false;
				player.parent = reciver.root;
				Fakeplayer.parent = this.transform.root;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			playerIsOverlapping = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			playerIsOverlapping = false;
		}
	}
}
