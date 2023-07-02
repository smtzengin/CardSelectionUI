using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    public RacesSO[] races;  // Irkların tutulduğu ScriptableObject dizisi
    public Sprite[] classSprites;  // Sınıfların tutulduğu ScriptableObject dizisi
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
        UpdateRace(selectedRaceIndex);
        UpdateClass();

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
        if (selectedRaceIndex < 0)
            selectedRaceIndex = races.Length - 1;

        selectedClassIndex = 0;  // Bir önceki ırka geçtiğimizde sınıfı sıfırlayalım
        UpdateRace(selectedRaceIndex);
        UpdateClass();
    }

    // Bir sonraki ırka geçmek için kullanılan metot
    public void SelectNextRace()
    {
        selectedRaceIndex++;
        if (selectedRaceIndex >= races.Length)
            selectedRaceIndex = 0;

        selectedClassIndex = 0;  // Bir sonraki ırka geçtiğimizde sınıfı sıfırlayalım
        UpdateRace(selectedRaceIndex);
        UpdateClass();
    }

    // Bir önceki sınıfa geçmek için kullanılan metot
    public void SelectPreviousClass()
    {
        if (selectedClassIndex > 0)
        {
            selectedClassIndex--;
            UpdateClass();
        }
    }

    // Bir sonraki sınıfa geçmek için kullanılan metot
    public void SelectNextClass()
    {
        if (selectedClassIndex < classImages.Length - 1)
        {
            selectedClassIndex++;
            UpdateClass();
        }
    }

    // Seçilen ırkın görüntüsünü güncelleyen yardımcı metot
    private void UpdateRace(int raceIndex)
    {
        if (raceIndex >= 0 && raceIndex < races.Length)
        {
            RacesSO selectedRace = races[raceIndex];
            if (selectedRace != null)
            {
                raceText.text = selectedRace.raceName;
            }
        }
        print(GetRaceImage());
        print(GetRaceName());
    }

    // Seçilen sınıfın görüntüsünü güncelleyen yardımcı metot
    private void UpdateClass()
    {
        for (int i = 0; i < classImages.Length; i++)
        {
            bool shouldShow = (i / 2) == selectedRaceIndex;  // Sadece seçilen ırka ait sınıfları gösterelim
            classImages[i].gameObject.SetActive(shouldShow && (i % 2 == selectedClassIndex));

            if (shouldShow && (i % 2 == selectedClassIndex))
            {
                int classIndex = i / 2;
                classImages[i].sprite = classSprites[classIndex];
                classText.text = "Class " + (classIndex + 1);
            }
        }
    }

    public string GetRaceName()
    {
        return races[selectedRaceIndex].raceName;
    }

    public Sprite GetRaceImage()
    {
        return races[selectedRaceIndex].raceImg;
    }

}