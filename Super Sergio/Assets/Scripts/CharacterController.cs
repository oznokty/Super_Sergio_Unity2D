using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
  [SerializeField] private float speed = 5f;
  [SerializeField] private float jumpForce = 550f;
  private Rigidbody2D _rigidbody2d;
  private Animator _animator;

  private bool grounded;
  private bool started;
  private bool jumping;

  private void Awake() 
  {
    _rigidbody2d =  GetComponent<Rigidbody2D>();
    _animator = GetComponent<Animator>();
    grounded = true;
    //started = true;
  }

  private void Update()
  {
    if (Input.GetKeyDown(name: "space"))
    {
        if(started && grounded)
        {
            _animator.SetTrigger(name:"Jump");
            grounded = false;
            jumping = true;

        }
        else
        {
            _animator.SetBool(name:"GameStart", value:true);
            started = true;
        }
    }
        _animator.SetBool(name:"Grounded", grounded);
  }
  private void FixedUpdate() 
  {
    if(started)
    {
        _rigidbody2d.velocity = new Vector2(x:speed, _rigidbody2d.velocity.y);
    }
    if (jumping)
    {
        _rigidbody2d.AddForce(new Vector2(x:0f, y:jumpForce));
        jumping = false;
    }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"));
        {
            grounded = true;
        }
    }



    
}
  