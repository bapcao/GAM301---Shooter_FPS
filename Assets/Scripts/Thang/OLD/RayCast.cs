using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float raycastDistance = 10f;
    [SerializeField] private bool destroyOnHit = false; // lỗi 
    /// </summary>
    private int hitCount = 0;
    private HashSet<Collider> hitColliders = new HashSet<Collider>();
    public TextMeshProUGUI Sl; // Reference to the TextMeshProUGUI

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, raycastDistance, layerMask))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);

            if (hitColliders.Add(hit.collider))
            {
                hitCount++;
                Debug.Log("Hit Count: " + hitCount);
            }

            if (destroyOnHit)
            {
                hitColliders.Remove(hit.collider);
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.yellow);
        }

        // Update the TextMeshProUGUI with the hit count
        Sl.text = "Hit Count: " + hitCount;
    }
}