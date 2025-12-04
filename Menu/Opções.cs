using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class Opções : MonoBehaviour
{
    public string NomeCena;
    public void ChangeScene()
    {
        SceneManager.LoadScene(NomeCena);
    }
}