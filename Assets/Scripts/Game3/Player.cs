using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
   public Sprite[] playerSprites;

   float horizontal;
   Rigidbody2D playerRigid;

   private void Awake()
   {
      gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[Random.Range(0, playerSprites.Length)];
      playerRigid = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
      CheckScreenBorders();
   }


   private void FixedUpdate()
   {
      if (Application.platform == RuntimePlatform.Android)
      {
         horizontal = Input.acceleration.x;
      }

      if (Input.acceleration.x < 0)
         gameObject.GetComponent<SpriteRenderer>().flipX = true;

      if (Input.acceleration.x > 0)
         gameObject.GetComponent<SpriteRenderer>().flipX = false;

      playerRigid.velocity = new Vector2(Input.acceleration.x * 17f, playerRigid.velocity.y);
   }

   void CheckScreenBorders()
   {
      if (gameObject.transform.position.x >= 3.26f)
         gameObject.transform.position = new Vector3(-3.26f, transform.position.y, transform.position.z);

      else if (gameObject.transform.position.x <= -3.26f)
         gameObject.transform.position = new Vector3(3.26f, transform.position.y, transform.position.z);
   }

   public void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.collider.name == "DeadZone")
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
