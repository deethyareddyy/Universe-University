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
        if (amount < 0) return $"(Need) {amount}";
        if (amount > 0) return $"(Donation) {amount}";
        return "None";
        // if (amount < 0) return $"<color=red>(Need) {amount}</color>";
        // if (amount > 0) return $"<color=green>(Donation) {amount}</color>";
        // return "<color=grey>None</color>";
    }

    public string PrintProfile()
    {
        string formattedProfile = $"<b>{name}'s Profile:</b>\n\n" +
            $"<u>Galactic Readiness Test (GRT):</u>\n" +
            $"• Computational score: {grt_comp}\n" +
            $"• Literacy score: {grt_lit}\n\n" +
            $"<u>Extracurriculars:</u>\n";

        foreach (var act in extracurriculars)
        {
            formattedProfile += $"• {act.activity_name} ({act.subject}): {act.activity_score}\n";
        }

        formattedProfile += $"\n<u>Retention Likeliness:</u> {retentionLikeliness}%\n\n" +
            $"<u>Financial Contribution:</u> {GetFinancialStatus(financialContribution)}";

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