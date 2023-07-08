using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public ParticleSystem particle;
    AudioSource sound;
    public AudioClip clearSound;
    // Start is called before the first frame update
    private void Start()
    {
        particle.Stop();
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            particle.Play();
            sound.PlayOneShot(clearSound,0.2f);
        }
    }
}
