using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    public bool _roundStarted = true;
    public float _score = 0f; // Player Score
    public float _ScoreScore = 0f; // Enemy Score
    [SerializeField] public TMP_Text _scoreText; // To display PlayerScore in UI
    [SerializeField] public TMP_Text _enemyScore; // To display EnemyScore in UI
    [SerializeField] public GameObject _ball; // Insert the prefab ball you created.

    

   
    private void Start()
    {
        _scoreText.text = _score.ToString();
        _enemyScore.text = _ScoreScore.ToString();
        // To spawn the ball when game starts
        Spawn();  
    }


    private void Update()
    {
        _scoreText.text = _score.ToString();
        _enemyScore.text = _ScoreScore.ToString();  
    }
    
    public void Spawn()
    {
        Instantiate(_ball, new Vector2(0, 0), Quaternion.identity);
    }
   
}
