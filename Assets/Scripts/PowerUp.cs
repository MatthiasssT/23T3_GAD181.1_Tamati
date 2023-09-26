using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip powerUpSound;
    public GameObject currentTime;
    public Timer timer;
    public float destroyDelay = 1.0f;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("collided with powerup");
            audioSource.PlayOneShot(powerUpSound);
            timer.currentTime = 10f;
            StartCoroutine(Destruct());
        }
    }

    IEnumerator Destruct()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(this.gameObject);
    }
}
