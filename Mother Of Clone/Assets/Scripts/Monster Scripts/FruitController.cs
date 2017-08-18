using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitController : MonoBehaviour {
    public List<Sprite> fruit;

    private ScoringManager scoringManager;

    private bool firstTimeSetFruitSprite = true;
    private bool isFruitAppear;

    private int count = 0;

    private void Awake()
    {
        scoringManager = GetComponent<ScoringManager>();
    }

    private void FixedUpdate()
    {
        if (!firstTimeSetFruitSprite)
        {
            if (isFruitAppear)
            {
                count++;
                if (count % 125 == 0)
                {
                    gameObject.GetComponent<Image>().enabled = false;
                    isFruitAppear = false;
                    count = 0;
                    StartCoroutine(WaitForChange());
                }
            }
            else
                count = 0;
        }
    }

    private void Update()
    {
        if(MonsterController.isCountDownDone && firstTimeSetFruitSprite)
        {
            gameObject.GetComponent<Image>().enabled = true;
            gameObject.GetComponent<Image>().sprite = fruit.RandomItem();
            isFruitAppear = true;
            firstTimeSetFruitSprite = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoringManager.Scoring(collision);
        gameObject.GetComponent<Image>().enabled = false;
        isFruitAppear = false;
        StartCoroutine(WaitForChange());
    }

    private IEnumerator WaitForChange()
    {
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Image>().sprite = fruit.RandomItem();
        gameObject.GetComponent<Image>().enabled = true;
        isFruitAppear = true;
    }
}
