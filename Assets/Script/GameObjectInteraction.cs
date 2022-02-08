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
        model = SetLastObject.lastSelected;
        if (model != null)
        {
            camera = Camera.main;
            model.GetComponent<Rigidbody>().useGravity = true;
            model.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log(model);
            model.GetComponent<Rigidbody>().isKinematic = !model.GetComponent<Rigidbody>().isKinematic;
            if (model.GetComponent<Rigidbody>().isKinematic)
            {
                model.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z + 0.7f);
                model.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }

    public void deleteObject()
    {
        model = SetLastObject.lastSelected;
        if (model != null)
        {
            Destroy(model);
        }
    }

    public void changeDimension()
    {
        model = SetLastObject.lastSelected;
        Debug.Log(model);
    }
}