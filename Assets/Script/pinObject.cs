using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinObject : MonoBehaviour
{
    private bool isPinned = false;
    private Mesh mesh;
    private Vector3[] vertices;

    private Renderer rend;
    private void OnTriggerEnter(Collider other)
    {
        if  (isPinned == false){
            mesh = other.gameObject.GetComponent<MeshFilter>().mesh;
            vertices = mesh.vertices;
            rend = other.gameObject.GetComponent<Renderer>();

            List<Vector3> corners = new List<Vector3>();

            // get all corners
            for (int i = 0; i < vertices.Length; i++)
            { 
                if (vertices[i].y < rend.bounds.min.y + 1f)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.position = vertices[i] + other.transform.position;

                    Vector3 cornPos = vertices[i] + other.transform.position;
                    corners.Add(cornPos);
                }
            }
            
            // check the shortest dist 
            float shortestDist = Vector3.Distance(corners[0], this.transform.position);
            int shortestIndex = 0;
            for (int j = 0; j < corners.Count; j++)
            {
                float dist = Vector3.Distance(corners[j], this.transform.position);
                if (dist < shortestDist)
                {
                    shortestIndex = j;
                    shortestDist = dist;
                }
            }

            // set the gameobject to the shortest corner
            this.transform.position = corners[shortestIndex];

            isPinned = true;
            print("pinned");
        }
        
    }
}
