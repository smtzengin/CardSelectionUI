using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CardCreation : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI raceTextCW;
    [SerializeField] private TextMeshProUGUI classTextCW;
    [SerializeField] private TextMeshProUGUI healthTextCW;
    [SerializeField] private TextMeshProUGUI damageTextCW;
    [SerializeField] private Image raceImg;
    [SerializeField] int classIndex;
    [SerializeField] TMP_Dropdown raceIndexDD;

    private void Awake()
    {
        RaceDropDown(0);
    }

    public void RaceDropDown(int raceIndex)
    {
        raceIndex = raceIndexDD.value;
        raceTextCW.text = raceIndex switch
        {
            0 => GameController.instance.races[0].ToString(),
            1 => GameController.instance.races[1].ToString(),
            2 => GameController.instance.races[2].ToString(),
            3 => GameController.instance.races[3].ToString(),
            4 => GameController.instance.races[4].ToString(),
            5 => GameController.instance.races[5].ToString(),
            _ => "Default",
        };
        raceImg.sprite = raceIndex switch
        {
            0 => GameController.instance.racesImg[0],
            1 => GameController.instance.racesImg[1],
            2 => GameController.instance.racesImg[2],
            3 => GameController.instance.racesImg[3],
            4 => GameController.instance.racesImg[4],
            5 => GameController.instance.racesImg[5],
        };
    }

    
}
