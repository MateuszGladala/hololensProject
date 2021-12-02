using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class Interactions : MonoBehaviour, IFocusable, IInputClickHandler
{
    public GameObject windZone;
    public bool Rotating, highlight;
    public float RotationSpeed;
    public GameObject cursor;
    public float thrust = 500.0f;
    float x = 1;
    float y = 1;
    float z = 1;
    float new_x, new_y, new_z;
    Color originalColor;
    Color highlightedColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().useGravity != true)
        {
            if (Rotating)
                this.transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
        }
       
        if(highlight)
        GetComponent<Renderer>().material.color = highlightedColor;
        
    }

    public void OnFocusEnter()
    {
        Rotating = true;
        highlight = true;
        // GetComponent<Renderer>().material.EnableKeyword("_ENVIRONMENT_COLORING");
       originalColor = GetComponent<Renderer>().material.color;
       highlightedColor = originalColor/ (float)0.8;
    }

    public void OnFocusExit()
    {
        Rotating = false;
        //highlight = false;
        highlightedColor = originalColor;
       // GetComponent<Renderer>().material.DisableKeyword("_ENVIRONMENT_COLORING");
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (gameObject.tag == "cube")
        {
            moveCube();
        }
        else if (gameObject.tag == "sphere")
        {
            moveSphere();
        }
        else if (gameObject.tag == "capsule") 
        {
            capsuleManipulation();
        }
        else if (gameObject.tag == "cylinder")
        {
            cylinderek();
        }
        else if (gameObject.tag == "tree")
        {
            activateWind();
        }      

    }

    void moveCube()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    void activateWind()
    {
        windZone.SetActive(true);
    }

    void capsuleManipulation()
    {
        new_x = (float)(x - 0.1);
        new_y = (float)(y - 0.1);
        new_z = (float)(z - 0.1);
        x = new_x;
        y = new_y;
        z = new_z;
        Vector3 newScale = new Vector3(new_x, new_y, new_z);
        gameObject.transform.localScale = newScale;
    }

    void cylinderek()
    {
       originalColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        highlightedColor = originalColor / (float)0.8;
    }

    void moveSphere()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().AddForce(0, 0, thrust, ForceMode.Impulse);
    }
}
