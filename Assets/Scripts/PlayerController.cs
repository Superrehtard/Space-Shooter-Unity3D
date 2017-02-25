using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float minX, maxX, minZ, maxZ;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		float forceHorizontal = Input.GetAxis ("Horizontal");
		float forceVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (forceHorizontal, 0.0f, forceVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3 (
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.minX, boundary.maxX),
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.minZ, boundary.maxZ)
		);

		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (GetComponent<Rigidbody>().velocity.z * -tilt/2, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

}
