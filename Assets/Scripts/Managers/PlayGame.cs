using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayGame : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
}
