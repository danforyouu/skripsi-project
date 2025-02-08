using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerAnim = other.GetComponent<PlayerController>();
            if (playerAnim != null)
            {
                playerAnim.TriggerVictory();
            }
        }
    }
}
