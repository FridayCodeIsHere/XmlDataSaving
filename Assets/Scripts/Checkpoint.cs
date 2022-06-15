using UnityEngine;

namespace XmlDataSave
{
    public class Checkpoint : MonoBehaviour
    {
        private GameHelper _helper;

        private void Awake()
        {
            _helper = FindObjectOfType<GameHelper>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Character>())
            {
                _helper.Save();
            }
        }
    }
}
