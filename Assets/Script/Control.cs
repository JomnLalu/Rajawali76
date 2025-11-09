using UnityEngine;
using TMPro;
public class Control : MonoBehaviour
{
    private Vector2 direction;
    [Header ("Speed")]
    public float speed;
    [Header ("Workspace")]
    private Rigidbody2D playerRb;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        direction = new Vector2(x, y);
    }
    void FixedUpdate()
    {
        playerRb.linearVelocity = direction * speed;
    }
}