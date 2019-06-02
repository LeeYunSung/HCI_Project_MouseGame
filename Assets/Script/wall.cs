using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class wall : MonoBehaviour {
    public GlobalVariable global;

    public Text quizText;
    public Text AnswerText1;
    public Text AnswerText2;
    public Player player_script;
    public GameManager GM;
    int answer1 = 0;
    int answer2 = 0;

    const int CLEAR_SCORE = 500;

    public GameObject Explosion;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(Explosion, transform.position, transform.rotation);
        }
    }

    // Use this for initialization
    void Start () {
        global = GameObject.FindGameObjectWithTag("global").GetComponent<GlobalVariable>();

        player_script = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        quizText = transform.GetChild(0).gameObject.GetComponent<Text>();
        AnswerText1 = transform.GetChild(1).gameObject.GetComponent<Text>();
        AnswerText2 = transform.GetChild(2).gameObject.GetComponent<Text>();

        int a = Random.Range(0, 10);//숫자 1
        int b = Random.Range(0, 10);//숫자 2
        int op = Random.Range(0, 3);//+ or - or *

        //문제의 경우에 따라
        switch(op)
        {
            //+문제
            case 0:
                answer1 = a + b;
                answer2 = Random.Range(2, 20);
                if (answer2 == answer1)
                {
                    answer2 = Random.Range(2, 20);
                }
                quizText.text = a.ToString() + " + " + b.ToString() + " = ?";
                break;
            //-문제
            case 1:
                answer1 = a - b;
                answer2 = Random.Range(-10, 10);
                if (answer2 == answer1)
                {
                    answer2 = Random.Range(-10, 10);
                }
                quizText.text = a.ToString() + " - " + b.ToString() + " = ?";
                break;
            //*문제
            case 2:
                answer1 = a * b;
                answer2 = Random.Range(1, 20);
                if (answer2 == answer1)
                {
                    answer2 = Random.Range(1, 20);
                }
                quizText.text = a.ToString() + " x " + b.ToString() + " = ?";
                break;
        }
        //답 위치를 랜덤으로 배치
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            AnswerText1.text = answer1.ToString();
            AnswerText2.text = answer2.ToString();
        }
        else
        {
            AnswerText2.text = answer1.ToString();
            AnswerText1.text = answer2.ToString();
        }
    }
	
	void Update () {
		
	}

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);

        if (transform.position.y <= -10f)
        {
            Destroy(gameObject);
        }
    }
  
    //벽 통과 예외처리
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //왼쪽으로 통과했을 때
            if (player_script.movePoint == 0)
            {
                if(System.Convert.ToInt32(AnswerText1.text) == answer1)
                {
                    global.gScore += 100;
                    if (global.gScore== CLEAR_SCORE)
                    {
                        GM.isGameNext = true;
                        global.gLevel++;
                    }
                }
                else
                {
                    GM.isGameOver = true;
                }
            }
            //오른쪽으로 통과했을 때
            else if (player_script.movePoint == 2)
            {
                if (System.Convert.ToInt32(AnswerText2.text) == answer1)
                {
                    global.gScore += 100;
                    if (global.gScore == CLEAR_SCORE)
                    {
                        GM.isGameNext = true;
                        global.gLevel++;
                    }
                }
                else
                {
                    GM.isGameOver = true;
                }
            }
            //답 위치가 아닌 다른데 부딪혔을 때
            else
            {
                GM.isGameOver = true;
            }
        }
    }
}
