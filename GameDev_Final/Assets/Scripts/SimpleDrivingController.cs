using UnityEngine;

public class SimpleDrivingController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    
    [Header("Input Settings")]
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    
    void Update()
    {
        HandleMovement();
        HandleRotation();
    }
    
    void HandleMovement()
    {
        // Move forward/backward with W/S keys
        if (Input.GetKey(forwardKey))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(backwardKey))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }
    
    void HandleRotation()
    {
        // Rotate left/right with A/D keys
        if (Input.GetKey(leftKey))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(rightKey))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}
