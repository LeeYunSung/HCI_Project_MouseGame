using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can : MonoBehaviour
{
    public float speed = 3.0f; //차의 속도
    private float deadHeight = -15.0f; //y값이 -15.0 아래로 내려가면 화면에서 안보이는 거니까 없애기

    void Start()
    {

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
        if(col.gameObject.tag.Equals("Player"))
        {
            //hp를 더한다
            Destroy(gameObject);
        }
    }
}
