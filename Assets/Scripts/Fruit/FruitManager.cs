using UnityEngine;

public class FruitManager : MonoBehaviour
{
    FruitCutSound fruitCutSound;
    FruitStateEnum fruitStateEnum;


    private void Awake()
    {
        fruitStateEnum = GetComponent<FruitStateEnum>();
        Debug.Log(fruitStateEnum.ToString());
        fruitCutSound = GetComponent<FruitCutSound>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FruitVibration.Vibrate();
            fruitCutSound.CutFruitSound(true);
            fruitStateEnum.fruitstate = FruitState.Cut;
            Debug.Log(fruitStateEnum.ToString());
        }
        fruitStateEnum.fruitstate = FruitState.Destroyable;

    }
}
