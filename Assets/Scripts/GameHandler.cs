using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public List<GameObject> objPrefabs;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button resetButton;

    public bool isGameActive = true;

    private float spawnRate = 2.5f;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObj());
        score = 0;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObj()
    {
        while (isGameActive)
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

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
