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
        TKSceneManager.ChangeScene("Game 3");
    }

    public void PlayAgain()
    {
        TKSceneManager.ChangeScene("2Cars");
        Game2CarManager.pause = false;
        Game2CarManager.die = false;
        Game2CarManager.score = 0;
    }

    public void Home()
    {
        TKSceneManager.ChangeScene("StartScene");
        Game2CarManager.pause = false;
        Game2CarManager.die = false;
        Game2CarManager.score = 0;
    }
}
