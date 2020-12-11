using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public List<GameObject> objPrefabs;

    private float spawnRate = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObj());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObj()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, objPrefabs.Count);
            Instantiate(objPrefabs[index]);
        }
    }
}
