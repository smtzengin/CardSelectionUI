using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    public ScriptableObject race;   // Irkların görüntülerini tutacak dizi
    public Image[] classImages;  // Sınıfların görüntülerini tutacak dizi
    public Image raceImg;
    public Button raceBackButton;    // Irk geri butonu
    public Button raceNextButton;    // Irk ileri butonu
    public Button classBackButton;   // Sınıf geri butonu
    public Button classNextButton;   // Sınıf ileri butonu
    public Text raceText;
    public Text classText;


    private int selectedRaceIndex;  // Seçilen ırkın dizideki indeksi
    private int selectedClassIndex; // Seçilen sınıfın dizideki indeksi

    private void Start()
    {
        // Başlangıçta ilk ırk ve sınıf seçili olarak kabul edelim
        selectedRaceIndex = 0;
        selectedClassIndex = 0;

        // İlk ırk ve sınıfın görüntülerini ayarlayalım
        //UpdateRaceImage();
        UpdateClassImage();

        // Irk geri ve ileri butonlarının tıklama olaylarını tanımlayalım
        raceBackButton.onClick.AddListener(SelectPreviousRace);
        raceNextButton.onClick.AddListener(SelectNextRace);

        // Sınıf geri ve ileri butonlarının tıklama olaylarını tanımlayalım
        classBackButton.onClick.AddListener(SelectPreviousClass);
        classNextButton.onClick.AddListener(SelectNextClass);
    }

    // Bir önceki ırka geçmek için kullanılan metot
    public void SelectPreviousRace()
    {
         selectedRaceIndex--;
         selectedClassIndex = 0;  // Bir önceki ırka geçtiğimizde sınıfı sıfırlayalım
         UpdateRaceImage(selectedRaceIndex);
         UpdateClassImage();
        
    }

    // Bir sonraki ırka geçmek için kullanılan metot
    public void SelectNextRace()
    {
         selectedRaceIndex++;
         selectedClassIndex = 0;  // Bir sonraki ırka geçtiğimizde sınıfı sıfırlayalım
         UpdateRaceImage(selectedRaceIndex);
         UpdateClassImage();
    }

    // Bir önceki sınıfa geçmek için kullanılan metot
    public void SelectPreviousClass()
    {
        if (selectedClassIndex > 0)
        {
            selectedClassIndex--;
            UpdateClassImage();
        }
    }

    // Bir sonraki sınıfa geçmek için kullanılan metot
    public void SelectNextClass()
    {
        if (selectedClassIndex < classImages.Length - 1)
        {
            selectedClassIndex++;
            UpdateClassImage();
        }
    }

    // Seçilen ırkın görüntüsünü güncelleyen yardımcı metot
    private void UpdateRaceImage(int raceIndex)
    {
        //raceImg.sprite = race.;
        
        
    }

    // Seçilen sınıfın görüntüsünü güncelleyen yardımcı metot
    private void UpdateClassImage()
    {
        for (int i = 0; i < classImages.Length; i++)
        {
            bool shouldShow = (i / 2) == selectedRaceIndex;  // Sadece seçilen ırka ait sınıfları gösterelim
            classImages[i].gameObject.SetActive(shouldShow && (i % 2 == selectedClassIndex));
        }
    }

   
}
