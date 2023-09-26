using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Snow : MonoBehaviour
{
    public GameObject snowPoof;
    public float destroyDelay = 1.0f;

    private AudioSource audioSource;
    public AudioClip snowHitSound;

    public GameObject snowCollision;

    public PlayerScore playerScore;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerScore = GameObject.Find("Player").GetComponent<PlayerScore>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("snow"))
        {
            snowCollision = collision.gameObject;
            audioSource.PlayOneShot(snowHitSound);
            playerScore.UpdateScore();
            StartCoroutine(Destruct());
        }
            
    }

    IEnumerator Destruct()
    {
        yield return new WaitForSeconds(destroyDelay);
        Instantiate(snowPoof, snowCollision.transform.position, Quaternion.identity);
        Destroy(snowCollision);
    }
}
