using UnityEngine;

public class FruitLaunch : MonoBehaviour
{
    Rigidbody rb;

    public float forwardForce = 6f;
    public float upwardForce = 15f;
    public float spinForce = 3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.useGravity = true;

        float randomForward = Random.Range(4f, 8f);
        float randomUpward = Random.Range(12f, 18f);

        Vector3 launchDirection =
            transform.right * randomForward +
            Vector3.up * randomUpward;

        rb.AddForce(launchDirection, ForceMode.Impulse);

        rb.angularVelocity = Random.insideUnitSphere * spinForce;
    }

}
