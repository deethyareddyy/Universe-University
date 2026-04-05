using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject popUpWindow;

    // The text element inside the pop-up
    public TextMeshProUGUI popUpText;

    // Data
    private string myData = "Current rank: #1";

    // Function to open the pop-up and set the text
    public void OpenPopUp()
    {
        popUpWindow.SetActive(true);
        popUpText.text = myData;
        Debug.Log("Trying to set text to: " + myData);
    }

    // Function to close the pop-up
    public void ClosePopUp()
    {
        popUpWindow.SetActive(false);
    }
}
