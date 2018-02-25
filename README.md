# cookiecutter-rimworld-mod-development
A cookiecutter project that builds the basic Rimworld mod development file structure and sets up a sane build environment.

# Table of Contents  
- [Install/Setup](#installsetup) 
  - [Windows Command Prompt](#windows-command-prompt)  
    - [Required Programs](#required-programs)  
    - [Usage](#usage-inside-rimworldmods-folder)  
  - [Microsoft Visual Studio Integration](#microsoft-visual-studio-integration)  
    - [Required Programs](#required-programs-1)  
    - [Usage](#usage)  
- [Basic Features](#basic-features) 
  - [Folder Structure](#folder-structure)  
  - [VS Setup Automation](#vs-setup-automation)  
- [Advanced Features](#advanced-features) 
  - [Debug/Release Versioning](#debugrelease-versioning)  
  - [Optional Debug Save Profile](#optional-debug-save-profile)  
  - [Accident Forgiveness :tm:](#accident-forgiveness)  


# Install/Setup
### Windows Command Prompt
##### Required Programs
- [git](https://git-scm.com/downloads)
- [python](https://www.python.org/downloads/)
- [cookiecutter](https://github.com/audreyr/cookiecutter) (or `pip install cookiecutter`)

##### Usage (inside Rimworld/Mods folder)
1. `cookiecutter gh:n-fisher/cookiecutter-rimworld-mod-development`
2. `[Answer the prompts]`
3. Open the folder you just created and double-click the `ModName.sln` file
4. In the Solution Explorer view on the right, right click `RimWorldWin` and click `Set as Startup Project`
    
### Microsoft Visual Studio Integration
##### Required Programs

- [Visual Studio Community 2017](https://www.visualstudio.com/downloads/)
##### Usage
(Due to a bug in VS, you'll have to make the specific mod's folder in `[...]/Rimworld/Mods/ModName` beforehand)
1. Open Visual Studio
2. `File -> New -> From Cookiecutter...`
3. Search for `rimworld`
4. Double-click `n-fisher/cookiecutter-rimworld-mod-development`
5. Change the Template Options:
   - `Create To` => `[...]/Rimworld/Mods/mod_name`
   - `Mod name`
   - `Author` (Use your Steam username for automatic linking of mod to profile) (can change later in About-Release.xml)
   - `Mod Description` (not required, can change later in About-Release.xml)
   - `Create blank XML files` (yes/no)
6. `Create and Open Folder`
7. In the Solution Explorer pane that comes up on the right, double click your `ModName.sln` file
8. In the new Solution Explorer view that comes up, right click `RimWorldWin` and click `Set as Startup Project`


# Basic Features
### Folder Structure
This cookiecutter builds the entire standard mod folder structure, with empty folders as the default. `namespace_name` is automatically calculated.
- {{cookiecutter.mod_name}}
  - About
    - About-Debug.xml
    - About-Release.xml
    - Preview.png
  - Assemblies
  - Defs
  - Languages
  - Patches
  - Sounds
  - Source
    - Properties
      - AssemblyInfo.cs
    - `namespace_name`.cs
    - `namespace_name`.csproj
    - `namespace_name`.csproj.user
  - Textures
  - `namespace_name`.sln

### VS Setup Automation
- Links Rimworld and UnityEngine .dlls for importing in code
- Sets build events to automate file management of About-$Version.xml for tagging development versions.
- Clears the default set debugging and trace constants
- Creates a VS solution with correctly defined paths
- Clicking `Start ▶️` will preform the designated build sequence and start Rimworld.exe tied to a Visual Studio resource monitor.

# Advanced Features
### Debug/Release Versioning
This cookiecutter setup takes full advantage of VS debug/release versions
- Debug mode
  - About-Debug.xml contains instructions on editing About-Release.xml and has a separate title for easy recognition from the Release version 
  - Building creates an About.xml from About-Debug.xml with a "- Dev Build" tag to be easily distinguishable in the mod list
  - The resulting .dll is placed in "{{cookiecutter.mod_name}}/Assemblies"
- Release mode
  - About-Release.xml is copied to "{{cookiecutter.mod_name}} - Release/About/About.xml" and does not include the "- Dev Mode" tag in its title
  - Building utilizes scripts to create or update the Release version of the mod. Solely the essential files are copied into a separate Release mod folder for a storage-optimized version of the mod
  
### Optional Debug Save Profile
<Temporarily removed>
  
### Accident Forgiveness
- Edits in either generated temporary About.xml file (release or debug) won't get overwritten as long as the About-$Version.xml file it was copied from is not updated
- Items edited in the Release directory will not be overwritten with older data from the Debug/Dev directory
