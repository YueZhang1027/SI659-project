using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace oculus
{
    public class Pig : MonoBehaviour
    {
        public GameObject bridge;
        bool Completed = false;
        public Text dialog;
        public AudioClip successClip;

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
                dialog.text = "Cool~ But not the best!";
            }
            else if (other.name == "Carrot")
            {
                bridge.SetActive(true);
                dialog.text = "Smart! Are you MC player?";
                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = successClip;
                audio.Play();
            }
        }
    }
}
