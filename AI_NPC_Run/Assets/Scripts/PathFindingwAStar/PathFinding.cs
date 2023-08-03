using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMarker
{
    //public MapLocation mapLocation;
    public float g;
    public float h;
    public float f;
    public GameObject marker;
    public PathMarker parentPathMarker;

    public PathMarker(float g, float h, float f, GameObject marker, PathMarker parentPathMarker)
    {
        this.g = g;
        this.h = h;
        this.f = f;
        this.marker = marker;
        this.parentPathMarker = parentPathMarker;
    }

    //public override bool Equals(object markerObj)
    //{
    //    if(markerObj == null && !this.GetType().Equals(markerObj.GetType()))
    //        return false;

    //    return mapLocation.Equals(((PathMarker) markerObj).mapLocation);
    //}
}


public class PathFinding : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
