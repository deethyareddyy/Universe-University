using UnityEngine;

public class RankPopUpManager : MonoBehaviour
{
    public UIManager uiManager; 
    void OnMouseDown() 
    {
        uiManager.OpenPopUp("Current rank: #1");
    }
}
