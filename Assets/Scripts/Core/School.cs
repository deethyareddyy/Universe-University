using System.Collections.Generic;
using System;
using UnityEngine;

public class School {
    public bool open = true;
    public const int MaxStudentsPerDay = 5;
    public static int MaxAcceptances = 3;

    private static int Budget = 20000;
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
    private int Average(int total_sum, int num_of_students) {
        if (num_of_students == 0) return 0;
        return total_sum / num_of_students;
    }
    private bool CanAcceptMore() {
        return AcceptedStudents.Count < MaxAcceptances;
    }
    public int GetBudget() {
        return Budget;
    }

    private bool CanAfford(int cost) {
        return Budget + cost >= 0;
    }
    private void AcceptStudent(Student s) {
        if (CanAfford(s.financialContribution)) { // is open check shouldn't be necessary?
            AcceptedStudents[s.name] = s;
            Budget += s.financialContribution;

            Athletics += s.Athletics;
            Robotics += s.Robotics;
            Diplomacy += s.Diplomacy;
            Artistry += s.Artistry;
            Service += s.Service;

            CompScoreTot += s.grt_comp;
            LitScoreTot += s.grt_lit;
            RetentionRateTot += s.retentionLikeliness;

            CompScore = Average(CompScoreTot, AcceptedStudents.Count);
            LitScore = Average(LitScoreTot, AcceptedStudents.Count);
            RetentionRate = Average(RetentionRateTot, AcceptedStudents.Count);
        } else {
            Debug.Log("You cannot afford to accept this student!");
        }
    }

    public enum AcceptResult {
        Success,
        MaxStudentsReached,
        CannotAfford
    }

    public AcceptResult TryAcceptStudent(Student s) {
        if (!CanAcceptMore()) return AcceptResult.MaxStudentsReached;
        if (!CanAfford(s.financialContribution)) return AcceptResult.CannotAfford;

        AcceptStudent(s);
        return AcceptResult.Success;
    }

    public int NumOfStudents() {
        return AcceptedStudents.Count;
    }
}