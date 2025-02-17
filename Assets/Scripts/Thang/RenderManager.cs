using UnityEngine;
using System.Collections.Generic;

public class TerrainManager : MonoBehaviour
{
    public List<GameObject> terrains;
    public float maxDistance = 500f; // Maximum render distance
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found!");
            enabled = false;
            return;
        }
    }

    void Update()
    {
        foreach (GameObject terrain in terrains)
        {
            Renderer renderer = terrain.GetComponent<Renderer>();
            if (renderer == null) continue; // Skip if no renderer

            // Get the center of the terrain's bounding box
            Vector3 terrainCenter = renderer.bounds.center;

            // Calculate the distance from the camera to the terrain center
            float distance = Vector3.Distance(mainCamera.transform.position, terrainCenter);

            // Distance-based culling: Check if the terrain is within the maxDistance
            if (distance <= maxDistance)
            {
                // Frustum culling: Check if the terrain is within the camera's view frustum
                bool isVisible = GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(mainCamera), renderer.bounds);
                renderer.enabled = isVisible;
            }
            else
            {
                // Terrain is outside the maxDistance, disable rendering
                renderer.enabled = false;
            }
        }
    }
}