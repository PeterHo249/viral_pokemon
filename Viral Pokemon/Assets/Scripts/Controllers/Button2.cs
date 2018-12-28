using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button2 : MonoBehaviour
{

    public Button button2;
    public BattleManager battleManager;

    public void handleClick()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        button2 = GameObject.Find("Button2").GetComponent<Button>();
        battleManager = FindObjectOfType<BattleManager>();
        button2.onClick.AddListener(handleClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
