using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject firstPerson;
    public GameObject thirdPerson;
    private bool cam1;
    private bool cam2;
    // Start is called before the first frame update
    void Start()
    {
        cam1 = true;
        cam2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && cam1 == true)
        {
            thirdPerson.SetActive(false);
            firstPerson.SetActive(true);
            cam1 = false;
            cam2 = true;
        }
       else if(Input.GetKeyDown(KeyCode.Tab) && cam2 == true)
        {
            firstPerson.SetActive(false);
            thirdPerson.SetActive(true);
            cam1 = true;
            cam2 = false;
        }
    }
}
