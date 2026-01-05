using TMPro;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        Updatescore(0);
    }

    public void Updatescore(int newScore)
    {
        _scoreText.text = $"Score : {newScore.ToString()}";
    }
}
