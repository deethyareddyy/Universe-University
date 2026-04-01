using UnityEngine;
using UnityEngine.InputSystem;
public class HoverScript : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2D;
    Transform previousHoverObj, nextHoverObj;
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
    void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);
        previousHoverObj = nextHoverObj;
        raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
        nextHoverObj = raycastHit2D ? raycastHit2D.collider.transform : null;

        if (nextHoverObj)
        {
            nextHoverObj.GetComponent<SpriteRenderer>().color = Color.red; // visible
            if (previousHoverObj && nextHoverObj && previousHoverObj.GetInstanceID() != nextHoverObj.GetInstanceID())
            {
                previousHoverObj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0); // invisible again
            }
        }
        else
        {
            if (previousHoverObj)
            {
                previousHoverObj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0); // invisible again
            }
        }
    }
}
