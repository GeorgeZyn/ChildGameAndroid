using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
   public Text score;
   public GameObject player;

   private void Update()
   {
      score.text = Mathf.Round((player.transform.position.y)-4).ToString();
   }

}
