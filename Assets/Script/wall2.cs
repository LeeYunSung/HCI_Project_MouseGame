using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class wall2 : MonoBehaviour
{
    public GlobalVariable global;

    public Text quizText;
    public Text AnswerText1;
    public Text AnswerText2;
    public Player player_script;
    public GameManager GM;
    int answer1 = 0;
    int answer2 = 0;

    const int CLEAR_SCORE = 1000;

    public GameObject Explosion;

    ArrayList questionList;
    ArrayList optionList;
    ArrayList answerList;

    int num;
    string[] q = new string[]
    {
        "골목을 뜻하는 제주도 사투리는?",
        "캐나다의 수도는?",
        "수도가 아닌 도시는?",
        "털어서 (  ) 안 나는 사람 없다.",
        "누난 나의 (  )",
        "(  )에 옷 젖는 줄 모른다.",
        "간에 붙었다 (  )에 붙었다 한다.",
        "개밥에 (  )",
        "(  ) 목에 방울 달기",
        "(  )도 식후경"
    };

    string[] ops = new string[]
    {
        "올레/둘레",
        "토론토/오타와",
        "시드니/델리",
        "먼지/각질",
        "VIP/MVP",
        "가랑비/소나기",
        "췌장/쓸개",
        "알밤/도토리",
        "고양이/강아지",
        "설악산/금강산"
    };

    int[] ans = new int[]
    {
            1, 2, 1, 1, 2, 1, 2, 2, 1, 2
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
        optionList = new ArrayList();
        answerList = new ArrayList();

        questionList.AddRange(q);
        optionList.AddRange(ops);
        answerList.AddRange(ans);

        num = Random.Range(0, 10);
        quizText.text = questionList[num].ToString();
        string[] str = optionList[num].ToString().Split('/');
        AnswerText1.text = str[0].ToString();
        AnswerText2.text = str[1].ToString();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.07f, transform.position.z);

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
                if (ans[num] == 2)
                {
                    // 정답
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
