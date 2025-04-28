using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    void Update()
    {
        // Input
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Movement
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);
        
        // Turning (only while moving)
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
        }
    }
}