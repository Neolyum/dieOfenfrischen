using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyUI : MonoBehaviour {
    private TextMeshProUGUI textMesh;
    public float currentEnergy = 200;
    public float maxEnergy = 500;
    
    private void Awake() {
        textMesh = transform.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMesh.text = "Energy: " + currentEnergy;
    }
}
