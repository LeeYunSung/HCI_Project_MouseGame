using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    bool isMove = false;
    public int movePoint = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void left()
    {
        if(isMove == false && (movePoint == 1 || movePoint == 2 ))
            StartCoroutine("Move", 0);
    }

    public void right()
    {
        if (isMove == false && (movePoint == 0 || movePoint == 1))
            StartCoroutine("Move", 1);
    }

    IEnumerator Move(int flag)
    {
        isMove = true;
        if (flag == 0)
        {
            transform.Rotate(Vector3.forward * 50);
            for (int i = 0; i < 10; i++)
            {
                transform.position = new Vector3(transform.position.x - 0.15f, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(0.001f);
            }
            for (int i = 0; i < 5; i++)
            {
                transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(0.001f);
            }
            movePoint--;
            transform.Rotate(Vector3.back * 50);
        }
        else
        {
            transform.Rotate(Vector3.back * 50);
            for (int i = 0; i < 10; i++)
            {
                transform.position = new Vector3(transform.position.x + 0.15f, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(0.001f);
            }
            for (int i = 0; i < 5; i++)
            {
                transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(0.001f);
            }
            movePoint++;
            transform.Rotate(Vector3.forward * 50);

        }
        isMove = false;
    }
}
