using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D m_rb;
    public float speed;
    public float timeToDestroy;
    GameController m_gc;
    AudioSource aus;
    public AudioClip hitSound;
    public GameObject hitVFX;

    // Start is called before the first frame update
    void Start()
    {
        aus = FindAnyObjectByType<AudioSource>();
        m_gc = FindAnyObjectByType<GameController>();
        m_rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector3.up* speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if(aus && hitSound)
            {
                aus.PlayOneShot(hitSound);
            }
            if (hitVFX)
            {
                Instantiate(hitVFX,collision.transform.position, Quaternion.identity);
            }
            m_gc.ScoreIncrement();
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("cham enemy");
        }
        if (collision.CompareTag("SceneTopLimit"))
        {
            Destroy(gameObject);
        }
    }
    
}
