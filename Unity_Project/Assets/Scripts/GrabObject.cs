using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObject : MonoBehaviour
{
    public Transform grabPoint;
    public Transform rayPoint;

    public float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;
    private Vector2 playerMoveInput;
    Vector2 dir;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
        dir = playerMoveInput;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if(grabbedObject == null)
        {
            RotateGrabRayPoint();
        }

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }
            else if(Keyboard.current.eKey.wasPressedThisFrame)
            {
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
        }
        Debug.DrawRay(rayPoint.position, transform.right * rayDistance, Color.red);
    }

    void RotateGrabRayPoint()
    {
        
        playerMoveInput = gameObject.GetComponent<PlayerMovement>().moveInput;
        if (!playerMoveInput.Equals(Vector2.zero))
        {
            dir = playerMoveInput;
        }
        


        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            // Movimento horizontal
            if (dir.x > 0)
            {
                // Direita
                grabPoint.localPosition = new Vector2(1.3f, 0);
                rayPoint.localPosition = new Vector2(1.3f, 0);
            }
            else
            {
                // Esquerda
                grabPoint.localPosition = new Vector2(-1.3f, 0);
                rayPoint.localPosition = new Vector2(-1.3f, 0);
            }
        }
        else
        {
            // Movimento vertical
            if (dir.y > 0)
            {
                // Cima
                grabPoint.localPosition = new Vector2(0, 1.3f);
                rayPoint.localPosition = new Vector2(0, 1.3f);
            }
            else
            {
                // Baixo
                grabPoint.localPosition = new Vector2(0, -1.3f);
                rayPoint.localPosition = new Vector2(0, -1.3f);
            }
        }
    }

}
