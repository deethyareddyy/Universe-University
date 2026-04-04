using UnityEngine;
using System.Collections.Generic;

public static class StudentGenerator {
    public static Student Generate() {
        Student s = new Student();

        string first = Names.firstNames[Random.Range(0, Names.firstNames.Count)];
        string last = Names.lastNames[Random.Range(0, Names.lastNames.Count)];
        s.name = first + " " + last;

        int grt_comp_per = Random.Range(0, 101);
        if (grt_comp_per <= 20) {
            s.grt_comp = Random.Range(0, 11);
        } else if (grt_comp_per <= 80) {
            s.grt_comp = Random.Range(11, 21);
        } else {
            s.grt_comp = Random.Range(21, 26);
        }

        int grt_lit_per = Random.Range(0, 101);
        if (grt_lit_per <= 20) {
            s.grt_lit = Random.Range(0, 11);
        } else if (grt_lit_per <= 80) {
            s.grt_lit = Random.Range(11, 21);
        } else {
            s.grt_lit = Random.Range(21, 26);
        }

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

        int ret_per = Random.Range(0, 101);
        if (ret_per <= 20) {
            s.retentionLikeliness = Random.Range(0, 51);
        } else if (ret_per <= 70) {
            s.retentionLikeliness = Random.Range(51, 76);
        } else {
            s.retentionLikeliness = Random.Range(76, 101);
        }

        int fin_per = Random.Range(0, 101);
        if (fin_per <= 60) {
            if (fin_per <= 5) s.financialContribution = Random.Range(-25, -19) * 1000;
            else if (fin_per <= 35) s.financialContribution = Random.Range(-19, -9) * 1000;
            else s.financialContribution = Random.Range(-9, 0) * 1000;
        } else if (fin_per <= 70) {
            s.financialContribution = 0;
        } else {
            if (fin_per <= 85) s.financialContribution = Random.Range(1, 11) * 1000;
            else if (fin_per <= 95) s.financialContribution = Random.Range(11, 21) * 1000;
            else s.financialContribution = Random.Range(21, 31) * 1000;
        }
        return s;
    }
}