<<<<<<< HEAD
// Assets/Editor/BuildScript.cs
using System;
=======
﻿using System;
>>>>>>> work/merge-unrelated
using System.IO;
using UnityEditor;
using UnityEngine;

public static class BuildScript
{
    public static void BuildAndroidAAB()
    {
        string projectPath = Directory.GetCurrentDirectory();
<<<<<<< HEAD
        string outputDir = Path.Combine(projectPath, "Builds", "android");
        Directory.CreateDirectory(outputDir);
        string outputPath = Path.Combine(outputDir, "app.aab");

        // Leer variables de entorno para keystore (seguro en CI)
        string keystorePath = Environment.GetEnvironmentVariable("KEYSTORE_PATH") ?? "";
        string keystorePass = Environment.GetEnvironmentVariable("KEYSTORE_PASS") ?? "";
        string keyAlias = Environment.GetEnvironmentVariable("KEY_ALIAS") ?? "";
        string keyPass = Environment.GetEnvironmentVariable("KEY_PASS") ?? "";
=======
        string outputDir = Path.Combine(projectPath, ""Builds"", ""android"");
        Directory.CreateDirectory(outputDir);
        string outputPath = Path.Combine(outputDir, ""app.aab"");

        string keystorePath = Environment.GetEnvironmentVariable(""KEYSTORE_PATH"") ?? """";
        string keystorePass = Environment.GetEnvironmentVariable(""KEYSTORE_PASS"") ?? """";
        string keyAlias = Environment.GetEnvironmentVariable(""KEY_ALIAS"") ?? """";
        string keyPass = Environment.GetEnvironmentVariable(""KEY_PASS"") ?? """";
>>>>>>> work/merge-unrelated

        if (!string.IsNullOrEmpty(keystorePath))
        {
            PlayerSettings.Android.useCustomKeystore = true;
            PlayerSettings.Android.keystoreName = keystorePath;
            PlayerSettings.Android.keystorePass = keystorePass;
            PlayerSettings.Android.keyaliasName = keyAlias;
            PlayerSettings.Android.keyaliasPass = keyPass;
        }
        else
        {
<<<<<<< HEAD
            Debug.LogWarning("No se encontró KEYSTORE_PATH. Usando configuración de PlayerSettings local.");
        }

        // Asegúrate de que las escenas estén listadas
=======
            Debug.LogWarning(""No se encontró KEYSTORE_PATH. Usando configuración local de PlayerSettings."");
        }

>>>>>>> work/merge-unrelated
        string[] scenes = Array.FindAll(EditorBuildSettings.scenes, s => s.enabled).ConvertAll(s => s.path).ToArray();

        var opts = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = outputPath,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

<<<<<<< HEAD
        // Forzar AAB
=======
>>>>>>> work/merge-unrelated
        PlayerSettings.Android.buildAppBundle = true;

        var report = BuildPipeline.BuildPlayer(opts);
        if (report.summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded)
<<<<<<< HEAD
            Debug.Log("Build AAB generado en: " + outputPath);
        else
            Debug.LogError("Build fallido: " + report.summary.result);
    }

    // Helper extension to convert array
=======
            Debug.Log(""Build AAB generado en: "" + outputPath);
        else
            Debug.LogError(""Build fallido: "" + report.summary.result);
    }

>>>>>>> work/merge-unrelated
    private static string[] ConvertAll(this EditorBuildSettingsScene[] arr, Func<EditorBuildSettingsScene, string> selector)
    {
        string[] outArr = new string[arr.Length];
        for (int i = 0; i < arr.Length; i++) outArr[i] = selector(arr[i]);
        return outArr;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> work/merge-unrelated
