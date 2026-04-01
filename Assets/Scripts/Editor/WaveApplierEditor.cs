using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WaveApplier))]
public class WaveApplierEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Start Simulation"))
            EditorApplication.update += Update;

        if (GUILayout.Button("Stop Simulation"))
            EditorApplication.update -= Update;
    }

    void Update()
    {
        foreach (var a in FindObjectsOfType<WaveApplier>())
            a.SendMessage("ApplyWaves");
    }
}
