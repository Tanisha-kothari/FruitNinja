using UnityEngine;

public class CameraShakeForEffect : MonoBehaviour
{
    [SerializeField] float shakeAmount = 0.02f;

    private Vector3 initialPos;

    void Awake()
    {
        initialPos = transform.position;
    }

    public void ShakeTheCamera()
    {
        transform.position = initialPos + Random.insideUnitSphere * shakeAmount;
    }
}
