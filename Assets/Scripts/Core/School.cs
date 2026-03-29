using System.Collections.Generic;
using System;

public class School {

    public const int MaxStudentsPerDay = 5;
    public const int MaxAcceptances = 3;
    public int Budget = 50000;
    public int CompScoreAvg = 0 ;
    public int LitScoreAvg = 0;
    public int RetentionRateAvg = 0;
    public int CompScoreTot = 0 ;
    public int LitScoreTot = 0;
    public int RetentionRateTot = 0;
    public int Athletics = 0;
    public int Robotics = 0;
    public int Diplomacy = 0;
    public int Artistry = 0;
    public int Service = 0;

    Dictionary<string, int> AcceptedStudents = new Dictionary<string, Student>();

    public int NumOfStudents() {
        return AcceptedStudents.Count;
    }
    public bool CanAcceptMore() {
        return AcceptedStudents.Count < MaxAcceptances;
    }

    public void AcceptStudent(Student s) {
        if (CanAcceptMore()) {
            AcceptedStudents.Add(s.name, s);
            Budget -= s.financialNeed;
            Athletics += s.Athletics;
            Robotics += s.Athletics;
            Diplomacy += s.Diplomacy;
            Artistry += s.Artistry;
            Service += s.Service;
        }
    }

    //public int CompScore = 0 ;
    //public int LitScore = 0;
    //public int RetentionRate = 0;
}

//if (AcceptedStudents.Count == MaxAcceptances) {} day over, close window. But when to trigger?