using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float upForce = 40f;
   private Rigidbody2D playerRb;
   private bool isDead;
   private Animator playerAnimator;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
         if(!isDead && (Input.GetKey(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
         {
            Flap();
         } 
     }

    
    
    private void Flap()
    {
          playerRb.velocity = Vector2.zero;
          playerRb.AddForce(Vector2.up * upForce);
          playerAnimator.SetTrigger("Flap");
    }

   private void OnCollisionEnter2D() 
       {
        isDead = true;
        playerAnimator.SetTrigger("Die");
        GameManager.Instance.GameOver();
       }
}
