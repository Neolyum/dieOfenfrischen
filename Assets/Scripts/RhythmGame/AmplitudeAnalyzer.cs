using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UI;

public class AmplitudeAnalyzer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSourcePreload;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;
    
    public TextAsset textFile;
    private float[] beatArray;
    private int beatIdx = 0;
    private bool beatEnd = false;

    public GameObject BeatMarkers;
    public GameObject beatMarkerPrefab;
    public float delay;
    public float offset;
    public float staticAverage;

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
        
        //getBeats();
 
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
            
//            Debug.Log("Higherst: " + highest);
//            Debug.Log("Lowest: " + lowest);
//            Debug.Log("Average: " + average);
            
            // Debug.Log("Average: " + average);

            if (clipLoudness >= staticAverage - offset && beatHigh == false) {

                GameObject beatMarker = Instantiate(beatMarkerPrefab);
                beatMarker.transform.SetParent(BeatMarkers.transform);
                beatHigh = true;
            }
            else {
                beatHigh = false;
            }
        }
        
//        if(Time.time >= beatArray[beatIdx] && !beatEnd)
//        {
//            GameObject beatMarker = Instantiate(beatMarkerPrefab);
//            beatMarker.transform.SetParent(BeatMarkers.transform);
//            beatIdx++;
//            if (beatIdx == beatArray.Length - 1) beatEnd = true;
//        }
 
    }

    void getBeats() {
        string text = textFile.text;
        text = text.Replace("[", "");
        text = text.Replace("]", "");
        text = text.Replace(" ", "");
        text = text.Replace("\r", "").Replace("\n", "");
        char[] separator = { ',' };
        string[] beatArrayStr = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        Debug.Log(beatArrayStr[0]);
        Debug.Log(beatArrayStr[1]);
        Debug.Log(beatArrayStr[2]);
        Debug.Log(beatArrayStr[3]);
        Debug.Log(beatArrayStr[4]);
        Debug.Log(beatArrayStr[5]);
        
        
        beatArray = Array.ConvertAll(beatArrayStr, s => float.Parse(s));
    }
}
