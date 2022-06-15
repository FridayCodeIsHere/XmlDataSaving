using UnityEngine;
using UnityEngine.UI;

namespace XmlDataSave
{
    [RequireComponent(typeof(Animator))]
    public class WindowPrompt : MonoBehaviour
    {
        private Text _promptText;
        private Animator _animator;
        private void Start()
        {
            _promptText = GetComponentInChildren<Text>();
            _animator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            GameHelper.SaveDataIsNull += ShowPrompt;
        }

        private void ShowPrompt(string message, float delay)
        {
            Debug.Log("Show Prompt");
            _promptText.text = message;
            _animator.SetTrigger("Show");
            Invoke(nameof(HidePrompt), delay);
        }

        private void HidePrompt()
        {
            Debug.Log("Hide Prompt");
            _animator.SetTrigger("Hide");
        }
    }
}
