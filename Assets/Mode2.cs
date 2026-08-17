using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Mode2 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Aritmatika;
    [SerializeField] TMP_InputField Result;
    [SerializeField] TMP_InputField[] InputFields;
    private double a;
    private double b;
    private double s;
    private double result;
    private bool amodified;
    private bool bmodified;
    private bool smodified;


    
    public int A
    {
        get
        {
            return (int)a;
        }
        set
        {
            a = value;
            amodified = true;
            OnValueChanged();
            
        }
    }
    public int B 
    {
        get
        {
            return (int)b;
        }
        set
        {
            b = value;
            bmodified = true;
            OnValueChanged ();
        }
    }

    public int S
    {
        get
        {
            return (int)s;
        }
        set
        {
            s = value;
            smodified = true;
            OnValueChanged();
        }
    }


    void OnValueChanged()
    {
        if(amodified == true && bmodified == true)
        {
            Aritmatika.text = $"{a} + {a + b} + {a + b + b} + {a + b + b + b} + ...";
        }
        else if (amodified == true && bmodified == false || b == 0)
        {
            Aritmatika.text = $"{a} + ...";
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetA(string input)
    {
        ClearResult();
        if (int.TryParse(input, out int result))
        {
            A = result;
        }
        else
        {
            A = 0;
            amodified = false;
        }
        
    }
    public void SetB(string input)
    {
        ClearResult();
        if (int.TryParse(input, out int result))
        {
            B = result;
        }
        else
        {
            B = 0;
            bmodified = false;
        }
    }
    public void SetS(string input)
    {
        ClearResult();
        if (int.TryParse(input, out int result))
        {
            S = result;
        }
        else
        {
            S = 0;
            smodified = false;
        }
    }
    void ClearResult()
    {
        result = 0;
        Result.text = "";

    }

    public void CleanUp()
    {
        SetA("");
        SetB("");
        SetS("");
        foreach (TMP_InputField Input in InputFields)
        {
            Input.text = "";
        }
        result = 0;
        Aritmatika.text = "";
        Result.text = "";

    }
    public void Calculate()
    {
        if(amodified == true && bmodified == true && smodified == true)
        {
            if (s >= 0)
            {
                result = s / 2 * (2 * a + (s - 1) * b);
                print(result + " " + s / 2);
                Result.text = result.ToString();
                if (Kalkulator.Instance.Setpenjelasan != null)
                {
                    if (s != 1)
                    {
                        Kalkulator.Instance.Setpenjelasan.State = 2;
                    }
                    else if (s == 1)
                    {
                        Kalkulator.Instance.Setpenjelasan.State = 3;
                    }
                }

                Kalkulator.Instance.a = a;
                Kalkulator.Instance.b = b;
                Kalkulator.Instance.n = s;
                Kalkulator.Instance.PenjelasanButton.SetActive(true);
            }
            else if(s < 0)
            {
                Kalkulator.Instance.ErrorLabel.text = "*n tidak boleh negatif";
            }
        }
    }
}
