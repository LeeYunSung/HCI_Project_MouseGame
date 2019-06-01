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

    private float time;
    private Vector2[] pos;

    //초기화
    void Start()
    {
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
        time += Time.deltaTime;
        if(time > 2)//2초마다 복제
        {
            int i = Random.Range(1, 3);
            if (i == 1)
            {
                cloneCan();
            }
            if (i == 2)
            {
                cloneCheese();
            }
            time = 0;
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
}
