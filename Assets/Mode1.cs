using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Mode1 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Aritmatika;
    [SerializeField] TMP_InputField Result;
    [SerializeField] TMP_InputField[] InputFields;
    private int a;
    private int b;
    private int u;
    private int result;
    private bool amodified;
    private bool bmodified;
    private bool umodified;


    
    public int A
    {
        get
        {
            return a;
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
            return b;
        }
        set
        {
            b = value;
            bmodified = true;
            OnValueChanged ();
        }
    }

    public int U
    {
        get
        {
            return u;
        }
        set
        {
            u = value;
            umodified = true;
            OnValueChanged();
        }
    }
    public void CleanUp()
    {
        SetA("");
        SetB("");
        SetU("");
        foreach (TMP_InputField Input in InputFields)
        {
            Input.text = "";
        }
        result = 0;
        Aritmatika.text = "";
        Result.text = "";

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
    public void SetU(string input)
    {
        ClearResult();
        if (int.TryParse(input, out int result))
        {
            U = result;
        }
        else
        {
            U = 0;
            umodified = false;
        }
    }
    void ClearResult()
    {
        result = 0;
        Result.text = "";
    }
    public void Calculate()
    {
        if(amodified == true && bmodified == true && umodified == true)
        {
            
            result = a + (u - 1) * b;
            Result.text = result.ToString();
            if (Kalkulator.Instance.Setpenjelasan != null)
            {
                if (u != 1)
                {
                    Kalkulator.Instance.Setpenjelasan.State = 0;
                }
                else if (u == 1)
                {
                    Kalkulator.Instance.Setpenjelasan.State = 1;
                }
            }
            Kalkulator.Instance.a = a;
            Kalkulator.Instance.b = b;
            Kalkulator.Instance.n = u;
                Kalkulator.Instance.PenjelasanButton.SetActive(true);
        }
    }
}
