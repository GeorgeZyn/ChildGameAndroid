using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
   public List<QuestionAnswers> QnA;
   public GameObject[] options;
   public int currentQuestion;

   public Image image;

   public AudioClip correctSound;
   public AudioClip wrongSound;
   AudioSource _audio;

   public GameObject correctPanel;
   public GameObject wrongPanel;

   [SerializeField] private Color initialColor;

   private void Start()
   {
      _audio = GetComponent<AudioSource>();
      GenerateQuestion();
   }

   public void Correct()
   {
      _audio.PlayOneShot(correctSound);
      correctPanel.transform.GetChild(0).GetComponent<Image>().sprite = image.GetComponent<Image>().sprite;
      correctPanel.SetActive(true);
      StartCoroutine(HidePanel(correctPanel));
      QnA.RemoveAt(currentQuestion);
      GenerateQuestion();
   }

   public void Wrong()
   {
      _audio.PlayOneShot(wrongSound);
      wrongPanel.SetActive(true);
      StartCoroutine(HidePanel(wrongPanel));
      QnA.RemoveAt(currentQuestion);
      GenerateQuestion();
   }

   IEnumerator HidePanel(GameObject panel)
   {
      yield return new WaitForSeconds(1.6f);
      if (panel.activeSelf) panel.SetActive(false);
   }

   IEnumerator ResetScene()
   {
      yield return new WaitForSeconds(0.9f);
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   void SetAnswers()
   {
      for (int i = 0; i < options.Length; i++)
      {
         options[i].GetComponent<AnswerScript>().isCorrect = false;
         options[i].transform.GetChild(0).GetComponent<Image>().sprite = QnA[currentQuestion].Answers[i];

         if(QnA[currentQuestion].CorrectAnswer == i + 1)
         {
            options[i].GetComponent<AnswerScript>().isCorrect = true;
         }
      }
   }

   void GenerateQuestion()
   {
      if (QnA.Count > 0)
      {
         currentQuestion = Random.Range(0, QnA.Count);
         image.GetComponent<Image>().sprite = QnA[currentQuestion].Question;
         image.GetComponent<Image>().color = initialColor;
         SetAnswers();
      }
      else
         StartCoroutine(ResetScene());
   }
}
