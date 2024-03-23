using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform Peko;
    [SerializeField] private Animator anim;

    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private AudioSource jumpSoundEffect;
    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;

    private void Update() {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        #region JUMPING
        if (isGrounded && Input.GetButtonDown("Jump")) {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
            jumpSoundEffect.Play();
        }

        if (isJumping && Input.GetButton("Jump")) {

            if (jumpTimer < jumpTime) {
                rb.velocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;
            } else {
                isJumping = false;
            }
        }
        if (Input.GetButtonUp("Jump")) {
            isJumping = false;
            jumpTimer = 0;
        }

        #endregion

        #region CROUCHING
        if (isGrounded && Input.GetButton("Crouch")) {
            Peko.localScale = new Vector3(Peko.localScale.x, crouchHeight, Peko.localScale.z);
            
            if (isJumping && Input.GetButton("Crouch")) {
                Peko.localScale = new Vector3(Peko.localScale.x, 1f, Peko.localScale.z);
        }

        }

        

        if (Input.GetButtonUp("Crouch")) {
            Peko.localScale = new Vector3(Peko.localScale.x, 1f, Peko.localScale.z);
        }
    }
        #endregion


}
