using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinObject : MonoBehaviour
{
    public bool isPinned = false;
    private Mesh mesh;
    private Vector3[] vertices;
    private List<Vector3> corners = new List<Vector3>();
    private int shortestIndex;
    private GameObject refGO = null;
    public GameObject RefGO
    {
        get => refGO;
        set => refGO = value;
    }

    private Renderer rend;
    private void OnTriggerEnter(Collider other)
    {
        if  (isPinned == false){
            refGO = other.gameObject;
            mesh = other.gameObject.GetComponent<MeshFilter>().mesh;
            vertices = mesh.vertices;
            rend = other.gameObject.GetComponent<Renderer>();

            corners = new List<Vector3>();
            print("début");

            // get all corners
            for (int i = 0; i < vertices.Length; i++)
            { 
                if (vertices[i].y < rend.bounds.min.y + 1f)
                {
                    Vector3 cornPos = vertices[i] + other.transform.position;
                    corners.Add(cornPos);
                }
            }
            print("milieu");
            
            // check the shortest dist 
            if(corners.Count <= 0){
                print("ya rien dans corners");
            }
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
            print("fin");
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
            refGO.GetComponent<VirtualObject>().AddChild(this.gameObject);
        }
        else
        {
            refGO = null;
        }
       
    }

    public void RemovePin()
    {
        refGO.GetComponent<pinnedObject>().UnPin(this.gameObject);
        GetComponent<VirtualObject>().DeleteOnScene();
    }


}
