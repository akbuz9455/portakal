using Dreamteck.Splines;
using Dreamteck.Splines.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSwitch : MonoBehaviour
{
    public SplineFollower _follower;
    public bool isChange;
    public double _lastPercent = 0.0;
    private JunctionSwitch junctionSwitch;
    void Start()
    {
        _follower = GetComponent<SplineFollower>();
        _follower.onNode += OnJunction;
        _follower.onMotionApplied += OnMotionApplied;
    }
    private void OnMotionApplied()
    {
        //Apply the wagon's offset (this will recursively apply the offsets to the rest of the wagons in the chain)
        _lastPercent = _follower.result.percent;

    }
    private void OnJunction(List<SplineTracer.NodeConnection> passed)
    {
        if (isChange) return;
        isChange = true;

        Invoke(nameof(ChangeUpdate), 1f);


        Node node = passed[0].node; //Get the node of the junction
        junctionSwitch = node.GetComponent<JunctionSwitch>(); //Look for a JunctionSwitch component

        UnityEngine.Debug.Log("Look for a JunctionSwitch component");
        if (junctionSwitch == null) return; //No JunctionSwitch - ignore it - this isn't a real junction
        UnityEngine.Debug.Log("No JunctionSwitch - ignore it - this isn't a real junction");
        if (junctionSwitch.bridges.Length == 0) return; //The JunctionSwitch does not have bridge elements
        UnityEngine.Debug.Log("The JunctionSwitch does not have bridge elements");
        foreach (JunctionSwitch.Bridge bridge in junctionSwitch.bridges)
        {
            //Look for a suitable bridge element based on the spline we are currently traversing
            if (!bridge.active) continue;
            UnityEngine.Debug.Log("Look for a suitable bridge element based on the spline we are currently traversing");
            if (bridge.a == bridge.b) continue; //Skip bridge if it points to the same spline  
            UnityEngine.Debug.Log("Skip bridge if it points to the same spline");
            int currentConnection = 0;
            Node.Connection[] connections = node.GetConnections();
            UnityEngine.Debug.Log("get the connected splines and find the index of the tracer's current spline");
            //get the connected splines and find the index of the tracer's current spline
            for (int i = 0; i < connections.Length; i++)
            {
                if (connections[i].spline == _follower.spline)
                {

                    currentConnection = i;
                    break;

                }
            }
            UnityEngine.Debug.Log("Skip the bridge if we are not on one of the splines that the switch connects");
            //Skip the bridge if we are not on one of the splines that the switch connects
            if (currentConnection != bridge.a && currentConnection != bridge.b) continue;
            if (currentConnection == bridge.a)
            {
                if ((int)_follower.direction != (int)bridge.bDirection) continue;
                //This bridge is suitable and should use it
                SwitchSpline(connections[bridge.a], connections[bridge.b]);
                return;
            }
            else
            {
                if ((int)_follower.direction != (int)bridge.aDirection) continue;
                //This bridge is suitable and should use it
                SwitchSpline(connections[bridge.b], connections[bridge.a]);
                return;
            }
        }
    }
    void SwitchSpline(Node.Connection from, Node.Connection to)
    {

        //See how much units we have travelled past that Node in the last frame

        float excessDistance = from.spline.CalculateLength(from.spline.GetPointPercent(from.pointIndex), _follower.UnclipPercent(_lastPercent));
        //Set the spline to the tracer
        _follower.spline = to.spline;
        _follower.RebuildImmediate();
        //Get the location of the junction point in percent along the new spline
        double startpercent = _follower.ClipPercent(to.spline.GetPointPercent(to.pointIndex));
        /*   if (Vector3.Dot(from.spline.Evaluate(from.pointIndex).forward, to.spline.Evaluate(to.pointIndex).forward) < 0f)
           {
               if (_follower.direction == Spline.Direction.Forward) _follower.direction = Spline.Direction.Backward;
               else _follower.direction = Spline.Direction.Forward;
           }*/
        if (junctionSwitch.returnLine)
        {
            _follower.direction = Spline.Direction.Backward;
        }
        else
        {
            _follower.direction = Spline.Direction.Forward;

        }

        //Position the tracer at the new location and travel excessDistance along the new spline
        _follower.SetPercent(_follower.Travel(startpercent, excessDistance, _follower.direction));
        //Notify the wagon that we have entered a new spline segment


    }

    public void ChangeUpdate()
    {
        isChange = false;
    }
}

