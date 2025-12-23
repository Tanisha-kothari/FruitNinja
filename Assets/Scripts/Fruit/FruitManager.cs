using UnityEngine;

public class FruitManager : MonoBehaviour
{
    FruitCutSound fruitCutSound;
    FruitStateEnum fruitStateEnum;
    CameraShakeForEffect camShakeForEffect;
    FruitSplatterSystem fruitSplatterSystem;


    private void Awake()
    {
        camShakeForEffect = Camera.main.GetComponent<CameraShakeForEffect>();
        fruitStateEnum = GetComponent<FruitStateEnum>();
        Debug.Log(fruitStateEnum.ToString());
        fruitCutSound = GetComponent<FruitCutSound>();
        fruitSplatterSystem = GetComponent<FruitSplatterSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FruitVibration.Vibrate();
            camShakeForEffect.ShakeTheCamera();
            fruitCutSound.CutFruitSound(true);
            fruitStateEnum.fruitstate = FruitState.Cut;
            Debug.Log(fruitStateEnum.ToString());
            fruitSplatterSystem.GenerateParticle();
            FruitCutScore.Instance.AddScore(1);

        }

    }
}
