using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public IntVariable currentScore;
    public IntVariable highScore;

    private const string KEY_HIGH_SCORE = "KEY_HIGH_SCORE";

    public void SaveNewHighScore()
    {
        if(currentScore.CurrentValue > highScore.CurrentValue)
        {
            //Then save the currentScore as the new high score:
            PlayerPrefs.SetInt(KEY_HIGH_SCORE, currentScore.CurrentValue);
        } 
    }

    public void LoadHighScore()
    {
        if(PlayerPrefs.HasKey(KEY_HIGH_SCORE))
        {
            highScore.CurrentValue = PlayerPrefs.GetInt(KEY_HIGH_SCORE);
        }
    }

}
