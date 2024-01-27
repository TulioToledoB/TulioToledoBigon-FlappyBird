using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private float spriteWidth;

    
    void Start()
    {
        SpriteRenderer groundRenderer = GetComponent<SpriteRenderer>();
    spriteWidth = groundRenderer.bounds.size.x;
    }

    
    void Update()
    {
        if(transform.position.x < -spriteWidth)
    {
        ResetPosition();
    }
    }
    private void ResetPosition()
        {
            
    Vector3 newPosition = new Vector3(transform.position.x + 2 * spriteWidth, transform.position.y, transform.position.z);
    transform.position = newPosition;
        }
    
}
