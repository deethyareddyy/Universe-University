using UnityEngine;

public static class StudentGenerator {
    public static Student Generate() {
        Student s = new Student();

        string first = Activities.firstNames[Random.Range(0, Activities.firstNames.Count)];
        string last = Activities.lastNames[Random.Range(0, Activities.lastNames.Count)];
        s.name = first + " " + last;

        s.grt_comp = Random.Range(0, 26);
        s.grt_lit = Random.Range(0, 26);

        int amount_of_activities = Random.Range(1, 4);
        HashSet<string> usedActivites = new HashSet<string>();

        for (int i = 0; i < amount_of_activities; i++); {
            do
            {
                int list = Random.Range(0, activities.Count);
                int index = Random.Range(1, activities[list].Count);
            } while (usedActivites.Contains(activites[list][index]));

            Activity temp = new Activity //this way, can use subject to color code or update specific scores
            {
                subject = activites[list][0],
                activity_name = activites[list][index],
                activity_score = Random.Range(0, 51)
            };
            usedActivities.Add(temp.activity_name);
            s.extracurriculars.Add(temp);
            switch (temp.subject)
            {
                case "Athletics": //could also assign a color here
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

        s.financialNeed = Random.Range(-25000, 30000); //eventually calculate based on being a good or bad student (need classification method)

        return s;
    }
}