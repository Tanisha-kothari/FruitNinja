using UnityEngine;

public class FruitManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FruitVibration.Vibrate();
    }
}
