// Assets/Editor/BuildScript.cs
using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class BuildScript
{
    public static void BuildAndroidAAB()
    {
        string projectPath = Directory.GetCurrentDirectory();
        string outputDir = Path.Combine(projectPath, "Builds", "android");
        Directory.CreateDirectory(outputDir);
        string outputPath = Path.Combine(outputDir, "app.aab");

        // Leer variables de entorno para keystore (seguro en CI)
        string keystorePath = Environment.GetEnvironmentVariable("KEYSTORE_PATH") ?? "";
        string keystorePass = Environment.GetEnvironmentVariable("KEYSTORE_PASS") ?? "";
        string keyAlias = Environment.GetEnvironmentVariable("KEY_ALIAS") ?? "";
        string keyPass = Environment.GetEnvironmentVariable("KEY_PASS") ?? "";

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
            Debug.LogWarning("No se encontró KEYSTORE_PATH. Usando configuración local de PlayerSettings.");
        }

        // Obtener rutas de escenas habilitadas usando LINQ y convertir a string[]
        string[] scenes = EditorBuildSettings.scenes
            .Where(s => s.enabled)
            .Select(s => s.path)
            .ToArray();

        var opts = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = outputPath,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        // Forzar AAB (API compatible con más versiones de Unity)
        EditorUserBuildSettings.buildAppBundle = true;

        var report = BuildPipeline.BuildPlayer(opts);
        if (report.summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded)
            Debug.Log("Build AAB generado en: " + outputPath);
        else
            Debug.LogError("Build fallido: " + report.summary.result);
    }
}
