using UnityEngine;

public class BombCutSound : MonoBehaviour
{
    [SerializeField] AudioSource audio1;
    //[SerializeField] AudioSource audio2;

    private void Awake()
    {
        audio1.playOnAwake = false; //audio2.playOnAwake = false;
    }
    public void CutFruitSound(bool hit)
    {
        if (hit)
        {
            audio1.Play();
        }
        else
        {
            //audio2.Play();
        }
    }
}
