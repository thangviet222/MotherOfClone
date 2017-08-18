using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
    public float moveSpeed;

    void Update ()
    {
        if(!DataManager.pause)
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
	}
}