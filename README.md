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
  - [Accident Forgiveness :tm:](#accident-forgiveness)  


# Install/Setup
## Windows Command Prompt
#### Required Programs
- [git](https://git-scm.com/downloads)
- [python](https://www.python.org/downloads/)
- [cookiecutter](https://github.com/audreyr/cookiecutter) (or `pip install cookiecutter`)

#### Usage (inside Rimworld/Mods folder)
    $ cookiecutter gh:n-fisher/cookiecutter-rimworld-mod-development
    
## Microsoft Visual Studio Integration
#### Required Programs

- [Visual Studio Community 2017](https://www.visualstudio.com/downloads/)
#### Usage
(Due to a bug in VS, you'll have to make the specific mod's folder in `[...]/Rimworld/Mods/ModName` beforehand)
1. Open Visual Studio
2. `File -> New -> From Cookiecutter...`
3. Search for `rimworld`
4. Double-click `n-fisher/cookiecutter-rimworld-mod-development`
5. Change the Template Options:
   - `Create To` => `[...]/Rimworld/Mods/ModName`
   - `mod_name`
   - `skippable_namespace_name` (don't change if unsure)
   - `author` => `your steam username`
   - `target_version` => `current RW version` (can leave blank for most up-to-date)
   - `in_game_description` (not required, can change later in About-Release.xml)
   - `url` (can leave blank for link to your Steam Workshop profile)
6. `Create and Open Folder`


# Basic Features
## Folder Structure
This cookiecutter builds the entire standard mod folder structure, with empty folders as the default.
- {{cookiecutter.mod_name}}
  - About
    - About-Debug.xml
    - About-Release.xml
    - Preview.png
  - Assemblies
  - Defs
  - Languages
  - Sounds
  - Source
    - Properties
      - AssemblyInfo.cs
    - {{cookiecutter.skippable_namespace_name}}.cs
    - {{cookiecutter.skippable_namespace_name}}.csproj
    - {{cookiecutter.skippable_namespace_name}}.csproj.user
  - Textures
  - {{cookiecutter.skippable_namespace_name}}.sln

## VS Setup Automation
- Links Rimworld and UnityEngine .dlls for importing in code
- Sets build events to automate file management of About-$Version.xml for tagging development versions.
- Clears the default set debugging and trace constants
- Creates a VS solution with correctly defined paths
- Clicking `Start ▶️` will preform the designated build sequence and start Rimworld.exe tied to a Visual Studio resource monitor.

# Advanced Features
## Debug/Release Versioning
This cookiecutter setup takes full advantage of VS debug/release versions
- Debug mode
  - About-Debug.xml contains instructions on editing About-Release.xml and has a separate title for easy recognition from the Release version 
  - Building creates an About.xml from About-Debug.xml with a "- Dev Build" tag to be easily distinguishable in the mod list
  - The resulting .dll is placed in "{{cookiecutter.mod_name}}/"
- Release mode
  - About-Release.xml is copied to "{{cookiecutter.mod_name}} - Release/About/About.xml" and does not include the "- Dev Mode" tag in its title
  - Building utilizes scripts to create or update the Release version of the mod. Solely the essential files are copied into a separate Release mod folder for a storage-optimized version of the mod
  
## Accident Forgiveness
- Edits in either generated temporary About.xml file (release or debug) won't get overwritten as long as the About-$Version.xml file it was copied from is not updated
- Items edited in the Release directory will not be overwritten with older data from the Debug/Dev directory
