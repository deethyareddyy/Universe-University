using UnityEngine;
using UnityEngine.InputSystem;
public class HoverScript : MonoBehaviour
{
    Vector2 mousePosition;
    //RaycastHit2D raycastHit2D;
    Transform previousHoverObj, nextHoverObj;
    void Start()
    {
        //GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
    void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();
        // Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);
        Vector3 worldPos3D = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0));
        Vector2 worldPos = new Vector2(worldPos3D.x, worldPos3D.y);
        previousHoverObj = nextHoverObj;
        //raycastHit2D = Physics2D.Raycast(worldPos, Vector2.zero);
        Collider2D hit = Physics2D.OverlapPoint(worldPos, ~0);
        // Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        // RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, ~0);
        // Debug.Log(hit ? $"Hit: {hit.name}, Root: {hit.transform.root.name}" : "No hit");
        nextHoverObj = hit ? hit.transform.root : null;

        if (nextHoverObj != null)
        {
            SetColor(nextHoverObj, Color.yellowGreen);
            if (previousHoverObj != null && nextHoverObj && previousHoverObj != nextHoverObj)
            {
                SetColor(previousHoverObj, Color.white);
            }
        }
        else
        {
            if (previousHoverObj != null)
            {
                SetColor(previousHoverObj, Color.white);
            }
        }
    }

    void SetColor(Transform root, Color color)
    {
        foreach (SpriteRenderer sr in root.GetComponentsInChildren<SpriteRenderer>(true))
        {
            sr.color = color;
        }
    }
}
