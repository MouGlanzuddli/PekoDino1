using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;


    private void Awake() {
        if (Instance == null) Instance = this;
    }

    #endregion

    public float currentScore = 0f;
    public Data data;

    public bool isPlaying = false;

    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();

    private void Start() {
        data = new Data();
    }

    private void Update() {
        if (isPlaying){
            currentScore += Time.deltaTime;
        }
    }

    public void StartGame() {
        onPlay.Invoke();
        currentScore = 0;
        isPlaying = true;
    }

    public void GameOver(){
        if (data.highscore < currentScore) {
            PlayerPrefs.SetFloat("Highscore:", currentScore);
            data.highscore = currentScore;
        }
        isPlaying = false;

        onGameOver.Invoke();
    }


    public string PrettyScore () {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    public string PrettyHighscore () {
        return Mathf.RoundToInt(data.highscore).ToString();
    }
}
