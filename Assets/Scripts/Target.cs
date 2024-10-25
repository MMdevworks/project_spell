using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class Target : MonoBehaviour
{
    private GameManager gameManager; //reference to GameManager class
    private Rigidbody targetRb;
    private float minSpeed=12;
    private float maxSpeed=16;
    private float maxTorque =10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    public ParticleSystem explosionParticle;
    public int pointValue; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //a above line wasnt working, had to add below
        GameObject gameManagerObject = GameObject.Find("Game Manager");
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
            if (gameManager == null)
            {
                Debug.LogError("GameManager component not found on Game Manager object.");
            }
        }
        else
        {
            Debug.LogError("Game Manager object not found");
        }

        
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }
    // destroy item if hits bottom of screen and game over
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
