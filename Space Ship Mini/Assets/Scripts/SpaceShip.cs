using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpaceShip : MonoBehaviour
{
    public float speed = 3f;
    public float force;
    public event Action OnPlayerDeath;

    Vector3 worldPosition;
    Vector3 velocity;
    Vector3 acceleration;

    Vector3 mouseInWorldPos;

    private void Awake() {
        Application.targetFrameRate = 300;
    }

    private void Start()
    {
        acceleration = Vector3.zero;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mouseInWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        mouseInWorldPos.z = 0;
        
        MoveToMouse(mouseInWorldPos);
        //RotateToMouse(mouseInWorldPos);
    }

    void MoveToMouse(Vector3 mousePos)
    {
        Vector3 displacementFromMouse = mousePos - transform.position;
        Vector3 direction = displacementFromMouse.normalized;
        //velocity = direction * speed;

        direction = direction * force;
        acceleration = direction;
        velocity += acceleration;

        //Limit speed
        if (velocity.sqrMagnitude > speed * speed)
        {
            velocity.Normalize();
            velocity *= speed;
        }

        transform.position += velocity * Time.deltaTime;
        //rigi.velocity += new Vector2(velocity.x, velocity.y) * Time.fixedDeltaTime;
    }

    void RotateToMouse(Vector3 mousePos)
    {
        Vector3 displacementFromMouse = mousePos - transform.position;
        Vector3 dirToMouse = displacementFromMouse.normalized;

        transform.up = dirToMouse;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath.Invoke();
            }
            Destroy(gameObject);
        }
    }
}
