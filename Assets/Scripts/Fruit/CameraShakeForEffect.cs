using UnityEngine;
using System.Collections;

public class CameraShakeForEffect : MonoBehaviour
{
    [SerializeField] float shakeAmount = 0.05f;
    [SerializeField] float shakeDuration = 0.15f;

    Vector3 initialPos;
    Coroutine shakeRoutine;

    void Awake()
    {
        initialPos = transform.localPosition;
    }

    public void ShakeTheCamera()
    {
        if (shakeRoutine != null)
            StopCoroutine(shakeRoutine);

        shakeRoutine = StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeAmount;
            transform.localPosition = initialPos + randomOffset;

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = initialPos;
    }
}
