using UnityEngine;

public class FruitDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            FruitStateEnum fruitStateEnum = other.GetComponent<FruitStateEnum>();

            if (fruitStateEnum == null)
            {
                Debug.LogWarning("Fruit has no FruitStateEnum component!");
                return;
            }

            Debug.Log("Fruit State: " + fruitStateEnum.fruitstate);

            if (fruitStateEnum.fruitstate == FruitState.Uncut || fruitStateEnum.fruitstate == FruitState.Cut)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
