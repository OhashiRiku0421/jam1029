using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreResult: MonoBehaviour
{
    [SerializeField, Header("リザルトのスコアテキストを設定")]
    Text _result;

    private void Update()
    {
        _result.text = ScoreAndScene.scoreData.ToString("000000");
    }
}
