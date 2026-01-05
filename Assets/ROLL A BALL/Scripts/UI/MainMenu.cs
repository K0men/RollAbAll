using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource buttonSound;
    public ScoreDatas scoreData;
    public float delay = 1f;
    public void PlayGame()
    {
        AudioSource soundClone = Instantiate(buttonSound);
        DontDestroyOnLoad(soundClone.gameObject);
        soundClone.Play();
        SceneManager.LoadScene("Level1");
        scoreData.ScoreValue = 0;
    }

    public void QuitGame()
    {
        StartCoroutine(QuitAfterDelay());
    }

    private System.Collections.IEnumerator QuitAfterDelay()
    {
        yield return new WaitForSeconds(delay); 
        ExitApplication();
    }

    private void ExitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#else
        Application.Quit(); 
#endif
    }
}
