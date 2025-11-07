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
    void Start()
    {
        currentFuel = maxFuel;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        burnFuel();
    }
    void burnFuel()
    {
        currentFuel -= fuelDrainPerSecond * Time.deltaTime;
        currentFuel = Mathf.clamp(currentFuel, 0, maxFuel);

        if (currentFuel <= 0f)
        {
            currentHealth -= 10f * Time.deltaTime;
        }
    }
}
