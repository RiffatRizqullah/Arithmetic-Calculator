using DG.Tweening;
using System.Security.Cryptography;
using UnityEngine;
using System.Collections;
using TMPro;
public class Kalkulator : MonoBehaviour
{
    public static Kalkulator Instance { get; private set; }
    public bool lockpos;
    public int width = 0;
    public int height = 0;
    public int PosX;
    public int PosY;
    [SerializeField] Mode ModeSelector;

    [SerializeField] RectTransform canvas;
    [SerializeField] WindowScript window;
    [SerializeField] CanvasGroup MainGroup;
    public SetPenjelasan Setpenjelasan;
    public GameObject PenjelasanButton;
    public TextMeshProUGUI ErrorLabel;
    public int mode;
    public double a;
    public double b;
    public double n;

    public double Un1;
    public double Un2;
    public double n1;
    public double n2;
    public int result;

    [SerializeField] GameObject Teacher;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    private void OnApplicationQuit()
    {
        DOTween.Clear();
        width = 0;
        height = 0;
        Screen.SetResolution(0, 0, false);
    }
    public void Calculate()
    {
        switch (ModeSelector.currentMode)
        {
            case 0:
                ModeSelector.Modes[0].GetComponent<Mode1>().Calculate();
                break;
            case 1:
                ModeSelector.Modes[1].GetComponent<Mode2>().Calculate();
                break;
            case 2:
                ModeSelector.Modes[2].GetComponent<Mode3>().Calculate();
                break;
            case 3:
                //ModeSelector.Modes[3].GetComponent<Mode1>().Calculate();
                break;
        }
        
    }
    void Awake()
    {
        //if (Application.platform == RuntimePlatform.WindowsPlayer)
        //{
        //    window.OnNoBorderBtnClick();
        //}
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        if(lockpos == false)
        {
            PosX = Screen.mainWindowPosition.x;
            PosY = Screen.mainWindowPosition.y;
        }
        else
        {
            DisplayInfo info = Screen.mainWindowDisplayInfo;
            Screen.MoveMainWindowTo(in info, new Vector2Int(PosX, PosY));
        }
        if (Screen.currentResolution.width != width || Screen.currentResolution.height != height)
        {
            Screen.SetResolution(width, height, Screen.fullScreenMode);
        }
        canvas.rect.size.Set(width, height);
    }

    public void Penjelasan()
    {
        MainGroup.DOFade(0, 1).OnComplete(() =>
        {
            MainGroup.gameObject.SetActive(false);
            MainGroup.alpha = 1;
            MainGroup.blocksRaycasts = true;
            lockpos = true;
            DOVirtual.Vector2(new Vector2(PosX, PosY), new Vector2((Display.main.systemWidth / 2) - (Screen.width / 2), (Display.main.systemHeight / 2) - (Screen.height / 2) - 30), 1.5f, v =>
            {
                PosX = (int)v.x;
                PosY = (int)v.y;
            }).SetEase(Ease.InOutElastic).OnComplete(() =>
            {
                lockpos = false;
                DOVirtual.Float(width, 1024, 1, v =>
                {
                    width = (int)v;
                }).SetEase(Ease.OutBounce);
                DOVirtual.Float(height, 600, 1, v =>
                {
                    height = (int)v;
                }).SetEase(Ease.OutBounce).OnComplete(() =>
                {
                    Teacher.SetActive(true);
                });
            });

        });
    }
    public void ClosePenjelasan()
    {
        lockpos = true;
        DOVirtual.Vector2(new Vector2(PosX, PosY), new Vector2((Display.main.systemWidth / 2) - (Screen.width / 2), (Display.main.systemHeight / 2) - (Screen.height / 2) - 30), 1.5f, v =>
        {
            PosX = (int)v.x;
            PosY = (int)v.y;
        }).SetEase(Ease.InOutCubic).OnComplete(() =>
        {
            lockpos = false;
            DOVirtual.Float(width, 320, 1, v =>
            {
                width = (int)v;
            }).SetEase(Ease.OutBounce);
            DOVirtual.Float(height, ModeSelector.Height, 1, v =>
            {
                height = (int)v;
            }).SetEase(Ease.OutBounce).OnComplete(() =>
            {
                Setpenjelasan.CleanAll();
                Setpenjelasan.gameObject.SetActive(false);
                MainGroup.gameObject.SetActive(true);
            });
        });

    }
    public void DisablePenjelasan()
    {
        if (PenjelasanButton.activeInHierarchy == true)
        {
            IEnumerator w()
            {
                PenjelasanButton.GetComponent<Animator>().Play("DeInit");
                yield return new WaitForSeconds(0.5f);
                PenjelasanButton.SetActive(false);
            }
            StartCoroutine(w());
        }
    }
}
