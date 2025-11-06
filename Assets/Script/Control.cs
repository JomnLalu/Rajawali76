using UnityEngine;

public class Control : MonoBehaviour
{
    public float thrust;
    public Rigidbody2D playerRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) == true)
        {
          playerRb.AddForce(new Vector2(playerRb.linearVelocity.x, thrust), ForceMode2D.Force);
        }
        if (Input.GetKeyDown(KeyCode.A) == true)
        {
          playerRb.AddForce(new Vector2(-thrust, playerRb.linearVelocity.y), ForceMode2D.Force);
        }
        if (Input.GetKeyDown(KeyCode.S) == true)
        {
          playerRb.AddForce(new Vector2(playerRb.linearVelocity.x, -thrust), ForceMode2D.Force);
    }
        if (Input.GetKeyDown(KeyCode.D) == true)
        {
          playerRb.AddForce(new Vector2(thrust, playerRb.linearVelocity.y), ForceMode2D.Force);
        }
        
    }
}
