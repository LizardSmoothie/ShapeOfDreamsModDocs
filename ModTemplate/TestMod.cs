using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HarmonyLib;

namespace TestMod
{
    // ModBehaviour will be instantiated and attached as a component in a container game object named <Your Mod Id>
    // Multiple ModBehaviours in your mod will share the same container.
    public class TestMod : ModBehaviour
    {
        private void Awake()
        {
            // Metadata of your mod is stored in this.about
            Debug.Log("Hello! I'm loaded! " + mod.metadata.id);

            // If you need to patch with Harmony, you can use this.harmony to access the Harmony instance for your mod.
            // It will be created with your mod's id automatically, the first time you access the property.
            harmony.PatchAll();
        }

        private void OnDestroy()
        {
            // Make sure you clean up properly to support Live Reload.
            Debug.Log("Good bye! " + mod.metadata.id);
            harmony.UnpatchAll();
        }
    }
}