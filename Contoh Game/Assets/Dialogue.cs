using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    void Start()
    {
        if (textComponent == null)
        {
            Debug.LogError("TextMeshProUGUI belum diassign di Inspector!");
            return;
        }

        if (lines == null || lines.Length == 0)
        {
            Debug.LogError("Array lines kosong! Pastikan sudah diisi dengan teks dialog.");
            return;
        }

        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(Typeline());
    }

    IEnumerator Typeline()
    {
        textComponent.text = string.Empty;
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StopAllCoroutines();
            StartCoroutine(Typeline());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void PreviousLine()
    {
        if (index > 0)
        {
            index--;
            StopAllCoroutines();
            StartCoroutine(Typeline());
        }
    }

    public bool CanGoBack()
    {
        return index > 0;
    }
}