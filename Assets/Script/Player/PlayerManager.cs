namespace ru.lifanoff {

    /// <summary>
    /// Настройки игрока во время игрового процесса
    /// </summary>
    public class PlayerManager {

        /// <summary>Можети ли игрок передвигаться</summary>
        public bool canMoving;
        /// <summary>Есть ли у игрока ключ от выхода</summary>
        public bool hasExitKey;

        /// <summary>Единственный экземпляр класса <seealso cref="PlayerManager"/></summary>
        private static PlayerManager instance;
        /// <summary>Единственный экземпляр класса <seealso cref="PlayerManager"/></summary>
        public static PlayerManager Instance {
            get { return instance; }
        }

        static PlayerManager() {
            if (instance == null) {
                instance = new PlayerManager();
            }
        }

        private PlayerManager() {
            canMoving = true;
            hasExitKey = false;
        }


    }//class
}//namespace
