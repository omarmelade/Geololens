using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuDislay : MonoBehaviour
{

    public GameObject menu;

    public void afficheMenu()
    {
        if (menu.tag == "maj_arbo")
        {
            maj_arbo();
        }
        menu.SetActive(!menu.active);
    }

    public void maj_arbo()
    {
        suppressionArbo();
        var tree = GameObject.FindGameObjectsWithTag("Virtual Scene")[0].GetComponent<VirtualObjectScene>().GetVirtualTree();
        int nb_go = 0;
        string indent = "";
        creationArbo(tree, indent, nb_go);

        //Code de mise ? jour Arborescence
        /*List<ObjetScene> listeObjet = new List<ObjetScene>();
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
                }*/
    }

    public void creationArbo(List<ArboRessource> tree, string indent, int nb_go)
    {
     
        Transform ArborescenceBalise = menu.transform.GetChild(4);
        float y = 0.0f;
        string s = "";
        foreach (ArboRessource arbo in tree)
        {
            GameObject go = arbo.GetGameObject();
            s = indent + go.GetComponent<VirtualObject>().GetName();
            nb_go++;
            Debug.Log(nb_go);
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
            if (!arbo.childvide())
            {
                Debug.Log("Enfant");
                indent = indent + "   "; 
                creationArbo(arbo.GetChildren(), indent + ">", nb_go);
                nb_go = nb_go + arbo.childCount();
                indent = "";
            }
        }
    }

    public void suppressionArbo()
    {
        int numberOfChild = 5;
        menu.transform.rotation = new Quaternion(0, 0, 0, 0);
        for (int i = menu.transform.childCount; i > numberOfChild; i--)
        {
            Destroy(menu.transform.GetChild(i - 1).gameObject);
        }
    }
}
