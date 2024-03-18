using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class NodeConnector : MonoBehaviour
{
    public SplineFollower _follower; // Spline �zerinde hareket edecek olan nesneyi temsil eder.
    public bool isChange;
    public SplineComputer targetSpline; // Hedef spline
    public int targetPointIndex = 0; // Hedef spline �zerindeki nokta indexi

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

        // Hedef spline ve noktaya ge�i�
        Debug.Log("Hedef spline de�i�tiriliyor...");
        _follower.spline = targetSpline; // SplineFollower'�n spline'�n� hedef spline ile de�i�tir.
        Debug.Log("Hedef spline de�i�tirildi.");
        // Hedef noktan�n y�zdesini hesapla
        double targetPercent = (double)targetPointIndex / (targetSpline.pointCount - 1);

        // Spline de�i�ikli�inden sonra hedef y�zdeye ayarla
        StartCoroutine(SetPercentAfterSplineChange(targetPercent));
    }

    private IEnumerator SetPercentAfterSplineChange(double targetPercent)
    {
        // Spline de�i�ikli�i tamamland�ktan sonra belirtilen y�zdeye ayarla
        yield return new WaitForEndOfFrame();
      

        Debug.Log("Y�zde de�eri ayarlan�yor...");
        _follower.SetPercent(targetPercent); // SplineFollower'�n y�zdesini, belirlenen hedef y�zde ile g�nceller.
        Debug.Log("Y�zde de�eri ayarland�.");
       

    }

    public void ChangeUpdate()
    {
        isChange = false;
    }
}
