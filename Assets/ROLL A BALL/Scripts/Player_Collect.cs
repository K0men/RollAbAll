using UnityEngine;

public class Player_Collect : MonoBehaviour
{
    [SerializeField] private ScoreDatas _scoreData;
    [SerializeField] private UI_Controller _uiController;
    [SerializeField] private UI_Controller _ui;

    public void UpdateScore(int value)
    {
        _scoreData.ScoreValue = Mathf.Clamp(_scoreData.ScoreValue+ value,min:0,max:_scoreData.ScoreValue+ value);
        _uiController.Updatescore(_scoreData.ScoreValue);
    }
}