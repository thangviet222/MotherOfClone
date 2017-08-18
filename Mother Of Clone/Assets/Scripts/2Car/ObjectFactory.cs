using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory : MonoBehaviour {
    public GameObject squareRoadLeft;
    public GameObject squareRoadRight;
    public GameObject circleRoadLeft;
    public GameObject circleRoadRight;

    public float startPositionY = 50;
    public float timeDelay = 1;

    private List<GameObject> squareRoadPool = new List<GameObject>();
    private List<GameObject> circleRoadPool = new List<GameObject>();
    private bool canCreate = true;

    void Update()
    {
        if(!Game2CarManager.pause)
        {
            CreateGameObject();
            CheckGameObject();
        }
    }

    void CreateGameObject()
    {
        if (canCreate)
        {
            Create(squareRoadLeft, circleRoadLeft, -Game2CarManager.widthOneRoad * 3 / 2, -Game2CarManager.widthOneRoad / 2);
            Create(squareRoadRight, circleRoadRight, Game2CarManager.widthOneRoad / 2, Game2CarManager.widthOneRoad * 3 / 2);

            canCreate = false;
            StartCoroutine(StartCreateGameObject());
        }
    }

    void Create(GameObject squareObject, GameObject circleObject, float startposition1, float startposition2)
    {
        int i = Random.Range(0, 2);

        if (i == 0)
            CreateInRoad(squareObject, circleObject, startposition1);
        else
            CreateInRoad(squareObject, circleObject, startposition2);
    }

    void CreateInRoad(GameObject squareObject, GameObject circleObject, float startX)
    {
        int i = Random.Range(0, 2);

        if (i == 0)
        {
            GameObject gameObject = GetNewObject(squareRoadPool, squareObject, startX);
            gameObject.GetComponent<SpriteRenderer>().sprite = squareObject.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            GameObject gameObject = GetNewObject(circleRoadPool, circleObject, startX);
            gameObject.GetComponent<SpriteRenderer>().sprite = circleObject.GetComponent<SpriteRenderer>().sprite;
        }
    }

    GameObject GetNewObject(List<GameObject> pool, GameObject objects, float startX)
    {
        foreach (GameObject gameObject in pool)
        {
            if (!gameObject.activeInHierarchy)
            {
                gameObject.transform.position = new Vector3(startX, Camera.main.orthographicSize + startPositionY, 0);
                gameObject.SetActive(true);
                return gameObject;
            }
        }

        GameObject newGameObject = Instantiate(
            objects,
            new Vector3(startX, Camera.main.orthographicSize + startPositionY, 0),
            Quaternion.identity
        );

        pool.Add(newGameObject);
        return newGameObject;
    }

    void CheckGameObject()
    {
        foreach (GameObject gameObject in squareRoadPool)
        {
            if (gameObject.transform.position.y < -Camera.main.orthographicSize - startPositionY)
                gameObject.SetActive(false);
        }

        foreach (GameObject gameObject in circleRoadPool)
        {
            if (gameObject.transform.position.y < -Camera.main.orthographicSize - startPositionY)
            {
                gameObject.SetActive(false);
                Game2CarManager.die = true;
            }
        }
    }

    IEnumerator StartCreateGameObject()
    {
        if(!canCreate)
        {
            yield return new WaitForSeconds(timeDelay);
            canCreate = true;
        }
    }
}