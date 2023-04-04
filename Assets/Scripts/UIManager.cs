using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject platformSpawner;

    public void GameStart()
    {
        titleScreen.SetActive(false);
        ball.GetComponent<BallController>().enabled = true;
        ball.GetComponent<SphereCollider>().enabled = true;
        platformSpawner.GetComponent<PlatformSpawner>().enabled = true;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

}
