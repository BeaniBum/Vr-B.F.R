using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndPressToPlace : MonoBehaviour
{
    public Material neutralMaterial;
    public Material hoverMaterial;
    public GameObject Slot;
    public MeshRenderer Collider;

    // Start is called before the first frame update
    void Start()
    {
       
        //Collider = Slot.transform.GetChild(1).gameObject;
        neutralMaterial = Collider.GetComponent<Renderer>().material;
        
    }


    public void hoverColor()
    {
        Collider.material = hoverMaterial;
    }

    public void neutralColor()
    {
        Collider.material = neutralMaterial;
    }

    void Update()
    {
        
    }
}
