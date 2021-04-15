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

        public void ChangeQuantity(int changeCount)
        {
            this.quantity += changeCount;
            Text menuItem = menu.GetComponentInChildren<Text>();
            menuItem.text = "x" + quantity.ToString();
        }
    }

    public class ObjectMenu : MonoBehaviour
    {
        Dictionary<string, PacketObject> itemDic = new Dictionary<string, PacketObject>();
        public GameObject Apple;
        public GameObject AppleMenu;

        public Transform rightHandTransform;

        public GameObject Milk;
        public GameObject MilkMenu;

        public GameObject carrot;
        public GameObject carrotMenu;

        public void OnObjectClick(string name)
        {
            if (itemDic.ContainsKey(name) && itemDic[name].quantity > 0)
            {
                GameObject go = GameObject.Instantiate(itemDic[name].go, 
                    new Vector3(rightHandTransform.position.x, 
                                rightHandTransform.position.y + 0.3f, 
                                rightHandTransform.position.z), Quaternion.identity);
                go.name = name;
                itemDic[name].ChangeQuantity(-1);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Collectible")
            {
                string name = other.gameObject.name;
                Destroy(other.gameObject);

                if (itemDic.ContainsKey(name))
                {
                    itemDic[name].ChangeQuantity(1);
                    /*switch (name)
                    {
                        case "Apple":
                            AppleMenu.SetActive(true);
                            itemDic.Add("Apple", new PacketObject("Apple", Apple, 1, AppleMenu));
                            break;
                        case "Milk":
                            MilkMenu.SetActive(true);
                            itemDic.Add("Milk", new PacketObject("Milk", Milk, 1, MilkMenu));
                            break;
                        case "Carrot":
                            carrotMenu.SetActive(true);
                            itemDic.Add("Carrot", new PacketObject("Carrot", carrot, 1, carrotMenu));
                            break;
                    }*/
                }
            }
        }

        private void Awake()
        {
            itemDic.Add("Apple", new PacketObject("Apple", Apple, 3, AppleMenu));
            itemDic.Add("Milk", new PacketObject("Milk", Milk, 0, MilkMenu));
            itemDic.Add("Carrot", new PacketObject("Carrot", carrot, 0, carrotMenu));
        }

    }
}
