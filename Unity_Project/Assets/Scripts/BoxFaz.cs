using UnityEngine;

public class BoxFaz : Blocks

/*  Herdados do Blocks
public float rayDistance;
BlockType blocktype

O que vai fazer: vai dizer a ação que um objeto irá fazer após a condição ser realizada
*/

{
    public FazType fazType;
    public enum FazType
    {
        Open, Spawn, Destroy
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
