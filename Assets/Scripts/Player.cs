using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject projectile;
    public Transform shootingPoint;
    GameController m_gc;
    public AudioSource aus;
    public AudioClip shootingSound;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindAnyObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        if ((transform.position.x > 17.3 && xDir > 0)
            || (transform.position.x < -2 && xDir < 0) || m_gc.m_isGameOver) return;
        transform.position += Vector3.right * moveSpeed * Time.deltaTime * xDir;
        if(Input.GetKeyDown(KeyCode.Space))
        { 
            Shoot();
        }
    }
    public void Shoot()
    {
        if(shootingPoint && projectile)
        {
            if (aus && shootingSound)
            {
                aus.PlayOneShot(shootingSound); 
            }
            Instantiate(projectile,shootingPoint.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            m_gc.m_isGameOver = true;
            Destroy(gameObject);
            Debug.Log("over");
        }
    }
}
