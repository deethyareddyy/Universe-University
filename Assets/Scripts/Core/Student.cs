using System.Collections.Generic;
using UnityEngine;

public class Student {
    public string name;
    public Sprite portrait;

    // Galactic Readiness Test (0-25)
    public int grt_comp;
    public int grt_lit;

    // Core stats (0-100)
    public int retentionLikeliness;
    public int Athletics = 0;
    public int Robotics = 0;
    public int Diplomacy = 0;
    public int Artistry = 0;
    public int Service = 0;
    public List<Activity> extracurriculars = new List<Activity>();

    // Other traits
    public int financialContribution;
    //public int criminalRecord;

    public override string ToString() {
        return
            $"{name}'s profile:\n\n" + //bolded
            $"Galactic Readiness Test (GRT)\n" +
            $"GRT Comp: {grt_comp}\n" +
            $"GRT Lit: {grt_lit}\n\n" +
            $"Retention Likeliness: {retentionLikeliness}\n" +
            $"Financial Contribution: {financialContribution}\n" +
            $"Athletics: {Athletics}\n" +
            $"Robotics: {Robotics}\n" +
            $"Diplomacy: {Diplomacy}\n" +
            $"Artistry: {Artistry}\n" +
            $"Service: {Service}";
    }
}