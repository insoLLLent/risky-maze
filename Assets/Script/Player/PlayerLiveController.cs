using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

using ru.lifanoff.Intarface;

namespace ru.lifanoff.Player {

    [RequireComponent(typeof(DropPebble), typeof(UseController), typeof(PostProcessVolume))]
    public class PlayerLiveController : MonoBehaviour, ILives {

        [Tooltip("UI отображение количества жизней")]
        [SerializeField] private Text livesText = null;

        /// <summary>Количество жизней</summary>
        private int countLives = Unchangeable.DEFAULT_COUNT_LIVES_EASY;
        /// <summary>Количество жизней</summary>
        public int CountLives {
            get {
                return countLives;
            }
            set {
                if (countLives == value) return;

                countLives = Mathf.Clamp(value, 0, int.MaxValue);
                UpdatePebbleText();

                if (countLives < 1) GoToGameOver();
            }
        }

        private bool canDamage = true;

        private PostProcessVolume ppv = null;
        private Vignette vignette = null;

        private SoundController soundController = null;

        #region Unity events
        void Start() {
            soundController = SoundController.Instance;

            ppv = SecondaryFunctions.GetCameraPlayer().GetComponent<PostProcessVolume>();
            ppv.profile.TryGetSettings(out vignette);
            vignette.active = false;
            vignette.color.overrideState = true;

            InitCountLives();
            UpdatePebbleText();
        }
        #endregion

        private void InitCountLives() {
            switch (GameController.Instance.difficulMode) {
                case DifficultMode.EASY:
                    countLives = Unchangeable.DEFAULT_COUNT_LIVES_EASY;
                    break;
                case DifficultMode.MEDIUM:
                    countLives = Unchangeable.DEFAULT_COUNT_LIVES_MEDIUM;
                    break;
                case DifficultMode.HARD:
                    countLives = Unchangeable.DEFAULT_COUNT_LIVES_HARD;
                    break;
            }
        }

        private void UpdatePebbleText() {
            if (livesText == null) return;
            livesText.text = $"x{countLives}";
        }

        private void GoToGameOver() {
            PlayerManager.Instance.SendMessageToPlayer("You died :(");

            PlayerManager.Instance.canMoving = false;
            GetComponent<DropPebble>().canDrop = false;
            GetComponent<UseController>().canUsing = false;
            soundController.StopPlayerAudioSource();

            StartCoroutine(GoToGameOverScene());
        }

        private IEnumerator GoToGameOverScene() {
            yield return new WaitForSeconds(2.0f);
            GameController.Instance.GoToNextScene(Unchangeable.GAME_OVER_SCENE_NAME);
        }

        public void IncreaseLive(int count = 1) {
            CountLives += count;
        }

        public void DecreaseLive(int count = 1) {
            if (!canDamage) return;

            CountLives -= count;

            soundController.PlayPainPlayer();

            StartCoroutine(DisableDamageForTwoSeconds());
        }

        private IEnumerator DisableDamageForTwoSeconds() {
            canDamage = false;

            if (CountLives > 0) {
                StartCoroutine(VignetteDamage());
            }

            yield return new WaitForSeconds(2f);
            canDamage = true;
        }

        private IEnumerator VignetteDamage() {
            vignette.active = true;

            float pp = 0f;

            do {
                pp = Mathf.PingPong(Time.time, 1);
                vignette.color.value = Color.Lerp(Color.white, Color.red, pp);
                yield return null;
            } while (!canDamage);

            while (pp > 0.1f) {
                pp = Mathf.PingPong(Time.time, 1);
                vignette.color.value = Color.Lerp(Color.white, Color.red, pp);
                yield return null;
            }

            vignette.active = false;
        }
    }

}
