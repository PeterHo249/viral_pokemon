using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkObstacle : MonoBehaviour
{
    public Text InputText;
    public Text TalkText;
    public GameObject Dialog;
    public LevelManager levelManager;

    public bool isCollise = false;

    public int number;

    public string talk = "Press Space to talk";
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isCollise == true)
        {
            if (levelManager.state == true)
            {
                levelManager.state = false;
                InputText.text = "";
            }
            else
            {
                levelManager.state = true;
                InputText.text = "";
            }
            if (levelManager.state)
            {
                ShowElement();
            }
            else
            {
                HideElement();
            }

        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject.Find("obstacle1").GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    public void ShowElement()
    {
        Dialog.SetActive(true);
        TalkText.text = "123456789 123456789 123456789 123456789 123456789 123456789 123456789";
        if (number == levelManager.level + 1)
        {
            print("Chuan bi danh");
        }
    }

    public void HideElement()
    {
        Dialog.SetActive(false);
        TalkText.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollise = true;
            InputText.text = (talk);
            GameObject.Find("obstacle1").GetComponent<BoxCollider2D>().isTrigger = false;
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
            isCollise = false;;
            InputText.text = ("");
        }
    }
}
