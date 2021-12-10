using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    TMP_Text coinsTxt;
    [SerializeField]
    TMP_Text scoreTxt;
    int score = 0;
    [SerializeField]
    GameObject[] playerLifes;
    [SerializeField]
    GameObject gameOverPanel;
    public int lifes = 3;
    [SerializeField]
    BoolSO canMove;
    int coins = 0;
    void Start()
    {

    }

    void FixedUpdate()
    {
        UpdateScore();
    }
    void UpdateScore()
    {
        score++;
        scoreTxt.text = score.ToString();
    }
    public void AddCoins()
    {
        coins++;
        coinsTxt.text = coins.ToString();
    }
    public void ApplyDamage()
    {
        if (lifes > 0)
        {
            lifes--;
            playerLifes[lifes].gameObject.gameObject.SetActive(false);
        }
        if (lifes == 0)
            GameOver();
    }
    public void Healing(int amount)
    {
        if (lifes < 3)
        {
            playerLifes[lifes].gameObject.gameObject.SetActive(true);
            lifes++;
        }
        else if (amount == 2 && lifes < 3)
        {
            playerLifes[lifes].gameObject.gameObject.SetActive(true);
            lifes++;
        }
    }
    void GameOver()
    {
        StartCoroutine(ShowGameOverPanel());
        //Stop player movement
        canMove.state = false;
    }
    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(2f);
        gameOverPanel.gameObject.SetActive(true);
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }
}
