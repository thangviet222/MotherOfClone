using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Player : MonoBehaviour {

    // Use this for initialization
    public GameObject laser;
    public GameObject boxcolider;
    public float LerpTime;
    public string enemy;
    public bool candestroy;
    BoxCollider2D laserCollider;
    bool canSkill;
    private GameObject newLaser;
    private GameObject obj;
    BoxCollider2D box;
    DemoScript demo;

    void Start()
    {
        canSkill = true;
        candestroy = false;
        newLaser = Instantiate(laser, Vector3.zero, Quaternion.identity);
        obj = Instantiate(boxcolider, Vector3.zero, Quaternion.identity);
        obj.SetActive(false);
        newLaser.SetActive(false);
        box = obj.GetComponent<BoxCollider2D>();
        box.enabled = false;
        
    }
   
    // Update is called once per frame
    IEnumerator LaserReasle(float x)
    {
        candestroy = true;
        canSkill = false;
        float time = 0;
        box.enabled = true;
        newLaser.transform.position = new Vector2(x, 614);
        obj.transform.position = new Vector2(newLaser.transform.position.x, 0);
        obj.SetActive(true);
        newLaser.transform.eulerAngles = new Vector3(90, 0, 0);
        newLaser.SetActive(true);
        box.size = new Vector2(100, 2f * Camera.main.orthographicSize);
        while (time < LerpTime)
        {
            float scale = Mathf.Lerp(100, 0,time/LerpTime);
            newLaser.transform.localScale = new Vector3(scale, scale, scale);
            time += Time.deltaTime;
            yield return null;

        }
        box.size = Vector2.zero;
        box.enabled = false;    
        newLaser.SetActive(false);
        canSkill = true;
        candestroy = false;
    }
    public bool cankill()
    {
        return candestroy;
    }
    public void Skill(float x)
    {
        if (canSkill ) {
            StartCoroutine(LaserReasle(x));

        }
    }

    private void Update()
    {
        print(this.gameObject.tag+" "+box.size.x + "   " + box.size.y); 

    }

   
    
}
