using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PenjelasanMode3V1 : MonoBehaviour
{
    public int IterationIndex;
    public string[] texts;
    double Un1;
    double Un2;
    double n1;
    double n2;

    [SerializeField]int KalkulasiIndex;
    [SerializeField] TextMeshProUGUI Persamaan1Diket;
    [SerializeField] TextMeshProUGUI Persamaan2Diket;

    [SerializeField] TextMeshProUGUI P1Suku;
    [SerializeField] TextMeshProUGUI P1SukuUpdate;
    [SerializeField] TextMeshProUGUI P1Nilai;

    [SerializeField] TextMeshProUGUI P2Suku;
    [SerializeField] TextMeshProUGUI P2SukuUpdate;
    [SerializeField] TextMeshProUGUI P2Nilai;

    [SerializeField] TextMeshProUGUI P3Suku;
    [SerializeField] TextMeshProUGUI P3SukuUpdate;
    [SerializeField] TextMeshProUGUI P3Nilai;
    [SerializeField] TextMeshProUGUI P3NilaiUpdate;

    [SerializeField] CaraAttemptMode1[] caracara;
    [SerializeField] TextMeshProUGUI Iteration;

    public int CaraIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        Un1 = Kalkulator.Instance.Un1;
        Un2 = Kalkulator.Instance.Un2;
        n1 = Kalkulator.Instance.n1;
        n2 = Kalkulator.Instance.n2;

        texts[1] = $"Setiap n dikurangi 1";
        texts[2] = $"Kedua persamaan dikurangkan";
        texts[3] = $"{n1} dikurangi {n2} = {n1 - n2}";
        texts[4] = $"{Un1} dikurangi {Un2} = {Un1 - Un2}";
        texts[5] = $"Untuk mencari nilai b, maka dibagi {n1 - n2}";
        texts[6] = $"Jadi, jawabannya adalah {(Un1 - Un2) / (n1 - n2)}";
        Persamaan1Diket.text = $"U{n1} = {Un1}";
        Persamaan2Diket.text = $"U{n2} = {Un2}";

        Iteration.text = texts[IterationIndex];
        IterationIndex++;

    }
    public void ChangeKalkulasiIndex()
    {
        switch (KalkulasiIndex)
        {
            case 0:
                P1Suku.text = $"U{n1}";
                P2Suku.text = $"U{n2}";

                P1Nilai.text = Un1.ToString();
                P2Nilai.text = Un2.ToString();
                break;
            case 1:
                P1SukuUpdate.text = $"a + (n - 1)b";
                P2SukuUpdate.text = $"a + (n - 1)b";
                break;
            case 2:
                P1Suku.text = $"a + ({n1} - 1)b";
                P2Suku.text = $"a + ({n2} - 1)b";
                break;
            case 3:
                P1SukuUpdate.text = $"a + ({n1 - 1})b";
                P2SukuUpdate.text = $"a + ({n2 - 1})b";
                break;
            case 4:
                P3Suku.text = $"{(n1 - n2)}b";
                P3Nilai.text = (Un1 - Un2).ToString();
                break;
            case 5:
                P3SukuUpdate.text = $"b";
                P3NilaiUpdate.text = ((Un1 - Un2) / (n1 - n2)).ToString();
                break;

        }
        KalkulasiIndex++;
    }
    public void ChangeIterationText()
    {
        Iteration.text = texts[IterationIndex];
        IterationIndex++;
    }

    public void ChangeIterationText(int iteration)
    {
        Iteration.text = texts[iteration];
        IterationIndex++;
        
    }

    public void CleanUp()
    {
        IterationIndex = 0;
        KalkulasiIndex = 0;
    }
    public void Close()
    {
        Kalkulator.Instance.ClosePenjelasan();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
