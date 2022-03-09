using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class CreateObject : MonoBehaviour
{

    public GameObject objet;
    Camera camera = Camera.current;

    public void CreateNewObject()
    {
        camera = Camera.main;
        Vector3 camVect = new Vector3(camera.transform.position.x, camera.transform.position.y - (objet.transform.localScale.y), camera.transform.position.z + 0.8f);
        GameObject[] bat = GameObject.FindGameObjectsWithTag("Bat");

        // only one Bat can be instantiate
        if (objet.tag == "Bat" && bat.Length == 0)
        {
            camVect = new Vector3(camera.transform.position.x, camera.transform.position.y - (objet.transform.localScale.y), camera.transform.position.z + 45f);
        }
        else
        {
            camVect = new Vector3(camera.transform.position.x, camera.transform.position.y - (objet.transform.localScale.y * 4), camera.transform.position.z + 0.8f);

        }
        GameObject go = (GameObject) Instantiate(objet, camVect, Quaternion.identity);
        GameObject.FindGameObjectsWithTag("Virtual Scene")[0].GetComponent<VirtualObjectScene>().AddVirtualChild(go.gameObject);
        GameObject.FindGameObjectsWithTag("Virtual Scene")[0].GetComponent<VirtualObjectScene>().GetVirtualTreeText();
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
                baliseVect.x + 1 / 2 * objet.transform.localScale.x,
                baliseVect.y + 1 / 2 * objet.transform.localScale.y,
                baliseVect.z
             );

            Instantiate(objet, cornerCube, Quaternion.identity);
        }
    }
}
