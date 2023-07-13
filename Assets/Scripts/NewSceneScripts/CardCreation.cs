using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEditor;

public class CardCreation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI raceTextCW;
    [SerializeField] private TextMeshProUGUI classTextCW;
    [SerializeField] private TextMeshProUGUI abilityTextCW;
    [SerializeField] private TextMeshProUGUI healthTextCW;
    [SerializeField] private TextMeshProUGUI damageTextCW;
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private TextMeshProUGUI labelAbility;
    [SerializeField] private Image raceImg;
    [SerializeField] private string[,] classNames = null;
    private List<string> abilityOptions = new List<string>();
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private string savePath = "Assets/Cards/";


    //DropDown objesinin i?erisinde bulunan Dropdown TextMeshPro'ya eri?memizi sa?l?yor. direkt dropdown'?n tamam?n? kapsam?yor!
    [SerializeField] TMP_Dropdown raceIndex_DD;
    [SerializeField] TMP_Dropdown classIndex_DD;
    [SerializeField] TMP_Dropdown abilityIndex_DD;

    //Ability fonksiyonunu degistirmek icin enum kullaniyoruz
    private AbilityEnums ability;

    private void Awake()
    {
        RaceDropDown(0);
        ClassDropDrown(0);
        AbilityDropDown(0);
    }

    public void RaceDropDown(int raceIndex)
    {
        //Irk se?iminin yap?ld??? yer.
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
        //Irk se?imine g?re sprite g?ncelleniyor.
        raceImg.sprite = raceIndex switch
        {
            0 => GameController.instance.racesImg[0],
            1 => GameController.instance.racesImg[1],
            2 => GameController.instance.racesImg[2],
            3 => GameController.instance.racesImg[3],
            4 => GameController.instance.racesImg[4],
            5 => GameController.instance.racesImg[5],
            _ => GameController.instance.racesImg[0],
        };

        
        //Irklar?n indexlerine g?re GameController s?n?f?nda olu?turulan ?zel s?n?f dizilerine eri?memizi sa?l?yor
        //ilk olarak GameController'daki diziyi classNames dizisine aktar?yor ve for d?ng?s? i?erisinde DropDown'da g?ncelleme yap?yor.
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
                classIndex_DD.options[i].text = classNames[0,i].ToString();                
            }
        }
        //alttaki 3 sat?r kod ?rk de?i?ti?inde cardView ?zerindeki label ve text'in de?i?mesini sa?l?yor.
        classIndex_DD.value = 0;
        label.text = classIndex_DD.options[0].text;
        classTextCW.text = classIndex_DD.options[0].text;

    } 
       
    public void ClassDropDrown(int classIndex)
    {
        //S?n?f se?iminin yap?ld??? yer.
        classIndex = classIndex_DD.value;
        classTextCW.text = classIndex switch
        {
            0 => classNames[0,0].ToString(),
            1 => classNames[0,1].ToString(),
            2 => classNames[0,2].ToString(),
            _ => "Default",
        };


        if (classNames != null && classIndex >= 0 && classIndex < classNames.GetLength(1))
        {
            classTextCW.text = classNames[0, classIndex].ToString();

            abilityOptions.Clear();
            for (int i = 1; i < classNames.GetLength(0); i++)
            {
                abilityOptions.Add(classNames[i, classIndex]);
            }

            abilityIndex_DD.ClearOptions();
            abilityIndex_DD.AddOptions(abilityOptions);

            labelAbility.text = abilityIndex_DD.options[0].text;
        }


    }

    public void AbilityDropDown(int abilityIndex)
    {
        
        abilityIndex = abilityIndex_DD.value;
        abilityTextCW.text = abilityIndex switch
        {
            0 => abilityOptions[0],
            1 => abilityOptions[1],
            2 => abilityOptions[2],
            _ => "Default",
        };
    }

    public AbilityEnums ConnectAbilityIndexAndEnum(int raceIndex, int classIndex, int abilityIndex)
    {

        switch (raceIndex, classIndex, abilityIndex)
        {
            case (0, 0, 0):
                ability = AbilityEnums.Damage;
                break;
            case (0, 0, 1):
                ability = AbilityEnums.Heal;
                break;
            case (0, 0, 2):
                ability = AbilityEnums.Damage;
                break;
            case (0, 1, 0):
                ability = AbilityEnums.Heal;
                break;
            case (0, 1, 1):
                ability = AbilityEnums.Damage;
                break;
            case (0, 1, 2):
                ability = AbilityEnums.Heal;
                break;
            default:
                break;
        }
        return ability;
    }


    public void CreateCardAndSavePrefab()
    {
        // Kart? olu?tur
        CardCreationSO card = ScriptableObject.CreateInstance<CardCreationSO>();

        // Kart ?zelliklerini ayarla
        card.raceName = raceTextCW.text;
        card.raceImg = raceImg.sprite;
        card.className = classTextCW.text;
        card.abilityName = abilityTextCW.text;
        card.ability = ConnectAbilityIndexAndEnum(raceIndex_DD.value, classIndex_DD.value, abilityIndex_DD.value);

        // Scriptable object'i proje dosyas?na kaydet
        string fileName = card.raceName + "_" + card.className + ".asset";
        string assetPath = savePath + fileName;
        AssetDatabase.CreateAsset(card, assetPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("CardCreationSO olu?turuldu ve kaydedildi: " + assetPath);

        cardPrefab.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = card.raceName;
        cardPrefab.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = card.className;
        cardPrefab.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = card.abilityName;
        cardPrefab.transform.GetChild(5).GetComponent<Image>().sprite = card.raceImg;

        // Kart? prefab olarak kaydet
        GameObject prefabCopy = Instantiate(cardPrefab);
        string prefabPath = savePath + card.raceName + "_" + card.className + ".prefab";
        GameObject prefab = PrefabUtility.SaveAsPrefabAsset(prefabCopy, prefabPath);

        Debug.Log("Prefab kaydedildi: " + prefabPath);
    }



}
