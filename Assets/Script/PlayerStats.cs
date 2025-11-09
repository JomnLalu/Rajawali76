using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Score")]
    public float score = 0f;
    public float distanceTravelled = 0f;
    [Header("Health")]
    public float maxHealth;
    public float currentHealth;
    [Header("Fuel")]
    public float maxFuel;
    public float currentFuel;
    public float fuelDrainPerSecond;
    public float fuelDrainedDamagef;
    [Header("Audio (SFX)")]
    public AudioSource BGMSource;
    public AudioSource SFXSource;
    public AudioClip deathSFX;

    void Start()
    {
        currentFuel = maxFuel;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        score += 1f * Time.deltaTime;
        distanceTravelled += 1f * Time.deltaTime;
        burnFuel();
        healthCheck();
    }
    void burnFuel()
    {
        currentFuel -= fuelDrainPerSecond * Time.deltaTime;
        currentFuel = Mathf.Clamp(currentFuel, 0f, maxFuel);

        if (currentFuel <= 0f)
        {
            currentHealth -= 10f * Time.deltaTime;
        }
    }
    void healthCheck()
    {
        if (currentHealth <= 0 && currentHealth != -100f)
        {
            currentHealth = -100f;
            OnDeath();
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    void OnDeath()
    {
        //Audio Handler
        if (BGMSource.isPlaying)
        {
            BGMSource.Stop();
        }
        SFXSource.PlayOneShot(deathSFX);

        Destroy(gameObject);
    }
}
