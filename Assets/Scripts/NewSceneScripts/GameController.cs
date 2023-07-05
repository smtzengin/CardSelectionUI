using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    [SerializeField] public string[] races;
    [SerializeField] public Sprite[] racesImg;
    [SerializeField] public string[] class0_1 = { "UndeadClass1", "UndeadClass2", "UndeadClass3" };
    [SerializeField] public string[] class1_1 = { "GolemClass1", "GolemClass2", "GolemClass3" };
    [SerializeField] public string[] class2_1 = { "CosmicClass1", "CosmicClass2", "CosmicClass3" };
    [SerializeField] public string[] class3_1 = { "ElvenClass1", "ElvenClass2", "ElvenClass3" };
    [SerializeField] public string[] class4_1 = { "BeastClass1", "BeastClass2", "BeastClass3" };
    [SerializeField] public string[] class5_1 = { "BöcekClass1", "BöcekClass2", "BöcekClass3" };
    private void Awake()
    {
        instance = this;
    }

 
   
}
