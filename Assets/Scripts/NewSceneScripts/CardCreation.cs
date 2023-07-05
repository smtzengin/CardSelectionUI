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
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private Image raceImg;
    [SerializeField] private string[] classNames = null;

    //DropDown objesinin içerisinde bulunan Dropdown TextMeshPro'ya eriþmemizi saðlýyor. direkt dropdown'ýn tamamýný kapsamýyor!
    [SerializeField] TMP_Dropdown raceIndex_DD;
    [SerializeField] TMP_Dropdown classIndex_DD;

    private void Awake()
    {
        RaceDropDown(0);
        ClassDropDrown(0);
    }

    public void RaceDropDown(int raceIndex)
    {
        //Irk seçiminin yapýldýðý yer.
        raceIndex = raceIndex_DD.value;
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
        //Irk seçimine göre sprite güncelleniyor.
        raceImg.sprite = raceIndex switch
        {
            0 => GameController.instance.racesImg[0],
            1 => GameController.instance.racesImg[1],
            2 => GameController.instance.racesImg[2],
            3 => GameController.instance.racesImg[3],
            4 => GameController.instance.racesImg[4],
            5 => GameController.instance.racesImg[5],
        };

        
        //Irklarýn indexlerine göre GameController sýnýfýnda oluþturulan özel sýnýf dizilerine eriþmemizi saðlýyor
        //ilk olarak GameController'daki diziyi classNames dizisine aktarýyor ve for döngüsü içerisinde DropDown'da güncelleme yapýyor.
        switch (raceIndex)
        {
            case 0:
                classNames = GameController.instance.class0_1;
                break;
            case 1:
                classNames = GameController.instance.class1_1;
                break;
            case 2:
                classNames = GameController.instance.class2_1;
                break;
            case 3:
                classNames = GameController.instance.class3_1;
                break;
            case 4:
                classNames = GameController.instance.class4_1;
                break;
            case 5:
                classNames = GameController.instance.class5_1;
                break;
            default:
                break;
        }

        if (classNames != null)
        {
            for (int i = 0; i < 3; i++)
            {
                classIndex_DD.options[i].text = classNames[i].ToString();                
            }
        }
        //alttaki 3 satýr kod ýrk deðiþtiðinde cardView üzerindeki label ve text'in deðiþmesini saðlýyor.
        classIndex_DD.value = 0;
        label.text = classIndex_DD.options[0].text;
        classTextCW.text = classIndex_DD.options[0].text;

    } 
       
    public void ClassDropDrown(int classIndex)
    {
        //Sýnýf seçiminin yapýldýðý yer.
        classIndex = classIndex_DD.value;
        classTextCW.text = classIndex switch
        {
            0 => classNames[0].ToString(),
            1 => classNames[1].ToString(),
            2 => classNames[2].ToString(),
            _ => "Default",
        };
    }

    

}
