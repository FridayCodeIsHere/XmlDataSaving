using UnityEngine;
using UnityEngine.UI;

namespace XmlDataSave
{
    [RequireComponent(typeof(Animator))]
    public class WindowPrompt : MonoBehaviour
    {
        private Text _promptText;
        private Animator _animator;
        private void Awake()
        {
            _promptText = GetComponentInChildren<Text>();
            _animator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            GameHelper.ShowDataState += ShowPrompt;
        }

        private void OnDisable()
        {
            GameHelper.ShowDataState -= ShowPrompt;
        }

        private void ShowPrompt(string message, float delay)
        {
            _promptText.text = message;
            _animator.SetTrigger("Show");
            Invoke(nameof(HidePrompt), delay);
        }

        private void HidePrompt()
        {
            _animator.SetTrigger("Hide");
        }
    }
}
