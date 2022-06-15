using UnityEngine;
using UnityEngine.SceneManagement;

namespace XmlDataSave
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;
        private Vector3 _direction;

        private void Start()
        {
            _direction = Vector3.zero;
        }

        #region MonoBehaviour
        private void OnValidate()
        {
            if (_speed < 0f) _speed = 0f;
        }
        #endregion

        private void Update()
        {
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");

            transform.position += _direction * _speed * Time.deltaTime;
            if (transform.position.y < -3f)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
