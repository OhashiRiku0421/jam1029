using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreResult: MonoBehaviour
{
    [SerializeField, Header("���U���g�̃X�R�A�e�L�X�g��ݒ�")]
    Text _result;

    private void Update()
    {
        _result.text = ScoreAndScene.scoreData.ToString("000000");
    }
}
