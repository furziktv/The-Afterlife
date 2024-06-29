using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyLoot : MonoBehaviour
{
    private EnemyEntity _enemyEntity;
    [SerializeField] private GameObject[] _lootPrefabs;

    private void Awake()
    {
        _enemyEntity = GetComponent<EnemyEntity>();
    }

    private void Start()
    {
        _enemyEntity.OnDeath += EnemyEntity_OnDeath;
    }

    private void EnemyEntity_OnDeath(object sender, EventArgs e)
    {
        for (int i = 0; i < Random.Range(1, _lootPrefabs.Length); i++)
        {
            var _loot = Instantiate(_lootPrefabs[i], transform.position + Utils.GetRandomDir(), quaternion.identity);
            if (_loot.GetComponent<XP>())
            {
                _loot.transform.GetComponent<XP>()._playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }

        _enemyEntity.OnDeath -= EnemyEntity_OnDeath;
    }
}
