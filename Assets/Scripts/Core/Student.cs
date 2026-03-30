public class Student {
    public string name;

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
    public int extracurriculars;
    //public int personality;

    // Other traits
    public int financialNeed;
    //public int criminalRecord;

    public override string ToString() {
        // Change this later depending on what we want to display for a student
        return $"{name} | Ret:{retentionLikeliness}";
    }

    // Scoring function. Change this later
    public int GetScore() {
        int score = 0;

        score += grt_comp * 2;
        score += grt_lit * 2;
        score += retentionLikeliness;

        score -= financialNeed;
        // score -= criminalRecord * 2;

        return score;
    }
}