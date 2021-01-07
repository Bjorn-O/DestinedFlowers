using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 6f;
    [SerializeField] float _jumpheight = 2.5f;

    [SerializeField] float _gravity = 5f;
    private float _verticalVelocity;

    [SerializeField] CharacterController _charControl;

    //[SerializeField] Animator anime;



    void Start()
    {
        _movementSpeed = 6f;
        //anime = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(horizontal, 0f).normalized;
        direction = Vector2.ClampMagnitude(direction, _movementSpeed);


        if (_charControl.isGrounded)
        {
            _verticalVelocity = -_gravity * Time.deltaTime;
            if(Input.GetButtonDown("Jump"))
            {
                _verticalVelocity = _jumpheight;
            }
        }

        else 
        {
            _verticalVelocity -= _gravity * Time.deltaTime;
        }

        direction.y = _verticalVelocity; //applies gravity


        if (direction.magnitude >= 0.1f)
        {
        float lookAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, lookAngle, 0f);

        _charControl.Move(direction * _movementSpeed * Time.deltaTime);
        }

        

    }
}
