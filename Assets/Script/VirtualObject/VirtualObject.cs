using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualObject : MonoBehaviour
{
    protected GameObject parent = null;
    protected List<GameObject> children = new List<GameObject>();
    protected string virtualName = "";
    protected string iconName = "";
    protected Color highlightColor = new Color(1.0f,0.0f,0.0f);
    protected Material realMaterial = null;
    protected bool highlighted = false;
    protected bool useGravity = false;

    public void Start() {
        if(this.gameObject.GetComponent<Renderer>() != null) {
            realMaterial = this.gameObject.GetComponent<Renderer>().material;
        }
    }

    public virtual void AddChild(GameObject child) {
        if(children.Contains(child)) {
            Debug.LogWarning("Child cannot be a child of its parent twice.");
            return;
        }
        if(child.GetComponent<VirtualObject>() == null) {
            Debug.LogWarning("Cannot add a child that isn't a VirtualObject.");
            return;
        }
        child.GetComponent<VirtualObject>().SetParent(this.gameObject);
        children.Add(child);
        this.OnAddChild(child);
    }

    /**
     * Called when a new child was added
     * Rewrite this in childs classes
     */
    public virtual void OnAddChild(GameObject child) { }

    public virtual void SetParent(GameObject parent){
        this.parent = parent;
        this.OnSetParent(parent);
    }

    /**
     * Called when the parent is set
     * Rewrite this in childs classes
     */
    protected virtual void OnSetParent(GameObject parent) { }

    public GameObject GetParent() {
        return parent;
    }

    public List<GameObject> GetChildren() {
        return children;
    }

    public string GetName() {
        return virtualName;
    }

    public string GetIcon() {
        return iconName;
    }

    public void SetHighlightColor(Color color){
        this.highlightColor = color;
    }

    public Color GetHighlightColor(){
        return highlightColor;
    }

    public virtual void DeleteOnScene() {
        foreach (GameObject child in children){
            child.GetComponent<VirtualObject>().DeleteOnScene();
        }
        Destroy(this);
    }

    public virtual void Highlight() {
        if(this.gameObject.GetComponent<Renderer>() == null) {
            Debug.LogWarning("Cannot highlight a GameObject without renderer.");
        }
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", highlightColor);
        this.highlighted = true;
    }

    public virtual void removeHighlight() {
        if(this.gameObject.GetComponent<Renderer>() == null) {
            Debug.LogWarning("Cannot remove highlight on a GameObject without renderer.");
            return;
        }
        this.gameObject.GetComponent<Renderer>().material = realMaterial;
        this.highlighted = false;
    }

    /**
     * Called when the highlight of an object is toggled
     * Rewriteme in childs classes
     */
    protected virtual void OnHighlightChanged() { }

    public void ApplyGravity() {
        if(this.gameObject.GetComponent<Rigidbody>() == null){
            Debug.LogWarning("Cannot apply gravity on GameObject without component Rigidbody");
            return;
        }
        this.OnApplyGravity();
    }

    public void RemoveGravity()
    {
        if (this.gameObject.GetComponent<Rigidbody>() == null)
        {
            Debug.LogWarning("Cannot remove gravity on GameObject without component Rigidbody");
            return;
        }
        this.OnRemoveGravity();
        
    }

    /**
     * Rewite me in childs classes
     */
    protected virtual void OnApplyGravity() {
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    /**
     * Rewite me in childs classes
     */
    protected virtual void OnRemoveGravity()
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    public virtual void ShowAccurateUI() {

    }

    public virtual void HideAccurateUI() {

    }
}