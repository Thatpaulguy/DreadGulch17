using UnityEngine;

public class ExplosivesScript : MonoBehaviour
{
    private AudioSource sfxAudioSource;
    private float timer = 0.0f;
    private bool isExploding = false;
    private EnableBankEntrance enabler;

    public float explosionDuration = 0.5f;

    public void Start()
    {
        sfxAudioSource = GetComponent<AudioSource>();
        enabler = GetComponent<EnableBankEntrance>();
    }

    public void Update()
    {
        if (isExploding && timer < explosionDuration)
            timer += Time.deltaTime;

        if (timer >= explosionDuration)
        {
            GameObject explosion = GameObject.Find("Explosion");
            if (explosion != null)
                explosion.SetActive(false);

            Destroy(gameObject);
        }
    }

    public void Explode()
    {
        GameObject explosion = GameObject.Find("Explosion");
        explosion.SetActive(true);
        isExploding = true;
        ParticleSystem[] particles = explosion.GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < particles.Length; i++)
            particles[i].Play();
        sfxAudioSource.Play();
        if (enabler != null)
            enabler.EnableTrigger();

        GameObject.FindGameObjectWithTag("Player").GetComponent<SceneCheck>().ItemStatus["SaloonEntrance"] = true;
    }

    public void IsDestroyed()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<SceneCheck>().ItemStatus["SaloonEntrance"])
        {
            if (enabler != null)
                enabler.EnableTrigger();

            Destroy(gameObject);
        }
    }
}