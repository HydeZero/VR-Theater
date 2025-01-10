# VR Theater

VR Theater is an app that allows you to view your movies in a virtual theater. It uses Google Cardboard to display a virtual theater in VR.

### CURRENTLY IN BETA, NOT POLISHED AND DONE BUT WORKS

You can connect a left JoyCon to your android phone and move around in the theater. It uses the Unity Input System, so other controllers might work.

Use [this website](https://wwgc.firebaseapp.com/) to make a cardboard calibration profile, if needed. The QR code system doesn't work, so copy the save/load URI (click "Save And Load Viewer Preferences to get the URI) and use something like [QR Code Generator](https://www.qr-code-generator.com/) to make a QR code of it.

## CONTRIBUTING
Make a fork of the "Development" branch and develop with it, pulling changes if necessary. When done, open a pull request.

## Technical Details
* **Engine Version**: 6000.0.32f1 (Unity 6)
* **Cardboard SDK Version**: 1.27.0 (installed via git, [https://github.com/googlevr/cardboard-xr-plugin.git](https://github.com/googlevr/cardboard-xr-plugin.git))

This used the sample scene in Google Cardboard to give myself a starting point. I modified `CardboardStartup.cs`, which was originally made by Google. I am required to disclose changes. Changes will be located in the `LIBRARIES.md` file.

## Compilation Instructions
Due to the nature of Unity Projects, the build settings should be there. Just `git clone` and open it up. Use the "main" branch to guarantee compilation, and "Development" if you want every latest feature.

You should just be able to click "Build And Run" in the android build profile with your phone connected and be able to compile, provided there aren't any compilation errors. Sign with a debug key. Compilations that are signed and suitable for release will be uploaded to the Releases page.
