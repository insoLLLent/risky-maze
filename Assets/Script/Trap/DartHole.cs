using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ru.lifanoff.Trap {
    public class DartHole : MonoBehaviour {
        [SerializeField] private GameObject dartArrowObject = null;

        private GameObject currentArrow = null;

        void Start() {
            currentArrow = Instantiate(dartArrowObject, transform);
            currentArrow.transform.SetParent(null);
            currentArrow.SetActive(true);
        }

    }
}
