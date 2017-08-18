using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
    private float currentSpeed;

    void Start()
    {
        currentSpeed = Game2CarManager.game2CarManager.moveSpeed;
    }

    void Update ()
    {
        if (currentSpeed > Game2CarManager.game2CarManager.maxSpeed)
            currentSpeed = Game2CarManager.game2CarManager.maxSpeed;

        if (!Game2CarManager.pause && currentSpeed <= Game2CarManager.game2CarManager.maxSpeed)
        {
            currentSpeed = Game2CarManager.game2CarManager.moveSpeed + Game2CarManager.game2CarManager.speedUp * Game2CarManager.game2CarManager.number;
            transform.position += Vector3.down * currentSpeed * Time.deltaTime;
        }
    }
}