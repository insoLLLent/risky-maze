using System;

namespace ru.lifanoff.Options {

    /// <summary>
    /// Класс для настроек графики
    /// </summary>
    [Serializable]
    public class GraphicsOptions {
        public bool isFullscreen = true;
        public int resolution = 0;
        public int textureQuality = 1;
        public int antialiasing = 0;
        public int vSync = 0;
    }//class
}//namespace
