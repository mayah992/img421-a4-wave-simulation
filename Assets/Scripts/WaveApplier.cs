using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class WaveApplier : MonoBehaviour
{
    private MeshFilter meshFilter;
    private List<Wave> waves;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        waves = FindObjectsOfType<Wave>().ToList();
    }

    void Update()
    {
        ApplyWaves();
    }

    void ApplyWaves()
    {
        var mesh = meshFilter.mesh;
        var vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 world = transform.TransformPoint(vertices[i]);

            float height = 0f;
            foreach (var wave in waves)
                height += wave.GetHeight(world.x, world.z);

            Vector3 newWorld = new Vector3(world.x, height, world.z);
            vertices[i] = transform.InverseTransformPoint(newWorld);
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
