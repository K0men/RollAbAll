using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreLevelManager : MonoBehaviour
{
    public int scoreThreshold = 6;
    public string nextSceneName = "Level2";
    public ScoreDatas scoreData;
    public AudioSource levelUpSound;

    private bool levelLoaded = false; 

    void Update()
    {
        if (!levelLoaded && scoreData != null && scoreData.ScoreValue >= scoreThreshold)
        {
            levelLoaded = true;
            PlaySoundAndLoadLevel();
        }
    }

    private void PlaySoundAndLoadLevel()
    {
        AudioSource soundClone = Instantiate(levelUpSound);
        DontDestroyOnLoad(soundClone.gameObject);
        soundClone.Play();
        StartCoroutine(LoadSceneAfterSound(soundClone.clip.length));
        SceneManager.LoadScene(nextSceneName);
    }

    private System.Collections.IEnumerator LoadSceneAfterSound(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}
