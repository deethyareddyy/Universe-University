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

    public void OpenPopUp(string myData)
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null!");
            return;
        }

        Student student = GameManager.Instance.GetCurrentStudent();
        popUpWindow.SetActive(true);

<<<<<<< HEAD
=======
        string myData = student.ToString();

>>>>>>> 6ab1375e9707df66cfd1f271d4720beac706a3f1
        popUpText.text = myData;

        //Debug.Log("Trying to set text to: " + myData);
    }

    public void ClosePopUp()
    {
        popUpWindow.SetActive(false);
    }
}