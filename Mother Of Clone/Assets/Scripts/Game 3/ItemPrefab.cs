using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemPrefab : MonoBehaviour {

    public GameObject itemPrefab;

    private bool canCreate;
    private List<GameObject> listItem2 = new List<GameObject>();

    private List<GameObject> listItem1 = new List<GameObject>();
    private List<GameObject> listItem3 = new List<GameObject>();
    private List<GameObject> listItem4 = new List<GameObject>();
    private List<GameObject> listItem5 = new List<GameObject>();
    private List<GameObject> listItem6 = new List<GameObject>();
    private List<GameObject> listItem7 = new List<GameObject>();
    private List<GameObject> listItem8 = new List<GameObject>();


    private void Start()
    {
        canCreate = true;
        releaseItem();
    }
    void addToList(Vector2 possition,List<GameObject> list)
    {
        GameObject newPlatform = Instantiate(
            itemPrefab,
            Vector3.zero,
            Quaternion.identity
        );
        newPlatform.transform.position = possition;
        list.Add(newPlatform);
        newPlatform.SetActive(true);
    }
    
    IEnumerator createItem(List<GameObject> list)
    {
        activeOb(list);
        yield return new WaitForSeconds(4);
        deactiveOb(list);
    }
    IEnumerator createItem()
    {
        canCreate = false;
        int x = Random.Range(1, 9);
        if (x == 1)
        {
            StartCoroutine(createItem(listItem1));
        }
        else if (x == 2)
        {
            StartCoroutine(createItem(listItem2));
        }
        else if (x == 3)
        {
            StartCoroutine(createItem(listItem3));
        }
        else if (x == 4)
        {
            StartCoroutine(createItem(listItem4));
        }
        else if (x == 5)
        {
            StartCoroutine(createItem(listItem5));
        }
        else if (x == 6)
        {
            StartCoroutine(createItem(listItem6));
        }
        else if (x == 7)
        {
            StartCoroutine(createItem(listItem7));
        }
        else if (x == 8)
        {
            StartCoroutine(createItem(listItem8));
        }


        yield return new WaitForSeconds(4);
        canCreate = true;

        
    }
    private void Update()
    {
        if (canCreate)
        {
            StartCoroutine(createItem());
        }
    }
    void releaseItem()
    {
        addToList(new Vector2(-462, -192), listItem1);
        addToList(new Vector2(-231, -96), listItem1);
        addToList(new Vector2(0, 0), listItem1);
        addToList(new Vector2(231, -96), listItem1);
        addToList(new Vector2(462, -192), listItem1);
        deactiveOb(listItem1);
        addToList(new Vector2(-462, 192), listItem2);
        addToList(new Vector2(-231, 96), listItem2);
        addToList(new Vector2(0, 0), listItem2);
        addToList(new Vector2(231, 96), listItem2);
        addToList(new Vector2(462, 192), listItem2);
        deactiveOb(listItem2);
        addToList(new Vector2(-462, -192), listItem3);
        addToList(new Vector2(-231, -96), listItem3);
        addToList(new Vector2(0, 0), listItem3);
        addToList(new Vector2(-462, 192), listItem3);
        addToList(new Vector2(-231, 96), listItem3);
        deactiveOb(listItem3);
        addToList(new Vector2(462, -192), listItem4);
        addToList(new Vector2(231, -96), listItem4);
        addToList(new Vector2(0, 0), listItem4);
        addToList(new Vector2(462, 192), listItem4);
        addToList(new Vector2(231, 96), listItem4);
        deactiveOb(listItem4);
        addToList(new Vector2(-711, 96), listItem5);
        addToList(new Vector2(-711, -96), listItem5);
        deactiveOb(listItem5);
        addToList(new Vector2(711, 96), listItem6);
        addToList(new Vector2(711, -96), listItem6);
        deactiveOb(listItem6);
        addToList(new Vector2(-462, -192), listItem7);
        addToList(new Vector2(462, 192), listItem7);
        addToList(new Vector2(-231, -96), listItem7);
        addToList(new Vector2(231, 96), listItem7);
        addToList(new Vector2(0, 0), listItem7);
        deactiveOb(listItem7);
        addToList(new Vector2(-462, 192), listItem8);
        addToList(new Vector2(462, -192), listItem8);
        addToList(new Vector2(-231, 96), listItem8);
        addToList(new Vector2(231, -96), listItem8);
        addToList(new Vector2(0, 0), listItem8);
        deactiveOb(listItem8);

    }
    void activeOb(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetActive(true);

        }
    }
    void deactiveOb(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
           list[i].SetActive(false);

        }
    }
}
