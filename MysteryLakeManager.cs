using UnityEngine;
using System;

namespace ObjectRemover
{
    // This class handles all the climbing object removals specifically for the Mystery Lake region
    public class MysteryLakeManager
    {
        // This is the main method that decides what modifications to make based on which scene
        // of Mystery Lake we're in (LakeRegion or LakeRegion_SANDBOX)
        public static void ProcessMysteryLakeRemovals(string sceneName)
        {
            // Check if the scene name is valid to prevent errors
            if (string.IsNullOrEmpty(sceneName))
            {
                MelonLogger.Error("****************************** ProcessMysteryLakeRemovals called with null or empty scene name");
                return; // Stop execution if the scene name is invalid
            }

            // Log that we're starting to process Mystery Lake
            MelonLogger.Msg($"****************************** Processing Mystery Lake removals for scene: {sceneName}");

            // Use try-catch to prevent the mod from crashing if something goes wrong
            try
            {
                // Check which scene of Mystery Lake we're in
                switch (sceneName)
                {
                    case "LakeRegion": // This is the LakeRegion scene
                        MelonLogger.Msg("****************************** Modifying Mystery Lake");
                        ModifyMysteryLake(); // Call the method to remove objects in LakeRegion scene
                        break;
                    case "LakeRegion_SANDBOX": // This is the LakeRegion_SANDBOX scene
                        MelonLogger.Msg("****************************** Modifying Mystery Lake SANDBOX");
                        ModifyMysteryLakeSandbox(); // Call the method to remove objects in LakeRegion_SANDBOX scene
                        break;
                    default: // If it's neither of the above, we don't need to do anything
                        MelonLogger.Msg($"****************************** No Mystery Lake modifications for scene: {sceneName}");
                        break;
                }
            }
            catch (Exception ex)
            {
                // If anything goes wrong, log the error details so we can fix the mod
                MelonLogger.Error($"****************************** Exception in ProcessMysteryLakeRemovals: {ex.Message}");
                MelonLogger.Error($"****************************** Stack trace: {ex.StackTrace}");
            }
        }

        // ------------------------------------------------------------------------------------------------------------------
        // MYSTERY LAKE - LakeRegion scene
        // ------------------------------------------------------------------------------------------------------------------
        private static void ModifyMysteryLake()
        {
            // Log that we're starting to modify Mystery Lake - LakeRegion scene
            MelonLogger.Msg("****************************** Starting Mystery Lake modifications");

            try
            {
                // Log that we're about to disable objects
                MelonLogger.Msg("****************************** Disabling Objects");

                // This array contains the paths to the objects we want to disable
                // Make sure there is a comma after each object, except for the last one
                string[] objectsToDisable = new string[] {
                    "Art/Structures/STRSPAWN_CampOffice_Prefab",  // Camp Office
                    "Art/Objects/OBJ_RoadSignI_Prefab"  // Camp Office Sign
                };

                if (objectsToDisable == null || objectsToDisable.Length == 0)
                {
                    MelonLogger.Warning("****************************** Objects to disable array is null or empty");
                }
                else
                {
                    // Call the utility method to actually disable the objects
                    ObjectRemoverUtility.DisableGameObjects(objectsToDisable);
                }

                MelonLogger.Msg("****************************** Completed Mystery Lake modifications");
            }
            catch (Exception ex)
            {
                MelonLogger.Error($"****************************** Exception in ModifyMysteryLake: {ex.Message}");
                MelonLogger.Error($"****************************** Stack trace: {ex.StackTrace}");
            }
        }

        // ------------------------------------------------------------------------------------------------------------------
        // MYSTERY LAKE SANDBOX - LakeRegion_SANDBOX scene
        // ------------------------------------------------------------------------------------------------------------------
        private static void ModifyMysteryLakeSandbox()
        {
            // Log that we're starting to modify Mystery Lake - LakeRegion_SANDBOX scene
            MelonLogger.Msg("****************************** Starting Mystery Lake SANDBOX modifications");

            try
            {
                MelonLogger.Msg("****************************** Disabling Objects");

                // This array contains the paths to the objects we want to disable
                // Make sure there is a comma after each object, except for the last one
                string[] objectsToDisable = new string[] {
                    "Design/RandomSpawnStructures" // All random cabins and fishing huts
                };

                if (objectsToDisable == null || objectsToDisable.Length == 0)
                {
                    MelonLogger.Warning("****************************** Objects to disable array is null or empty");
                }
                else
                {
                    // Call the utility method to actually disable the objects
                    ObjectRemoverUtility.DisableGameObjects(objectsToDisable);
                }

                MelonLogger.Msg("****************************** Completed Mystery Lake SANDBOX modifications");
            }
            catch (Exception ex)
            {
                MelonLogger.Error($"****************************** Exception in ModifyMysteryLakeSandbox: {ex.Message}");
                MelonLogger.Error($"****************************** Stack trace: {ex.StackTrace}");
            }
        }
    }
}