using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatPanel : MonoBehaviour {
    private GameObject currentMarker;
    public float greenOffset = 1f;


    void Update()
    {

        if (Input.GetKey("space")) {
            if (!currentMarker) {
                gameObject.GetComponent<Image>().color = Color.red;
            }
            else if (currentMarker.transform.position.x <= transform.position.x + greenOffset ||
                     currentMarker.transform.position.x >= transform.position.x - greenOffset) {
                gameObject.GetComponent<Image>().color = Color.green;
            }
            else {
                Debug.Log("Yellow");
                gameObject.GetComponent<Image>().color = Color.yellow;
            }
        }
        if (Input.GetKeyUp("space")) {
            gameObject.GetComponent<Image>().color = Color.black;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        currentMarker = other.gameObject;
        Debug.Log("MARKER ENTER");
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (currentMarker == other.gameObject) {
            currentMarker = null;
        }
    }
}
