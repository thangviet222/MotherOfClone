using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Skill_Player))]

public class Game3_PlayerController : MonoBehaviour {
    public float lerpTime;
    public Image ProgressBar;
    public KeyCode toLocation1;
    public KeyCode toLocation2;
    public KeyCode toLocation3; 
    public KeyCode toLocation4;
    public KeyCode SkillButton;
    public int startLocationX;
    public int startLocationY;


    Skill_Player skill;
    private Vector2 location1;
    private Vector2 location2;
    private Vector2 location3;
    private Vector2 location4;
    private bool canMove;
    private Collider2D coliderPlayer;
    private int score=0;
    private void Awake()
    {
        skill = GetComponent<Skill_Player>();
    }
    private void Start()
    {
        location1 = new Vector2(-711, 306);
        location2 = new Vector2(711, 306);
        location3 = new Vector2(711,-306);
        location4 = new Vector2(-711,-306);
        //coliderPlayer = 
        StartCoroutine(MoveTo(new Vector2(startLocationX,startLocationY)));
        canMove = true;
       // ProgressBar.fillAmount = 5 / 10;
    }
    
    IEnumerator MoveTo(Vector3 targetPos)
    {
        float time = 0;
        Vector3 startingPos = transform.position;
        canMove = false;
        while (time < lerpTime)
        {
            transform.position = Vector3.Lerp(startingPos, targetPos, time / lerpTime);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        canMove = true;
    }

    private void Update()
    {
        float PossitionX = transform.position.x;
        if (Input.GetKeyDown(toLocation1) && canMove)
        {   
            StartCoroutine(MoveTo(location1));
        }
        if (Input.GetKeyDown(toLocation2) && canMove)
        {
            StartCoroutine(MoveTo(location2));
        }
        if (Input.GetKeyDown(toLocation3) && canMove)
        {
            StartCoroutine(MoveTo(location3));
        }
        if (Input.GetKeyDown(toLocation4) && canMove)
        {
            StartCoroutine(MoveTo(location4));
        }
        ProgressBar.fillAmount=(float)score/20;
        print("Pro   "+ProgressBar.fillAmount);
        if (Input.GetKeyDown(SkillButton)&& score>=20)
        {
            score = 0;
            skill.Skill(PossitionX);
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            score++;
         //  print("score"+score);
            collision.gameObject.SetActive(false);
        }
    }
}
