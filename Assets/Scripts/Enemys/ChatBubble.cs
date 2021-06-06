using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour
{
    public static ChatBubble instance;

    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] public TextMeshProUGUI text;
    [SerializeField] private Animator anim;

    [Header("Frases")]
    [TextArea]
    [SerializeField] private string[] sentences;

    void Start()
    {
        instance = this;
        Speak();
    }

    private IEnumerator TypeEnemy()
    {
        foreach (char letter in sentences[Random.Range(0, sentences.Length)].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Speak()
    {
        StartCoroutine(TypeEnemy());
    }
}