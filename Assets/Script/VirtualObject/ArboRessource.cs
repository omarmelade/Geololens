using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArboRessource
{
    private GameObject gameObject = null;
    private List<ArboRessource> children = new List<ArboRessource>();

    public ArboRessource(GameObject go, List<ArboRessource> children){
        this.gameObject = go;
        this.children = children;
    }

    public GameObject GetGameObject(){
        return gameObject;
    }

    public List<ArboRessource> GetChildren(){
        return children;
    }

    public void AddChild(ArboRessource child){
        children.Add(child);
    }

    public bool childvide()
    {
        return children.Count == 0;
    }

    public int childCount()
    {
        return children.Count;
    }
}
