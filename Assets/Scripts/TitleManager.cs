using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject credits;

    public void ShowCredits()
    {
        credits.SetActive(true);
    }

    public void HideCredits()
    {
        credits.SetActive(false);
    }
}
