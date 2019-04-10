using UnityEngine;

namespace ru.lifanoff {

    /// <summary>
    /// Класс, отвечающий за респаун объекта.
    /// В случае, если объект оказался ниже контрольной точки по оси Y, он будет переброшен в точку респауна
    /// </summary>
    public class SpawnFallingBehindWall : MonoBehaviour {

        private Vector3 spawnPosition; // Стартовая позиция объекта (респаун)
        private Rigidbody _rb;
        private CharacterController _cc;

        #region Unity Events
        void Start() {
            spawnPosition = transform.position;
            _rb = GetComponent<Rigidbody>();
            _cc = GetComponent<CharacterController>();
        }

        void Update() {
            if (transform.position.y < Unchangeable.RESPAWN_POSITION_Y) {
                if (_rb != null) {
                    _rb.velocity = Vector3.zero;
                    _rb.angularVelocity = Vector3.zero;
                }

                if (_cc != null) {
                    _cc.SimpleMove(Vector3.zero);
                }

                transform.position = spawnPosition;
            }
        }
        #endregion

    }

}