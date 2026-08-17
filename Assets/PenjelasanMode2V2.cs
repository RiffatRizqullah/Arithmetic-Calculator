using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PenjelasanMode2V2 : MonoBehaviour
{
    public int IterationIndex;
    public string[] texts;
    double a;
    double b;
    double n;

    [SerializeField] TextMeshProUGUI aDiket;
    [SerializeField] TextMeshProUGUI bDiket;
    [SerializeField] TextMeshProUGUI nDiket;
    [SerializeField] TextMeshProUGUI nDiketSimplified;

    [SerializeField] TextMeshProUGUI RumusKlarifikasi;
    [SerializeField] TextMeshProUGUI Iteration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        a = Kalkulator.Instance.a;
        b = Kalkulator.Instance.b;
        n = Kalkulator.Instance.n;

        aDiket.text = $"a = {a}";
        bDiket.text = $"b = {b}";
        nDiket.text = $"Jumlah {n} suku pertama";
        nDiketSimplified.text = $"S{n}";

        RumusKlarifikasi.text = $"S1 = {a}";
        
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
