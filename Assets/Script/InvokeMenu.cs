using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace oculus
{
    public class InvokeMenu : MonoBehaviour
    {
        public GameObject menu;
        public Transform player;
        //bool isOpened = false;
        Animator menuAnimator;

        private void Start()
        {
            menuAnimator = menu?.GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Hand")
            {
                bool isOpened = menu.activeSelf;
                if (isOpened)
                {
                    //menuAnimator.ResetTrigger("Open");
                    menuAnimator.SetTrigger("Close");
                    StartCoroutine(Wait());
                }
                else
                {
                    SetInitPosition();
                    menu.SetActive(true);
                    //menuAnimator.ResetTrigger("Close");
                    menuAnimator.SetTrigger("Open");
                }
            }
        }

        IEnumerator Wait()
        {
             yield return new WaitForSeconds(4 / 3f);
             menu.SetActive(false);
        }

        void SetInitPosition()
        {
            menu.transform.position = new Vector3(player.position.x, player.position.y - 1f, player.position.z);
            menu.transform.position += player.forward * 0.5f;
            menu.transform.rotation = Quaternion.Euler(15f, player.rotation.eulerAngles.y, 0f);
        }
    }
}
