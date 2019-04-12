using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ru.lifanoff.Trap {


    public class TrapPeaks : MonoBehaviour {
        private static System.Random rnd = SecondaryFunctions.GetNewRandom();

        [SerializeField] private GameObject trapObject = null;

        private List<GameObject> allTraps = new List<GameObject>();

        #region Unity events
        void Start() {
            PeaksInit();
            DamagersInit();
        }
        #endregion

        private void PeaksInit() {
            for (float i = -2f; i <= 2f; i += 1.25f) {
                for (float j = -2f; j <= 2f; j += 1.25f) {
                    allTraps.Add(Instantiate(trapObject, transform));

                    Vector3 newPos = allTraps[allTraps.Count - 1].transform.localPosition;
                    newPos.x += i * Mathf.Clamp(Convert.ToSingle(rnd.NextDouble()), 0.6f, 0.8f);
                    newPos.z += j * Mathf.Clamp(Convert.ToSingle(rnd.NextDouble()), 0.6f, 0.8f);
                    allTraps[allTraps.Count - 1].transform.localPosition = newPos;

                    Vector3 newRot = allTraps[allTraps.Count - 1].transform.eulerAngles;
                    newRot.y = rnd.Next(0, 360);
                    allTraps[allTraps.Count - 1].transform.eulerAngles = newRot;
                }
            }
        }

        private void DamagersInit() {
            foreach (GameObject go in allTraps) {
                GameObject goChild = go.transform.GetChild(0)?.gameObject;
                if (goChild == null) continue;

                Vector3 childPos = goChild.transform.localPosition;
                childPos.y -= Mathf.Clamp(Convert.ToSingle(rnd.NextDouble()), 0.0f, 0.1f);
                goChild.transform.localPosition = childPos;
            }
        }

    }
}