using System;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    

    public float rayDistance;
    public BlockType blockType;

    public enum BlockType
    {
        If, Acao, Condicao, Algo
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    /*public void ChecarBloco()
    {
        RaycastHit2D[] hitInfo = Physics2D.RaycastAll(transform.position, transform.right, rayDistance);
        if (hitInfo.Length == 3)//Pega o de si msm, e aí ignora
        {
            GameObject primeiroObjeto = hitInfo[1].collider.gameObject;
            GameObject segundoObjeto = hitInfo[2].collider.gameObject;

            if (primeiroObjeto.GetComponent<Blocks>().blockType.Equals(BlockType.Algo) && segundoObjeto.GetComponent<Blocks>().blockType.Equals(BlockType.Condicao))
            {
                Debug.Log("2 objetos, primeiro algo segundo condicao");
            }
        }
    }*/
}
