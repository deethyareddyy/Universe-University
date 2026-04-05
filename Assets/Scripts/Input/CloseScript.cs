using UnityEngine;

public class CloseScript : MonoBehaviour
{
    public void CloseWindow()
    {
        UIManager.Instance.ClosePopUp();
    }
}