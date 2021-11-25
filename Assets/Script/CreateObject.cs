using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{

    public GameObject gameObject;
    public GameObject camera;

    public void CreateNewObject()
    {
        Vector3 camVect = new Vector3(camera.transform.position.x, camera.transform.position.y - gameObject.transform.localScale.y, camera.transform.position.z + 0.8f);
        Instantiate(gameObject, camVect, Quaternion.identity);
    }

    public void CreateNewObjectOnBalise()
    {
        GameObject[] balises = GameObject.FindGameObjectsWithTag("Balise");
        if(balises.Length != 0)
        {
            GameObject balise = balises[0];
            Vector3 baliseVect = new Vector3(balise.transform.position.x, balise.transform.position.y, balise.transform.position.z);
            Vector3 cornerCube = new Vector3(
                baliseVect.x + 1 / 2 * gameObject.transform.localScale.x,
                baliseVect.y + 1/2 * gameObject.transform.localScale.y,
                baliseVect.z
                );

            Instantiate(gameObject, cornerCube, Quaternion.identity);
        }
    }
}
