using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMarkerComponent : MonoBehaviour {
    
    public float destroyDelay;
    public Canvas UI;
    

    private void Start() {
        transform.position = new Vector3(transform.position.x + 200, transform.position.y + 75, transform.position.z);
        Destroy(gameObject, destroyDelay);
    }

    private void FixedUpdate() {
        gameObject.transform.position = new Vector3(transform.position.x + 4.0f, transform.position.y, transform.position.z);
    }
}
