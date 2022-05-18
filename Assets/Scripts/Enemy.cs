using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private int pointsPerEnemy = 10;

    private Rigidbody enemyRb;
    private GameObject player;
    private ScoreManager theScoreManager;

    public int PointsPerEnemy
    {
        get
        {
            return pointsPerEnemy;
        }
    }

    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            theScoreManager.AddScore(pointsPerEnemy);
            Destroy(gameObject); 
        }
    }
}
