using UnityEngine;

public class DoorSet : MonoBehaviour
{
    public bool isOpen,isPressed,isInterected = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDoorInactive(bool doorSet)
    {
        gameObject.SetActive(!doorSet);
        isOpen = !doorSet;
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        isPressed = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isPressed = false;
    }
}
