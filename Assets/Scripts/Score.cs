using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    DatabaseReference reference;
    [SerializeField] InputField username;
    [SerializeField] InputField tempo;
    [SerializeField] InputField morte;
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void savedata(){
        User user = new User();
        user.UserName = username.text;
        user.Tempo = tempo.text;
        user.Morte = morte.text;

        string json = JsonUtility.ToJson(user);

        reference.Child("User").Child(user.UserName).SetRawJsonValueAsync(json).ContinueWith(task =>
        {
            if(task.IsCompleted){
                Debug.Log("sucesso");
            }
            else{
                Debug.Log("Erro");
            }
        });
    }
    void Update()
    {
        
    }
}
