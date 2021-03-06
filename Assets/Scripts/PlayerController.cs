using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private GameObject playerObj = null;
    private float powerupStrength = 850.0f;

    public float speed = 2.0f;
    public float gravityModifier;
    public float jumpForce;

    public bool hasPowerup;
    public bool gameOver = false;
    public bool isOnGround = true;

    public GameObject powerupIndicator;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        // jump
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && (isOnGround == true))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

    }

    void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        
        if (playerObj.transform.position.y < -10)
        {
            gameOver = true;
            Debug.Log("Game Over!");
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("Collided " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
}
