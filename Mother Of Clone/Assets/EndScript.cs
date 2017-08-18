using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndScript : MonoBehaviour {
    
    public GameObject winner1;
    public GameObject winner2;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject end;
    GameObject test;
    GameObject winner;
    // Use this for initialization
    void Start () {
        
        test = GameObject.FindWithTag("SceneScript");
        //test.GetComponent<ItemPrefab>().enabled = false;
        end.SetActive(false);
    }
    GameObject getwinner()
    {
        if (Player1.activeInHierarchy == true && Player2.activeInHierarchy == false) return Player1;
        if (Player1.activeInHierarchy == false && Player2.activeInHierarchy == true) return Player2;
        return null;
    }
    // Update is called once per frame
    void Update () {
      if(Player1.activeInHierarchy ==false || Player2.activeInHierarchy == false)
        {
            StartCoroutine(endscript());
            test.GetComponent<ItemPrefab>().enabled = false;
        }
	}
IEnumerator endscript()
    {

        yield return new WaitForSeconds(1);
        end.SetActive(true);
        getwinner().transform.position = Vector3.zero;
        getwinner().GetComponent<Game3_PlayerController>().enabled = false;
    }
} 
