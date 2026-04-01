using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DynamicMesh))]
public class DynamicMeshEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var dynamicMesh = (DynamicMesh)target;

        if(GUILayout.Button("Create Mesh"))
        {
            var mesh = dynamicMesh.GenerateGridMesh();
            dynamicMesh.ApplyToMeshFilter(mesh);
        }
    }

}
