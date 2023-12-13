using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody zombieRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        zombieRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        zombieRb.AddForce(lookDirection * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("The Zombie hit the Player!");
        }
    }
}
