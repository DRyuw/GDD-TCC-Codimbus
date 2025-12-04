using UnityEngine;

public class FixarNoEixoZ : MonoBehaviour
{
    public float zFixo = 0f;

    void LateUpdate()
    {
        Vector3 posicaoAtual = transform.position;
        posicaoAtual.z = zFixo;
        transform.position = posicaoAtual;
    }
}