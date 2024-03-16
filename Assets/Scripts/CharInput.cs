using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInput : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("JumpTrigger");
            animator.SetBool("IsJump", true);
        }

        //basic movement handling
        movementInitiatedHandler();

        //basic stop of movement handling
        movementStoppingHandler();

        //talk
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("TalkTrigger");
        }
    }

    //WASD pressed
    public void movementInitiatedHandler()
    {
        //LShift pressed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("IsSprint", true);
        }

        //WASD pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("IsMove", true);
            animator.SetFloat("FBSpeed", 2f);

            Vector3 moveDir = new Vector3(animator.GetFloat("FBSpeed"), 0f, 0f).normalized;

            if (animator.GetBool("IsSprint"))
            {
                transform.Translate(moveDir * animator.GetFloat("FBSpeed") * Time.deltaTime * 4);
            } else
            {
                transform.Translate(moveDir * animator.GetFloat("FBSpeed") * Time.deltaTime);
            }
        } 
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("IsMove", true);
            animator.SetFloat("LRSpeed", 2f);

            Vector3 moveDir = new Vector3(0f, 0f, animator.GetFloat("LRSpeed")).normalized;
            if (animator.GetBool("IsSprint"))
            {
                transform.Translate(moveDir * animator.GetFloat("LRSpeed") * Time.deltaTime * 4);
            }
            else
            {
                transform.Translate(moveDir * animator.GetFloat("LRSpeed") * Time.deltaTime);
            }
        } 
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("IsMove", true);
            animator.SetFloat("FBSpeed", -2f);

            Vector3 moveDir = new Vector3(animator.GetFloat("FBSpeed"), 0f, 0f).normalized;
            if (animator.GetBool("IsSprint"))
            {
                transform.Translate(moveDir * animator.GetFloat("FBSpeed") * Time.deltaTime * 4);
            }
            else
            {
                transform.Translate(moveDir * animator.GetFloat("FBSpeed") * Time.deltaTime);
            }
        } 
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("IsMove", true);
            animator.SetFloat("LRSpeed", -2f);

            Vector3 moveDir = new Vector3(0f, 0f, animator.GetFloat("LRSpeed")).normalized;
            if (animator.GetBool("IsSprint"))
            {
                transform.Translate(moveDir * animator.GetFloat("LRSpeed") * Time.deltaTime * 4);
            }
            else
            {
                transform.Translate(moveDir * animator.GetFloat("LRSpeed") * Time.deltaTime);
            }
        }
    }

    //keys NOT pressed
    public void movementStoppingHandler()
    {
        //Lshift let go
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("IsSprint", false);
        }

        //WASD let go
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("IsMove", false);
            animator.SetFloat("FBSpeed", 0f);
        } 
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("IsMove", false);
            animator.SetFloat("LRSpeed", 0f);
        } 
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("IsMove", false);
            animator.SetFloat("FBSpeed", 0f);
        } 
        
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("IsMove", false);
            animator.SetFloat("LRSpeed", 0f);
        }
    }
}
