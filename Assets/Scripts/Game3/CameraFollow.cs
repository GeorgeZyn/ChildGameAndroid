using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform playerPos;

   private void Update()
   {
      if (playerPos.position.y > transform.position.y)
         transform.position = new Vector3(transform.position.x, playerPos.position.y, transform.position.z);
   }
}
