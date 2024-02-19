using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollower : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin transformu
    public float positionSmoothSpeed = 5f; // Pozisyonun yumu�ak ge�i� h�z�
    public float rotationSmoothSpeed = 5f; // Rotasyonun yumu�ak ge�i� h�z�

    void Update()
    {
        if (target == null) return;

        // Karakterin pozisyonunu takip et
        Vector3 targetPosition = target.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, positionSmoothSpeed * Time.deltaTime);

        // Karakterin rotasyonunu takip et
        Quaternion targetRotation = target.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothSpeed * Time.deltaTime);
    }
}
