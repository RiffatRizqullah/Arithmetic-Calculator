using DG.Tweening;
using UnityEngine;

public class Mode : MonoBehaviour
{
    public  GameObject[] Modes;
    public int currentMode;
    public int Height;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Height = Kalkulator.Instance.height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateMode(int input)
    {
        if (currentMode != input)
        {
            currentMode = input;
            Kalkulator.Instance.DisablePenjelasan();
        }

        foreach(GameObject obj in Modes)
        {
            obj.SetActive(false);
            
        }
        switch (currentMode)
        {
            case 0:
                Modes[currentMode].GetComponent<Mode1>().CleanUp();
                break;

            case 1:
                Modes[currentMode].GetComponent<Mode2>().CleanUp();
                break;
            case 2:
                Modes[currentMode].GetComponent<Mode3>().CleanUp();
                break;
            case 3:
                //Modes[currentMode].GetComponent<Mode4>().CleanUp();
                break;
        }
        Kalkulator.Instance.ErrorLabel.text = "";
        if (input == 2 && Kalkulator.Instance.height != 540)
        {
            Height = 540;
            DOVirtual.Int(Kalkulator.Instance.height, 540, .4f, v =>
            {
                Kalkulator.Instance.height = v;
            }).SetEase(Ease.OutCubic);
        }
        else if (input == 0 && Kalkulator.Instance.height != 480)
        {
            Height = 480;
            DOVirtual.Int(Kalkulator.Instance.height, 480, .4f, v =>
            {
                Kalkulator.Instance.height = v;
            }).SetEase(Ease.OutCubic);
        }
        else if(input == 1 && Kalkulator.Instance.height != 520)
        {
            Height = 520;
            DOVirtual.Int(Kalkulator.Instance.height, 520, .4f, v =>
            {
                Kalkulator.Instance.height = v;
            }).SetEase(Ease.OutCubic);
        }
        else
        {
            Height = Kalkulator.Instance.height;
        }

            Modes[input].SetActive(true);
    }
}
