
// SCRIPT NAME BallBehaviour.

using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Ball_behaviour : MonoBehaviour
{

    private Rigidbody2D _rb;
    private float _moveSpeed ;
    public Vector2 _ballPos;
    private GameManager _gm;
    public float _enemySpeed;
    [SerializeField] private GameObject _ball;
    public AudioSource _bounce;
    public float _random;
    private float _speedMultiplier = 1.02f;



    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _random = Random.Range(0f, 2f);
        _enemySpeed = 10f;
        if(_random > 1)
        {
            _moveSpeed = Random.Range(10,13);
            //Debug.Log("Right");
        }
        else{
            _moveSpeed = Random.Range(-13,-10);
        }
        //Ball Dash
        Invoke("BallDash", 1.5f);
    }


    // To check collision between player and the ball
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _bounce.Play();
            _rb.velocity *= _speedMultiplier; // To increase ball speed after collision
        }
    }

   

    private void Update()
    {
        
        if (gameObject.transform.position.x < -7.9f)
        {
            Destroy(gameObject);
            _gm._score++;
            _gm.Spawn();
           
        }
        if (gameObject.transform.position.x > 7.9f)
        {
            Destroy(gameObject);
            _gm._ScoreScore++;
            _gm.Spawn();
        }    
    }


    // Used to apply the initial velocity in the ball after spawning
    private void BallDash()
    {
       
        Vector2 dir = new Vector2(_moveSpeed, 0);
        dir.y = Random.Range(-4, 4);
        if (dir.y == 0 || dir.y == 1)
        {
            dir.y += 2;
        }
        if (dir.y == -1)
        {
            dir.y -= 1;
        }
        _rb.velocity = dir;
    }
}
