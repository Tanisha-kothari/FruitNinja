using UnityEngine;

public class FruitSplatterSystem : MonoBehaviour
{
    ParticleSystem splatter;
    private void Awake()
    {
        splatter = GetComponent<ParticleSystem>();
        splatter.Stop();
    }

    public void GenerateParticle()
    {
        splatter.Play();
    }
}
