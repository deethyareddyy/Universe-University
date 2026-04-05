using UnityEngine;
using UnityEngine.InputSystem;

public class BudgetPopUpManager : MonoBehaviour
{
    public UIManager uiManager;

    void Update()
    {
        // 1. Listen for the exact frame the left mouse button is clicked
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector3 worldPos3D = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0));
            Vector2 worldPos = new Vector2(worldPos3D.x, worldPos3D.y);

            Collider2D hit = Physics2D.OverlapPoint(worldPos);

            if (hit != null && hit.gameObject == this.gameObject)
            {
                Debug.Log("Clicked on the file");

                if (uiManager != null)
                {
                    uiManager.OpenPopUp("Money money money");
                }
                else
                {
                    Debug.LogWarning("No UIManager in the inspector");
                }
            }
        }
    }
}
