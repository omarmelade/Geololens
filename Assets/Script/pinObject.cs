using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinObject : MonoBehaviour
{
    private bool isPinned = false;
    private Mesh mesh;
    private Vector3[] vertices;
    private List<Vector3> corners;
    private int shortestIndex;
    private GameObject refGO = null;

    private Renderer rend;
    private void OnTriggerEnter(Collider other)
    {
        if  (isPinned == false){
            refGO = other.gameObject;
            mesh = other.gameObject.GetComponent<MeshFilter>().mesh;
            vertices = mesh.vertices;
            rend = other.gameObject.GetComponent<Renderer>();

            corners = new List<Vector3>();

            // get all corners
            for (int i = 0; i < vertices.Length; i++)
            { 
                if (vertices[i].y < rend.bounds.min.y + 1f)
                {
                    Vector3 cornPos = vertices[i] + other.transform.position;
                    corners.Add(cornPos);
                }
            }
            
            // check the shortest dist 
            float shortestDist = Vector3.Distance(corners[0], this.transform.position);
            shortestIndex = 0;
            for (int j = 0; j < corners.Count; j++)
            {
                float dist = Vector3.Distance(corners[j], this.transform.position);
                if (dist < shortestDist)
                {
                    shortestIndex = j;
                    shortestDist = dist;
                }
            }
        }
    }


    public void UnSelectBalise()
    {
        // set the gameobject to the shortest corner
        if (corners.Count > 0)
        {
            this.transform.position = corners[shortestIndex];
            isPinned = true;
            GetComponent<BoxCollider>().enabled = false;
            refGO.GetComponent<pinnedObject>().Pin(this.gameObject);
        }
        else
        {
            refGO = null;
        }
       
    }
}
