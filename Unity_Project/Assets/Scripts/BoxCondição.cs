using UnityEngine;

public class BoxCondição : Blocks
{
    /*  Herdados do Blocks
    public float rayDistance;

    O que vai fazer: Vai checar se o if está analisando um BoxAlgo seguido desse box condicao, se tem um BoxAlgo a esquerda
    */
    //Deixar true no editor
    public bool isPressed, isOpen, isInterected = true; //POR exemplo esse é um bloco isOpen ent deixa isOpen true, e marca a condicao dele como isOpen. Se fosse um bloco isClosed, só muda o sprite e deixa o isOpen false e a condicao isOpen
    public CondicaoType condicaoType;
    public bool blockIfChecked;
    public enum CondicaoType
    {
        IsOpen, isPressed, isInterected
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
