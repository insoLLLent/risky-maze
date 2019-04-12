using UnityEngine;


namespace ru.lifanoff.Util {
    /// <summary>
    /// Класс, который поворачивает объект по оси y лицевой стороной к камере
    /// </summary>
    public class FaceToScreen : MonoBehaviour {

        private Transform lookAtTransform = null;
        private Vector3 targetRotation = new Vector3();
        private Camera playerCamera = null;

        void Start() {
            playerCamera = SecondaryFunctions.GetCameraPlayer();
        }

        void Update() {
            lookAtTransform = transform;
            targetRotation = transform.eulerAngles;

            lookAtTransform.LookAt(playerCamera.transform);
            targetRotation.y = lookAtTransform.eulerAngles.y;
            transform.eulerAngles = targetRotation;
        }

    }

}
