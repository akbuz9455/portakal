using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class NodeConnector : MonoBehaviour
{
    public SplineFollower _follower; // Spline üzerinde hareket edecek olan nesneyi temsil eder.
    public bool isChange;
    public SplineComputer targetSpline; // Hedef spline
    public int targetPointIndex = 0; // Hedef spline üzerindeki nokta indexi

    void Start()
    {
        _follower = GetComponent<SplineFollower>();
        _follower.onNode += OnNodePassed;
    }

    private void OnNodePassed(List<SplineTracer.NodeConnection> passed)
    {
        if (isChange) return;
        isChange = true;

        Invoke("ChangeUpdate", 1f);

        // Hedef spline ve noktaya geçiþ
        Debug.Log("Hedef spline deðiþtiriliyor...");
        _follower.spline = targetSpline; // SplineFollower'ýn spline'ýný hedef spline ile deðiþtir.
        Debug.Log("Hedef spline deðiþtirildi.");
        // Hedef noktanýn yüzdesini hesapla
        double targetPercent = (double)targetPointIndex / (targetSpline.pointCount - 1);

        // Spline deðiþikliðinden sonra hedef yüzdeye ayarla
        StartCoroutine(SetPercentAfterSplineChange(targetPercent));
    }

    private IEnumerator SetPercentAfterSplineChange(double targetPercent)
    {
        // Spline deðiþikliði tamamlandýktan sonra belirtilen yüzdeye ayarla
        yield return new WaitForEndOfFrame();
      

        Debug.Log("Yüzde deðeri ayarlanýyor...");
        _follower.SetPercent(targetPercent); // SplineFollower'ýn yüzdesini, belirlenen hedef yüzde ile günceller.
        Debug.Log("Yüzde deðeri ayarlandý.");
       

    }

    public void ChangeUpdate()
    {
        isChange = false;
    }
}
