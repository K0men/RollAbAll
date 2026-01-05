using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnTouch : MonoBehaviour
{
    public string sceneName = "GameOverScene";
    public string triggerTag = "Trap";

    private void OnTriggerEnter(Collider other)
    {
    Debug.Log("Le joueur a touché : " + other.name);
    SceneManager.LoadScene(sceneName);
    }
}
