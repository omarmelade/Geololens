using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectInteraction : MonoBehaviour
{
    public GameObject model;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toogleBtn()
    {
        model.GetComponent<Rigidbody>().isKinematic = !model.GetComponent<Rigidbody>().isKinematic;
        if (model.GetComponent<Rigidbody>().isKinematic)
        {
            model.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z + 0.7f);
            model.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public void toogleGravity()
    {
        Debug.Log("Entrer gravity");
        model = SetLastObject.lastSelected;
        Debug.Log(model);
        if (model != null)
        {
            Debug.Log(model.GetComponent<VirtualObject>().isUsingGravity());
            if (model.GetComponent<VirtualObject>().isUsingGravity())
            {
                model.GetComponent<VirtualObject>().RemoveGravity();
            }
            else
            {
                model.GetComponent<VirtualObject>().ApplyGravity();
            }
        }
    }

    public void deleteObject()
    {
        Debug.Log("DeleteObject");
        model = SetLastObject.lastSelected;
        Debug.Log(model);
        if (model != null)
        {
            model.GetComponent<VirtualObject>().DeleteOnScene();
            model = null;
            SetLastObject.lastSelected = null;
            if (GameObject.FindGameObjectsWithTag("Arborescence").Length > 0)
            {
                Debug.Log("Jtai dit que j'etais dedans");
                GameObject.FindGameObjectsWithTag("Arborescence")[0].GetComponent<MenuDislay>().maj_arbo();
            }
        }
    }

    public void changeDimension()
    {
        Debug.Log("ChangeDimension");
        model = SetLastObject.lastSelected;
        Debug.Log(model);
        if (model != null)
        {
            Debug.Log(model.GetComponent<VirtualObject>().isAccurateUI());
            if (model.GetComponent<VirtualObject>().isAccurateUI())
            {
                model.GetComponent<VirtualObject>().HideAccurateUI();
            }
            else
            {
                model.GetComponent<VirtualObject>().ShowAccurateUI();
            }
        }
    }
}