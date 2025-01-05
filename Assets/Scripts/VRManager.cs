using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Management;

// See https://discussions.unity.com/t/toggle-between-2d-and-google-cardboard/793625/3 for the source of this code
public class VRManager : MonoBehaviour
{
    void Start() // this starts XR on loading the scene.
    {
        StartCoroutine(StartXR());
    }

    IEnumerator StartXR()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();


        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
        }
        else
        {
            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.activeLoader.Start();
        }
    }

    public void StopXR()
    {
        Debug.Log("Stopping XR...");

        if (XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            XRGeneralSettings.Instance.Manager.activeLoader.Stop();
            XRGeneralSettings.Instance.Manager.activeLoader.Deinitialize();
            Debug.Log("XR stopped completely.");
        }
    }
}