using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{ 
    public CharacterController CharacterController;
    public Animator Animator;
    public Camera MainCamera;
    public Transform GroundCheck;
    public Transform CamPos;
    public LayerMask GroundMask;
    
    public float MouseSensitivity = 100f;
    public float Speed = 10f;
    public float JumpHeight = 3f;
    public float GroundDistance = 0.4f;
    public float VelocityRatio;
    public float BackVelocityRatio;

    private float _xRotation = 0f;
    private float _yRotation = 0f;

    private Vector3 _yVelocity;
    private Vector3 _xzVelocity;
    private bool _isGrounded;
    private const float _gravity = -10f;
    private bool _canMove;

    private void OnEnable()
    {
        EventManager.Singleton.E_UiWindowActivated += OnUiActivated;
        EventManager.Singleton.E_UiWindowDisabled += OnUiDisabled;
    }

    private void OnDisable()
    {
        EventManager.Singleton.E_UiWindowActivated -= OnUiActivated;
        EventManager.Singleton.E_UiWindowDisabled -= OnUiDisabled;
    }
    // Start is called before the first frame update
    void Start()
    {
        _canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canMove)
        {
            return;
        }

        RotateBody();
        MoveBody();
        Jump();
    }

    public void RotateBody()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.fixedDeltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _yRotation += mouseX;

        CharacterController.transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);

        MainCamera.transform.position = CamPos.position;
        MainCamera.transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0f);

    }

    public void MoveBody()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        float xVelocity = xMove * VelocityRatio;
        float zVelocity = Mathf.Clamp(zMove * VelocityRatio, BackVelocityRatio, VelocityRatio);
        _xzVelocity = transform.right * xVelocity + transform.forward * zVelocity;

        Animator.SetFloat("xVelocity", xVelocity);
        Animator.SetFloat("zVelocity", zVelocity);

        CharacterController.Move(_xzVelocity * Speed * Time.deltaTime);
        
    }

    public void Jump()
    {
        _isGrounded = Physics.CheckSphere(GroundCheck.position,GroundDistance,GroundMask);

        if(_isGrounded && _yVelocity.y < 0)
        {
            _yVelocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _yVelocity.y = Mathf.Sqrt(-2f * _gravity * JumpHeight);
        }

        _yVelocity.y += _gravity * Time.deltaTime;
        CharacterController.Move(_yVelocity * Time.deltaTime);
    }

    private void OnUiActivated(UiWindowType type)
    {
        _canMove = false;
    }

    private void OnUiDisabled(UiWindowType type)
    {
        _canMove = true;
    }
}

