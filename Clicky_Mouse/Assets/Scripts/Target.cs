using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour { 
    public float minSpeed = 12f;
    public float maxSpeed = 16f;

    [SerializeField] private float maxTorque = 10f;

    private float xRange = 4f;
    private float ySpawnPos = -6f;

    private Rigidbody targetRb;

    // Start is called before the first frame update
    void Start() {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomUpwardForce(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
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
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }



}
