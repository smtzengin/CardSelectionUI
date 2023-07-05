using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    [SerializeField] public string[] races;
    [SerializeField] public Sprite[] racesImg;
    [SerializeField] public string[] class1_1 = { "UndeadClass1", "UndeadClass2", "UndeadClass3" };
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }
    public void SetClass()
    {

    }
}
