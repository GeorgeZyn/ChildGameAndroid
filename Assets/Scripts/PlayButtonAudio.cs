using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonAudio : MonoBehaviour
{
   SoundCheck SC;
   public int soundNum;

   private void Start()
   {
      SC = FindObjectOfType<SoundCheck>();
   }

   public void PlayAudio()
   {
      SC._audio.clip = SC.sounds[soundNum];
      SC._audio.Play();
   }
}
