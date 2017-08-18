using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour {
    public bool halfLeft;
    public KeyCode moveButton;
    public Image image;
    public Text text;
    
    private Vector2 velocity;
    private Vector2 isRight;
    private Vector2 isLeft;
    private bool left;
    private float timeDown;

    private Animator anim;
    private Coroutine coroutine;

    void Start()
    {
        anim = GetComponent<Animator>();

        if(halfLeft)
        {
            isLeft = new Vector2(-Game2CarManager.widthOneRoad * 3 / 2, - Camera.main.orthographicSize / 2);
            isRight = new Vector2(-Game2CarManager.widthOneRoad / 2, - Camera.main.orthographicSize / 2);
        }
        else
        {
            isLeft = new Vector2(Game2CarManager.widthOneRoad / 2, -Camera.main.orthographicSize / 2);
            isRight = new Vector2(Game2CarManager.widthOneRoad * 3 / 2, -Camera.main.orthographicSize / 2);
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
            Game2CarManager.die = true;
            collision.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag == "Item")
        {
            Game2CarManager.score++;
            collision.gameObject.SetActive(false);
            Game2CarManager.game2CarManager.Score();
        }
    }

    void Update()
    {
        if (Game2CarManager.die)
        {
            Game2CarManager.pause = true;
            anim.SetTrigger("IsDie");
            text.text = Game2CarManager.score.ToString();
            image.gameObject.SetActive(true);
        }

        if (Game2CarManager.pause)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
        }

        if (Input.GetKeyDown(moveButton) && !Game2CarManager.pause)
        {
            if (left)
            {
                if(coroutine != null)
                    StopCoroutine(coroutine);

                coroutine = StartCoroutine(MoveTo(isRight));
                left = !left;
            }
            else
            {
                if (coroutine != null)
                    StopCoroutine(coroutine);

                coroutine = StartCoroutine(MoveTo(isLeft));
                left = !left;
            }
        }
    }

    IEnumerator MoveTo(Vector3 targetPos)
    {
        float time = 0;
        Vector3 startingPos = transform.position;

        while (time < Game2CarManager.game2CarManager.lerpTime)
        {
            transform.position = Vector3.Lerp(startingPos, targetPos, time / Game2CarManager.game2CarManager.lerpTime);
            time += Time.deltaTime;

            yield return null;
        }

        transform.position = targetPos;
    }
}