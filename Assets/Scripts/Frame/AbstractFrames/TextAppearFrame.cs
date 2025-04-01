using System.Collections;
using TMPro;
using UnityEngine;

namespace Visual.Novel.Frame
{
    public abstract class TextAppearFrame : TapFrame
    {
        [SerializeField] private float _charsPerSecond = 30f;

        private Coroutine _typingCoroutine;
        private string _fullText;
        private bool _isTyping;
        private TextMeshProUGUI _textComponent;

        protected void SetText(string text, TextMeshProUGUI textComponent)
        {
            _textComponent = textComponent;
            _fullText = text;
            _textComponent.text = "";
            StartTyping();
        }

        private void StartTyping()
        {
            if (_typingCoroutine != null)
                StopCoroutine(_typingCoroutine);

            _typingCoroutine = StartCoroutine(TypeText());
        }

        private IEnumerator TypeText()
        {
            _isTyping = true;
            _textComponent.maxVisibleCharacters = 0;
            _textComponent.text = _fullText;

            int totalChars = _fullText.Length;
            float interval = 1f / _charsPerSecond;

            while (_textComponent.maxVisibleCharacters < totalChars)
            {
                _textComponent.maxVisibleCharacters++;
                yield return new WaitForSeconds(interval);
            }

            _isTyping = false;
        }

        protected override void HandleTap()
        {
            if (_isTyping)
            {
                if (_typingCoroutine != null)
                    StopCoroutine(_typingCoroutine);

                _textComponent.maxVisibleCharacters = _fullText.Length;
                _isTyping = false;
            }
            else
            {
                base.HandleTap();
            }
        }
    }
}