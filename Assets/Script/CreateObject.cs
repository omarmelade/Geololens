using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class CreateObject : MonoBehaviour
{

    public GameObject objet;
    Camera camera;

    public void CreateNewObject()
    {
        camera = Camera.main;
        //Vector3 camVect = new Vector3(camera.transform.position.x, camera.transform.position.y - (objet.transform.localScale.y), camera.transform.position.z + 0.8f);
        Vector3 camVect;
        GameObject[] bat = GameObject.FindGameObjectsWithTag("Bat");
        Vector3 camForward = Camera.current.transform.forward;
        // only one Bat can be instantiate
        if (objet.tag == "Bat" && bat.Length == 0)
        {
            camVect = Camera.current.transform.position + new Vector3(Vector3.Dot(camForward,new Vector3(1f,0f,0f)),0f,Vector3.Dot(camForward,new Vector3(0f,0f,1f)))*45f;
        }
        else
        {
            camVect = Camera.current.transform.position + new Vector3(Vector3.Dot(camForward,new Vector3(1f,0f,0f)),0f,Vector3.Dot(camForward,new Vector3(0f,0f,1f)))*1.2f;
        }
        GameObject go = (GameObject) Instantiate(objet, camVect, Quaternion.identity);
        GameObject.FindGameObjectsWithTag("Virtual Scene")[0].GetComponent<VirtualObjectScene>().AddVirtualChild(go.gameObject);
        GameObject.FindGameObjectsWithTag("Virtual Scene")[0].GetComponent<VirtualObjectScene>().GetVirtualTreeText();
        if (GameObject.FindGameObjectsWithTag("Arborescence").Length > 0)
        {
            GameObject.FindGameObjectsWithTag("Arborescence")[0].GetComponent<MenuDislay>().maj_arbo();
        }

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
