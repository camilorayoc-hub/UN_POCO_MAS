using UnityEditor;
public static class BuildMenu
{
    [MenuItem("Build/Build Android AAB")]
    public static void BuildAAB()
    {
        BuildScript.BuildAndroidAAB();
    }
}
