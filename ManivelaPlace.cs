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
    //Will grab crank from the players hand and put on the right place to disable the object
        if(NoLugar == true)
        {
            ManivelaToPlace.transform.SetParent(null);

            ManivelaToPlace.GetComponent<Rigidbody>().isKinematic = true;

            

            ManivelaToPlace.transform.position = ManivelainPlace.transform.position;
            ManivelaToPlace.transform.rotation = ManivelainPlace.transform.rotation;
            





        }

  

    }
    // wiil activete the text to inform player hou to put the crank(a tutorial text)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("manivela" + manivelaTipe))
        {
            guiObject.SetActive(true);
        }
            
    }
    
    //when the crank is in place and the player press F, a sound will play.
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
        //when the player is near and the crank is in place, pressing F, will play another sound like if the crank was turned and then the game object that you wanted will be destroyed
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


//Will disable the U.I text if the player get's far from the crank place
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

//if the game object was destroyed and the game was save, when the game is load, the game object will be destroyed again. I use int beacuse PlayerPrefes don't have bool.
    private void Awake()
    {
        if(GameObject.Find("GameManager").GetComponent<GameManager>().desativarSmoke[numero] == 1)
        {
            Destroy(GameObject.Find("Smoke" + numero).gameObject);
        }


    }

}
