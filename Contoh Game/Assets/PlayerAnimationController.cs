using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;
    public float speed = 0f;
    public float walkSpeed = 2f;
    public float runSpeed = 5f;

    void Update()
    {
        // Ambil input pergerakan
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Hitung kecepatan total
        speed = new Vector2(moveX, moveY).magnitude;
        animator.SetFloat("MoveSpeed", speed);

        // Cek apakah tombol sprint ditekan
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    // Panggil fungsi ini ketika mencapai finish
    public void TriggerVictory()
    {
        animator.SetBool("Victory", true);
    }
}
