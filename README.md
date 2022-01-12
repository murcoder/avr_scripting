# Unity3D VR - Scripting
Unity3D C# scripting lecture by FH. St Pölten 

## Exercise Part 1: C# and Coroutines
![screenshot](Assets/Screenshots/exercise1.jpg)
### Aim
Use fields, references, public, private, lists, instantiate,
frame update times

### Goal
*[x] Instantiate a total of x game objects (e.g., cubes)

*[x] x is configurable in the Unity editor

*[x] Create a new cube prefab instance after a random amount of time passed. Apply a random color.
You can store a target time in a variable and check if it’s reached in Update() (or use Invoke() )

*[x] Fade the game object in by modifying its alpha with a coroutine.
Make sure you use a material / shader that supports transparency. Choose one of the two variants:

  * Use yield return new WaitForSeconds(.05f)
  * Use Time.deltaTime & yield return null for a smooth fade in that updates every frame

### Solution
Added a Fader script with a variable duation to the cube. The script _WorldManagement.cs_ in the EventSystem, 
adds the logic for the cube creation.


## Exercise Part 2: Gaze & Events
![screenshot](Assets/Screenshots/exercise2.jpg)

### Aim
Use events, perform raycast, trigger change

### Goal
*[x] Extend previous exercise: gazing on an object changes its color
*[x] When gazed on, store its color. Replace it with highlight color.
*[x] Restore original color on GazeOut.

### Sources
* [Unity + C# - Events and Delegates Explained](https://www.youtube.com/watch?v=ihIOVj9t0_E&ab_channel=UnityChat)
* [C# Events](https://docs.microsoft.com/en-us/dotnet/csharp/events-overview)
* [VR Dev](https://www.coursera.org/learn/mobile-vr-app-development-unity/)


## Exercise Part 3: Reticle / Cursor
![screenshot](Assets/Screenshots/exercise3.jpg)

### Aim
Using canvas, dynamic positioning of items in scene according to gaze

### Goal
*[x] Add a reticle to your scene
  * Rotate it according to the hit surface normal
  * Scale with distance from camera
  * Use default distance if no hit
*[x] Position reticle in Update() / PerformEyeRaycast() in EyeRaycast.cs


## License
[MIT](https://choosealicense.com/licenses/mit/)
