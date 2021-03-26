using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oculus
{
    public class ObjectMenu : MonoBehaviour
    {
        public GameObject window;

        //public Dictionary<string, GameObject> dic = new Dictionary<string, GameObject>();
        public GameObject apple;
        private void Awake()
        {
            
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void OnObjectClick(string name)
        {
            Instantiate(apple, Vector3.zero, Quaternion.identity);
            /*if (dic.ContainsKey(name))
            {
                Instantiate(dic[name], window.transform);
            }*/
        }
    }
}
