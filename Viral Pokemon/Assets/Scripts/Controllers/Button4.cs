using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button4 : MonoBehaviour
{
    public Button button4;
    public BattleManager battleManager;

    public void handleClick()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        button4 = GameObject.Find("Button4").GetComponent<Button>();
        battleManager = FindObjectOfType<BattleManager>();
        button4.onClick.AddListener(handleClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
