using UnityEngine;

public class MagnetSystem : MonoBehaviour
{
    public float magnetRange = 10f;
    public float pullForce = 5f;
    public LayerMask coinLayer;
    private bool magnetActive = false;

    void Update()
    {
        if (magnetActive)
        {
            PullCoins();
        }
    }

    public void ActivateMagnet(float duration)
    {
        magnetActive = true;
        Invoke("DeactivateMagnet", duration);
    }

    private void DeactivateMagnet()
    {
        magnetActive = false;
    }

    void PullCoins()
    {
        Collider[] coins = Physics.OverlapSphere(transform.position, magnetRange, coinLayer);

        foreach (Collider coin in coins)
        {
           
            coin.transform.position = Vector3.MoveTowards(coin.transform.position,new Vector3( transform.position.x,transform.position.y+1,transform.position.z), pullForce * Time.deltaTime);
        }
    }
}
