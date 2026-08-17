using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Mode3 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI V1;
    [SerializeField] TextMeshProUGUI V2;
    [SerializeField] TMP_InputField Result;

    [SerializeField] TextMeshProUGUI LabelUaNilai;
    [SerializeField] TextMeshProUGUI LabelUbNilai;
    [SerializeField] TMP_InputField[] InputFields;

    private double ua;
    private double uanilai;
    private double ub;
    private double ubnilai;
    private double result;
    private bool uamodified;
    private bool uanilaimodified;
    private bool ubmodified;
    private bool ubnilaimodified;



    
    public int Ua
    {
        get
        {
            return (int)ua;
        }
        set
        {
            ua = value;
            uamodified = true;
            OnValueChanged();
            
        }
    }
    public int UaNilai 
    {
        get
        {
            return (int)uanilai;
        }
        set
        {
            uanilai = value;
            uanilaimodified = true;
            OnValueChanged ();
        }
    }

    public int Ub
    {
        get
        {
            return (int)ub;
        }
        set
        {
            ub = value;
            ubmodified = true;
            OnValueChanged();

        }
    }
    public int UbNilai
    {
        get
        {
            return (int)ubnilai;
        }
        set
        {
            ubnilai = value;
            ubnilaimodified = true;
            OnValueChanged();
        }
    }


    void OnValueChanged()
    {
        if(uamodified == true && uanilaimodified == true)
        {
            V1.text = $"U{ua} = {uanilai}";
        }
        else if (uamodified == true && uanilaimodified == false)
        {
            V1.text = $"U{ua} = ...";
        }


        if (ubmodified == true && ubnilaimodified == true)
        {
            V2.text = $"U{ub} = {ubnilai}";
        }
        else if (ubmodified == true && ubnilaimodified == false)
        {
            V2.text = $"U{ub} = ...";
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
    public void SetUa(string input)
    {
        ClearResult();
        if (int.TryParse(input, out int result))
        {
            Ua = result;
            LabelUaNilai.text = $"Nilai Dari Suku Ke {Ua}";
        }
        else
        {
            Ua = 0;
            LabelUaNilai.text = $"Nilai Dari Suku Ke ...";
            uamodified = false;
            OnValueChanged();
        }
        
    }
    public void SetUb(string input)
    {
        ClearResult();
        if (int.TryParse(input, out int result))
        {
            Ub = result;
            LabelUbNilai.text = $"Nilai Dari Suku Ke {Ub}";
        }
        else
        {
            Ub = 0; 
            LabelUbNilai.text = $"Nilai Dari Suku Ke ...";
            ubmodified = false;
            OnValueChanged();
        }
    }

    public void SetUaNilai(string input)
    {
        ClearResult();
        if (int.TryParse(input, out int result))
        {
            UaNilai = result;
        }
        else
        {
            UaNilai = 0;
            uanilaimodified = false;
            OnValueChanged();
        }

    }
    public void SetUbNilai(string input)
    {
        ClearResult();
        if (int.TryParse(input, out int result))
        {
            UbNilai = result;
        }
        else
        {
            UbNilai = 0;
            ubnilaimodified = false;
            OnValueChanged();
        }
    }
    void ClearResult()
    {
        result = 0;
        Result.text = "";
        Kalkulator.Instance.ErrorLabel.text = "";
    }
    public void CleanUp()
    {
        SetUa("");
        SetUb("");
        SetUaNilai("");
        SetUbNilai("");
        foreach (TMP_InputField Input in InputFields)
        {
            Input.text = "";
        }
        V1.text = "";
        V2.text = "";
        result = 0;
        Result.text = "";

    }
    public void Calculate()
    {
        if (uamodified == true && ubmodified == true && uanilaimodified == true && ubnilaimodified == true)
        {

                if (ua != ub)
                {
                    double _ua = 0;
                    double _uanilai = 0;
                    double _ub = 0;
                    double _ubnilai = 0;

                    double b = 0;
                    double a = 0;

                    if (ua > ub)
                    {
                        _ua = ua;
                        _uanilai = uanilai;

                        _ub = ub;
                        _ubnilai = ubnilai;
                    }
                    else if (ua < ub)
                    {
                        _ua = ub;
                        _uanilai = ubnilai;

                        _ub = ua;
                        _ubnilai = uanilai;

                    }

                    b = (_uanilai - _ubnilai) / ((_ua - 1) - (_ub - 1));
                    result = b;

                    Result.text = result.ToString("G");

                if (Kalkulator.Instance.Setpenjelasan != null)
                {
                    Kalkulator.Instance.Setpenjelasan.State = 4;
                }
                if (ua > ub)
                {
                    Kalkulator.Instance.Un1 = uanilai;
                    Kalkulator.Instance.Un2 = ubnilai;
                    Kalkulator.Instance.n1 = ua;
                    Kalkulator.Instance.n2 = ub;
                }
                else if (ua < ub)
                {
                    Kalkulator.Instance.Un1 = ubnilai;
                    Kalkulator.Instance.Un2 = uanilai;
                    Kalkulator.Instance.n1 = ub;
                    Kalkulator.Instance.n2 = ua;
                }
                    Kalkulator.Instance.PenjelasanButton.SetActive(true);
                }
                else if (ua == ub)
                {
                    Kalkulator.Instance.ErrorLabel.text = "*kedua suku tidak boleh sama";
                }
            }
        }
    }

