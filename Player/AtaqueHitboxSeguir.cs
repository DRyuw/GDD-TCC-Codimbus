using UnityEngine;

public class AtaqueHitboxSeguir : MonoBehaviour
{
    public Transform jogador;        
    public Vector3 offset = new Vector3(1f, 0f, 0f); 
    public bool espelharComDirecao = true;         

    void LateUpdate()
    {
        if (jogador == null) return;

        Vector3 novaPosicao = jogador.position;
        
        if (espelharComDirecao && jogador.localScale.x < 0)
        {
            novaPosicao += new Vector3(-offset.x, offset.y, offset.z);
        }
        else
        {
            novaPosicao += offset;
        }

        transform.position = novaPosicao;
    }
}