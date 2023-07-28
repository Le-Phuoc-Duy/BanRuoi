using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enmy;
    public float spawnTime;
    public float m_spawmTime {get; set;}
    public int m_score {get; set;}
    public bool m_isGameOver { get; set; }
    UI m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawmTime = 0;
        m_ui = FindObjectOfType<UI>();
        m_ui.SetScoreText("Score: " + m_score);
    }
    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    // Update is called once per frame
    void Update()
    {
        if (m_isGameOver)
        {
            m_spawmTime = 0;
            m_ui.ShowGameOverPanel(true);
            return;
        }
        m_spawmTime -= Time.deltaTime;
        if(m_spawmTime <= 0)
        {
            SpawnEnemy();
            m_spawmTime = spawnTime;
        }
    }
    public void ScoreIncrement()
    {
        if(m_isGameOver)
        {
            return;
        }
        m_score++;
        m_ui.SetScoreText("Score: "  + m_score);
    }
    public void SpawnEnemy()
    {
        float randXpos = Random.Range(-9f, 9f);
        Vector2 spawnPos = new Vector2(randXpos, 6.5f);
        if (enmy)
        {
            Instantiate(enmy,spawnPos,Quaternion.identity);
        }
    }
}
