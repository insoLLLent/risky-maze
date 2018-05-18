namespace ru.lifanoff.Options {

    /// <summary>
    /// Класс-синглтон, который хранит настройки
    /// </summary>
    [System.Serializable]
    public class OptionsManager {

        /// <summary>Единственный экземпляр класса <seealso cref="OptionsManager"/></summary>
        public static OptionsManager Instance { get; private set; }

        static OptionsManager() {
            if (Instance == null) {
                Instance = new OptionsManager();
            }
        }

        private OptionsManager() { }


        #region Menu Options
        /// <summary>Хранилище настроек графики</summary>
        public GraphicsOptions graphicsOptions { get; private set; } = new GraphicsOptions();

        /// <summary>Хранилище настроек музыки и звуков</summary>
        public MusicOptions musicOptions { get; private set; } = new MusicOptions();

        /// <summary>Хранилище используемых в игре клавиш</summary>
        public ControlOptions controlOptions { get; private set; } = new ControlOptions();
        #endregion

    }//class
}//namespace
