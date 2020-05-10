using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    private bool running = true;
    private AudioSource source;
    private AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.Find("Leviathan").GetComponent<AudioSource>();
        StartCoroutine("playSounds");
    }

    IEnumerator playSounds()
    {
        while (running/* && !GameObject.Find("Leviathan").GetComponent<Leviathan>().dead*/) {
            yield return new WaitForSeconds(Random.Range(10, 16));
            clip = clips[Random.Range(0, clips.Length)];
            source.PlayOneShot(clip);
        }
        Debug.Log("L dead, exit RandomSoiunds");
    }

}
