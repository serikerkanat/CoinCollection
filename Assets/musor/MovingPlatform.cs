using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;

    private Vector3 target;
    private Rigidbody rb;

    private void Start()
    {
        target = pointB;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; 
    }

    private void FixedUpdate()
    {
        rb.MovePosition(Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime));

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA ? pointB : pointA;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

}
