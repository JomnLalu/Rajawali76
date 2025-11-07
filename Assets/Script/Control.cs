using UnityEngine;
using TMPro;
public class Control : MonoBehaviour
{
    [Header ("Speed")]
    public float x_thrust;
  public float y_thrust;
    [Header ("Workspace")]
    private Rigidbody2D playerRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            //playerRb.linearVelocity = new Vector2()
            transform.Translate(Vector2.right * y_thrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            //playerRb.AddForce(new Vector2(-thrust - playerRb.linearVelocity.x, playerRb.linearVelocity.y).normalized, ForceMode2D.Force);
            transform.Translate(Vector2.up * x_thrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            transform.Translate(Vector2.left * y_thrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            //playerRb.AddForce(new Vector2(thrust + playerRb.linearVelocity.x, playerRb.linearVelocity.y).normalized, ForceMode2D.Force);
            transform.Translate(Vector2.down * x_thrust * Time.deltaTime);
        }



    }
}