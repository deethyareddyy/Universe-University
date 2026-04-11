using UnityEngine;
using UnityEngine.InputSystem;

public class WindowManager : MonoBehaviour
{
    public static WindowManager Instance;

    public GameObject window;
    private SpriteRenderer windowRenderer;
    private bool isOpen = true;

    void Awake()
    {
        // Simple Singleton pattern
        if (Instance != null && Instance != this) 
        { 
            Destroy(gameObject); 
            return; 
        }
        Instance = this;
    }

    void Start()
    {
        if (window != null)
        {
            windowRenderer = window.GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector3 worldPos3D = Camera.main.ScreenToWorldPoint(
                new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane)
            );
            
            Vector2 worldPos = new Vector2(worldPos3D.x, worldPos3D.y);

            Collider2D hit = Physics2D.OverlapPoint(worldPos);

            // If we clicked the window's collider
            if (hit != null && hit.gameObject == window)
            {
                if (isOpen) 
                {
                    CloseWindow(); 
                }
                else 
                {
                    OpenWindow();
                }
            }
        }
    }

    public void OpenWindow()
    {
        isOpen = true;
        if (windowRenderer != null) windowRenderer.enabled = true;
        Debug.Log("Window opened");
    }

    public void CloseWindow()
    {
        isOpen = false;
        if (windowRenderer != null) windowRenderer.enabled = false;
        Debug.Log("Window closed");
    }
}