using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cow : MonoBehaviour
{
    public GameObject bridge;
    public Text dialog;
    public AudioClip successClip;

    bool Completed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == "Apple")
        {
            other.gameObject.SetActive(false);
            Completed = true;
            dialog.text = "Thanks! You are the best!";

            bridge.SetActive(true);

            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = successClip;
            audio.Play();
        }
        else if (other.name == "Milk" && Completed) // 
        {
            Debug.Log("Milk!");
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (!Completed)
        {
            dialog.text = "Maybe something red and juicy...";
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = successClip;
            audio.Play();
        }
    }
}

