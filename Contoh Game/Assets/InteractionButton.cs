using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionButton : MonoBehaviour
{
    public GameObject targetObject; // Objek yang akan diinteraksi
    public TextMeshProUGUI messageText; // UI Text untuk menampilkan pesan

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(InteractWithObject);
        messageText.gameObject.SetActive(false);
    }

    void InteractWithObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(!targetObject.activeSelf); // Toggle objek (sembunyi/tampil)
            
            // Menampilkan pesan jika objek aktif
            if (messageText != null)
            {
                messageText.text = targetObject.activeSelf ? "Objek telah diaktifkan!" : "Objek disembunyikan!";
            }
        }
    }
}
