using UnityEngine;

[ExecuteAlways]
public class ParallaxLoop : MonoBehaviour
{
    public Transform[] layers;     // Assign background star layers
    public Camera cam;
    [Range(0f, 1f)]
    public float parallaxSpeed = 0.8f;
    public float offscreenMargin = 0.05f;

    private float spriteWidth;
    private Vector3 lastCamPos;

    void Start()
    {
        if (cam == null) cam = Camera.main;

        lastCamPos = cam.transform.position;

        // Get width of one background sprite
        SpriteRenderer sr = layers[0].GetComponent<SpriteRenderer>();
        spriteWidth = sr.bounds.size.x;
    }

    void Update()
    {
        Vector3 camMovement = cam.transform.position - lastCamPos;

        // Apply parallax movement
        transform.position += camMovement * parallaxSpeed;

        lastCamPos = cam.transform.position;

        // Loop logic (horizontal)
        for (int i = 0; i < layers.Length; i++)
        {
            Transform layer = layers[i];
            Vector3 vp = cam.WorldToViewportPoint(layer.position);

            // If sprite is off the right side of the screen → move it to the left end
            if (vp.x > 1f + offscreenMargin)
            {
                float minX = float.MaxValue;
                foreach (var l in layers)
                    if (l.position.x < minX) minX = l.position.x;

                layer.position = new Vector3(minX - spriteWidth, layer.position.y, layer.position.z);
            }

            // If sprite is off the left side of the screen → move it to the right end
            if (vp.x < 0f - offscreenMargin)
            {
                float maxX = float.MinValue;
                foreach (var l in layers)
                    if (l.position.x > maxX) maxX = l.position.x;

                layer.position = new Vector3(maxX + spriteWidth, layer.position.y, layer.position.z);
            }
        }
    }
}