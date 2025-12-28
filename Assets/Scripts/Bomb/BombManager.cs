using UnityEngine;

public class BombManager : MonoBehaviour
{
    BombCutSound bombCutSound;
    FruitStateEnum fruitStateEnum;
    CameraShakeForEffect camShakeForEffect;

    CutsceneManager cutsceneManager;

    private void Awake()
    {
        camShakeForEffect = Camera.main.GetComponent<CameraShakeForEffect>();
        fruitStateEnum = GetComponent<FruitStateEnum>();
        bombCutSound = GetComponent<BombCutSound>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FruitVibration.Vibrate();
            camShakeForEffect.ShakeTheCamera();
            bombCutSound.CutFruitSound(true);
            CutsceneManager.Instance.PlayBombCutscene();
        }
    }
}
