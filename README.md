# cookiecutter-rimworld-mod-development
A cookiecutter project that builds the basic Rimworld mod development file structure and sets up a sane build environment.

## Install/Setup
### Windows Shell
- [git](https://git-scm.com/downloads)
- [python](https://www.python.org/downloads/)
- [cookiecutter](https://github.com/audreyr/cookiecutter) (or `pip install cookiecutter`)
#### Usage (inside Rimworld/Mods folder)
    $ cookiecutter gh:n-fisher/cookiecutter-rimworld-mod-development
    
### Microsoft Visual Studio

1. `File -> New -> From Cookiecutter...`
2. Search for `rimworld`
3. Double-click `n-fisher/cookiecutter-rimworld-mod-development`
4. Change the Template Options:
   - `Create To` => `Your/Rimworld/Mod/Directory`
   - `mod_name`
   - `namespace_name` (don't change if unsure)
   - `author` => `your steam username`
   - `target_version` => `current RW version` (can leave blank for most up-to-date)
   - `in_game_description` (not required, can change later in About-Release.xml)
   - `url` (can leave blank for link to your Steam Workshop profile)
5. `Create and Open Folder`

## Basic Features
### Folder Structure
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
    - {{cookiecutter.namespace_name}}.cs
    - {{cookiecutter.namespace_name}}.csproj
    - {{cookiecutter.namespace_name}}.csproj.user
  - Textures
  - {{cookiecutter.namespace_name}}.sln

### VS Setup Automation
- Links Rimworld and UnityEngine .dlls for importing in code
- Sets build events to automate file management of About-$Version.xml for tagging development versions.
- Clears the default set debugging and trace constants
- Creates a VS solution with correctly defined paths
- Clicking `Start ▶️` will preform the designated build sequence and start Rimworld.exe tied to a Visual Studio resource monitor.

## Advanced Features
### Debug/Release Versioning
This cookiecutter setup takes full advantage of VS debug/release versions
- Debug mode
  - About-Debug.xml contains instructions on editing About-Release.xml and has a separate title for easy recognition from the Release version 
  - Building creates an About.xml from About-Debug.xml with a "- Dev Build" tag to be easily distinguishable in the mod list
  - The resulting .dll is placed in "{{cookiecutter.mod_name}}/
- Release mode
  - About-Release.xml is copied to "{{cookiecutter.mod_name}} - Release/About/About.xml" and does not include the "- Dev Mode" tag in its title
  - Building utilizes scripts to create or update the Release version of the mod. Solely the essential files are copied into a separate Release mod folder for a storage-optimized version of the mod
  
### Accident Forgiveness
- Edits in either generated temporary About.xml file (release or debug) won't get overwritten as long as the About-$Version.xml file it was copied from is not updated
- Items edited in the Release directory will not be overwritten with older data from the Debug/Dev directory
