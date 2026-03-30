using System.Collections.Generic;
using System;
using UnityEngine;

public class School {

    public bool open = true;
    private const int MaxStudentsPerDay = 5;
    public static int MaxAcceptances = 3;

    private int StudentsSeen = 0; //make sure to count up when triggering event
    private int Budget = 50000;
    private int CompScore = 0 ;
    private int LitScore = 0;
    private int RetentionRate = 0;
    private int CompScoreTot = 0 ;
    private int LitScoreTot = 0;
    private int RetentionRateTot = 0;
    private int Athletics = 0;
    private int Robotics = 0;
    private int Diplomacy = 0;
    private int Artistry = 0;
    private int Service = 0;

    public Dictionary<string, Student> AcceptedStudents = new Dictionary<string, Student>();
    private int average(int total_sum, int num_of_students)
    {
        if (num_of_students == 0) return 0;
        return total_sum / num_of_students;
    }
    private bool CanAcceptMore() {
        return AcceptedStudents.Count < MaxAcceptances;
    }

    private bool CanAfford(int cost)
    {
        return Budget - cost >= 0;
    }
    private void AcceptStudent(Student s) {
        if (CanAfford(s.financialNeed)) { //is open check shouldn't be necessary?
            AcceptedStudents.Add(s.name, s);
            Budget += s.financialNeed;

            //how to change based on Activity object??
            Athletics += s.Athletics;
            Robotics += s.Robotics;
            Diplomacy += s.Diplomacy;
            Artistry += s.Artistry;
            Service += s.Service;

            CompScoreTot += s.grt_comp;
            LitScoreTot += s.grt_lit;
            RetentionRateTot += s.retentionLikeliness;

            CompScore = average(CompScoreTot, AcceptedStudents.Count);
            LitScore = average(LitScoreTot, AcceptedStudents.Count);
            RetentionRate = average(RetentionRateTot, AcceptedStudents.Count);
        } else
        {
            Debug.Log("You cannot afford to accept this student!");
        }
    }

    public bool TryAcceptStudent(Student s) //combine checks with function above
    {
        if (!CanAcceptMore()) return false;
        if (!CanAfford(s.financialNeed)) return false;

        AcceptStudent(s);
        return true;
    }

    public int NumOfStudents()
    {
        return AcceptedStudents.Count;
    }
}