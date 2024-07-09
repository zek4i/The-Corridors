using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightMovement : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    private Vector3 initialLocalPosition; // Initial local position relative to the player

    void Start()
    {
        // Calculate initial local position relative to the player
        initialLocalPosition = transform.localPosition;
    }

    void LateUpdate()
    {
        // Update flashlight position based on player's position and initial local position
        transform.position = player.TransformPoint(initialLocalPosition);

        // Match flashlight rotation to player's rotation
        transform.rotation = player.rotation;
    }
}
