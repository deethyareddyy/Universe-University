using UnityEngine;

public static class StudentGenerator {
    public static Student Generate() {
        static Student s();

        s.name = "Student_" + Random.Range(0, 9999);

        s.knowledge = Random.Range(0, 101);
        s.retentionLikeliness = Random.Range(0, 101);
        s.extracurriculars = Random.Range(0, 101);
        s.personality = Random.Range(0, 101);

        s.financialNeed = Random.Range(0, 101);
        s.criminalRecord = Random.Range(0, 101);

        return s;
    }
}