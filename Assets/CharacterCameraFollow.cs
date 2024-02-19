using UnityEngine;

public class CharacterCameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin transformu
    public float smoothSpeed = 5f; // Dönüþ hýzý

    private Vector3 offset; // Kamera ile karakter arasýndaki mesafe

    void Start()
    {
        // Kameranýn karakterin arkasýnda olmasýný saðlayacak mesafeyi belirle
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Kameranýn hedefi takip etmesi için bir hedef konumu belirle
        Vector3 targetPosition = target.position + offset;

        // Yumuþak bir geçiþle kamerayý hedefe doðru döndür
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);

        // Kameranýn yumuþak bir þekilde hedefin pozisyonuna hareket etmesini saðla
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
