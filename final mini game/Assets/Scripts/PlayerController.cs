using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public AudioClip coinSound;
    public AudioClip zombieSound;

    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    private AudioSource playerAudio;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(horizontalInput, 0, forwardInput);
            playerRb.AddForce(moveDirection * speed);
        }

    }

    void OnTriggerEnter(Collider other)
    {
     if(other.gameObject.CompareTag("Coin"))
        {
            playerAudio.PlayOneShot(coinSound, 1f);
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>().SpawnCollectibleObject();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Zombie"))
        {
            playerAudio.PlayOneShot(zombieSound, 1f);
        }
    }
}
