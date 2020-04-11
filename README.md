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


# Install/Setup
### Windows Command Prompt
##### Required Programs
- [git](https://git-scm.com/downloads)
- [python](https://www.python.org/downloads/)
- [cookiecutter](https://github.com/audreyr/cookiecutter) (or `pip install cookiecutter`)

##### Usage (inside Rimworld/Mods folder)
1. `cookiecutter gh:n-fisher/cookiecutter-rimworld-mod-development`
2. Follow the prompts, and just press enter to skip the last prompt (`_visual_studio`)
3. Open the folder you just created and double-click the `ModName.sln` file
4. In the Solution Explorer pane right click `RimWorldWin` and click `Set as Startup Project`
    
### Microsoft Visual Studio Integration
##### Required Programs

- [Visual Studio Community 2017](https://www.visualstudio.com/downloads/)

##### Install (if no `File -> New -> From Cookiecutter...` option is available)
1. Open up VS Installer (In Visual Studio -> Tools -> Gets Tools and Features)
2. Click Modify
3. Click Individual Components
4. Scroll to Development activities
5. Click the Cookiecutter template support checkbox
6. Click Modify

##### Usage
(Due to a bug in VS, you'll have to make the specific mod's folder in `[...]/Rimworld/Mods/ModName` beforehand)
1. Open Visual Studio
2. `File -> New -> From Cookiecutter...`
3. Search for `rimworld`
4. Double-click `n-fisher/cookiecutter-rimworld-mod-development`
5. Change the Template Options:
   - `Create To` => `[...]/Rimworld/Mods/mod_name`
   - `Mod name`
   - `Author` (Use your Steam username for automatic linking of mod to profile) (can change later in About.xml)
   - `Mod Description` (not required, can change later in About.xml)
   - `Create blank XML files` (yes/no)
6. `Create and Open Folder`
7. In the Solution Explorer pane double click your `ModName.sln` file


# Basic Features
### Folder Structure
This cookiecutter builds the entire standard mod folder structure, with empty folders as the default. `namespace_name` is automatically calculated.
- {{cookiecutter.mod_name}}
  - About
    - About.xml
    - Preview.png
  - Common
    - Assemblies
    - Defs
    - Languages
    - Patches
    - Sounds
    - Textures
  - Source
    - Properties
      - AssemblyInfo.cs
    - `namespace_name`.cs
    - `namespace_name`.csproj
    - `namespace_name`.csproj.user
  - `namespace_name`.sln
  - LoadFolders.xml

### VS Setup Automation
- Links Rimworld and UnityEngine .dlls for importing in code
- Clears the default set debugging and trace constants
- Creates a VS solution with correctly defined paths
