using System;
using UnityEngine;
using System.Collections;


public class PlayerMobility : MonoBehaviour
{
	public float speed;
	public Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition); //find the mouse pos.
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward); //find the look rotation.

		transform.rotation = rot; // sets rotation of this object to be the rotation required to look at mouse.
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z); // strips away x and y rotations.
		rb.angularVelocity = 0; // prevents slide when rotating.

		float input = Input.GetAxis ("Vertical");
		rb.AddForce (gameObject.transform.up * speed * input);

	}
}


