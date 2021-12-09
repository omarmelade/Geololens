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

            Debug.Log(rend.bounds.min);
            for (int i = 0; i < vertices.Length; i++)
            {
                if (vertices[i].y == rend.bounds.min.y)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = vertices[i];

                }
                if (vertices[i].y <= rend.bounds.min.y+1)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.position = vertices[i];
                }
            }
            isPinned = true;
            print("pinned");
        }
        
    }
}
