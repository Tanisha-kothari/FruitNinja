using UnityEngine;

public class FruitLaunch : MonoBehaviour
{
    Rigidbody rb;
    Vector3 thrust = new Vector3(0, 15, 0);
    int no;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, no));
    }
    void Start()
    {
        no = Random.Range(2, 4);
        //rb.AddForce(transform.up * thrust, ForceMode.Impulse);
        rb.AddRelativeForce(thrust, ForceMode.Impulse);
        rb.useGravity = true;
    }

}
