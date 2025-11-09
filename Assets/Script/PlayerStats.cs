using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth = 100f;
    public float currentHealth;
    [Header("Fuel")]
    public float maxFuel = 50f;
    public float currentFuel;
    public float fuelDrainPerSecond = 1f;
    public float fuelDrainedDamage = 10f;
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
    }
    void OnDeath()
    {
        if (BGMSource.isPlaying)
        {
            BGMSource.Stop();
        }
        SFXSource.PlayOneShot(deathSFX);
    }
}
