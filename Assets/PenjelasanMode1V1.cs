using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PenjelasanMode1V1 : MonoBehaviour
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

    [SerializeField] CaraAttemptMode1[] caracara;
    [SerializeField] TextMeshProUGUI Iteration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        a = Kalkulator.Instance.a;
        b = Kalkulator.Instance.b;
        n = Kalkulator.Instance.n;

        texts[1] = $"{n} dikurangi 1 = {n - 1}";
        texts[2] = $"{n - 1} dikali {b} ={(n - 1) * b}";
        texts[3] = $"{a} ditambah {(n - 1) * b} = {a + ((n - 1) * b)}";
        texts[4] = $"Jadi, jawabannya adalah {a + ((n - 1) * b)}";
        aDiket.text = $"a = {a}";
        bDiket.text = $"b = {b}";

        string uText = "";
        if (n >= 0)
        {
            nDiket.text = $"Suku ke-{n}";
            uText = $"U{n}";
        }
        else if(n < 0)
        {
            nDiket.text = $"Suku ke-({n})";
            uText = $"U({n})";
        }
            nDiketSimplified.text = uText;

        caracara[0].Suku.text = uText;
        caracara[0].Nilai.text = $"{a} + ({n} - 1){b}";

        caracara[1].Suku.text = uText;
        caracara[1].Nilai.text = $"{a} + ({n-1}){b}";

        string hasil1 = "";
        if (((n - 1) * b) >= 0)
        {
            hasil1 = ((n - 1) * b).ToString();
        }
        else if (((n - 1) * b) < 0)
        {
            hasil1 = $"({((n - 1) * b)})";
        }

        caracara[2].Suku.text = uText;
        caracara[2].Nilai.text = $"{a} + {hasil1}";

        caracara[3].Suku.text = uText;
        caracara[3].Nilai.text = $"{a + ((n - 1) * b)}";

        Iteration.text = texts[IterationIndex];
        IterationIndex++;
        
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
