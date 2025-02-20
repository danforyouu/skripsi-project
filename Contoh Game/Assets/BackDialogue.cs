using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class BackDialogue : MonoBehaviour
{
    public Dialogue Dialogue; // Pastikan diassign di Inspector
    private Button backButton;

    void Start()
    {
        // Pastikan backButton tidak null
        backButton = GetComponent<Button>();
        if (backButton == null)
        {
            Debug.LogError("BackButton tidak ditemukan pada GameObject!");
            return;
        }

        // Pastikan dialogueScript tidak null
        if (Dialogue == null)
        {
            Dialogue = FindObjectOfType<Dialogue>(); // Cari otomatis jika tidak diassign
            if (Dialogue == null)
            {
                Debug.LogError("Dialogue script tidak ditemukan di scene!");
                return;
            }
        }

        backButton.onClick.AddListener(GoBack);
        UpdateButtonState();
    }

    public void GoBack()
    {
        if (Dialogue != null && Dialogue.CanGoBack())
        {
            Dialogue.PreviousLine();
            UpdateButtonState();
        }
    }

void UpdateButtonState()
{
    if (Dialogue != null && backButton != null)
    {
        // Pastikan tombol tetap aktif setidaknya sampai dialog pertama selesai
        backButton.interactable = (Dialogue.CanGoBack() || Dialogue.lines.Length > 1);
    }
}

}