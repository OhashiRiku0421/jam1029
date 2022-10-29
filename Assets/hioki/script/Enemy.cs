using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour, IPointerClickHandler
{
    EnemyGenerator _enemyG;
    Transform _spawnPos;
    [SerializeField]ScoreAndScene _scoreAndScene;
    [Header("ÉXÉRÉA")]
    [SerializeField] int _score;

    private void Start()
    {
        StartCoroutine(A());
    }
    IEnumerator A()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        var go = eventData.pointerCurrentRaycast.gameObject;
        if(go.name == "Enemy")
        {
            Destroy(go);
        }
    }
    private void OnDestroy()
    {
        _scoreAndScene._score += _score;
        _enemyG.EnemyDestroy(_spawnPos);
    }
    public void Set(EnemyGenerator eg, Transform t)
    {
        _enemyG = eg;
        _spawnPos = t;

    }
}
