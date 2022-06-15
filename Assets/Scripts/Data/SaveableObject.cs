using System.Xml.Linq;
using UnityEngine;

namespace XmlDataSave
{
    public enum TypeOfObject
    {
        Character,
        Platform,
        CheckPoint,
        Thing
    }

    public class SaveableObject : MonoBehaviour
    {
        [SerializeField] private TypeOfObject _objectType;
        private GameHelper _helper;

        private void Awake()
        {
            _helper = FindObjectOfType<GameHelper>();
        }
        private void Start()
        {
            _helper.Objects.Add(this);
        }

        private void OnDestroy()
        {
            _helper.Objects.Remove(this);
        }
        public XElement GetElement()
        {
            XAttribute x = new XAttribute("x", transform.position.x);
            XAttribute y = new XAttribute("y", transform.position.y);
            XAttribute z = new XAttribute("z", transform.position.z);

            XElement element = new XElement("instance", GetNameOfTypeObject(), x, y, z);
            return element;
        }

        private string GetNameOfTypeObject()
        {
            string nameObject = "";
            switch (_objectType)
            {
                case TypeOfObject.Character:
                    nameObject = "Character";
                    break;
                case TypeOfObject.Platform:
                    nameObject = "Platform";
                    break;
                case TypeOfObject.CheckPoint:
                    nameObject = "Checkpoint";
                    break;
                case TypeOfObject.Thing:
                    nameObject = "Thing";
                    break;
            }
            return nameObject;
        }

    }
}
