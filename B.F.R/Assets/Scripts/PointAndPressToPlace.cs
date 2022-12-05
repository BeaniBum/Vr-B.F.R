using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndPressToPlace : MonoBehaviour
{
    public Material neutralMaterial;
    public Material hoverMaterial;
    public GameObject Slot;
    public GameObject jumpPad;
    public GameObject boostPad;
    public GameObject movingPlatform;
    public MeshRenderer Collider;
    public Vector3 position;


    // Start is called before the first frame update
    void Start()
    {
       
        //Collider = Slot.transform.GetChild(1).gameObject;
        neutralMaterial = Collider.GetComponent<Renderer>().material;
        position = Slot.transform.position;
        
    }


    public void hoverColor()
    {
        Collider.material = hoverMaterial;
    }

    public void neutralColor()
    {
        Collider.material = neutralMaterial;
    }

    public void replace()
    {
        Instantiate(jumpPad, position,Slot.transform.rotation);
        Destroy(Slot);
    }

    void Update()
    {
        
    }
}
