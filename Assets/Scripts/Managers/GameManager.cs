using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public School school = new School();

    private List<Student> todaysStudents = new List<Student>();
    private int currentIndex = 0;

    void Start() {
        GenerateStudents();
        ShowCurrentStudent();
    }

    void GenerateStudents() {
        for (int i = 0; i < school.MaxStudentsPerDay; i++) {
            todaysStudents.Add(StudentGenerator.Generate());
        }
    }

    void ShowCurrentStudent() {
        if (currentIndex >= todaysStudents.Count) {
            EndDay();
            return;
        }

        Student s = todaysStudents[currentIndex];
        Debug.Log($"Viewing: {s}");
    }

    public void AcceptStudent() {
        Student s = todaysStudents[currentIndex];
        bool success = school.TryAcceptStudent(s);

        if (!success) {
            Debug.Log("You already accepted 3 students!");
            return;
        }

        Debug.Log("Accepted!");
        NextStudent();
    }

    public void RejectStudent() {
        Debug.Log("Rejected!");
        NextStudent();
    }

    void NextStudent() {
        currentIndex++;
        ShowCurrentStudent();
    }

    void EndDay() {
        Debug.Log("Day finished!");
        Debug.Log($"Accepted: {school.AcceptedStudents.Count}");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            AcceptStudent();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            RejectStudent();
        }
    }
}