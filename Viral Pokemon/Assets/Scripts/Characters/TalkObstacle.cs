using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TalkObstacle : MonoBehaviour
{

    public bool isCollise;

    public int number;


    public static List<Pokemon> fetch = new List<Pokemon>();

    // Start is called before the first frame update
    void Start()
    {
        isCollise = true;
        GameObject.Find("obstacle1").GetComponent<BoxCollider2D>().isTrigger = true;
        GameObject.Find("obstacle2").GetComponent<BoxCollider2D>().isTrigger = true;
        GameObject.Find("obstacle3").GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isCollise == true)
        {            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fetch = LevelManager.dataLevel[(LevelHandler.level - 1) * 3 + LevelManager.level];
                SceneManager.LoadScene("BattleScene");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollise = true;
            Debug.Log(LevelManager.level + 1);
            
            if (LevelManager.level + 1 == 1)
            {
                GameObject.Find("obstacle1").GetComponent<BoxCollider2D>().isTrigger = false;
            }
            if (LevelManager.level + 1 == 2)
            {
                GameObject.Find("obstacle2").GetComponent<BoxCollider2D>().isTrigger = false;
            }
            if (LevelManager.level + 1 == 3)
            {
                GameObject.Find("obstacle3").GetComponent<BoxCollider2D>().isTrigger = false;
            }
           
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollise = false;
        }
    }
}
