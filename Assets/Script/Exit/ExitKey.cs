using UnityEngine;

using ru.lifanoff.Intarface;

namespace ru.lifanoff.Exit {

    /// <summary>
    /// Скрипт для ключа от выхода
    /// </summary>
    public class ExitKey : MonoBehaviour, IUsable {
        public void Use() {
            GameController.Instance.playerHasKey = true;
            Destroy(gameObject);
        }
    }//class
}//namespace
