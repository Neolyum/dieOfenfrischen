using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leviathan : MonoBehaviour, IDamageable
{
    private float hp = 5000;
    [SerializeField] AudioClip dieSound;
    public bool dead = false;
    public void die()
    {
        dead = true;
        AudioSource source = gameObject.GetComponent<AudioSource>();
        source.PlayOneShot(dieSound);

        //impoolement absturz here
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "LEVIATHAN: " + hp.ToString());
    }

    public void takeDamage(float amount)
    {
        hp -= amount;
    }

    void FixedUpdate()
    {
        if (hp > 0) hp -= 15;
        if (hp <= 0 && !dead)
        {
            die();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
