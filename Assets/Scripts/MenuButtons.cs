using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   [SerializeField] private Image _img;
   [SerializeField] private Sprite _default, _pressed;
   [SerializeField] private AudioClip _clickSound;
   [SerializeField] private AudioSource _sourse;

   public void OnPointerDown(PointerEventData eventData)
   {
      _img.sprite = _pressed;
      _sourse.PlayOneShot(_clickSound);
   }

   public void OnPointerUp(PointerEventData eventData)
   {
      _img.sprite = _default;
   }

   public void Game1()
   {
      StartCoroutine(Load("Game1"));
   }

   public void Game2()
   {
      StartCoroutine(Load("Game2"));
   }

   public void Game3()
   {
      StartCoroutine(Load("Game3"));
   }

   private IEnumerator Load(string sceneString)
   {
      yield return new WaitForSeconds(0.3f);
      SceneManager.LoadScene(sceneString);
   }
}
