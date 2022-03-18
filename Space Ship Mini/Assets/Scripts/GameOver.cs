using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text secondSurvivedUI;
    bool gameOver;

    SpaceShip player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<SpaceShip>();
        player.OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene("Play Scene");
            }
        }
    }

    void OnGameOver() {
        gameOverScreen.SetActive(true);
        secondSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
        player.OnPlayerDeath -= OnGameOver;
    }
}
