using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeatPanel : MonoBehaviour {
    private GameObject currentMarker;
    public float greenOffset = 1f;
    public float largePanelScale;

    public GameObject hitsUI;
    public GameObject missesUI;
    private int hits = 0;
    private int misses = 0;

    private Vector2 panelSize;
    private Vector2 panelSizeLarge;


    private void Awake() {
        panelSize = gameObject.GetComponent<RectTransform>().rect.size;
        panelSizeLarge = new Vector2(panelSize.x * largePanelScale, panelSize.y * largePanelScale);
    }

    void Update()
    {

        if (Input.GetKeyDown("space")) {
            gameObject.GetComponent<RectTransform>().sizeDelta = panelSizeLarge;
            if (!currentMarker) {
                gameObject.GetComponent<Image>().color = Color.red;
                misses++;
            }
            else if (currentMarker.transform.position.x <= transform.position.x + greenOffset ||
                     currentMarker.transform.position.x >= transform.position.x - greenOffset) {
                gameObject.GetComponent<Image>().color = Color.green;
                hits++;
            }
            else {
                Debug.Log("Yellow");
                gameObject.GetComponent<Image>().color = Color.yellow;
            }
        }
        if (Input.GetKeyUp("space")) {
            gameObject.GetComponent<RectTransform>().sizeDelta = panelSize;
            gameObject.GetComponent<Image>().color = Color.black;
        }

        hitsUI.GetComponent<TextMeshProUGUI>().text = "Hits: " + hits;
        missesUI.GetComponent<TextMeshProUGUI>().text = "Misses: " + misses;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        currentMarker = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (currentMarker == other.gameObject) {
            currentMarker = null;
        }
    }
}
