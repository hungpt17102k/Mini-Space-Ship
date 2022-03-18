using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Vector3 shipPos;
    
    public Vector2 speedRotateMinMax;
    float speedRotate;
    public Vector2 speedMinMax;
    float speed;
    Vector3 dirToShip;
    Vector3 velocity;

    private void Awake() {
        if(GameObject.FindGameObjectWithTag("Player")) {
            shipPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        } else {
            shipPos = Vector3.zero;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        Vector3 displacementFromShip = shipPos - transform.position;
        dirToShip = displacementFromShip.normalized;
        velocity = dirToShip * speed;
        speedRotate = Random.Range(speedRotateMinMax.x, speedRotateMinMax.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
        transform.Rotate(new Vector3(0f,0f, speedRotate) * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "OutOfSpace") {
            Destroy(gameObject);
        }
    }
}
