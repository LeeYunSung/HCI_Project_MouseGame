using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanObjects : MonoBehaviour
{
    public GameObject canObject;
    private float time;
    private Vector2[] pos;

    void Start()
    {
        time = 0;
        pos = new Vector2[3];
        pos[0] = new Vector2(-1.5f, 7);
        pos[1] = new Vector2(0, 7);
        pos[2] = new Vector2(1.5f, 7);
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time > 1)
        {
            time = 0;
            cloneCan();
        }
    }

    void cloneCan()
    {
        int flag = Random.Range(0, 3);//-1,0,1 위치 랜덤
        Instantiate(canObject).GetComponent<Transform>().position = pos[flag];
    }
}
