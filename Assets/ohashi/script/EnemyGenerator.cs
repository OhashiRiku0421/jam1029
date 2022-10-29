using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// enemyのスポーンとリスポーンのクラス
/// </summary>
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPos = default;
    [SerializeField] EnemyController[] _enemies;
    [SerializeField] int _maxPos;
    [SerializeField] float interval = 1f;
    List<Transform> _posList = new List<Transform>();
    bool _rePopInterval = false;
    int _gCount = 0;

    void Start()
    {
        foreach (var t in _spawnPos)
        {
            //Listに全部追加
            _posList.Add(t);
        }
    }
    void Spawn()
    {
        int r1 = Random.Range(0, _posList.Count - 1);

        Transform pos = _posList[r1];

        int r2 = Random.Range(0, _enemies.Length);

        var enemyB = Instantiate(_enemies[r2]);
        enemyB.Set(this, pos);//参照先をセット
        enemyB.transform.position = pos.position;
        enemyB.transform.rotation = pos.rotation;
        _posList.Remove(pos); //削除
    }
    public void EnemyDestroy(Transform t)
    {
        _posList.Add(t);//Destroyしたenemyがスポーンした位置をリストに追加
        _gCount--;
    }
    void Update()
    {
        if (!_rePopInterval && _gCount <= _maxPos)
        {
            _gCount++;
            StartCoroutine(SpawnInterval());
            _rePopInterval = true;
        }
    }
    IEnumerator SpawnInterval()
    {
        
        yield return new WaitForSeconds(interval);
        Spawn();
        _rePopInterval = false;
    }
}