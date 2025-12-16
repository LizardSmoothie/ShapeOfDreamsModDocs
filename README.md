# Hello Travelers!

<img width="3840" height="1240" alt="steam banner" src="https://github.com/user-attachments/assets/a186b083-34df-4392-af83-d0be1ff292da" />

Welcome to the rudimentary documentation / starter guide for mod creators.

Please note that mod support (including this documentation) is currently in its early stages, and is somewhat basic. However, we are doing our best to make mod creation easy for developers, despite our limited time and being short-staffed. We are very short on programmers and we're all kind of uninitiated on this whole modding thing, so we would greatly appreciate feedback and helping hands.

**Sorry in advance for the bumpy road ahead, and thank you so much for your understanding!**

# Links

**Shape of Dreams Workshop:** https://steamcommunity.com/app/2444750/workshop/

**API References (Dew.Core):** https://lizardsmoothie.com/sod/moddoc/api/Global.html

**Official Example Mods:** https://steamcommunity.com/id/lizardsmoothie/myworkshopfiles/?appid=2444750

# Code of Conduct
1. You may make a mod that severely alters gameplay.
1. You may make a mod that lets you cheat progress or runs.
1. You **must not** make a mod that severely affects other's experience without their consent. (e.g. client-side cheats or troll mods)
   - All server-side mods that alters gameplay must set `instance.isAlteringGameplay = true`. This will add a MOD icon on your hosted lobby, and a simple notice will be shown on joining clients so they can expect a potentially different gameplay.
1. You **must not** make a mod that grants illicit access to exclusive, server-generated items. (e.g. things you cannot buy in-game using stardusts)
   - Not only it hurts the game's longevity, it undermines others effort put into getting them, and discourages players.
     
In short, don't be evil. If you NEED to break the rules, keep it to yourself or your friends. We don't have a way to force these rules on people, but we will monitor Workshop to take any necessary actions. Please be thoughtful of all parties involved.

# Getting Started

## Prerequisites
To mod the game easily, you’ll need below things at minimum:

- A basic knowledge on C# and .NET projects management
- A basic knowledge on modding Unity games by using Harmony
- A decompiler to look into the game’s code.

## Developer Mode & Console Commands
Go to gameplay settings, and enable Developer Mode to get access to in-game debug console.
With the mode enabled, press **F1** to toggle console mode.

- **Shown:** Log viewer is displayed on the right side of the screen. Use **[ ` ]** key to open or close the console.
- **ShownWithoutPopup:** Log viewer is not displayed. Use **[ ` ]** key to open or close the console.
- **Hidden:** Log viewer is not displayed and console cannot be opened.

You can add custom console commands with ModBehaviours, or you can install mods with console commands the others have built. Here's an [official one](https://steamcommunity.com/sharedfiles/filedetails/?id=3618192903) with several server-side cheats you can make use. This is what we also use internally inside our studio. 

## Mod Manager
Albeit a little bare bones, the game is equipped with a built-in mod manager, which you can find in the title screen among the menu buttons(”Mods”). 

If you have developer mode enabled, you can access the manager anywhere in the game, by opening the console and clicking on “Manage Mods”. 

A friendly reminder: loading and unloading mods in the middle of a game can cause unexpected bugs and shennanigans!

## Creating your own mod: Project Template
We provide a project template you can use to get started in making your own mod quickly, in "<GameFolder>/Mods/ModTemplate".
1. Install the template in your preferred IDE
2. Create a new project using the template in "Mods" folder.
3. Make sure you fill in required fields and enable "Place solution and project in a same folder". The project will then refer to the game's assembly files and provide you most of the necessary namespaces and classes.

## Uploading a Mod to Workshop
When you have the developer mode enabled, you will see Upload button in the mod manager when you select a mod. When you upload a mod for the first time, a new item will be created on Steam Workshop. After that, consequent uploads will be an update to the existing item.

Uploaded mods will have their visibility automatically set to **Hidden**, allowing you to make final changes and adjustments before you decide to publish this mod for everyone, by setting it to **Public**. Note that updating a mod will also set the visibility to hidden.

## Scripting and ModBehaviours
When loading a mod, DLLs specified in its metadata.json's "assemblies" key will be injected to the game. When this happens, **ModBehaviour**s will be your main entry point and a way to manage lifecycle of your mods. All ModBehaviours in your compiled assembly will be attached to a single container GameObject, and each container is created for each mod instance.

Mods can be loaded and be unloaded, so make sure you clean up properly when a ModBehaviour is destroyed!

After you write some useful code, build the solution to yield DLL files, and then load the mod to see the results.

## Harmony
Harmony is built-in, and you can access your harmony instance with `harmony` property in any ModBehaviors. If you're patching something, make sure you unpatch in `OnDestroy`.

## JSON Overrides
JSON Overrides are a powerful, easy, and declarative way to modify various parameters in the game. If you'd like to change character stats, damage numbers, cooldown times and such in the game statically, this is probably the easiest way to go.

`isAlteringGameplay` will automatically be set to true, for any mods making use of this system.

### Pros
1. Requires no C# knowledge
2. Supports multiplayer (automatically syncs from the host to clients)

### Cons
1. Cannot dynamically modify paramters (e.g. no user-customizable settings, no situational awareness)
2. Can only modify certain parameters (see: "<GameFolder>/RawData/!ModResources/overrides")
3. Works only if hosts have them installed

Please refer to [SUPER LACERTA](https://steamcommunity.com/sharedfiles/filedetails/?id=3618193300) example on how the system work.

Refer to "<GameFolder>/RawData/!ModResources/overrides" to see which paramters you can change.

## Under Construction

Sorry to disappoint you, but the documentation ends here for now. We are working hard to add more content useful for mod creators.
Until then, please refer to [Offical Example Mods](https://steamcommunity.com/id/lizardsmoothie/myworkshopfiles/?appid=2444750) or [Shape of Dreams Workshop](https://steamcommunity.com/app/2444750/workshop/) to see what others have already made. As a starting point, I suggest installing all official mods and taking a look into the source code.

If you have any contributions to make to this repository, we'll review them as quick as possible and make sure everyone gets a better version of the documentation. Thank you!

All the best, Lizard Smoothie
