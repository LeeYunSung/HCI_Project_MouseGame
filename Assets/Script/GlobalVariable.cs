using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalVariable : MonoBehaviour
{
    GameManager GM;
    public int gScore=0;
    public int gHP=5;
    public int gLevel=1;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }
    public void Update()
    {
        if (GM.isGameOver == true || GM.isGameClear == true)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
