using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public School school = new School();

    private List<Student> todaysStudents = new List<Student>();
    private int currentIndex = 0;
    public static GameManager Instance; // singleton


    public SpriteRenderer portraitRenderer; // drag the GameObject in Inspector
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
        GenerateStudents();
        Debug.Log($"Starting Budget: {school.GetBudget()}");
        ShowCurrentStudent();
    }

    public Portraits port;
    void GenerateStudents()
    {
        for (int i = 0; i < School.MaxStudentsPerDay; i++)
        {
            todaysStudents.Add(StudentGenerator.Generate(port));
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
        portraitRenderer.sprite = s.portrait;
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
        //Debug.Log($"Viewing: {s}");
    }

    public void AcceptStudent()
    {
        if (currentIndex >= todaysStudents.Count) return;

        Student s = todaysStudents[currentIndex];
        var result = school.TryAcceptStudent(s);

        if (result == School.AcceptResult.MaxStudentsReached)
        {
            Debug.Log("You already accepted 3 students!");
            return;
        }

        if (result == School.AcceptResult.CannotAfford)
        {
            Debug.Log("You cannot afford this student!");
            return;
        }

        Debug.Log($"Accepted: {s.name}");
        Debug.Log($"Remaining Budget: {school.GetBudget()}");

        if (school.NumOfStudents() >= School.MaxAcceptances)
        {
            EndDay();
            return;
        }

        UIManager.Instance.ClosePopUp(); // Hides the file popup
        WindowManager.Instance.CloseWindow(); // Shows the window background again

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
            return;
        }
        ShowCurrentStudent();
    }

    void EndDay()
    {
        Debug.Log("Day finished!");
        Debug.Log($"Accepted: {school.AcceptedStudents.Count}");
        Debug.Log($"Final Budget: {school.GetBudget()}");
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