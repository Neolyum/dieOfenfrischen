using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shot : MonoBehaviour {
	private Rigidbody rb;

	private Vector3 startPos;
	public float velocity = 10000f;
	private float maxDistance;

	void Start() {
		rb = GetComponent<Rigidbody>();
//		rb.isKinematic = true;
	}
    public void destroy()
    {
        Destroy(this);
    }
    public void Shoot(Vector3 dirVector, float distance) {
		maxDistance = distance;
		if (rb == null) {
			rb = GetComponent<Rigidbody>();
		}

		startPos = transform.position;
		//rb.AddForce(dirVector * velocity, ForceMode.Impulse);
	}

    public void up(Vector3 dirVector)
    {
        transform.position = dirVector * maxDistance;
    }

	private void Update() {
        
		if (Vector3.Distance(transform.position, startPos) > maxDistance) {
//			Destroy(this);
	//		Debug.Log("ni");
		}
	}
}