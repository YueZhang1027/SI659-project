using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace oculus
{
    public class ObjectMenu : MonoBehaviour
    {
        public Transform rightHandTransform;

        public void OnObjectClick(string name)
        {
            var dic = PlayerItems.itemDic;

            if (dic.ContainsKey(name) && dic[name].quantity != 0)
            {
                GameObject go = GameObject.Instantiate(dic[name].go, 
                    new Vector3(rightHandTransform.position.x, 
                                rightHandTransform.position.y + 0.3f, 
                                rightHandTransform.position.z), Quaternion.identity);
                go.name = name;
                dic[name].ReduceQuantity();
            }
        }
    }
}
