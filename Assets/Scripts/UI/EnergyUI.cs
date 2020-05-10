using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyUI : MonoBehaviour {
    private TextMeshProUGUI textMesh;
    public int currentEnergy = 200;
    public int maxEnergy = 500;
    
    private void Awake() {
        textMesh = transform.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMesh.text = "Energy: " + currentEnergy;
    }
}
