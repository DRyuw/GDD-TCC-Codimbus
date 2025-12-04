using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class Play : MonoBehaviour
{
    public string NomeCena; 
    public void ChangeScene()
    {
        SceneManager.LoadScene(NomeCena);
    }
}
