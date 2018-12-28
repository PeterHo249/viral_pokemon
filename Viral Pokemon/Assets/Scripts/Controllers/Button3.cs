using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button3 : MonoBehaviour
{

    public Button button3;
    public BattleManager battleManager;

    public void handleClick()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        button3 = GameObject.Find("Button3").GetComponent<Button>();
        battleManager = FindObjectOfType<BattleManager>();
        button3.onClick.AddListener(handleClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
