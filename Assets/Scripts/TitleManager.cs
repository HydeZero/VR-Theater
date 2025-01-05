using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject credits;

    public GameObject HelpMenu;

    public void ShowCredits()
    {
        credits.SetActive(true);
    }

    public void HideCredits()
    {
        credits.SetActive(false);
    }

    public void ShowHelp()
    {
        HelpMenu.SetActive(true);
    }

    public void HideHelp()
    {
        HelpMenu.SetActive(false);
    }
}
