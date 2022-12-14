using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour, IPointerClickHandler
{
    EnemyGenerator _enemyG;
    Transform _spawnPos;
　　ScoreAndScene _scoreAndScene;
    [Header("スコア")]
    [SerializeField] int _score;
    AudioSource _audio;

    private void Start()
    {
        _audio = GameObject.Find("a").GetComponent<AudioSource>();
        _scoreAndScene = GameObject.Find("scoremanager").GetComponent<ScoreAndScene>();
        StartCoroutine(A());
    }
    IEnumerator A()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        var go = eventData.pointerCurrentRaycast.gameObject;
        //if (go.name == "Enemy")
        //{
        //    Destroy(go);
        //}
        if(gameObject.tag == "Enemy")
        {
            
            _audio.Play();
            Debug.Log("aaa");
            _scoreAndScene._score += _score;
            Destroy(go);
        }
    }
    private void OnDestroy()
    {
       
        _enemyG.EnemyDestroy(_spawnPos);
    }
    public void Set(EnemyGenerator eg, Transform t)
    {
        _enemyG = eg;
        _spawnPos = t;

    }
}
