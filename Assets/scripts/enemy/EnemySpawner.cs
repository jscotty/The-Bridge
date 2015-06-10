using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    #region Vars

    [SerializeField]
    private EnemySpawnInfo[] _enemySpawnInfo;

    #endregion

    #region Methods

    private void Start()
    {
    }

    private void Update()
    {

    }

    private void SpawnNext()
    {
        byte rnd = (byte)(Random.value * 100);
        Debug.Log(rnd);
    }

    #endregion

    #region Properties

    #endregion
}

[System.Serializable]
public struct EnemySpawnInfo
{
    public GameObject Enemy; // Prefab
    public short chance; // (0 to 99) %
}