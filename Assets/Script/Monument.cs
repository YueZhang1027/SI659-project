using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace oculus
{
    public class Monument : MonoBehaviour
    {
        public Text hint;
        string hintText = "";
        bool isTriggered = false;

        public AudioClip encounter;

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (isTriggered) return;
            Debug.Log("Triggered!");
            hintText = hint.text;
            hint.text = "";
            StartCoroutine(FadeTo(1.0f, 5.0f));
            StartCoroutine(TypeWriter());
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
        }

        IEnumerator TypeWriter()
        {
            var wait = new WaitForSeconds(0.2f);
            foreach (char c in hintText)
            {
                hint.text += c;
                yield return wait;
            }
        }
    }
}
