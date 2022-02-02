using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuDislay : MonoBehaviour
{

    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void afficheMenu()
    {
        menu.SetActive(!menu.active);
        if (menu.tag == "Arborescence")
        {
            Transform ArborescenceBalise = menu.transform.GetChild(0);
            string s = "";
            float y = 0.0f;
            int nb_go = 0;
            //Code de mise à jour Arborescence
            List<ObjetScene> listeObjet = new List<ObjetScene>();
            Object[] GameobjectList = Resources.FindObjectsOfTypeAll(typeof(GameObject));
            foreach (GameObject go in GameobjectList)
            {
                if (go.GetComponent<Saveable>() && go.active)
                {
                    if(go.tag == "Banc")
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
                    Debug.Log(s);
                    nb_go++;
                    Debug.Log(nb_go);
                    y = -0.015f*nb_go;
                    Debug.Log(y);
                    TextMeshPro text = Instantiate(ArborescenceBalise.GetComponent<TextMeshPro>());
                    text.text = s;
                    text.transform.parent = ArborescenceBalise;
                    text.transform.position = new Vector3(text.transform.parent.position.x, text.transform.parent.position.y + y, text.transform.parent.position.z);
                }
            }
        }
    }
}
