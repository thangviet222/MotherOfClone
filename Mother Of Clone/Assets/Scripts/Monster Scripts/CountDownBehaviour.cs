using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownBehaviour : MonoBehaviour {
    public void SetCountDownNow()
    {
        MonsterController.isCountDownDone = true;
    }
}
