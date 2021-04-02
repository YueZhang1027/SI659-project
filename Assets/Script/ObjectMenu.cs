using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace oculus
{
    public struct PacketObject
    {
        public string name;
        public GameObject go;
        public int quantity;
        public GameObject menu;

        public PacketObject(string name, GameObject go, int quantity, GameObject menu)
        {
            this.name = name;
            this.go = go;
            this.quantity = quantity;
            this.menu = menu;
        }

        public void ReduceQuantity()
        {
            quantity--;
            Text menuItem = menu.GetComponentInChildren<Text>();
            menuItem.text = "x" + quantity.ToString();
        }
    }

    public class ObjectMenu : MonoBehaviour
    {
        static ObjectMenu instance;

        public static ObjectMenu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjectMenu();
                }
                return instance;
            }
        }

        

        static Dictionary<string, PacketObject> dic = new Dictionary<string, PacketObject>();
        public GameObject apple;
        public GameObject appleMenu;

        public Transform rightHandTransform;
        //public 

        private void Awake()
        {
            instance = this;
            if (!dic.ContainsKey("Apple"))
            {
                dic.Add("Apple", new PacketObject("Apple", apple, 3, appleMenu));
            }
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
            if (dic.ContainsKey(name) && dic[name].quantity != 0)
            {
                GameObject go = Instantiate(dic[name].go, 
                    new Vector3(rightHandTransform.position.x, 
                                rightHandTransform.position.y + 0.3f, 
                                rightHandTransform.position.z), Quaternion.identity);
                go.name = name;
                dic[name].ReduceQuantity();
            }
        }
    }
}
