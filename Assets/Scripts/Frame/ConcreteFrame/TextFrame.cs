using TMPro;
using UnityEngine;

namespace Visual.Novel.Frame
{
    public class TextFrame : TextAppearFrame
    {
        [SerializeField] private TextMeshProUGUI _text;

        public override void Show(FrameData data, FrameController controller)
        {
            base.Show(data, controller);
            if (data is not TextFrameData frameData)
                return;

            SetText(frameData.Text, _text);
        }
    }
}