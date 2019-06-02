using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjects : MonoBehaviour
{
    //선언
    public GameObject canObject;//캔
    public GameObject woodObject;//나무토막
    public GameObject cheeseObject;//치즈
    public GameObject hamObject;//햄
    public GlobalVariable global;

    private float time;
    private Vector2[] pos;

    public int Level;

    //초기화
    void Start()
    {
        global = GameObject.FindGameObjectWithTag("global").GetComponent<GlobalVariable>();

        time = 0;
        //아이템 생성위치 (-1.5, 7), (0, 7) , (1.5, 7)
        pos = new Vector2[3];
        pos[0] = new Vector2(-1.5f, 7);
        pos[1] = new Vector2(0, 7);
        pos[2] = new Vector2(1.5f, 7);
    }

    //thread
    void Update()
    {
        Level = global.gLevel;
        time += Time.deltaTime;
        switch (Level)
        {
            case 1:
                if (time > 2)//2초마다 복제
                {
                    int i = Random.Range(1, 3);
                    if (i == 1)
                    {
                        cloneHam();
                    }
                    if (i == 2)
                    {
                        cloneCheese();
                    }
                    time = 0;
                }
                break;

            case 2:
                if (time > 1.5)//1.5초마다 복제
                {
                    int i = Random.Range(1, 4);
                    if (i == 1)
                    {
                        cloneCan();
                    }
                    if (i == 2)
                    {
                        cloneCheese();
                    }
                    if (i == 3)
                    {
                        cloneHam();
                    }
                    time = 0;
                }
                break;

            case 3:
                if (time > 1)//1초마다 복제
                {
                    int i = Random.Range(1, 5);
                    if (i == 1)
                    {
                        cloneCan();
                    }
                    if (i == 2)
                    {
                        cloneCheese();
                    }
                    if (i == 3)
                    {
                        cloneWood();
                    }
                    if (i == 4)
                    {
                        cloneHam();
                    }
                    time = 0;
                }
                break;
        }
    }

    void cloneCan()
    {
        int flag = Random.Range(0, 3);//0,1,2 랜덤
        Instantiate(canObject).GetComponent<Transform>().position = pos[flag];
    }
    void cloneCheese()
    {
        int flag = Random.Range(0, 3);//0,1,2 랜덤
        Instantiate(cheeseObject).GetComponent<Transform>().position = pos[flag];
    }
    void cloneWood()
    {
        int flag = Random.Range(0, 3);//0,1,2 랜덤
        Instantiate(woodObject).GetComponent<Transform>().position = pos[flag];
    }
    void cloneHam()
    {
        int flag = Random.Range(0, 3);//0,1,2 랜덤
        Instantiate(hamObject).GetComponent<Transform>().position = pos[flag];
    }
}
