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

    public class PlayerItems : MonoBehaviour
    {
        private static PlayerItems playerItemInstance;

        public static Dictionary<string, PacketObject> itemDic = new Dictionary<string, PacketObject>();
        public GameObject Apple;
        public GameObject AppleMenu;

        private PlayerItems()
        {
            itemDic.Clear();
            itemDic.Add("Apple", new PacketObject("Apple", Apple, 3, AppleMenu));
        }

        public static PlayerItems GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (playerItemInstance == null)
            {
                playerItemInstance = new PlayerItems();
            }
            return playerItemInstance;
        }
    }
}
