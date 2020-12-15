using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;
    public ParticleSystem explosionParticle;

    private Rigidbody targetRB;
    private GameHandler gameHandler;
    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float torque = 10.0f;
    private float xRange = 4.0f;
    private float yPos = -3.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();

        targetRB.AddForce(GetRandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(GetRandomTorque(), GetRandomTorque(), GetRandomTorque(), ForceMode.Impulse);

        transform.position = GetRandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (gameHandler.isGameActive)
        {
            Destroy(gameObject);
            gameHandler.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            if (this.CompareTag("Bad_Object"))
            {
                gameHandler.GameOver();
            }
        }
    }

    void OnTriggerEnter()
    {
        Destroy(gameObject);
        if (!this.CompareTag("Bad_Object"))
        {
            gameHandler.GameOver();
        }
    }

    Vector3 GetRandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float GetRandomTorque()
    {
        return Random.Range(-torque, torque);
    }

    Vector3 GetRandomSpawn()
    {
        return new Vector3(Random.Range(-xRange, xRange), yPos);
    }
}
