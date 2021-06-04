using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour
{
    public static ChatBubble instance;

    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] public TextMeshProUGUI text;
    
    [Header("Frases")]
    [TextArea]
    [SerializeField] private string[] sentences;

    private int textIndex;

    private IEnumerator TypeEnemy()
    {
        foreach (char letter in sentences[textIndex].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Speak()
    {
        StartCoroutine(TypeEnemy());
    }

    void Start()
    {
        instance = this;
        Speak();
    }
}