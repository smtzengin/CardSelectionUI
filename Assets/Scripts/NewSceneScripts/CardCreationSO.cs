using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RacesScriptableObject", menuName = "ScriptableObjects/CreateCard")]
public class CardCreationSO : ScriptableObject
{
    public string raceName;
    public Sprite raceImg;
    public string className;
    public string abilityName;

}
