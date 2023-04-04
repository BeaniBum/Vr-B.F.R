using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndPressToPlace : MonoBehaviour
{
    public Material neutralMaterial;
    public Material hoverMaterial;
    public GameObject Slot;
    public GameObject selection;
    public GameObject Parent;
    public GameObject Placed;
    public MeshRenderer Collider;

    public Vector3 position;

    private StateManager statemanager;
    public PlayerMovement playermovement;


    // Start is called before the first frame update
    void Start()
    { 
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
        if(playermovement.buildMaterial > 0)
        {
            Placed = Instantiate(selection, position, Slot.transform.rotation);
            Destroy(Slot);
            Placed.transform.SetParent(Parent.transform);
            playermovement.buildMaterial--;
        }
        
    }

    void Update()
    {
        
    }
}
