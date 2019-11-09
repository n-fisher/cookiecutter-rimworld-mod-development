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
    $ cookiecutter gh:n-fisher/cookiecutter-rimworld-mod-development
    
### Microsoft Visual Studio Integration
##### Required Programs

- [Visual Studio Community 2017](https://www.visualstudio.com/downloads/)
##### Usage
(Due to a bug in VS, you'll have to make the specific mod's folder in `[...]/Rimworld/Mods/mod_name` beforehand)
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
7. In the Solution Explorer pane that comes up on the left, double click your `mod_name.sln` file
8. In the new Solution Explorer view that comes up, right click `RimWorldWin` and click `Set as Startup Project`


# Basic Features
### Folder Structure
This cookiecutter builds the entire standard mod folder structure, with empty folders as the default. `namespace_name` is automatically calculated.
- {{cookiecutter.mod_name}}
  - About
    - About.xml
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
- Clears the default set debugging and trace constants
- Creates a VS solution with correctly defined paths
- Clicking `Start ▶️` will preform the designated build sequence and start Rimworld.exe tied to a Visual Studio resource monitor.
