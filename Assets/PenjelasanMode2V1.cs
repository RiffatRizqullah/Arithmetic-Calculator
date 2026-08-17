using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PenjelasanMode2V1 : MonoBehaviour
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

        texts[1] = $"{n} dibagi 2 = {n / 2}";
        texts[2] = $"{a} dikali 2 = {a * 2}";
        texts[3] = $"{n} dikurangi 1 = {n - 1}";
        texts[4] = $"{n -1} dikali {b} = {(n - 1) * b}";
        texts[5] = $"{a * 2} ditambah {(n-1) * b} = {(a * 2) + ((n - 1) * b)}";
        texts[6] = $"{n / 2} dikali {(a * 2) + ((n - 1) * b)} = {(n / 2) * ((a * 2) + ((n - 1) * b))}";
        texts[7] = $"Jadi, jawabannya adalah {(n / 2) * ((a * 2) + ((n - 1) * b))}";
        aDiket.text = $"a = {a}";
        bDiket.text = $"b = {b}";
        nDiket.text = $"Jumlah {n} suku pertama";
        nDiketSimplified.text = $"S{n}";

        caracara[0].Suku.text = $"S{n}";
        caracara[0].Nilai.text = $"{n}/2 x (2({a}) + ({n} - 1){b})";

        caracara[1].Suku.text = $"S{n}";
        caracara[1].Nilai.text = $"{n / 2} x ({a * 2} + ({n} - 1){b})";

        caracara[2].Suku.text = $"S{n}";
        caracara[2].Nilai.text = $"{n/2} x ({a * 2} + ({n - 1}){b})";

        caracara[3].Suku.text = $"S{n}";
        caracara[3].Nilai.text = $"{n / 2} x ({a * 2} + {(n - 1) * b})";

        caracara[4].Suku.text = $"S{n}";
        caracara[4].Nilai.text = $"{n / 2} x ({(a * 2) + ((n - 1) * b)})";

        caracara[5].Suku.text = $"S{n}";
        caracara[5].Nilai.text = $"{(n / 2) * ((2 * a) + ((n - 1) * b))}";

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
