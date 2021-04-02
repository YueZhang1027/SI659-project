using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace oculus
{
    public class Monument : MonoBehaviour
    {
        public Text hint;
        bool isTriggered = false;
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (isTriggered) return;
            Debug.Log("Triggered!");
            StartCoroutine(FadeTo(1.0f, 5.0f));
            isTriggered = true;
        }

        IEnumerator FadeTo(float aValue, float aTime)
        {
            float alpha = hint.color.a;
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
            {
                Color newColor = new Color(50f / 255, 50f / 255, 50f / 255, Mathf.Lerp(alpha, aValue, t));
                hint.color = newColor;
                yield return null;
            }

            this.gameObject.SetActive(false);
        }
    }
}
