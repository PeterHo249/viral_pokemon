using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public LevelHandler levelHandler;
    // Start is called before the first frame update
    void Start()
    {
        levelHandler = FindObjectOfType<LevelHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonTapped(int level)
    {
        if (level > levelHandler.level)
        {
            print("You can't play this level");
        }
        else
        {
            print(level);
        }
    }

    public void OnMenuTapped(string menu)
    {
        print(menu);
    }

    public void OnBackTapped(string scene)
    {
        print(scene);
    }
} 
