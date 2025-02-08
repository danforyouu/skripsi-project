using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public float movementSpeed;
    public Animator animator;
    public readonly string moveAnimParameter = "MoveSpeed";
    public GameObject playerTpose;

    private AudioSource audioSource;

    Joystick joystick;

    public bool hasWon;
    public GameObject youWinText;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        joystick = FindAnyObjectByType<Joystick>();
    }

    void Update()
    {
        Movement();
    }
    void Movement()
    {
        
        float moveX = Input.GetAxis("Horizontal") + joystick.Horizontal;
        float moveZ = Input.GetAxis("Vertical") + joystick.Vertical;

        Vector3 move = new Vector3(moveX, 0, moveZ);

        characterController.Move(move * movementSpeed * Time.deltaTime);

        float moveAnim = new Vector2(moveX, moveZ).magnitude;
        animator.SetFloat(moveAnimParameter, moveAnim);

        
        if (moveX == 0 &&  moveZ == 0) return;
        float heading = Mathf.Atan2(moveX, moveZ);
        transform.rotation = Quaternion.Euler(0, heading * Mathf.Rad2Deg, 0);
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
        public void TriggerVictory()
    {
        animator.SetBool("Victory", true);
    }
}