using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public School school = new School();

    private List<Student> todaysStudents = new List<Student>();
    public SpriteRenderer studentPortrait;
    private int currentIndex = 0;
    public static GameManager Instance; // singleton


    // public SpriteRenderer portraitRenderer; // drag the GameObject in Inspector
    void Awake()
    {
        // Set singleton instance
        if (Instance == null)
        {
            Instance = this;
            // Optional: persist across scenes
            // DontDestroyOnLoad(gameObject);
        }
        // else
        // {
        //     Destroy(this);
        // }


        if (GameManager.Instance == null)  // ← add this
        {
            Debug.LogWarning("GameManager instance is null!");
            return;
        }

    }

    void Start()
    {
        //not sure if this is the right place to call it
        school.OverallRank = UnityEngine.Random.Range(1000, 1500);
        GenerateStudents();
        Debug.Log($"Starting Budget: {school.GetBudget()}");
        ShowCurrentStudent();
    }
    void GenerateStudents()
    {
        for (int i = 0; i < School.MaxStudentsPerDay; i++)
        {
            todaysStudents.Add(StudentGenerator.Generate());
        }
    }

    void ShowCurrentStudent()
    {
        if (currentIndex >= todaysStudents.Count)
        {
            EndDay();
            return;
        }
        Student s = todaysStudents[currentIndex];
        if (studentPortrait != null && s.portrait != null)
        {
            studentPortrait.sprite = s.portrait;
        }
        Debug.Log($"Viewing: {s}");
    }

    public Student GetCurrentStudent()
    {
        if (currentIndex >= todaysStudents.Count)
        {
            EndDay();
            return null;
        }

        return todaysStudents[currentIndex];
    }

    public void AcceptStudent()
    {
        if (currentIndex >= todaysStudents.Count) return;

        Student s = todaysStudents[currentIndex];
        var result = school.TryAcceptStudent(s);

        if (result == School.AcceptResult.MaxStudentsReached)
        {
            UIManager.Instance.ShowErrorMessage("You already accepted 3 students!");
            EndDay();
            return;
        }

        if (result == School.AcceptResult.CannotAfford)
        {
            UIManager.Instance.ShowErrorMessage("You cannot afford this student!");
            return;
        }

        Debug.Log($"Accepted: {s.name}");
        
        UIManager.Instance.ClosePopUp(); 
        WindowManager.Instance.CloseWindow(); 

        if (school.NumOfStudents() >= School.MaxAcceptances)
        {
            Debug.Log("School full! Ending day early.");
            EndDay();
            return;
        }

        NextStudent();
    }

    public void RejectStudent()
    {
        if (currentIndex >= todaysStudents.Count) return;

        Debug.Log("Rejected!");
        Debug.Log($"Remaining Budget: {school.GetBudget()}");

        UIManager.Instance.ClosePopUp(); // Hides the file popup
        WindowManager.Instance.CloseWindow(); // Shows the window background again

        NextStudent();
    }

    void NextStudent()
    {
        currentIndex++;
        
        if (currentIndex >= todaysStudents.Count)
        {
            EndDay();
        }
        else
        {
            ShowCurrentStudent();
        }
    }

    void EndDay()
    {
        Debug.Log("Day finished!");
        
        string summary = "DAY FINISHED!\n\n" +
                         $"Students Accepted: {school.AcceptedStudents.Count}\n" +
                         $"Final Budget: {school.GetBudget()}\n";
                         // Add more here
        
        UIManager.Instance.ShowEndDayReport(summary);
    }

    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            AcceptStudent();
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            RejectStudent();
        }
    }
}