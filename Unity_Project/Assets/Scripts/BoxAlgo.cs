using UnityEngine;

public class BoxAlgo : Blocks
/*  Herdados do Blocks
public float rayDistance;
BlockType blocktype

O que vai fazer: Vai conter um link à algum elemento da cena, como porta, botoes, alavancas , etc. o que vai conter uma condição
*/
{
    public GameObject objetoLinkado;//colocar na cena
    public bool isPressed, isOpen, isInterected;// Condicao do objeto, 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = objetoLinkado.GetComponent<DoorSet>().isOpen;
        isPressed = objetoLinkado.GetComponent<DoorSet>().isPressed;
    }
}
