using UnityEngine;

public class GunPivot : MonoBehaviour
{
    public Transform playerHand;  // Assign this to the player's hand or the player GameObject

    void LateUpdate()
    {
        // Ensure GunPivot stays aligned with the player's hand
        if (playerHand != null)
        {
            transform.position = playerHand.position; // Align pivot with player's hand
        }

        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Ensure the Z-position is zero since this is a top-down 2D game
        mousePosition.z = 0f;

        // Calculate the direction from the GunPivot to the mouse position
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle in degrees between the direction vector and the right vector
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;

        // Apply the rotation only on the Z-axis to keep the gun aligned in top-down view
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
