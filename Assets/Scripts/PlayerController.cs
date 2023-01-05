using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;

    private int score;
    private AudioSource playerAudio;
    private Animator playerAnimation;
    private InterfaceManager interfaceManager;
    private Rigidbody playerRb;
    private bool isOnGround = true;
    private bool gameOver = false;
    private bool doubleJump = false;

    private void Start()
    {
        score = -1;
        interfaceManager = FindObjectOfType<InterfaceManager>();
        playerRb = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            doubleJump = true;
            playerAnimation.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        } else if (doubleJump && !isOnGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerAudio.PlayOneShot(jumpSound, 1.0f);
                doubleJump = false;
            }
        }
        if (interfaceManager.gameWon)
        {
            // you've won the game
            Debug.Log("Congratulations!");
            gameOver = true;
            playerAnimation.SetFloat("Speed_f", 0.2f);
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            score += 1;
            dirtParticle.Play();

        } else if (collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            Debug.Log("Score: " + score);
        }
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

    public int GetScore()
    {
        return score;
    }
}
