using UnityEngine;

public class BombManager : MonoBehaviour
{
    BombCutSound bombCutSound;
    FruitStateEnum fruitStateEnum;
    CameraShakeForEffect camShakeForEffect;


    private void Awake()
    {
        camShakeForEffect = Camera.main.GetComponent<CameraShakeForEffect>();
        fruitStateEnum = GetComponent<FruitStateEnum>();
        Debug.Log(fruitStateEnum.ToString());
        bombCutSound = GetComponent<BombCutSound>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FruitVibration.Vibrate();
            camShakeForEffect.ShakeTheCamera();
            bombCutSound.CutFruitSound(true);
            fruitStateEnum.fruitstate = FruitState.Cut;
            //CutScene????

        }

    }
}
