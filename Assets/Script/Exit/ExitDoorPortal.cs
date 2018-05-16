using UnityEngine;

using ru.lifanoff.Intarface;

namespace ru.lifanoff.Exit {

    /// <summary>
    /// Скрипт для двери-выхода
    /// </summary>
    public class ExitDoorPortal : MonoBehaviour, IUsable {

        public void Use() {
            if (GameController.Instance.playerHasKey) {
                GameController.Instance.GoToNextScene(Unchangeable.RESULT_SCENE_NAME);
            }
        }

    }//class
}//namespace
