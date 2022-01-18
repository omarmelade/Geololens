using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{

    public GameObject gameObject;
    Camera camera;

    public void CreateNewObject()
    {
        camera = Camera.main;
        Vector3 camVect = new Vector3(camera.transform.position.x, camera.transform.position.y - (gameObject.transform.localScale.y), camera.transform.position.z + 0.8f);
        GameObject[] bats = GameObject.FindGameObjectsWithTag("Bat");

        if (gameObject.tag == "Balise")
        {
            camVect = new Vector3(camera.transform.position.x, camera.transform.position.y - (gameObject.transform.localScale.y * 4), camera.transform.position.z + 0.8f);
        }
        else if (gameObject.tag == "Bat" && bats.Length == 0)
        {
            camVect = new Vector3(camera.transform.position.x, camera.transform.position.y - (gameObject.transform.localScale.y), camera.transform.position.z + 50f);
        }

        Instantiate(gameObject, camVect, Quaternion.identity);
    }

    public void CreateNewObjectOnBalise()
    {
        GameObject[] balises = GameObject.FindGameObjectsWithTag("Balise");
        if(balises.Length != 0)
        {
            Debug.LogWarning("balises trouve");
            GameObject balise = balises[0];
            Vector3 baliseVect = new Vector3(balise.transform.position.x, balise.transform.position.y, balise.transform.position.z);
            Vector3 cornerCube = new Vector3(
                baliseVect.x + 1 / 2 * gameObject.transform.localScale.x,
                baliseVect.y + 1 / 2 * gameObject.transform.localScale.y,
                baliseVect.z
             );

            Instantiate(gameObject, cornerCube, Quaternion.identity);
        }
    }
}
