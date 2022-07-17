using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCheck : MonoBehaviour
{
   public AudioClip[] sounds;
   public AudioSource _audio;

   private void Start()
   {
      _audio = GetComponent<AudioSource>();
   }
}
