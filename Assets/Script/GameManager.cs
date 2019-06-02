using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GlobalVariable global;

    AudioSource bgm1;
    AudioSource bgm2;
    //AudioSource bgm3;

    public GameObject Wall;

    public GameObject waterFlow;
    public GameObject GameOverObj;
    public GameObject GameClearObj;
    public GameObject GameNextObj;

    public bool GameStart = true;
    public bool isGameOver = false;
    public bool isGameClear = false;
    public bool isGameNext = false;

    public Text ScoreText;
    public int Score;
    public Text HPText;
    public int HP;
    public int Level;

    void Start () {
        global = GameObject.FindGameObjectWithTag("global").GetComponent<GlobalVariable>();

        bgm1 = GameObject.Find("creepybgm").GetComponent<AudioSource>();
        bgm2 = GameObject.Find("ticking").GetComponent<AudioSource>();
        //bgm3 = GameObject.Find("clear").GetComponent<AudioSource>();

        //Time.timeScale = 0f;
        StartCoroutine("flow");
        StartCoroutine("wall");

        GameStart = false;
        Time.timeScale = 1f;
        bgm1.Play();
        bgm2.Play();
    }

    void Update () {
        Score = global.gScore;
        HP = global.gHP;
        Level = global.gLevel;

        ScoreText.text = Score.ToString();
        HPText.text = HP.ToString();

        if (isGameOver == true)
        {
            Time.timeScale = 0f;
            GameOverObj.SetActive(true);
            bgm1.Stop();
            bgm2.Stop();
            //bgm3.Stop();
        }

        if(isGameClear == true)
        {
            Time.timeScale = 0f;
            GameClearObj.SetActive(true);
            //bgm3.Play();
            bgm1.Stop();
            bgm2.Stop();
        }
        if (isGameNext == true)
        {
            Time.timeScale = 0f;
            GameNextObj.SetActive(true);
            //bgm3.Play();
            //bgm1.Stop();
            bgm2.Stop();
        }
    }

    IEnumerator flow()
    {
        Instantiate(waterFlow, waterFlow.transform.position, waterFlow.transform.rotation);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("flow");
    }
    IEnumerator wall()
    {
        Instantiate(Wall, Wall.transform.position, Wall.transform.rotation);
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        StartCoroutine("wall");
    }

    public void ReStartBt()
    {
        SceneManager.LoadScene("1.main");
    }
    public void goEnding()
    {
        SceneManager.LoadScene("3.ending");
    }
    public void goNextLevel2()
    {
        SceneManager.LoadScene("2.game2");
    }
    public void goNextLevel3()
    {
        SceneManager.LoadScene("2.game3");
    }
}
