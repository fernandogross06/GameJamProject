using UnityEngine;

public class ParticleSystemExplosionAwake : MonoBehaviour
{
    private ParticleSystem ps;

    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Play();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
