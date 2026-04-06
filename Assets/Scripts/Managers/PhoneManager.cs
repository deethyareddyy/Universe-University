using UnityEngine;
using UnityEngine.InputSystem;

public class PhoneManager : MonoBehaviour
{
    public UIManager uiManager;
    // private string display_budget = (char)228 + 2000.ToString();

    void Update()
    {
        // 1. Listen for the exact frame the left mouse button is clicked
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector3 worldPos3D = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0));
            Vector2 worldPos = new Vector2(worldPos3D.x, worldPos3D.y);

            Collider2D hit = Physics2D.OverlapPoint(worldPos);

            if (hit != null && hit.gameObject == this.gameObject)
            {
                Debug.Log("Clicked on the file");

                if (uiManager != null)
                {
                    string guide = "Welcome to Universe University! It's your first day as headmaster, so let's run through your duties: (click on the intergalactic phone on your desk to view this guide anytime) here are 5 applicants here today, hoping to be admitted to your school One-by-one, you will review and either accept or reject each applicant The day immediately ends once you admit 3 of them, so choose wisely! To achieve the best possible stats for your school, be mindful of what each student brings to the table: For the most knowledgeable students, look at their Galactic Readiness Test (GRT) results, with a score (0-25) for both the computational section and the literacy section. An average of your students' scores will be reflected as your school's score. Next, look at what extracurricular activities they are involved in. Each activity belongs to a specialty (Athletics, Robotics, Diplomacy, Artistry, or Service) and shows a proficiency score (0-50). This score will be added to your school's total for that speciality, helping define your school in whichever speciality you choose to prioritize. Then, look at their retention likeliness (0-100%). You don't want to invest in a student that isn't likely to stay, and it looks bad for your reputation! An average of your student's percentages will be reflected as your school's retention rate. Finally, look at their financial contribution. Many students will need financial aid to attend (up to ∑25000), while a generous few will offer…“donations” if you accept them (up to ∑30000). Your starting budget today is ∑20,000'make sure to stay within budget, or you won't be able to admit any more students! Got it, Headmaster? Best of luck! Click on the file folder on your desk to review your first applicant.";
                    uiManager.OpenPopUp(guide);
                }
                else
                {
                    Debug.LogWarning("No UIManager in the inspector");
                }
            }
        }
    }
}
