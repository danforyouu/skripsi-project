using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject panelMenu; // Drag Panel ke sini dari Inspector

    public void ToggleMenu()
    {
        // Mengubah status aktif/non-aktif panel menu
        panelMenu.SetActive(!panelMenu.activeSelf);
    }
    public GameObject menuPanel; // Drag Panel Menu ke sini dari Inspector
    public void CloseMenu()
    {
        // Menyembunyikan menu dan kembali ke gameplay
        menuPanel.SetActive(false);
        Time.timeScale = 1; // Pastikan game kembali berjalan normal jika sempat dipause
    }
}
