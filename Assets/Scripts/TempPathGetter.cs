using TMPro;
using UnityEngine;

public class TempPathGetter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        try
        {
            GetComponent<TextMeshPro>().text = MovieGrabber.Instance.moviePath;
        }
        catch
        {
            print("Error");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
