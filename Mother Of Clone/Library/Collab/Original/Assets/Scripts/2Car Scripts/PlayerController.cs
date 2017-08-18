using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float moventSpeed;
    public float lerpTime;
    public bool halfLeft;
    public KeyCode moveButton;
    public Image image;
    public Text text;

    private Vector2 velocity;
    private Vector2 isRight;
    private Vector2 isLeft;
    private bool left;
    private bool canMove = true;
    private Vector3 last;

    void Start()
    {
        if(halfLeft)
        {
            isLeft = new Vector2(- DataManager.widthOneRoad * 3 / 2, - Camera.main.orthographicSize / 2);
            isRight = new Vector2(- DataManager.widthOneRoad / 2, - Camera.main.orthographicSize / 2);
        }
        else
        {
            isLeft = new Vector2(DataManager.widthOneRoad / 2, -Camera.main.orthographicSize / 2);
            isRight = new Vector2(DataManager.widthOneRoad * 3 / 2, -Camera.main.orthographicSize / 2);
        }

        if (halfLeft)
        {
            velocity = isRight;
            left = false;
        }
        else
        {
            velocity = isLeft;
            left = true;
        }

        transform.position = (Vector3)(velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            DataManager.pause = true;
            text.text = DataManager.score.ToString();
            image.gameObject.SetActive(true);
        }
        else if(collision.gameObject.tag == "Item")
        {
            DataManager.score++;
            collision.gameObject.SetActive(false);
        }
    }

    void Update()
    {


        if (Input.GetKeyDown(moveButton) && !DataManager.pause)
        {
            //if(canMove)
            //{
            //    if (left)
            //    {
            //        last = (Vector3)isRight;
            //        StartCoroutine(MoveTo(last));
            //        last = (Vector3)isLeft;
            //        left = !left;
            //    }
            //    else
            //    {
            //        if (transform.position.Equals(isRight))
            //        {
            //            last =
            //        }
            //        StartCoroutine(MoveTo(last));

            //        left = !left;
            //    }


            //    canMove = false;
            //    StartCoroutine(Move());
            //}
            if (transform.position.Equals(isLeft))
            {
                last = (Vector3)isRight;
            }
            else
            {
                last = (Vector3)isLeft;
            }
            StartCoroutine(MoveTo(last));
            if (last.Equals(isRight))
            {
                last = (Vector3)isLeft;
            }
            else
            {
                last = (Vector3)isRight;
            }
        }
    }

    IEnumerator MoveTo(Vector3 targetPos)
    {
        float time = 0;
        Vector3 startingPos = transform.position;

        while (time < lerpTime)
        {
            transform.position = Vector3.Lerp(startingPos, targetPos, time / lerpTime);
            time += Time.deltaTime;

            yield return null;
        }

        transform.position = targetPos;
    }

    IEnumerator Move()
    {
        if(!canMove)
        {
            yield return new WaitForSeconds(1);
            canMove = true;
        }
    }
}