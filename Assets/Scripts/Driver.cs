using System;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float carSpeed = 25.0f;
    [SerializeField] private float steerSpeed = 1.0f;
    [SerializeField] private float speedUpSpeed = 30.0f;
    [SerializeField] private float slowedDownSpeed = 15.0f;

    private void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * carSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("SpeedReducer"))
        {
            carSpeed = slowedDownSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SpeedBooster"))
        {
            carSpeed = speedUpSpeed;
            Destroy(other.gameObject);
        }
    }
}