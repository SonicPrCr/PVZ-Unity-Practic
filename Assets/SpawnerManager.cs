using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private List<Transform> spawnerList;
    [SerializeField] private int rnd;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawner), 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawner()
    {
        rnd = Random.Range(0, spawnerList.Count);
        Instantiate(enemy, spawnerList[rnd].position, Quaternion.identity);
    }
}
