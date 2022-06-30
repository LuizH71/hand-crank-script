using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManivelaPlace : MonoBehaviour
{
    public GameObject ManivelainPlace;
    public GameObject ManivelaToPlace;
   

    public int numero;

    public bool NoLugar = false;

    public GameObject guiObject;
    public SimpleGrabSystem ScriptPickup;

    public char manivelaTipe;

    [HideInInspector]
    public bool tirarParede = false;



    void Update()
    {
        if(NoLugar == true)
        {
            ManivelaToPlace.transform.SetParent(null);

            ManivelaToPlace.GetComponent<Rigidbody>().isKinematic = true;

            

            ManivelaToPlace.transform.position = ManivelainPlace.transform.position;
            ManivelaToPlace.transform.rotation = ManivelainPlace.transform.rotation;
            





        }

  

    }
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("manivela" + manivelaTipe))
        {
            guiObject.SetActive(true);
        }
            
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("manivela" + manivelaTipe))
        {
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Destroy(other.gameObject);
                //ManivelainPlace.SetActive(true);

     

                ScriptPickup.hasItem = false;
                GameObject.Find("Audio Manager").GetComponent<AudioMan>().Play("Manivela");

                NoLugar = true;
          
            }
        }
        if (NoLugar == true && other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) )
            {
                Destroy(GameObject.Find("Smoke"+numero).gameObject);
                guiObject.SetActive(false);
                GameObject.Find("Audio Manager").GetComponent<AudioMan>().Play("ManivelaPlace");

                GameObject.Find("GameManager").GetComponent<GameManager>().desativarSmoke[numero] = 1 ;
                
            }
            if(Input.GetButtonDown("Fire1"))
            {
                NoLugar = false;
            }

        }
 
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("manivela"+ manivelaTipe))
        {
            guiObject.SetActive(false);
        }
        if (other.CompareTag("Player"))
        {
            guiObject.SetActive(false);
        }
    }

    private void Awake()
    {
        if(GameObject.Find("GameManager").GetComponent<GameManager>().desativarSmoke[numero] == 1)
        {
            Destroy(GameObject.Find("Smoke" + numero).gameObject);
        }


    }

}