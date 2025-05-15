using UnityEngine;
using System;

namespace ObjectRemover
{
    // Utility class to handle common operations for the ObjectRemover mod
    public static class ObjectRemoverUtility
    {
        /// <summary>
        /// Disables game objects in the scene based on their paths
        /// </summary>
        /// <param name="objectPaths">Array of paths to objects that should be disabled</param>
        public static void DisableGameObjects(string[] objectPaths)
        {
            // Check if the list of paths is valid
            if (objectPaths == null)
            {
                MelonLogger.Error("****************************** DisableGameObjects called with null objectPaths");
                return; // Stop execution if the paths are invalid
            }

            try
            {
                // Keep track of how many objects we successfully disable
                int disabledCount = 0;

                // Loop through each path in our list
                foreach (string path in objectPaths)
                {
                    // Check if this individual path is valid
                    if (string.IsNullOrEmpty(path))
                    {
                        MelonLogger.Warning("****************************** Skipping null or empty object path");
                        continue; // Skip to the next path if this one is invalid
                    }

                    // Try to find the object in the game world using its path
                    GameObject obj = GameObject.Find(path);

                    // Check if we found the object
                    if (obj != null)
                    {
                        // Disable the object (make it invisible and non-interactive)
                        obj.SetActive(false);
                        disabledCount++;
                        MelonLogger.Msg($"****************************** Disabled object: {path}");
                    }
                    else
                    {
                        // If we couldn't find the object, log a warning
                        MelonLogger.Warning($"****************************** Failed to find object to disable: {path}");
                    }
                }

                // Log a summary of how many objects we disabled
                MelonLogger.Msg($"****************************** Disabled {disabledCount} out of {objectPaths.Length} objects");
            }
            catch (Exception ex)
            {
                // If anything goes wrong, log the error details
                MelonLogger.Error($"****************************** Exception in DisableGameObjects: {ex.Message}");
                MelonLogger.Error($"****************************** Stack trace: {ex.StackTrace}");
            }
        }
    }
}