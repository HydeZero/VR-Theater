//-----------------------------------------------------------------------
// <copyright file="CardboardStartup.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

// NOTICE OF CHANGES
// I have made changes to this file that I am required to disclose to follow Apache terms. The changes are:
//   1. Added a reference to the VRManager script
//   2. Changed the Api.IsCloseButtonPressed if statement to run vrManager.StopXR() followed by switching the scene back to the title instead of Application.Quit() to exit the scene instead of closing the application.
//   3. Added a using statement for scene management.

using Google.XR.Cardboard;
using UnityEngine;
// NEW CODE BEGINS HERE
using UnityEngine.SceneManagement;
// NEW CODE ENDS HERE

/// <summary>
/// Initializes Cardboard XR Plugin.
/// </summary>
public class CardboardStartup : MonoBehaviour
{

    public VRManager vrManager;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        // NEW CODE BEGINS HERE
        vrManager = GameObject.Find("VRManager").GetComponent<VRManager>();
        // NEW CODE ENDS HERE

        // Configures the app to not shut down the screen and sets the brightness to maximum.
        // Brightness control is expected to work only in iOS, see:
        // https://docs.unity3d.com/ScriptReference/Screen-brightness.html.
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;

        // Checks if the device parameters are stored and scans them if not.
        if (!Api.HasDeviceParams())
        {
            Api.ScanDeviceParams();
        }
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        if (Api.IsGearButtonPressed)
        {
            Api.ScanDeviceParams();
        }

        if (Api.IsCloseButtonPressed) // This statement was modified; see changes at beginning of file.
        {
            vrManager.StopXR();
            SceneManager.LoadScene("Title");
        }

        if (Api.IsTriggerHeldPressed)
        {
            Api.Recenter();
        }

        if (Api.HasNewDeviceParams())
        {
            Api.ReloadDeviceParams();
        }

        Api.UpdateScreenParams();
    }
}
