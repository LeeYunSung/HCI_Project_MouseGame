using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class wall3 : MonoBehaviour
{
    public GlobalVariable global;

    public Text quizText;
    public Text AnswerText1;
    public Text AnswerText2;
    public Player player_script;
    public GameManager GM;
    int answer1 = 0;
    int answer2 = 0;

    const int CLEAR_SCORE = 1500;

    ArrayList questionList;
    ArrayList answerList;

    public GameObject Explosion;

    int num;
    string[] q = new string[]
    {
        "달팽이도 이빨이 있다.",
        "원숭이에게도 지문이 있다.",
        "벼룩도 간이 있다.",
        "비행기 블랙박스는 검은색",
        "대머리도 비듬이 있다.",
        "물고기도 색을 구분한다.",
        "낙지는 심장이 3개이다.",
        "세계에서 가장 긴 강은 황허강",
        "고래는 냄새를 맡을 수 있다.",
        "소는 색맹이다."

    };


    int[] ans = new int[] // o면 1, x면 2
    {
        1, 1, 2, 2, 1, 1, 1, 2, 1, 1
    };

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(Explosion, transform.position, transform.rotation);
        }
    }

    // Use this for initialization
    void Start()
    {
        global = GameObject.FindGameObjectWithTag("global").GetComponent<GlobalVariable>();

        player_script = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        quizText = transform.GetChild(0).gameObject.GetComponent<Text>();
        AnswerText1 = transform.GetChild(1).gameObject.GetComponent<Text>();
        AnswerText2 = transform.GetChild(2).gameObject.GetComponent<Text>();

        // 글자 크기 줄임
        AnswerText1.fontSize = 30;
        AnswerText2.fontSize = 30;
        quizText.fontSize = 30;

        questionList = new ArrayList();
        answerList = new ArrayList();

        questionList.AddRange(q);
        answerList.AddRange(ans);

        // 문제 출제
        num = Random.Range(0, 10);
        quizText.text = questionList[num].ToString();
        AnswerText1.text = "O";
        AnswerText2.text = "X";
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.08f, transform.position.z);

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
                if (ans[num] == 1)
                {
                    // 정답
                    global.gScore += 100;
                    if (global.gScore == CLEAR_SCORE)
                    {
                        global.gLevel++;
                        GM.isGameClear = true;
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
                if (ans[num] == 2)
                {
                    // 정답
                    global.gScore += 100;
                    if (global.gScore == CLEAR_SCORE)
                    {
                        global.gLevel++;
                        GM.isGameClear = true;
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
