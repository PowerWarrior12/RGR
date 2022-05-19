using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    OrbitCamera oCamera;
    [SerializeField]
    Character character;
    [SerializeField]
    GameObject button;

    public void StartGame() 
    {
        oCamera.StartGame();
        character.StartGame();
        button.SetActive(false);
    }
}
