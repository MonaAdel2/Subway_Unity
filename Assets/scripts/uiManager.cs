using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class uiManager : MonoBehaviour
{
    private float score = 1, coins = 0;
    [SerializeField] Text scoreTxt, coinsTxt;
    [SerializeField] GameObject startPanel, gamePanel, gameOverPanel;
    private Animator anim;
    [SerializeField] GameObject player;
    private playerController controller;
    private bool startPlaying = false;
    void Start()
    {
        anim = player.GetComponent<Animator>();
        controller = player.GetComponent<playerController>();
    }
    void Update()
    {
        if (startPlaying)
        {
            scoreUpdate();
        }
    }
    public void scoreUpdate()
    {
        score +=  Time.deltaTime;

        scoreTxt.text = "Score\n" + (int)score;
    }
    public void coinsUpdate()
    {
        coins++;
        coinsTxt.text = "Coins\n" + coins;
    }

    public void startGame()
    {
        //disable the panel of start panel 
        startPanel.gameObject.SetActive(false);
        //display the score panel
        gamePanel.gameObject.SetActive(true);
        //change the animation of the player to run
        anim.SetBool("idle", false);
        controller.enabled = true;
        startPlaying = true;
    }
    public void gameOver()
    {
        //dispaly game over panel 
        gameOverPanel.SetActive(true);
        //disable score panel 
        gamePanel.SetActive(false);
        
    }
    int s;
    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void saveScore(){
        PlayerPrefs.SetInt("score", s);
    }
    public void loadScore(){
        s =PlayerPrefs.GetInt("score", 0);
    }
    public void saveCoins(){

    }
    public void loadCoins(){
        
    }
    public float GetScore(){
        return score;
    }
}
