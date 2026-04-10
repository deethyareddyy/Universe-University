using UnityEngine;
using UnityEngine.InputSystem;

public class WindowManager : MonoBehaviour
{
    public GameObject window;
    public static WindowManager Instance;

    // If it starts visible, isOpen is true
    private bool isOpen = true;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector3 worldPos3D = Camera.main.ScreenToWorldPoint(
                new Vector3(mousePosition.x, mousePosition.y, 0)
            );
            Vector2 worldPos = new Vector2(worldPos3D.x, worldPos3D.y);

            Collider2D hit = Physics2D.OverlapPoint(worldPos);

            if (hit != null && hit.gameObject == window)
            {
                if (isOpen) 
                {
                    OpenWindow(); 
                }
                else 
                {
                    CloseWindow();
                }
            }
        }
    }

    // This function makes the window disappear
    public void OpenWindow()
    {
        isOpen = false;
        window.SetActive(false);
        Debug.Log("Window opened");
    }

    // This function makes the window appear
    public void CloseWindow()
    {
        isOpen = true;
        window.SetActive(true);
        Debug.Log("Window closed");
    }
}