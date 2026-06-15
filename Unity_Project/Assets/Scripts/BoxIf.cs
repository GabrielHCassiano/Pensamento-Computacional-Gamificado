using System;
using UnityEngine;

public class BoxIf : Blocks
{
    /*  Herdados do Blocks
    public float rayDistance;
    BlockType blocktype

    O que vai fazer: Vai soltar um Raycast, se acertar algo, vai checar que tipo de bloco é, aí checar a condiçaõ e fazer a ação
    */
    public bool isChecked = false; //Variavel pra saber se o if tem um Algo seguido por uma Condição
    GameObject primeiroObjeto;//Algo 1
    GameObject segundoObjeto;// Condicao
    GameObject terceiroObjeto;// Algo 2
    GameObject quartoObjeto;// Faz

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blockType = BlockType.If;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.right * rayDistance, Color.red);
        ChecarBloco();
    }

    public void ChecarBloco()//CHECA SE TEM UM BLOCO ALGO SEGUIDO POR UMA CONDICAO
    {
        RaycastHit2D[] hitInfo = Physics2D.RaycastAll(transform.position, transform.right, rayDistance);
        if (hitInfo.Length == 5)//Pega o de si msm, e aí ignora
        {
            primeiroObjeto = hitInfo[1].collider.gameObject;//ALGO 1
            segundoObjeto = hitInfo[2].collider.gameObject;//CONDICAO
            terceiroObjeto = hitInfo[3].collider.gameObject;//ALGO 2
            quartoObjeto = hitInfo[4].collider.gameObject;//FAZ


            if (primeiroObjeto.GetComponent<BoxAlgo>().blockType.Equals(BlockType.Algo) && segundoObjeto.GetComponent<BoxCondição>().blockType.Equals(BlockType.Condicao))//Checa se o 1 e o 2 Sao ALGO e condicao
            {
                isChecked = true;   
                segundoObjeto.GetComponent<BoxCondição>().blockIfChecked = true;//Era so que eu ia fazer de outro jeto, pode tirar dps
                if (segundoObjeto.GetComponent<BoxCondição>().condicaoType.Equals(BoxCondição.CondicaoType.IsOpen)) //checa as condicoes -- IsOpen
                { //SE A CONDICAO FOR UMA CAIXA DE IS OPENED OU IS CLOSED SE TIVER FALSE O BOOL
                    if (primeiroObjeto.GetComponent<BoxAlgo>().isOpen == segundoObjeto.GetComponent<BoxCondição>().isOpen) //SE ALGO ESTÁ ABERTO E CONDICAO FOR ESTAR ABERTO
                    {
                        //AKI FICA OS DO/FAZ
                        if (quartoObjeto.GetComponent<BoxFaz>().Equals(BoxFaz.FazType.Open))
                        {
                            terceiroObjeto.GetComponent<BoxAlgo>().objetoLinkado.GetComponent<DoorSet>().SetDoorInactive(true); //Abrir Porta, pode ser mais geral comoa tivar ou desativar
                        }
                        //ELSE colocar os outro faz, como invocar mais objetos, destruir obstaculos etc

                    }
                    //ELSE AVISAR QUE A CONDIÇÃO NÃO ESTÁ SENDO ACEITA, COLOCAR DPS
                }

                else if (segundoObjeto.GetComponent<BoxCondição>().condicaoType.Equals(BoxCondição.CondicaoType.isPressed))//SE A CONDICAO FOR UMA CAIXA DE ISPRESSED ENCONSTAR e enconstar
                {
                    if (primeiroObjeto.GetComponent<BoxAlgo>().isPressed && segundoObjeto.GetComponent<BoxCondição>().isPressed) // Se a condicao for encostar e tiver encostado
                    {
                        if (quartoObjeto.GetComponent<BoxFaz>().fazType.Equals(BoxFaz.FazType.Open))
                        {
                            terceiroObjeto.GetComponent<BoxAlgo>().objetoLinkado.GetComponent<DoorSet>().SetDoorInactive(true); //Abrir Porta, pode ser mais geral comoa tivar ou desativar
                        }
                    }
                }

                /*else if (segundoObjeto.GetComponent<BoxCondição>().condicaoType.Equals(BoxCondição.CondicaoType.isPressed))//SE A CONDICAO FOR UMA CAIXA DE INTERACT, apertar spaço no lugar
                {
                    if (primeiroObjeto.GetComponent<BoxAlgo>().isInterected == segundoObjeto.GetComponent<BoxCondição>().isInterected) //Se a condicao for interagir e interagir
                    {
                        if (quartoObjeto.GetComponent<BoxFaz>().fazType.Equals(BoxFaz.FazType.Open))
                        {
                            terceiroObjeto.GetComponent<BoxAlgo>().objetoLinkado.GetComponent<DoorSet>().SetDoorInactive(true); //Abrir Porta, pode ser mais geral comoa tivar ou desativar
                        }
                    }
                }*/



            }
            else if (segundoObjeto.GetComponent<BoxCondição>().blockType.Equals(BlockType.Condicao)){ //NAO PASSA NA 1 CONDICAO
                isChecked = false;
                segundoObjeto.GetComponent<BoxCondição>().blockIfChecked = false;
            }
        }
        else 
        {
            isChecked = false;
        }
    }
}
