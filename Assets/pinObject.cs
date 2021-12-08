using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinObject : MonoBehaviour
{
    private bool isPinned = false;
    private Mesh mesh;
    private Vector3[] vertices;
    private void OnTriggerEnter(Collider other)
    {
        if  (isPinned == false){
            mesh = other.gameObject.GetComponent<MeshFilter>().mesh;
            vertices = mesh.vertices;
            for (int i = 0; i < vertices.Length; i++){
                print(vertices[i]);
            }
            isPinned = true;
            print("pinned");
        }
        
    }
}
