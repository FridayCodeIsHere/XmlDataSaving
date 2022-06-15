using UnityEngine;

namespace XmlDataSave
{
    public class Thing : MonoBehaviour
    {


        private void OnTriggerEnter(Collider other)
        {
            Data.CollectScore();
            Destroy(this.gameObject);
        }
    }
}
