using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DemoScript : MonoBehaviour {
    public string enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == enemy)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
