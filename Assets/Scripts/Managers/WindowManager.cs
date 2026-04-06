using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class WindowManager : MonoBehaviour
{
    public GameObject window_close;
    // Update is called once per frame
    public bool open = false;
    void Update()
    {        // 1. Listen for the exact frame the left mouse button is clicked
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector3 worldPos3D = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0));
            Vector2 worldPos = new Vector2(worldPos3D.x, worldPos3D.y);

            Collider2D hit = Physics2D.OverlapPoint(worldPos);

            if (hit != null && hit.gameObject == this.gameObject && !open)
            {
                Debug.Log("Clicked on the window");
                window_close.SetActive(false);
            }
            else if (hit != null && hit.gameObject == this.gameObject && open)
            {
                Debug.Log("Clicked on the window");
                window_close.SetActive(true);
            }
        }
        
    }
}
