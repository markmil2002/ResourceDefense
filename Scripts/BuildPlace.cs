using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlace : MonoBehaviour {

    public GameObject[] towerPrefab;

    void OnMouseDownAsButton()
    {
        //Material newMaterial = GetComponent<MeshRenderer>().material = Resources.Load<Material>("Assets/Textures/BuildPlaceClicked");
        //gameObject.GetComponent<MeshRenderer>().material = newMaterial;
    }
    //Attempt as Ienumerator
    void OnMouseUpAsButton()
    {
        //Build Stuff
        
        //Material newMaterial = GetComponent<MeshRenderer>().material = Resources.LoadAssetAtPath<Material>("Assets/Textures/BuildPlace");
        //gameObject.GetComponent<MeshRenderer>().material = newMaterial;
        GameObject g = (GameObject)Instantiate(towerPrefab[1]);
        g.transform.position = transform.position + Vector3.up;
    }
}
