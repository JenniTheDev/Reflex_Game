using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour { 
    public float minSpeed = 12f;
    public float maxSpeed = 16f;

    [SerializeField] private float maxTorque = 10f;

    private float xRange = 4f;
    private float ySpawnPos = -6f;

    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explosionParticle;

    private Rigidbody targetRb;

    // Refrences the GameManager script
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start() {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomUpwardForce(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        
    }

    // Update is called once per frame
    void Update() {

    }

    Vector3 RandomUpwardForce() {
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        return Vector3.up * randomSpeed;
    }

    Vector3 RandomSpawnPos() {
        float randomXPos = Random.Range(-xRange, xRange);
        return new Vector3(randomXPos, ySpawnPos);
    }

    float RandomTorque() {
        float randomTorque = Random.Range(0, maxTorque);
        return randomTorque;
    }

    private void OnMouseDown() {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }



}
