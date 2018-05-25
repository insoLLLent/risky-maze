using UnityEngine;

using ru.lifanoff.Intarface;

namespace ru.lifanoff.Exit {

    /// <summary>
    /// Скрипт для ключа от выхода
    /// </summary>
    public class ExitKey : MonoBehaviour, IUsable {
        /// <summary>Сообщение для игрока, если он взял ключ и открыл дверь</summary>
        private const string DOOR_IS_OPENED_MESSAGE = "Выход открыт!";

        public void Use() {
            PlayerManager.Instance.hasExitKey = true;
            PlayerManager.Instance.SendMessageToPlayer(DOOR_IS_OPENED_MESSAGE);
            Destroy(gameObject);
        }
    }//class
}//namespace
