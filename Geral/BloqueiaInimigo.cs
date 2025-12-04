using UnityEngine;

public class BloqueiaInimigo : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Inimigo"))
        {
            var seguir = col.gameObject.GetComponent<ProjetilSeguir>();
            if (seguir != null)
                seguir.enabled = false;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Inimigo"))
        {
            var seguir = col.gameObject.GetComponent<ProjetilSeguir>();
            if (seguir != null)
                seguir.enabled = true;
        }
    }
}
