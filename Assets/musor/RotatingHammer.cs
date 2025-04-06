using UnityEngine;

public class RotatingHammer : MonoBehaviour
{
    public float rotationSpeed = 200f; 

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок ударен молотом!");
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 forceDirection = (other.transform.position - transform.position).normalized;
                playerRb.AddForce(forceDirection * 5f); 
            }
        }
    }
}
