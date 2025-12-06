using UnityEngine;

public class FruitLaunch : MonoBehaviour
{
    Rigidbody rb;
    public float thrust = 20f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        //rb.AddForce(transform.up * thrust, ForceMode.Impulse);
        rb.AddRelativeForce(Vector3.up * thrust, ForceMode.Impulse);
        rb.useGravity = true;
    }

}
