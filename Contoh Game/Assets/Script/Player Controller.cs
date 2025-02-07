using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public float movementSpeed;
    public Animator animator;
    public readonly string moveAnimParameter = "Move";
    public bool isDead;
    public GameObject playerTpose, playerRagdoll;

    public Transform ragdollHips;
    public CameraFollow cameraFollow;
    public ParticleSystem bloodEffect;

    private AudioSource audioSource;

    public bool hasWon;
    public GameObject youWinText;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (isDead) return;
        
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, 0, moveZ);

        characterController.Move(move * movementSpeed * Time.deltaTime);

        float moveAnim = new Vector2(moveX, moveZ).magnitude;
        animator.SetFloat(moveAnimParameter, moveAnim);
        
        if (moveX == 0 &&  moveZ == 0) return;
        float heading = Mathf.Atan2(moveX, moveZ);
        transform.rotation = Quaternion.Euler(0, heading * Mathf.Rad2Deg, 0);
    }

    public void Dead ()
    {
        isDead = true;
        bloodEffect.Play();
        cameraFollow.playerTarget = ragdollHips;
        playerTpose.SetActive(false);
        playerRagdoll.SetActive(true);
        print("Player Mati");
        StartCoroutine(RestartGameCoroutine());
    }

    IEnumerator RestartGameCoroutine()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FinishLine>())
        {
            youWinText.SetActive(true);
            hasWon = true;
        }
    }
}
