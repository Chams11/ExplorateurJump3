using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float speed = 6f;

    public float jumpspeed = 8f;

    public float gravity = 20f;

    private float animSpeed;

    private float animJump;

    private Vector3 moveD = Vector3.zero;
    CharacterController Cac;

    private Camera cam;
    private Vector3 forward, right;
    

    [SerializeField] private Animator anim;

    public GameObject groundRayObject;

    bool jumpOn;

    void Start()
    {
        jumpOn = false;
        Cac = GetComponent<CharacterController>();
        cam = Camera.main;
    }


    void Update()
    {
        GetCameraDirection();   
        if (Cac.isGrounded)
        {
            if(anim.GetBool("IsJumping"))
            {
                anim.SetBool("IsJumping", false);
            }
            Movement();
            Jump();
        }
        Rotate();
        UpdateMovement();
    }

    public void Movement()
    {
        //moveD = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveD = Input.GetAxis("Horizontal") * right + Input.GetAxis("Vertical") * forward;
        //moveD = transform.TransformDirection(moveD);
        moveD *= speed;
        MovementAnimation();
    }

    public void MovementAnimation()
    {
        animSpeed = moveD.magnitude * speed;
        anim.SetFloat("Speed", animSpeed);
    }
    
    public void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            moveD.y = jumpspeed;
            anim.SetBool("IsJumping", true);
        }
    }



    public void Rotate() 
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * speed * 10);
    }

    public void UpdateMovement()
    {
        moveD.y -= gravity * Time.deltaTime;
        Cac.Move(moveD * Time.deltaTime);
    }

    public void GetCameraDirection()
    {
        forward = cam.transform.forward;
        right = cam.transform.right;

        forward.y = 0; 
        right.y = 0;

        forward.Normalize();
        right.Normalize(); 
    }


    private void FixedUpdate ()
    {
        RaycastHit hitGround;
        if (Physics.Raycast(groundRayObject.transform.position, -Vector3.up, out hitGround))
        {
            if (hitGround.collider != null)
            {
                if (hitGround.distance <= 0.2)
                {
                    jumpOn = true;
                }
                else
                {
                    jumpOn = false;
                }
                Debug.DrawRay(groundRayObject.transform.position, -Vector3.up * hitGround.distance, Color.red);
            }
        }
    }
}


   