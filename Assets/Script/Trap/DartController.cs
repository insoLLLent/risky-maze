using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ru.lifanoff.Trap {
    public class DartController : MonoBehaviour {
        private static System.Random rnd = SecondaryFunctions.GetNewRandom();

        [SerializeField] private GameObject dartHoleObject = null;

        private List<GameObject> allTraps = new List<GameObject>();

        void Start() {
            PeaksInit();
        }

        /// <summary>Инициализация и позиционирование ловушек</summary>
        private void PeaksInit() {
            for (float i = -0.75f; i <= 0.75f; i += 0.75f) {
                for (float j = 1.25f; j <= 2.75f; j += 0.75f) {
                    allTraps.Add(Instantiate(dartHoleObject, transform));

                    Vector3 newPos = allTraps[allTraps.Count - 1].transform.localPosition;
                    newPos.x += i * Mathf.Clamp(Convert.ToSingle(rnd.NextDouble()), 0.8f, 1f);
                    newPos.y += j * Mathf.Clamp(Convert.ToSingle(rnd.NextDouble()), 0.8f, 1f);
                    newPos.z -= 2f;
                    allTraps[allTraps.Count - 1].transform.localPosition = newPos;

                    Vector3 newRot = allTraps[allTraps.Count - 1].transform.eulerAngles;
                    newRot.z = rnd.Next(0, 360);
                    allTraps[allTraps.Count - 1].transform.eulerAngles = newRot;
                }
            }
        }

    }
}