using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace oculus
{
    public class ObjectMenu : MonoBehaviour
    {
        public Transform rightHandTransform;
        public PlayerItems playerItems;

        public GameObject Milk;
        public GameObject MilkMenu;

        public GameObject carrot;
        public GameObject carrotMenu;

        public void OnObjectClick(string name)
        {
            var dic = playerItems.itemDic;

            if (dic.ContainsKey(name) && dic[name].quantity != 0)
            {
                GameObject go = GameObject.Instantiate(dic[name].go, 
                    new Vector3(rightHandTransform.position.x, 
                                rightHandTransform.position.y + 0.3f, 
                                rightHandTransform.position.z), Quaternion.identity);
                go.name = name;

                var packet = dic[name];
                packet.quantity--;
                packet.ChangeQuantity();
                dic[name] = packet;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Collectible")
            {
                string name = other.gameObject.name;
                Destroy(other.gameObject);

                if (!playerItems.itemDic.ContainsKey(name))
                {
                    switch (name)
                    {
                        case "Milk":
                            MilkMenu.SetActive(true);
                            playerItems.itemDic.Add("Milk", new PacketObject("Milk", Milk, 1, MilkMenu));
                            break;
                        case "Carrot":
                            carrotMenu.SetActive(true);
                            playerItems.itemDic.Add("Carrot", new PacketObject("Carrot", carrot, 1, carrotMenu));
                            break;
                    }
                }
                else
                {
                    var packet = playerItems.itemDic[name];
                    packet.quantity++;
                    packet.ChangeQuantity();
                    playerItems.itemDic[name] = packet;
                }
            }
        }

        private void Start()
        {
        }

    }
}
