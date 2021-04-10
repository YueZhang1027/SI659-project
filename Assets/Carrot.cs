using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oculus
{
    public class Carrot : MonoBehaviour
    {
        public GameObject carrot;
        public Transform rightHandTransform;

        bool Get = false;
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
            if (Get) return;
            GameObject go = GameObject.Instantiate(carrot, 
                    new Vector3(rightHandTransform.position.x, 
                                rightHandTransform.position.y + 0.3f, 
                                rightHandTransform.position.z), Quaternion.identity);
            go.name = "Carrot";
            Get = true;
        }

        private void OnTriggerExit(Collider other)
        {
            Get = false;
        }
    }
}
