using UnityEngine;
using System;

namespace ObjectRemover
{
    // Main mod class - this is the entry point of the mod that MelonLoader will call
    public class Main : MelonMod
    {
        // This method runs when the mod is first loaded by MelonLoader
        public override void OnInitializeMelon()
        {
            // Write a message to the log that our mod has started
            MelonLogger.Msg("****************************** ObjectRemover mod initialized");
            // Any startup code would go here if needed
        }

        // This method runs whenever a new game scene is loaded
        // buildIndex: A unique number identifying the scene
        // sceneName: The name of the scene (like "LakeRegion" for Mystery Lake)
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            // Make sure the scene name isn't empty - this prevents errors
            if (string.IsNullOrEmpty(sceneName))
            {
                MelonLogger.Warning("****************************** Scene initialized with null or empty scene name");
                return; // Stop execution if there's no valid scene name
            }

            // Log which scene was loaded to help with debugging
            MelonLogger.Msg($"****************************** Scene initialized: {sceneName} (Build Index: {buildIndex})");

            // Process the scene to remove climbing objects based on which region we're in
            ProcessSceneRoutes(sceneName);
        }

        // This method decides which region-specific code to run based on the scene name
        private void ProcessSceneRoutes(string sceneName)
        {
            // Another safety check to make sure the scene name isn't empty
            if (string.IsNullOrEmpty(sceneName))
            {
                MelonLogger.Error("****************************** ProcessSceneRoutes called with null or empty scene name");
                return; // Stop execution if there's no valid scene name
            }

            // Log that we're starting to process routes for this scene
            MelonLogger.Msg($"****************************** Processing removals for {sceneName}");

            // Use try-catch to prevent the mod from crashing if something goes wrong
            try
            {
                // If we're in Mystery Lake (either story mode or sandbox mode)
                if (sceneName == "LakeRegion" || sceneName == "LakeRegion_SANDBOX")
                {
                    MelonLogger.Msg("****************************** Calling MysteryLakeManager");
                    // Call the Mystery Lake specific code to remove climbing objects
                    MysteryLakeManager.ProcessMysteryLakeRemovals(sceneName);
                }
                // If we're in Forlorn Muskeg (either story mode or sandbox mode)
                else if (sceneName == "MarshRegion" || sceneName == "MarshRegionRegion_SANDBOX")
                {
                    MelonLogger.Msg("****************************** Calling ForlornMuskegManager");
                    // Call the Forlorn Muskeg specific code to remove climbing objects
                    ForlornMuskegManager.ProcessForlornMuskegRemovals(sceneName);
                }
                // If we're in any other region that we don't have special code for
                else
                {
                    MelonLogger.Msg($"****************************** No modifications for scene: {sceneName}");
                }
            }
            catch (System.Exception ex)
            {
                // If anything goes wrong, log the error details so we can fix the mod
                MelonLogger.Error($"****************************** Exception in ProcessSceneRoutes: {ex.Message}");
                MelonLogger.Error($"****************************** Stack trace: {ex.StackTrace}");
            }
        }
    }
}