using System.Collections.Generic;
using UnityEngine;
using TMPro;


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

    private string GetFinancialStatus(int amount)
    {
        if (amount < 0) return $"<color=red>Need: {amount}</color>";
        if (amount > 0) return $"<color=green>Donate: {amount}</color>";
        return "<color=grey>None</color>";
    }

    public string PrintProfile(Student student)
    {
        string formattedProfile = $"<b>{student.name}'s profile:</b>\n\n" +
            $"Galactic Readiness Test (GRT)\n" +
            $"• Computational score: {student.grt_comp}\n" +
            $"• Literacy score: {student.grt_lit}\n\n" +
            $"Extracurriculars:\n";

        foreach (var act in student.extracurriculars)
        {
            formattedProfile += $"• {act.activity_name}: {act.activity_score} ({act.subject})\n";
        }

        formattedProfile += $"\nRetention Likeliness: {student.retentionLikeliness}%\n\n" +
            $"Financial Contribution: {GetFinancialStatus(student.financialContribution)}";

        return formattedProfile;
    }
    // public override string ToString() {
    //     return
    //         // $"{name}'s profile:\n\n" +
    //         // $"Galactic Readiness Test (GRT)\n" +
    //         // $"Computational score: {grt_comp}\n" +
    //         // $"Literacy score: {grt_lit}\n\n" +

    //         // $"Athletics: {Athletics}\n" +
    //         // $"Robotics: {Robotics}\n" +
    //         // $"Diplomacy: {Diplomacy}\n" +
    //         // $"Artistry: {Artistry}\n" +
    //         // $"Service: {Service}" +

    //         // $"Retention Likeliness: {retentionLikeliness}\n\n" +
    //         // $"Financial Contribution: {financialContribution}\n\n";
    // }
}