using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using ru.lifanoff.Options;

namespace ru.lifanoff {

    /// <summary>
    /// Класс-синглтон, для хранения настроек игры
    /// </summary>
    [Serializable]
    public class SaveManager {
        /// <summary>Полный путь к сейв-файлу</summary>
        [NonSerialized] public static string FILEPATH = Path.GetFullPath(@"./saves/CourseworkSave.bin");
        /// <summary>Директория в который расположен сейв-файл</summary>
        [NonSerialized] public static string FILEDIR = Path.GetDirectoryName(FILEPATH);
        /// <summary>Только имя и расширение сейв-файл</summary>
        [NonSerialized] public static string FILENAME = Path.GetFileName(FILEPATH);

        /// <summary>Единственный экземпляр класса <seealso cref="SaveManager"/></summary>
        public static SaveManager Instance { get; private set; }

        static SaveManager() {
            if (Instance == null) {
                Instance = new SaveManager();
            }

            Instance.Load();
        }

        private SaveManager() { }


        /// <summary>Ссылка на единственный экземпляр класса OptionsManager</summary>
        public OptionsManager optionsManager { get; private set; } = OptionsManager.Instance;


        /// <summary>
        /// Сохранить (сериализовать) данные в файл <seealso cref="FILEPATH"/>
        /// </summary>
        public void Save() {
            if (!Directory.Exists(FILEDIR)) {
                Directory.CreateDirectory(FILEDIR);
            }

            using (FileStream fs = new FileStream(FILEPATH, FileMode.OpenOrCreate)) {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, Instance);
            }
        }

        /// <summary>
        /// Выгрузить (десериализовать) данные из файла <seealso cref="FILEPATH"/>
        /// </summary>
        public bool Load() {
            if (File.Exists(FILEPATH)) {
                try {
                    using (FileStream fs = new FileStream(FILEPATH, FileMode.Open)) {
                        BinaryFormatter bf = new BinaryFormatter();
                        Initialize((SaveManager)bf.Deserialize(fs));
                    }

                    return true;
                } catch (Exception) {
                    return false;
                }
            }

            return false;
        }


        /// <summary>
        /// Инициализация текущих значений параметрами из сейв-файла. 
        /// Если в старой версии сейва нет какого-либо свойства, котрое есть в новой версии сейва,
        /// то этому свойству в новом сейве будет присвоено значение по-умолчанию вместо null.
        /// Так сделано для обратной совместимости разных версий сейвов.
        /// </summary>
        /// <param name="oldSaver">Сохраненный на диске десериализованный файл</param>
        private void Initialize(SaveManager oldSaver) {
            try {
                foreach (object keyName in oldSaver.optionsManager.controlOptions.keyButtons.Keys) {
                    if (keyName is KeyName) {
                        KeyName kn = (KeyName)keyName;
                        optionsManager.controlOptions.keyButtons.Add(kn, oldSaver.optionsManager.controlOptions.keyButtons[kn]);
                    }
                }
            } catch (Exception) { }

            optionsManager.controlOptions.mouseSensitivityX = oldSaver.optionsManager.controlOptions.mouseSensitivityX;
            optionsManager.controlOptions.mouseSensitivityY = oldSaver.optionsManager.controlOptions.mouseSensitivityY;

            optionsManager.graphicsOptions.antialiasing = oldSaver.optionsManager.graphicsOptions.antialiasing;
            optionsManager.graphicsOptions.isFullscreen = oldSaver.optionsManager.graphicsOptions.isFullscreen;
            optionsManager.graphicsOptions.resolution = oldSaver.optionsManager.graphicsOptions.resolution;
            optionsManager.graphicsOptions.textureQuality = oldSaver.optionsManager.graphicsOptions.textureQuality;
            optionsManager.graphicsOptions.vSync = oldSaver.optionsManager.graphicsOptions.vSync;

            optionsManager.musicOptions.musicVolume = oldSaver.optionsManager.musicOptions.musicVolume;
        }

    }//class
}//namespace
