using UnityEngine;

public class LengthFinder : MonoBehaviour
{
        void Start()
        {
            // Get the MeshRenderer component of the plane
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

            if (meshRenderer != null)
            {
                // Get the bounds of the plane in world space
                Bounds planeBounds = meshRenderer.bounds;

                // Get the length of the plane along the Z axis (or any other axis depending on orientation)
                float length = planeBounds.size.z; // Assuming Z-axis is the length direction
                float width = planeBounds.size.x;  // For width
                float height = planeBounds.size.y; // For height (thickness)

                Debug.Log("Plane Length (Z): " + length);
                Debug.Log("Plane Width (X): " + width);
                Debug.Log("Plane Height (Y): " + height); // Typically very small for a plane
            }
            else
            {
                Debug.LogError("No MeshRenderer found on the plane!");
            }
        }
    }

