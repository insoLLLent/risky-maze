using UnityEngine;

namespace ru.lifanoff.Options {

    /// <summary>
    /// Класс для настроек графики
    /// </summary>
    [System.Serializable]
    public class GraphicsOptions {
        public bool isFullscreen = true;
        public int textureQuality = 1;
        public int antialiasing = 0;
        public int vSync = 0;

        public int resolution;

        public GraphicsOptions() {
            resolution = Screen.resolutions.Length - 1;

            DetermineCurrenScreenResolution();
        }

        /// <summary>Установить текущее разрешение экрана</summary>
        private void DetermineCurrenScreenResolution() {
            Resolution curRes = Screen.currentResolution;

            for (int i = 0; i < Screen.resolutions.Length; i++) {
                Resolution tmpRes = Screen.resolutions[i];

                if (tmpRes.width == curRes.width && tmpRes.height == curRes.height) {
                    resolution = i;
                    break;
                }
            }
        }
    }//class
}//namespace
