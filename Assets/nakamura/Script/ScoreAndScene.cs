using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreAndScene : MonoBehaviour
{
    [SerializeField, Header("スコア変数")] public int _score = 0;
    public static int scoreData;
    [SerializeField, Header("制限時間の設定")] float _timeLimit = 30.9f;
    [SerializeField, Header("遷移先のシーン")] string sceneName;
    [SerializeField, Header("時間を表示するTest")] Text _timeText;
    [SerializeField, Header("スコアを表示するTest")] Text _scoreText;
    [SerializeField] ScenSquare _scen;
    [SerializeField] Fade _fade;
    float _time;
    [SerializeField, Header("カウントダウンTime")] float countDown = 3.9f;
    bool start = false;

    private void Start()
    {
        _time = _timeLimit;
    }

    private void Update()
    {
        _scoreText.text = _score.ToString("000000");

        //if (!start)
        //{
        //    countDown -= Time.deltaTime;
        //    _timeText.text = countDown.ToString("00");

        //    if (countDown <= 0)
        //    {
        //        start = true;
        //    }
        //}
        //else if (start)
        //{
        _time -= Time.deltaTime;
        _timeText.text = _time.ToString("F2");

        if (_time <= 0 && !start)
        {
            start = true;
            scoreData = _score;
            _fade.FadeOut("result");
        }
        //}
    }
}