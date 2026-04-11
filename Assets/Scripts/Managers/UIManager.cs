using UnityEngine;
using TMPro;
using System.Collections;
// using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public GameObject popUpWindow;
    public TextMeshProUGUI popUpText;

    [Header("End Day Settings")]
    public GameObject endDayPanel; // The background panel for the summary
    public TextMeshProUGUI endDayStatsText; // The text to display stats
    public Button closeButton;
    public GameObject backgroundBlocker;
    public GameObject physicsBlocker;
    [Header("Error Settings")]
    public TextMeshProUGUI errorText; // Assign error message
    public float errorDisplayTime = 3f;

    public static UIManager Instance;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
    }

    public void ShowErrorMessage(string message)
    {
        StopAllCoroutines(); 
        StartCoroutine(ErrorSequence(message));
    }

    private IEnumerator ErrorSequence(string message)
    {
        errorText.text = message;
        errorText.gameObject.SetActive(true);

        yield return new WaitForSeconds(errorDisplayTime);

        errorText.gameObject.SetActive(false);
    }

    public void ShowEndDayReport(string stats)
    {
        endDayPanel.SetActive(true);
        endDayStatsText.text = stats;
        backgroundBlocker.SetActive(true);
        if (physicsBlocker!= null) physicsBlocker.SetActive(true);
    }
    public void CloseEndDayReport()
    {
        endDayPanel.SetActive(false);
        backgroundBlocker.SetActive(false);
        if (physicsBlocker!= null) physicsBlocker.SetActive(false);
        Debug.Log("End day panel closed");
    }

    public void OpenPopUp(string myData)
    {
        if (GameManager.Instance == null) return;
        popUpWindow.SetActive(true);
        popUpText.text = myData;
        backgroundBlocker.SetActive(true);
        if (physicsBlocker!= null) physicsBlocker.SetActive(true);
    }

    public void ClosePopUp()
    {
        popUpWindow.SetActive(false);
        backgroundBlocker.SetActive(false);
        if (physicsBlocker!= null) physicsBlocker.SetActive(false);
    }
}