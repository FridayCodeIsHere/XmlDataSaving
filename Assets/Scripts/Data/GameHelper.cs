using System.Xml.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;

namespace XmlDataSave
{
    public class GameHelper : MonoBehaviour
    {
        public delegate void WindowPrompt(string message, float Delay);
        public static WindowPrompt SaveDataIsNull;
        public List<SaveableObject> Objects = new List<SaveableObject>();
        [SerializeField] private GameObject _defaultLevel;
        private string _pathSave;
        private string _pathLevel1;

        private void Awake()
        {
            _pathSave = Application.persistentDataPath + "/saveGame.xml";
            _pathLevel1 = Application.persistentDataPath + "/level-1.xml";
        }

        public void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Save();
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                Load();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                CreateNewGame();
            }
        }


        public void CreateNewGame()
        {
            if (File.Exists(_pathLevel1))
            {
                string fileData = File.ReadAllText(_pathLevel1);
                XElement root = XDocument.Parse(fileData).Element("root");

                GenerateScene(root);
            }
            else
            {
                _defaultLevel.SetActive(true);
            }
            MainMenu.OnCreateLevel?.Invoke();
        }

        public void Save()
        {
            XElement root = new XElement("root");

            //Objects.ForEach(obj => root.Add(obj.GetElement()));
            foreach (SaveableObject obj in Objects)
            {
                root.Add(obj.GetElement());
            }

            root.AddFirst(new XElement("score", Data.Score));

            XDocument saveDoc = new XDocument(root);
            File.WriteAllText(_pathSave, saveDoc.ToString());
        }

        public void Load()
        {
            if (File.Exists(_pathSave))
            {
                XElement root = null;
                root = XDocument.Parse(File.ReadAllText(_pathSave)).Element("root");

                MainMenu.OnLoadLevel?.Invoke();
                GenerateScene(root);
            }
            else
            {
                SaveDataIsNull?.Invoke("Save data doesn't exists", 1f);
            }
        }

        private void GenerateScene(XElement root)
        {
            foreach(SaveableObject obj in Objects)
            {
                Destroy(obj.gameObject);
            }

            foreach(XElement instance in root.Elements("instance"))
            {
                Vector3 position = Vector3.zero;

                string x = instance.Attribute("x").Value;
                string y = instance.Attribute("y").Value;
                string z = instance.Attribute("z").Value;

                try
                {
                    position.x = float.Parse(instance.Attribute("x").Value, CultureInfo.InvariantCulture.NumberFormat);
                    position.y = float.Parse(instance.Attribute("y").Value, CultureInfo.InvariantCulture.NumberFormat);
                    position.z = float.Parse(instance.Attribute("z").Value, CultureInfo.InvariantCulture.NumberFormat);
                    //Debug.Log("Data is correct");
                }
                catch(Exception exception)
                {
                    Debug.Log($"Error occured: {exception}");
                }
                finally
                {
                    //Debug.Log($"Finally block");
                }

                Instantiate(Resources.Load<GameObject>(instance.Value), position, Quaternion.identity);
            }
        }
    }
}
