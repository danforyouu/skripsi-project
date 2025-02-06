using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1; // Level yang sedang dimainkan
    private const int totalLevel = 8; // Total level yang tersedia
    private const float unlockThreshold = 100f; // Persentase untuk membuka level

    void Start()
    {
        // Jika belum ada data progress, inisialisasi level pertama sebagai terbuka
        if (!PlayerPrefs.HasKey("Level1Progress"))
        {
            for (int i = 1; i <= totalLevel; i++)
            {
                PlayerPrefs.SetFloat($"Level{i}Progress", 0);
                PlayerPrefs.SetInt($"Level{i}Unlocked", i == 1 ? 1 : 0);
            }
            PlayerPrefs.Save();
        }
    }

    // Fungsi untuk menambah progress
    public void AddProgress(float amount)
    {
        string progressKey = $"Level{currentLevel}Progress";
        float newProgress = PlayerPrefs.GetFloat(progressKey) + amount;
        PlayerPrefs.SetFloat(progressKey, Mathf.Clamp(newProgress, 0, 100));
        PlayerPrefs.Save();

        // Cek apakah level saat ini sudah selesai
        if (newProgress >= unlockThreshold)
        {
            UnlockNextLevel();
        }
    }

    // Fungsi untuk membuka level berikutnya
    private void UnlockNextLevel()
    {
        if (currentLevel < totalLevel)
        {
            string nextLevelKey = $"Level{currentLevel + 1}Unlocked";
            PlayerPrefs.SetInt(nextLevelKey, 1);
            PlayerPrefs.Save();
        }
    }

    // Fungsi untuk mengecek apakah level bisa dimainkan
    public bool IsLevelUnlocked(int level)
    {
        return PlayerPrefs.GetInt($"Level{level}Unlocked", 0) == 1;
    }

    public void CompleteMaterial()
    {
        AddProgress(20f);
    }

    public void CompleteExampleAndCode()
    {
        AddProgress(20f);
    }

    public void CompleteMaterialQuestion()
    {
        AddProgress(30f);
    }

    public void CompleteCodingQuestion()
    {
        AddProgress(30f);
    }

    public void LoadLevel(int level)
    {
        string levelName = "Lv1" + level; // Sesuaikan dengan nama scene di folder "Scenes"
        if (PlayerPrefs.GetInt($"Level{level}Unlocked", 0) == 1) 
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.Log("Level terkunci!");
        }
    }
}