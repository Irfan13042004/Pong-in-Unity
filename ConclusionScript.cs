sing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ConclusionScript : MonoBehaviour
{
   
   private GameManager _gm;
   public GameObject _conclusionUI;

   public GameObject _gameUI;

   public TMP_Text _conclusionText;
   public string _youWin = "You Win!....";
   public string _youLose = "You Lose!...";

   public  bool _isGameEnd = false; 



   private void Start()
   {
      
      _gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

   }

   private void Update()
   {
      // Conditions to end the Game, Here When score reaches 10 and the variable _isGameEnd is false.
      if (_gm._ScoreScore == 10 && !_isGameEnd)//Change the score to 10
      {
         _isGameEnd = true;
         GameEnd();
         _conclusionText.text = _youLose;


      }
      if (_gm._score == 10 && !_isGameEnd)//Change the score to 10
      {
         _isGameEnd = true;
         GameEnd();
         _conclusionText.text = _youWin;
      }
      
   }

   // Do functions after the Game End
   private void GameEnd()
   {
      _gameUI.SetActive(false);
      _conclusionUI.SetActive(true);
      Time.timeScale = 0f;
      Debug.Log(Time.timeScale);
      Debug.Log(_isGameEnd);


   }

   // This Function is added in the Restart button and take cares of functions which used to restart the Game.
   public void Restart()
   {
      //_isGameEnd = false;
      Time.timeScale = 1f;
      SceneManager.LoadScene(1);
      _conclusionUI.SetActive(false);
      Debug.Log(Time.timeScale);
      Debug.Log(_isGameEnd);


   }
   
}
