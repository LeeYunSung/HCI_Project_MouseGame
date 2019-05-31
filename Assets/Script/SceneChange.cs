using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        SceneManager.LoadScene("2.game");
    }

    public void howGame()
    {
        SceneManager.LoadScene("1.main");

    }
    public void goMain()
    {
        SceneManager.LoadScene("1.main");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
