using UnityEngine;

public class CharacterCameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin transformu
    public float smoothSpeed = 5f; // D�n�� h�z�

    private Vector3 offset; // Kamera ile karakter aras�ndaki mesafe

    void Start()
    {
        // Kameran�n karakterin arkas�nda olmas�n� sa�layacak mesafeyi belirle
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Kameran�n hedefi takip etmesi i�in bir hedef konumu belirle
        Vector3 targetPosition = target.position + offset;

        // Yumu�ak bir ge�i�le kameray� hedefe do�ru d�nd�r
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);

        // Kameran�n yumu�ak bir �ekilde hedefin pozisyonuna hareket etmesini sa�la
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
