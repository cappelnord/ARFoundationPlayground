## Prerequisites

* This playground and documentation is based on Unity 2020.3 LTS.

### Building/Deploying for/on Android

* Android Build Support Module has to be installed via Unity Hub. When installing then expand the module and also install *Android SDK & NDK Tools* and *OpenJDK*. 
* An [ARCore compatible device](https://developers.google.com/ar/devices) is needed to test things.
* [Developer Options and USB Debugging must be activated for this device.](https://developer.android.com/studio/debug/dev-options)
* Device needs to be connected via USB to the Mac or PC.
* When connecting the device to the Mac or PC make sure to trust this device on your phone.

### Building/Deploying for/on iOS

Building/Deploying for/on iOS can be a bit more tricky, especially if not the most current versions of Xcode, iOS and macOS are used. Otherwise things can work if versions are compatible. But often problems will arise!

* iOS Build Support Module has to be installed via Unity Hub.
* Any device more recent than the iPhone 6s/iPhone SE (First Generation) will work.
* An [Apple Developer ID](https://developer.apple.com/) is needed (a free ID is fine! No need to enrol into the paid Apple Developer Program)
* ...


## Basic Unity Setup
Basic steps on how to setup an ARFoundation scene from scratch.

### Project Setup

* Create a new Unity project using the 3D template.
* Install required packages (Window -> Package Manager)
* * AR Foundation
* * For building for Android: ARCore XR Plugin
* * For building for iOS: ARKit XR Plugin
* In File -> Build Settings switch to your target platform (iOS or Android).
* In your Project Setttings (Edit -> Project Settings) head to XR Plug-in Management. Depending on your target platform/s see that ARCore is activated as a Plug-in Provider in the Android tab and/or ARKit is activated on the iOS tab.

#### When Building for Android:
In the Player Settings in the Android Tab:
* Locate Graphics APIs and remove Vulkan from the list (it should still say OpenGLES3).
* Locate Other Settings -> Minimum API Level and set this to API level 24.

### Scene Setup

* Either start with the SampleScene and remove *Main Camera* or start with an Empty Scene and add a Directional Light.
* Add two objects:
* * GameObject -> XR -> AR Session
* * GameObject -> XR -> AR Session Origin
* Add a cube as a child into the AR Session Origin object object, move it 1 units along the Z-axis and scale it to 0.25 at each axis.

*This scene can also be found under Scenes/MinimalARFoundationScene*

### Building

#### Android

With the phone connected to the Mac/PC File -> Build and Run should do what it promises.

#### iOS

...