using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Camera mCamera;
    private void Awake()
    {
        mCamera = Camera.main;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        float cameraHeight = mCamera.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(mCamera.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        Vector2 scale = transform.localScale;
        if (cameraSize.x >= cameraSize.y)
        { // Landscape (or equal)
            scale *= cameraSize.x / spriteSize.x;
        }
        else
        { // Portrait
            scale *= cameraSize.y / spriteSize.y;
        }

        transform.position = Vector2.zero; // Optional
        transform.localScale = scale;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(mCamera.transform.position.x, 0, 0);
    }
}
