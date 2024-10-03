using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //Script Objects
    private Rigidbody2D _rb;
    float _inputVertical;
    float _playerSpeed = 10f;
   
   
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

   
    private void Update()
    {
        _inputVertical = Input.GetAxisRaw("Vertical");
        _rb.velocity = new Vector2(0, _inputVertical * _playerSpeed);

    }
}
