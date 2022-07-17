using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerate : MonoBehaviour
{
   public GameObject[] platformPrefab;
   int randPlatform;

   private void Start()
   {
      Vector3 SpawnerPosition = new Vector3();

      for (int i = 0; i < 10; i++)
      {
         randPlatform = Random.Range(0, platformPrefab.Length);
         SpawnerPosition.x = Random.Range(-3f, 3f);
         SpawnerPosition.y += Random.Range(2f, 3.2f);

         Instantiate(platformPrefab[randPlatform], SpawnerPosition, Quaternion.identity);
      }
   }
}
