using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject popUpWindow;
    public TextMeshProUGUI popUpText;

    //private Student student = new Student(); // create instance
    public static UIManager Instance; // Singleton instance


    void Awake()
    {
        // Set singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        // else
        // {
        //     Destroy(this); // avoid duplicates
        // }
    }

    void Start()
    {

    }

    public void OpenPopUp()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null!");
            return;
        }

        Student student = GameManager.Instance.GetCurrentStudent();
        popUpWindow.SetActive(true);

        string myData = student.ToString();

        popUpText.text = myData;

        //Debug.Log("Trying to set text to: " + myData);
    }

    public void ClosePopUp()
    {
        popUpWindow.SetActive(false);
    }
}