using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuDislay : MonoBehaviour
{

    public GameObject menu;

    public void afficheMenu()
    {
        if (menu.tag == "Arborescence")
        {
            maj_arbo();
        }
        menu.SetActive(!menu.active);
    }

    public void maj_arbo()
    {
        int numberOfChild = 5;
        menu.transform.rotation = new Quaternion(0, 0, 0, 0);
        Debug.Log(menu.transform.childCount);
        if (menu.transform.childCount > numberOfChild)
        {
            Debug.Log("Suppression");
            Debug.Log(menu.transform.GetChild(numberOfChild).gameObject);
            Destroy(menu.transform.GetChild(numberOfChild).gameObject);
        }
        Transform ArborescenceBalise = menu.transform.GetChild(4);
        string s = "";
        float y = 0.0f;
        int nb_go = 0;

        //Code de mise ? jour Arborescence
        List<ObjetScene> listeObjet = new List<ObjetScene>();
        Object[] GameobjectList = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (GameObject go in GameobjectList)
        {
            if (go.GetComponent<Saveable>() && go.active)
            {
                if (go.tag == "Banc")
                {
                    s = "- Table de Pique Nique";
                }
                if (go.tag == "Balise")
                {
                    s = "- Balise";
                }
                if (go.tag == "Plateau")
                {
                    s = "- Plateau";
                }
                if (go.tag == "Bat")
                {
                    s = "- Quatrième ailes";
                }
                if (go.tag == "Bag")
                {
                    s = "- Sac";
                }
                nb_go++;
                y = -0.015f * nb_go;
                TextMeshPro text = Instantiate(ArborescenceBalise.GetComponent<TextMeshPro>(), menu.transform);
                text.text = s;
                text.transform.parent = menu.transform;
                text.transform.position = new Vector3(ArborescenceBalise.position.x, ArborescenceBalise.position.y + y, ArborescenceBalise.position.z);
                go.GetComponent<VirtualObject>().textArbo = text; 
                if (SetLastObject.lastSelected == go)
                {
                    go.GetComponent<VirtualObject>().textArbo.color = Color.green;
                }
            }
        }
    }
}
