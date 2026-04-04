using System;
using UnityEngine;

public class FilePopUpManager : MonoBehaviour
{
    public UIManager uiManager; 
    void OnMouseDown() 
    {
        uiManager.OpenPopUp();
        Console.WriteLine("File clicked");
    }
}
