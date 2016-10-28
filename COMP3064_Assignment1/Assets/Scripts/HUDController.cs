using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// Author - Anthony Kwan
// last modified by Anthony Kwan
// date last modified october 27, 2016
//program description - UI elements for each game state
public class HUDController : MonoBehaviour {

    [SerializeField]
    Text points = null;

    [SerializeField]
    Text lives = null;

    [SerializeField]
    Image gameover = null;

    [SerializeField]
    Text highscore = null;

    [SerializeField]
    Button start = null;

    [SerializeField]
    GameObject player = null;

    [SerializeField]
    GameObject enemy = null;

    [SerializeField]
    GameObject eBullet = null;

    [SerializeField]
    GameObject meteor = null;
    //game objects that will show or be hidden at start of game
    void Start()
    {
        points.text = "Points : 0";
        lives.text = "Health: 3";
        Player.Instance.hub = this;
        player.SetActive(false);
        gameover.gameObject.SetActive(false);
        highscore.gameObject.SetActive(false);
        start.gameObject.SetActive(true);
        enemy.gameObject.SetActive(false);
        eBullet.gameObject.SetActive(false);
       // meteor.gameObject.SetActive(false);
    }
    //updates score
    public void UpdatePoints()
    {
        points.text = "" + Player.Instance.Points;
    }
    //updates player lives
    public void UpdateLives()
    {
        lives.text = ""+ Player.Instance.Lives;
    }
    //things that will show or be hidden when game is over
    public void GameOver()
    {
        points.gameObject.SetActive(false);
        lives.gameObject.SetActive(false);
        player.SetActive(false);

        gameover.gameObject.SetActive(true);
        highscore.text = "High Score " + Player.Instance.HighScore;
        highscore.gameObject.SetActive(true);
        start.gameObject.SetActive(true);

    }
    //things that will be shown or hidden at start button
    public void StartButton()
    {
        points.gameObject.SetActive(true);
        lives.gameObject.SetActive(true);
        player.SetActive(true);
        start.gameObject.SetActive(false);
        Player.Instance.Lives = 3;
        Player.Instance.Points = 0;
        enemy.gameObject.SetActive(true);
        eBullet.gameObject.SetActive(true);
       // meteor.gameObject.SetActive(true);
        gameover.gameObject.SetActive(false);
        highscore.gameObject.SetActive(false);

    }

}
