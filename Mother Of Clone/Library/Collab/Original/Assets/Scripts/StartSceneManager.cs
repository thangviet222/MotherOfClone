using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour {

    public void Enter2Cars()
    {
        TKSceneManager.ChangeScene("2Cars");
    }

    public void EnterMonster()
    {
        TKSceneManager.ChangeScene("MonsterEatsFood");
    }
    public void EnterGame3()
    {

    }

    public void PlayAgain()
    {
        TKSceneManager.ChangeScene("2Cars");
        DataManager.pause = false;
        DataManager.score = 0;
    }

    public void Home()
    {
        TKSceneManager.ChangeScene("StartScene");
        DataManager.pause = false;
        DataManager.score = 0;
    }
}
