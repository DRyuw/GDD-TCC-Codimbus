using UnityEngine;
using System.Collections;

public class PlayerDano : MonoBehaviour
{
    public GameObject hitboxObjeto; 
    public float tempoAtivo = 0.2f; 

    private bool atacando = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(HitboxTemp());
        }
    }

    IEnumerator HitboxTemp()
    {
        atacando = true;

        hitboxObjeto.SetActive(true); 

        yield return new WaitForSeconds(tempoAtivo); 

        hitboxObjeto.SetActive(false); 

        atacando = false;
    }

}
