using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    StringSO playerName;
    [SerializeField]
    TMP_Text nameTxt;
    [SerializeField]
    TMP_Text highestScore;
    int highestScoreNum = 0;
    void Start()
    {
        nameTxt.text = playerName.str;
       // PlayerPrefs.DeleteAll();
    }

    void FixedUpdate()
    {
        if (canMove.state)
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
        if (amount == 2 && lifes < 3)
        {
            playerLifes[lifes].gameObject.gameObject.SetActive(true);
            lifes++;
        }
    }
    void GameOver()
    {
        if (score > PlayerPrefs.GetInt("highestScoreNum"))
        {
            PlayerPrefs.SetInt("highestScoreNum", score);
            highestScore.text = $"New High Score  {PlayerPrefs.GetInt("highestScoreNum")} " + playerName.str;
        }
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
