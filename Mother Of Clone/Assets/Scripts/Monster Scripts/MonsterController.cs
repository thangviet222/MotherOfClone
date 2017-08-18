using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {
    public float halfEatTime;
    public GameObject fruit;

    private InputController inputController;
    private Vector2 velocity;
    private Vector3 startingPos1;
    private Vector3 startingPos2;

    private Animator anim;
    private bool is1Eating;
    private bool is2Eating;

    public static bool isCountDownDone;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        inputController = GetComponent<InputController>();

        if (gameObject.tag == "Monster1")
            startingPos1 = gameObject.transform.position;
        if (gameObject.tag == "Monster2")
            startingPos2 = gameObject.transform.position;
    }

    private void Update()
    {
        if (isCountDownDone)
        {
            inputController.OnMonster1ButtonPressed += Monster1Eat;
            inputController.OnMonster2ButtonPressed += Monster2Eat;
        }
    }

    private void OnDestroy()
    {
        inputController.OnMonster1ButtonPressed -= Monster1Eat;
        inputController.OnMonster2ButtonPressed -= Monster2Eat;
    }

    private void Monster1Eat()
    {
        if (gameObject.tag == "Monster1" && is1Eating == false && !ButtonManager.isPausing)
        {
            anim.SetTrigger("Jump");
            is1Eating = true;
            StartCoroutine(RunCoroutine(startingPos1));
        }
    }

    private void Monster2Eat()
    {
        if (gameObject.tag == "Monster2" && is2Eating == false && !ButtonManager.isPausing)
        {
            anim.SetTrigger("Jump");
            is2Eating = true;
            StartCoroutine(RunCoroutine(startingPos2));
        }
    }

    private IEnumerator RunCoroutine(Vector3 startingPos)
    {
        float time = 0;
        while (time < halfEatTime)
        {
            transform.position = Vector3.Lerp(startingPos, fruit.transform.position, time/halfEatTime);
            time += Time.deltaTime;
            yield return null;
        }

        time = 0;
        while (time < halfEatTime)
        {
            transform.position = Vector3.Lerp(fruit.transform.position, startingPos, time / halfEatTime);
            time += Time.deltaTime;
            yield return null;
        }

        if (gameObject.tag == "Monster1")
            is1Eating = false;
        else
            is2Eating = false;
    }
}
