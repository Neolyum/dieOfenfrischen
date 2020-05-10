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

    public int hitPoints;
    public int missPoints;

    public GameObject hitsUI;
    public GameObject missesUI;
    private EnergyUI energyUI;
    private int hits = 0;
    private int misses = 0;

    private Vector2 panelSize;
    private Vector2 panelSizeLarge;


    private void Awake() {
        energyUI = GameObject.Find("EnergyUI").GetComponent<EnergyUI>();
        
        panelSize = gameObject.GetComponent<RectTransform>().rect.size;
        panelSizeLarge = new Vector2(panelSize.x * largePanelScale, panelSize.y * largePanelScale);
    }

    void Update()
    {
        hitsUI.GetComponent<TextMeshProUGUI>().text = "Hits: " + hits;
        missesUI.GetComponent<TextMeshProUGUI>().text = "Misses: " + misses;
    }

    public void OnBeatHitDown() {
        gameObject.GetComponent<RectTransform>().sizeDelta = panelSizeLarge;
        if (!currentMarker) {
            gameObject.GetComponent<Image>().color = Color.red;
            if (energyUI.currentEnergy - missPoints >= 0) {
                energyUI.currentEnergy -= missPoints;
            }
            else {
                energyUI.currentEnergy = 0;
            }
            misses++;
        }
        else if (currentMarker.transform.position.x <= transform.position.x + greenOffset ||
                 currentMarker.transform.position.x >= transform.position.x - greenOffset) {
            gameObject.GetComponent<Image>().color = Color.green;
            if (energyUI.currentEnergy <= energyUI.maxEnergy - hitPoints) {
                energyUI.currentEnergy+= hitPoints;
            }
            else {
                energyUI.currentEnergy = 500;
            }
            hits++;
        }
        else {
            Debug.Log("Yellow");
            gameObject.GetComponent<Image>().color = Color.yellow;
        }
    }

    public void OnBeatHitUp() {
        gameObject.GetComponent<RectTransform>().sizeDelta = panelSize;
        gameObject.GetComponent<Image>().color = Color.black;
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
