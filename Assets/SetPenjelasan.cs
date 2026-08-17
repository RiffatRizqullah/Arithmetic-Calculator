using UnityEngine;

public class SetPenjelasan : MonoBehaviour
{
    [SerializeField] GameObject[] Timelines;
    public int State;
    private void OnEnable()
    {
        Timelines[State].SetActive(true);
    }
    public void CleanAll()
    {
        foreach (GameObject go in Timelines)
        {
            go.SetActive(false);
        }
    }
}
