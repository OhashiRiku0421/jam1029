using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreAndScene : MonoBehaviour
{
    [SerializeField, Header("�X�R�A�ϐ�")] public int _score = 0;
    static int scoreData;
    [SerializeField,Header("�������Ԃ̐ݒ�")] float _timeLimit = 30.9f;
    [SerializeField, Header("�J�ڐ�̃V�[��")] string sceneName;
    [SerializeField, Header("���Ԃ�\������Test")] Text _timeText;
    [SerializeField, Header("�X�R�A��\������Test")] Text _scoreText;
    float _time;
    [SerializeField,Header("�J�E���g�_�E��Time")]float countDown = 3.9f;
    bool start = false;

    private void Start()
    {
        _time = _timeLimit;
    }

    private void Update()
    {
        _scoreText.text = _score.ToString("000000");

        if (!start)
        {
            countDown -= Time.deltaTime;
            _timeText.text = countDown.ToString("00");
            
            if (countDown <= 0)
            {
                start = true;
            }
        }
        else if (start)
        {
            _time -= Time.deltaTime;
            _timeText.text = _time.ToString("00");

            if (_time <= 0)
            {
                scoreData = _score;
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}