using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public float speed = 2.0f; //아이템 속도
    private float deadHeight = -15.0f; //y값이 -15.0 아래로 내려가면 화면에서 안보이는 거니까 없애기
    public GameManager GM;
    public GlobalVariable global;

    void Start()
    {
        global = GameObject.FindGameObjectWithTag("global").GetComponent<GlobalVariable>();
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    //계속 아래로 이동
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < deadHeight)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(gameObject.tag == "badItem" && col.gameObject.tag.Equals("Player"))
        {
            //hp 감소
            global.gHP--;
            if (global.gHP == 0)
            {
                GM.isGameOver = true;
            }
            //아이템 닿으면 없어지게
            Destroy(gameObject);
        }
        if (gameObject.tag == "goodItem" && col.gameObject.tag.Equals("Player"))
        {
            //hp증가
            global.gHP++;
            if(global.gHP >= 5)
            {
                global.gHP = 5;
            }
            //아이템 닿으면 없어지게
            Destroy(gameObject);
        }
    }
}
