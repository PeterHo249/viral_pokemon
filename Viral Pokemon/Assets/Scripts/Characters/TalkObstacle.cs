using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TalkObstacle : MonoBehaviour
{
    public Text TalkText;
    public GameObject Dialog;
    public LevelManager levelManager;

    public bool isCollise;

    public int number;

    public string talk = "Press Space to talk";
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        isCollise = true;
        GameObject.Find("obstacle1").GetComponent<BoxCollider2D>().isTrigger = true;
        GameObject.Find("obstacle2").GetComponent<BoxCollider2D>().isTrigger = true;
        GameObject.Find("obstacle3").GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isCollise == true)
        {
            if (levelManager.state == true)
            {
                levelManager.state = false;
            }
            else
            {
                levelManager.state = true;
            }
            if (levelManager.state)
            {
                //ShowElement();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("BattleScene");
                }
            }
            else
            {
                //HideElement();
            }

        }
    }

    //public void ShowElement()
    //{
    //    Dialog.SetActive(true);
    //    TalkText.text = "Let's battle";
    //}

    //public void HideElement()
    //{
    //    Dialog.SetActive(false);
    //    TalkText.text = "";
    //}

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
