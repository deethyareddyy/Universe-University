using UnityEngine;

public static class StudentGenerator {
    public static Student Generate() {
        Student s = new Student();

        string first = Activities.firstNames[Random.Range(0, Activities.firstNames.Count)];
        string last = Activities.lastNames[Random.Range(0, Activities.lastNames.Count)];
        s.name = first + " " + last;

        s.grt_comp = Random.Range(0, 26);
        s.grt_lit = Random.Range(0, 26);

        int amount_of_activites = Random.Range(0, 101);
        s.extracurriculars = Random.Range(0, 101);
         // (quantity 1-3)
// (random score from 5-50)
//Athletics (0-2), Robotics (3-5), Diplomacy (6-8), Artistry (9-11), Service (12-14)

        s.retentionLikeliness = Random.Range(0, 101); //potentially calculate based on our top

        s.financialNeed = Random.Range(0, 101);

        return s;
    }
}