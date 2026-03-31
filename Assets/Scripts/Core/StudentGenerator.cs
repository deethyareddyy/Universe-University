using UnityEngine;
using System.Collections.Generic;

public static class StudentGenerator {
    public static Student Generate() {
        Student s = new Student();

        string first = Names.firstNames[Random.Range(0, Names.firstNames.Count)];
        string last = Names.lastNames[Random.Range(0, Names.lastNames.Count)];
        s.name = first + " " + last;

        s.grt_comp = Random.Range(0, 26);
        s.grt_lit = Random.Range(0, 26);

        int amount_of_activities = Random.Range(1, 4);
        HashSet<string> usedActivities = new HashSet<string>();

        for (int i = 0; i < amount_of_activities; i++) {
            int list;
            int index;

            do {
                list = Random.Range(0, Activity.activites.Count);
                index = Random.Range(1, Activity.activites[list].Count);
            } while (usedActivities.Contains(Activity.activites[list][index]));

            Activity temp = new Activity { // this way, can use subject to color code or update specific scores
                subject = Activity.activites[list][0],
                activity_name = Activity.activites[list][index],
                activity_score = Random.Range(0, 51)
            };

            usedActivities.Add(temp.activity_name);
            s.extracurriculars.Add(temp);

            switch (temp.subject) {
                case "Athletics": // could also assign a color here
                    s.Athletics += temp.activity_score;
                    break;
                case "Robotics":
                    s.Robotics += temp.activity_score;
                    break;
                case "Diplomacy":
                    s.Diplomacy += temp.activity_score;
                    break;
                case "Artistry":
                    s.Artistry += temp.activity_score;
                    break;
                case "Service":
                    s.Service += temp.activity_score;
                    break;
            }
        }
        s.retentionLikeliness = Random.Range(0, 101); //eventually calculate based on school's top subjects (need ranking method)
        s.financialContribution = Random.Range(-25000, 30000); //eventually calculate based on being a good or bad student (need classification method)
        return s;
    }
}