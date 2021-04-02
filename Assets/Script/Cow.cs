using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace oculus
{
    public class Cow : MonoBehaviour
    {
        public GameObject bridge;
        public Text dialog;

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

            }
            else if (other.name == "Bucket")
            {
            }
            else
            {
                dialog.text = "Maybe something red and juicy...";
            }
        }
    }
}
