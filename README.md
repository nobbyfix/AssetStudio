A cheap edit of AssetStudio that allows extraction of Texture2D using console arguments.
* Use `-o <directory>` to define the output directory, to which the Texture2D objects should be extracted to.
* Pass additional directory and file paths as arguments for the assets that should be extracted, in case of directory all files in that directory will be extracted.
* If started with less than three arguments it will simply open the GUI.

# AssetStudio
[![Build status](https://ci.appveyor.com/api/projects/status/rnu7l90422pdewx4?svg=true)](https://ci.appveyor.com/project/Perfare/assetstudio/branch/master/artifacts)

**None of the repo, the tool, nor the repo owner is affiliated with, or sponsored or authorized by, Unity Technologies or its affiliates.**

AssetStudio is a tool for exploring, extracting and exporting assets and assetbundles.

## Features
* Support version:
  * 2.5 - 2019.3
* Support asset types:
  * **Texture2D** : convert to png, tga, jpeg, bmp
  * **Sprite** : crop Texture2D to png, tga, jpeg, bmp
  * **AudioClip** : mp3, ogg, wav, m4a, fsb. support convert FSB file to WAV(PCM)
  * **Font** : ttf, otf
  * **Mesh** : obj
  * **TextAsset**
  * **Shader**
  * **MovieTexture**
  * **VideoClip**
  * **MonoBehaviour**
  * **Animator** : export to FBX file with bound AnimationClip

## Usage
### Requirements

- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- [Microsoft Visual C++ 2017 Redistributable](https://support.microsoft.com/help/2977003/the-latest-supported-visual-c-downloads)

### How to use

* Use **File-Load file**, **File-Load folder** to load assets or assetbundles from multiple files or folder  
* Use **File-Extract file**, **File-Extract folder** to export assetbundles to assets from multiple files or folder  
* Export assets: use **Export** menu  
* Export model:  
  * Export model from "Scene Hierarchy" using the **Model** menu  
  * Export Animator from "Asset List" using the **Export** menu  
  * With AnimationClip:
    * Select model from "Scene Hierarchy" then select the AnimationClip from "Asset List", using **Model-Export selected objects with AnimationClip** to export
    * Export Animator will export bound AnimationClip or use **Ctrl** to select Animator and AnimationClip from "Asset List", using **Export-Export Animator with selected AnimationClip** to export
  
## Build

* Visual Studio 2019 or newer
* **AssetStudioFBX** uses FBX SDK 2020.0.1 VS2017, before building, you need to install the FBX SDK and modify the project file, change include directory and library directory to point to the FBX SDK directory
* If you want to change the FBX SDK version, you need to replace `libfbxsdk.dll` which in `AssetStudioGUI/Libraries/x86/` and `AssetStudioGUI/Libraries/x64/` directory to the new version

## Open source libraries used

### Texture2DDecoder
* [Ishotihadus/mikunyan](https://github.com/Ishotihadus/mikunyan)
* [BinomialLLC/crunch](https://github.com/BinomialLLC/crunch)
* [Unity-Technologies/crunch](https://github.com/Unity-Technologies/crunch/tree/unity)
