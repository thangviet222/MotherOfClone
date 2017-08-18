using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringManager : MonoBehaviour {
    public GameObject scorePrefab;
    public GameObject emptyScorePrefab;
    public int winningScore;
    public GameObject WinPanel;
    public Text scoreText;

    private GameObject[] scoreList1 = new GameObject[10];
    private GameObject[] scoreList2 = new GameObject[10];
    private int score1 = 0;
    private int score2 = 0;

    private void Awake()
    {
        for (int i = 0; i < winningScore; i++)
        {
            Instantiate(emptyScorePrefab,
                    new Vector3(scorePrefab.transform.position.x + 30 * (i + 1), scorePrefab.transform.position.y),
                    Quaternion.identity);

            Instantiate(emptyScorePrefab,
                    new Vector3(-scorePrefab.transform.position.x - 30 * (i + 1), scorePrefab.transform.position.y),
                    Quaternion.identity);
        }
    }

    private void Win()
    {
        if(score1 == winningScore)
        {
            WinPanel.SetActive(true);
            scoreText.text = "Player 1 Win!";
        }

        if(score2 == winningScore)
        {
            WinPanel.SetActive(true);
            scoreText.text = "Player 2 Win!";
        }
    }

    public void Scoring(Collider2D collision)
    {
        if (gameObject.GetComponent<Image>().enabled == true)
        {
            if (collision.gameObject.tag == "Monster1")
            {
                if (!gameObject.GetComponent<Image>().sprite.name.Contains("bad"))
                {
                    score1++;
                    scoreList1[score1 - 1] = (Instantiate(scorePrefab,
                        new Vector3(scorePrefab.transform.position.x + 30 * score1,
                        scorePrefab.transform.position.y),
                        Quaternion.identity)
                        );
                    Win();
                }

                if (gameObject.GetComponent<Image>().sprite.name.Contains("bad"))
                {
                    if(score1 > 0)
                    {
                        score1--;
                        scoreList1[score1].SetActive(false);
                    }
                }
            }
            else
            {
                if (!gameObject.GetComponent<Image>().sprite.name.Contains("bad"))
                {
                    score2++;
                    scoreList2[score2 - 1] = Instantiate(scorePrefab,
                        new Vector3(-scorePrefab.transform.position.x - 30 * score2,
                        scorePrefab.transform.position.y),
                        Quaternion.identity)
                        ;
                    Win();
                }

                if (gameObject.GetComponent<Image>().sprite.name.Contains("bad"))
                {
                    if (score2 > 0)
                    {
                        score2--;
                        scoreList2[score2].SetActive(false);
                    }
                }
            }
        }
    }
}
