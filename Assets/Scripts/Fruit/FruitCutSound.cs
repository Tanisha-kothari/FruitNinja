using UnityEngine;

public class FruitCutSound : MonoBehaviour
{
    [SerializeField]AudioSource audio1;
    [SerializeField]AudioSource audio2;
    public void CutFruitSound(bool hit)
    {
        if (hit)
        {
            audio1.Play();
        }
        else
        {
            audio2.Play();
        }
    }
}
