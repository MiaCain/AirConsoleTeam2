using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : PhysicsObject
{
    public bool isActive;
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        if (isActive)
        {
            Vector2 move = Vector2.zero;

            move.x = Input.GetAxis("Horizontal");

            if (Input.GetButtonDown("Jump") && grounded)
            {
                velocity.y = jumpTakeOffSpeed;
            }
            else if (Input.GetButtonUp("Jump"))
            {
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * 0.5f;
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("Attack");
                Attack.gameObject.SetActive(true);
            }

            bool flipSprite = (spriteRenderer.flipX ? (move.x >= 0.01f) : (move.x <= -0.01f));
            if (flipSprite)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(0);
            }



            targetVelocity = move * maxSpeed;
        }            

            animator.SetBool("grounded", grounded);
            animator.SetFloat("VelocityX", Mathf.Abs(velocity.x) / maxSpeed);
            animator.SetFloat("VelocityY", velocity.y);
            animator.SetBool("Damaged", isHurt);
    }

    public void StopAttack()
    {
        Attack.gameObject.SetActive(false);
    }

    public void StopDamaged()
    {
        isHurt = false;
    }
}