using UnityEngine;

public class FruitManager : MonoBehaviour
{
    FruitCutSound fruitCutSound;
    FruitStateEnum fruitStateEnum;
    CameraShakeForEffect camShakeForEffect;


    private void Awake()
    {
        camShakeForEffect = Camera.main.GetComponent<CameraShakeForEffect>();
        fruitStateEnum = GetComponent<FruitStateEnum>();
        Debug.Log(fruitStateEnum.ToString());
        fruitCutSound = GetComponent<FruitCutSound>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FruitVibration.Vibrate();
            camShakeForEffect.ShakeTheCamera();
            fruitCutSound.CutFruitSound(true);
            fruitStateEnum.fruitstate = FruitState.Destroyable;
            Debug.Log(fruitStateEnum.ToString());

        }

    }
}
