using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Visual.Novel.Frame
{
    public class DialogueFrame : TextAppearFrame
    {
        [SerializeField] private TextMeshProUGUI _characterNameText;
        [SerializeField] private TextMeshProUGUI _dialogueText;
        [SerializeField] private Image _characterImage;
        [SerializeField] private RectTransform _characterContiner;

        public override void Show(FrameData data, FrameController controller)
        {
            base.Show(data, controller);
            if (data is not DialogueFrameData frameData)
                return;

            _characterNameText.text = frameData.CharacterName;
            SetText(frameData.Text, _dialogueText);
            _characterImage.sprite = Resources.Load<Sprite>(frameData.CharacterSprite);
            _characterContiner.localScale = frameData.IsLeft ? Vector3.one : new Vector3(-1, 1, 1);
        }
    }
}