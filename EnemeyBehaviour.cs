using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyMovement : MonoBehaviour
{
    GameObject _ball;
    [SerializeField] private GameObject _enemy;

    public Ball_behaviour _ballBehaviour;

   

    private Vector2 _ballPosition;

    private Rigidbody2D _rb;

    private Vector2 _paddlePositionUpper;
    private Vector2 _paddlePositionLower;

    public AudioSource _deathAudio;


    private void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball"); // Catch the object with the ball tag
        _ballBehaviour = _ball.GetComponent<Ball_behaviour>(); // From that ball it fetches out ball behaviour
         // This method is followed since the ball object is spawned and destroyed when playing the game. This type of Assignment worked during trial and error
        _rb = gameObject.GetComponent<Rigidbody2D>();

    }


    private void Update()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball"); // _ball has the details about ball.
        _ballBehaviour = _ball.GetComponent<Ball_behaviour>(); // Fetch the Script BallBehaviour from the ball object
        // This method is followed since the ball object is spawned and destroyed when playing the game. This type of Assignment worked during trial and error
        _ballPosition = new Vector2(-6.66f, _ball.transform.position.y); // _ballposition is the variable that stores the position of ball in every frame.
        Debug.Log(_ballBehaviour._enemySpeed);
        
        
        
        EnemyMove();

        _paddlePositionLower = new Vector2(-6.66f, _ball.transform.position.y + 0.8f);
        _paddlePositionUpper = new Vector2(-6.66f, _ball.transform.position.y - 0.8f);

        if (_ball.transform.position.x < -7.9f || _ball.transform.position.x > 7.9f)
        {
            _deathAudio.Play();
        }

    }

    // To move the enemy based on the balls position.
    private void EnemyMove()
    {
        if (_ball.transform.position.x < -1)
        {
            _rb.transform.position = Vector2.MoveTowards(transform.position, _ballPosition, _ballBehaviour._enemySpeed * Time.deltaTime);

            if (_rb.transform.position.y > 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, _paddlePositionUpper, _ballBehaviour._enemySpeed * Time.deltaTime);
            }
            if (_rb.transform.position.y < -2)
            {
                transform.position = Vector2.MoveTowards(transform.position, _paddlePositionLower, _ballBehaviour._enemySpeed * Time.deltaTime);
            }
        }
    }

    
    // To Slow the speed of the enemy very slightly per collision with the ball.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            _ballBehaviour._enemySpeed = _ballBehaviour._enemySpeed / 1.01f;
        }
    }
}
