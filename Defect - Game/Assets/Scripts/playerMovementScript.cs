using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{
    public Rigidbody2D rigBod;
    public bool isGrounded = true, activeCharacter;
    public Animator animator;
    public Transform groundCheck;
    public LayerMask groundLayer, entity;
    public float jumpForce, moveForce, xDir;
    public GameObject interactIcon;
    public bool isMainChar;
    public bool isActive;
    public bool canInteract = false;


    private Vector2 boxSize = new Vector2(1f, 1f);

    void Start()
    {
        rigBod = GetComponent<Rigidbody2D>();

        interactIcon.SetActive(false);

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CheckInteraction();
            }


            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.42f, groundLayer);

            GameObject searchRes = GameObject.FindGameObjectWithTag("Player");
            if (searchRes != null && !isMainChar)
            {
                //CheckForJump
                if (Physics2D.OverlapCircle(groundCheck.position, 0.42f, entity))
                {
                    //Debug.Log("MainPlayer can totem jump");
                    isGrounded = true;
                }
                    

            }
            else
            {
                searchRes = GameObject.FindGameObjectWithTag("SidePlayer");
                if (searchRes != null && isMainChar)
                {
                    if (Physics2D.OverlapCircle(groundCheck.position, 0.42f, entity))
                    {
                        //Debug.Log("sidePlayer can totem jump");
                        isGrounded = true;
                    }
                }
            }



            if (Input.GetButtonDown("Jump")) Jump();
        }
    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        xDir = Input.GetAxisRaw("Horizontal");
        if (!isActive) xDir = 0;
        rigBod.velocity = new Vector2(xDir * moveForce, rigBod.velocity.y);

        if (isActive)
        {
            Move();
        }
        if (canInteract && isActive)
        {
            OpenInteractIcon();
        }
    }


    void Jump()
    {
        if (isGrounded)
        {
            rigBod.velocity = new Vector2(rigBod.velocity.x, jumpForce);
        }
    }


    public void OpenInteractIcon()
    {
        if (canInteract) interactIcon.SetActive(true);
    }

    public void CloseInteractIcon()
    {
        interactIcon.SetActive(false);
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if(rc.transform.GetComponent<interactibleScript>())
                {
                    rc.transform.GetComponent<interactibleScript>().Interact(isMainChar);
                    return; 
                }
            }
        }
    }

    public void setIsActive(bool activeState)
    {
        isActive = activeState;
    }

    void Move()
    {
    
        Vector3 charScale = transform.localScale;

        if (xDir > 0)
        {
            charScale.x = 6;
            animator.SetBool("isMoving", true);
        }
        else if (xDir < 0)
        {
            charScale.x = -6;
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        transform.localScale = charScale;
    }

    public void setInteract()
    {
        canInteract = !canInteract;
    }
}
