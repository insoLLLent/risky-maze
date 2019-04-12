using UnityEngine;

using ru.lifanoff.Intarface;

namespace ru.lifanoff.Player {

    public class DamagePlayer : MonoBehaviour {

        public int countDecreaseLive = 1;

        void OnTriggerEnter(Collider other) {
            foreach (MonoBehaviour script in other.transform.GetComponents<MonoBehaviour>()) {
                if (script != null) {
                    if (script is ILives) {
                        (script as ILives).DecreaseLive();
                    }//fi
                }//fi
            }//hcaerof
        }

    }

}
