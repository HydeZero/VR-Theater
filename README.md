# VR Theater

VR Theater is an app that allows you to view your movies in a virtual theater. It uses Google Cardboard to display a virtual theater in VR.

You can connect a left JoyCon to your android phone and move around in the theater. It uses the Unity Input System, so other controllers might work.

Use [this website](https://wwgc.firebaseapp.com/) to make a cardboard calibration profile, if needed. The QR code system doesn't work, so copy the save/load URI (click "Save And Load Viewer Preferences to get the URI) and use something like [QR Code Generator](https://www.qr-code-generator.com/) to make a QR code of it.

## Technical Details
* **Engine Version**: 6000.0.32f1 (Unity 6)
* **Cardboard SDK Version**: 1.27.0 (installed via git, [https://github.com/googlevr/cardboard-xr-plugin.git](https://github.com/googlevr/cardboard-xr-plugin.git))

This used the sample scene in Google Cardboard to give myself a starting point. I modified `CardboardStartup.cs`, which was originally made by Google. I am required to disclose changes. Changes will be located in the `LIBRARIES.md` file.
