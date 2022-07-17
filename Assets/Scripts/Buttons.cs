using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
   public AudioSource buttonClick;
   SoundCheck sound;

   private void Start()
   {
      sound = FindObjectOfType<SoundCheck>();
   }

   public void Home()
   {
      PlaySound();
      StartCoroutine(Load("Home"));
   }

   public void RandomSound()
   {
      int rand = Random.Range(0, sound.sounds.Length);

      sound._audio.clip = sound.sounds[rand];
      sound._audio.Play();
   }

   private void PlaySound()
   {
      buttonClick.Play();
   }

   private IEnumerator Load(string sceneString)
   {
      yield return new WaitForSeconds(0.3f);
      SceneManager.LoadScene(sceneString);
   }
}
