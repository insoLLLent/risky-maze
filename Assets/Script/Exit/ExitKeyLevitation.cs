using System.Collections;
using UnityEngine;

namespace ru.lifanoff.Exit {

    /// <summary>
    /// Скрипт для ключа от выхода
    /// </summary>
    public class ExitKeyLevitation : MonoBehaviour {

        private Vector3 downPosition = Vector3.zero;
        private Vector3 upPosition = Vector3.zero;

        void Start() {
            downPosition = transform.position;
            upPosition = transform.position;
            upPosition.y += 0.15f;

            StartCoroutine(Levitation());
        }

        private IEnumerator Levitation() {
            float pingPong = 0f;
            float smoothStep = 0f;

            while (true) {
                if (!PauseController.isPaused) {
                    pingPong = Mathf.PingPong(Time.time, 1f);
                    smoothStep = Mathf.SmoothStep(0.0f, 1.0f, pingPong);
                }

                transform.position = Vector3.Lerp(downPosition, upPosition, smoothStep);

                yield return null;
            }
        }

    }//class
}//namespace
