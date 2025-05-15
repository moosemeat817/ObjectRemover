using UnityEngine;
using System;

namespace ObjectRemover
{
    // This class handles all the climbing object removals specifically for the Forlorn Muskeg region
    public class ForlornMuskegManager
    {
        // This is the main method that decides what modifications to make based on which scene
        // of Forlorn Muskeg we're in (MarshRegion or MarshRegion_SANDBOX)
        public static void ProcessForlornMuskegRemovals(string sceneName)
        {
            // Check if the scene name is valid to prevent errors
            if (string.IsNullOrEmpty(sceneName))
            {
                MelonLogger.Error("****************************** ProcessForlornMuskegRemovals called with null or empty scene name");
                return; // Stop execution if the scene name is invalid
            }

            // Log that we're starting to process Forlorn Muskeg
            MelonLogger.Msg($"****************************** Processing Forlorn Muskeg removals for scene: {sceneName}");

            // Use try-catch to prevent the mod from crashing if something goes wrong
            try
            {
                // Check which scene of Forlorn Muskeg we're in
                switch (sceneName)
                {
                    case "MarshRegion": // This is the MarshRegion scene
                        MelonLogger.Msg("****************************** Modifying Forlorn Muskeg");
                        ModifyForlornMuskeg(); // Call the method to remove objects in MarshRegion scene
                        break;
                    case "MarshRegionRegion_SANDBOX": // This is the MarshRegion_SANDBOX scene
                        MelonLogger.Msg("****************************** Modifying Forlorn Muskeg SANDBOX");
                        ModifyForlornMuskegSandbox(); // Call the method to remove objects in MarshRegion_SANDBOX scene
                        break;
                    default: // If it's neither of the above, we don't need to do anything
                        MelonLogger.Msg($"****************************** No Forlorn Muskeg modifications for scene: {sceneName}");
                        break;
                }
            }
            catch (Exception ex)
            {
                // If anything goes wrong, log the error details so we can fix the mod
                MelonLogger.Error($"****************************** Exception in ProcessForlornMuskegRemovals: {ex.Message}");
                MelonLogger.Error($"****************************** Stack trace: {ex.StackTrace}");
            }
        }

        // ------------------------------------------------------------------------------------------------------------------
        // FORLORN MUSKEG - MarshRegion scene
        // ------------------------------------------------------------------------------------------------------------------
        private static void ModifyForlornMuskeg()
        {
            // Log that we're starting to modify Forlorn Muskeg - MarshRegion scene
            MelonLogger.Msg("****************************** Starting Forlorn Muskeg modifications");

            try
            {
                // Log that we're about to disable objects
                MelonLogger.Msg("****************************** Disabling Objects");

                // This array contains the paths to the objects we want to disable
                // Make sure there is a comma after each object, except for the last one
                string[] objectsToDisable = new string[] {
                    "Art/Structures/FarmStead", // Spence Farm
                    "Art/terrain objects/OBJ_IndustrialDebrisA_Prefab" // Industrial debris at Spence Farm
                };

                // Check if our list of objects is valid
                if (objectsToDisable == null || objectsToDisable.Length == 0)
                {
                    MelonLogger.Warning("****************************** Objects to disable array is null or empty");
                }
                else
                {
                    // Call the utility method to actually disable the objects
                    ObjectRemoverUtility.DisableGameObjects(objectsToDisable);
                }

                // Log that we're done modifying Forlorn Muskeg
                MelonLogger.Msg("****************************** Completed Forlorn Muskeg modifications");
            }
            catch (Exception ex)
            {
                // If anything goes wrong, log the error details
                MelonLogger.Error($"****************************** Exception in ModifyForlornMuskeg: {ex.Message}");
                MelonLogger.Error($"****************************** Stack trace: {ex.StackTrace}");
            }
        }

        // ------------------------------------------------------------------------------------------------------------------
        // FORLORN MUSKEG SANDBOX - MarshRegion_SANDBOX scene
        // ------------------------------------------------------------------------------------------------------------------
        private static void ModifyForlornMuskegSandbox()
        {
            // Log that we're starting to modify Forlorn Muskeg - MarshRegion_SANDBOX scene
            MelonLogger.Msg("****************************** Starting Forlorn Muskeg SANDBOX modifications");

            try
            {
                // Log that we're about to disable objects
                MelonLogger.Msg("****************************** Disabling Objects");

                // This array contains the paths to the objects we want to disable
                // Make sure there is a comma after each object, except for the last one
                string[] objectsToDisable = new string[] {
                    "Design/TLD-17972/STR_RadioTowerDamagedBase_Prefab" // Damaged Radio Tower
                };

                // Check if our list of objects is valid
                if (objectsToDisable == null || objectsToDisable.Length == 0)
                {
                    MelonLogger.Warning("****************************** Objects to disable array is null or empty");
                }
                else
                {
                    // Call the utility method to actually disable the objects
                    ObjectRemoverUtility.DisableGameObjects(objectsToDisable);
                }

                // Log that we're done modifying Forlorn Muskeg
                MelonLogger.Msg("****************************** Completed Forlorn Muskeg SANDBOX modifications");
            }
            catch (Exception ex)
            {
                // If anything goes wrong, log the error details
                MelonLogger.Error($"****************************** Exception in ModifyForlornMuskeg: {ex.Message}");
                MelonLogger.Error($"****************************** Stack trace: {ex.StackTrace}");
            }
        }
    }
}