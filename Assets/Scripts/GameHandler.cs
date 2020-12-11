using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public List<GameObject> objPrefabs;
    public TextMeshProUGUI scoreText;

    private float spawnRate = 2.5f;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObj());
        score = 0;
        UpdateScore(0);
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

    public void UpdateScore(int add)
    {
        score += add;
        if (score <= 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score;
    }
}
