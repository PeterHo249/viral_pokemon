using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public int level;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        if (level != 0)
        {
            if (level > LevelHandler.level)
            {
                button.enabled = false;
                button.image.color = Color.gray;
            }
            else
            {
                button.enabled = true;
                button.image.color = Color.white;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonTapped()
    {
        if (level > LevelHandler.level)
        {
            print("You can't play this level");
        }
        else
        {
            SceneManager.LoadScene("Level");
        }
    }

    public void OnMenuTapped(string menu)
    {
        print(menu);
    }

    public void OnBackTapped(string scene)
    {
        SceneManager.LoadScene(scene);
    }
} 
