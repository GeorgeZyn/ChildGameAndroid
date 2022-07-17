using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
   public float jumpForce = 15f;
   AudioSource jumpSound;

   private void Start()
   {
      jumpSound = GetComponent<AudioSource>();
   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
      if(collision.collider.name == "Player" && collision.relativeVelocity.y <= 0f)
      {
         Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
         if(rb != null)
         {
            jumpSound.Play();
            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
         }
      }

      if (collision.collider.name == "DeadZone")
      {
         float RandX = Random.Range(-3f, 3f);

         transform.position = new Vector3(RandX, transform.position.y + 25f, 0);
      }
   }
}
