using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmplitudeAnalyzer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSourcePreload;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    public GameObject BeatMarkers;
    public GameObject beatMarkerPrefab;
    public float delay;
    public float offset;

    private float currentUpdateTime = 0f;
 
    private float clipLoudness;
    private float[] clipSampleData;

    private float highest;
    private float lowest;
    private float sum;
    private float average;
    private float counter;
    private bool beatHigh = false;
        
    // Use this for initialization
    void Awake () {
        
        audioSourcePreload.Play();
        audioSource.PlayDelayed(delay);

        highest = float.MinValue;
        lowest = float.MaxValue;
        average = 0;
        sum = 0;
        
        if (!audioSource) {
            Debug.LogError(GetType() + ".Awake: there was no audioSource set.");
        }
        else {
            Debug.Log("Awake: audioSource active");
        }
        clipSampleData = new float[sampleDataLength];
 
    }
     
    // Update is called once per frame
    void Update () {
     
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep) {
            currentUpdateTime = 0f;
            audioSourcePreload.clip.GetData(clipSampleData, audioSourcePreload.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData) {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
            counter += 1;
            highest = highest < clipLoudness ? clipLoudness : highest;
            lowest = lowest > clipLoudness ? clipLoudness : lowest;
            sum += clipLoudness;
            average = sum / counter;
            
            // Debug.Log("Average: " + average);

            if (clipLoudness >= average + offset && beatHigh == false) {

                GameObject beatMarker = Instantiate(beatMarkerPrefab);
                beatMarker.transform.SetParent(BeatMarkers.transform);
                beatHigh = true;
            }
            else {
                beatHigh = false;
            }
        }
 
    }
}