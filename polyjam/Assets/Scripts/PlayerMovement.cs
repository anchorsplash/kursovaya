using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public CharacterController controller;
    public float smoothTime;
    float smoothVelocity;
    public float speed = 25.0f; // скорость передвижения
    public Transform firstCamera;
    public Transform orientation;
    public float jumpSpeed = 7.0f;
    public float gravity = 0;
    public float jumpHeight = 70;

    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    Vector3 velocity;
    public bool isGrounded;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        Vector3 viewDirection = transform.position - new Vector3(firstCamera.transform.position.x, firstCamera.transform.position.y, firstCamera.transform.position.z);
        orientation.forward = viewDirection.normalized;

        float horizontal = Input.GetAxis("Horizontal"); // получаем значение оси горизонтали (A и D)
        float vertical = Input.GetAxis("Vertical"); // получаем значение оси вертикали (W и S)
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical).normalized; // создаем вектор движения

        //sprint
        if (Input.GetKey(KeyCode.LeftShift) && movement.magnitude >= 0.1f)
        {
            speed = 25;
            animator.SetBool("sprint", true);
        }
        else
        {
            speed = 12;
            animator.SetBool("sprint", false);
        }

        //walking
        if (movement.magnitude >= 0.1f)
        {
            float rotationAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + firstCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationAngle, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 move = Quaternion.Euler(0f, rotationAngle, 0f) * Vector3.forward;

            controller.Move(move.normalized * speed * Time.deltaTime);

            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }

        transform.Translate(movement * speed * Time.deltaTime); // перемещаем персонажа

        //gravity and jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            animator.SetBool("jumping", true);
        }
        else
        {
            animator.SetBool("jumping", false);
        }
    }
}