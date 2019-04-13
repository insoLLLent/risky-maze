using System;
using System.Collections;
using UnityEngine;


namespace ru.lifanoff.Util {
    /// <summary>
    /// Класс, который перемещает объект вверх-вниз
    /// </summary>
    public class MovingByAxis : MonoBehaviour {
        private static System.Random rnd = SecondaryFunctions.GetNewRandom();

        private bool isUpDirection = false;

        [SerializeField] private Vector3 targetUp = new Vector3();
        [SerializeField] private Vector3 targetDown = new Vector3();

        [SerializeField] private float maxRndSpeed = 10f;
        [SerializeField] private float maxRndSleepSeconds = 3f;

        void Start() {
            transform.localPosition = targetUp;
            maxRndSpeed *= Convert.ToSingle(rnd.NextDouble());
            maxRndSleepSeconds *= Convert.ToSingle(rnd.NextDouble());
            StartCoroutine(MoveObject());
        }

        private IEnumerator MoveObject() {
            while (true) {
                transform.localPosition = Vector3.MoveTowards(
                    transform.localPosition,
                    (isUpDirection ? targetUp : targetDown),
                    Time.deltaTime * maxRndSpeed
                );

                if (isUpDirection) {
                    if (transform.localPosition == targetUp) {
                        isUpDirection = false;
                        yield return new WaitForSeconds(maxRndSleepSeconds);
                    }//fi
                } else {
                    if (transform.localPosition == targetDown) {
                        isUpDirection = true;
                        yield return new WaitForSeconds(maxRndSleepSeconds);
                    }//fi
                }//fi

                yield return null;
            }
        }

    }

}
