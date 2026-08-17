using UnityEngine;
[ExecuteInEditMode]
public class DynamicResolutionHelper : MonoBehaviour
{
    [SerializeField] Kalkulator kalkulator;
    [SerializeField] RectTransform rt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kalkulator != null && rt != null)
        {
            rt.sizeDelta = new Vector2(kalkulator.width, kalkulator.height);
            //rt.localPosition = new Vector2(kalkulator.PosX, kalkulator.PosY);
        }
    }
}
