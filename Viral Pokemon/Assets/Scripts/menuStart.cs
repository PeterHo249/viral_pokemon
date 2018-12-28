using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuStart : MonoBehaviour
{
    public void changeMenuScenne(string SceneName)
    {
        Application.LoadLevel(SceneName);
    }
}
