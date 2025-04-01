using UnityEngine;

namespace Visual.Novel.Frame
{
    public class ChoiceFrame : BaseFrame
    {
        [SerializeField] private ChoiceOptionView _choiceOptionPrefab;

        public override void Show(FrameData data, FrameController controller)
        {
            base.Show(data, controller);
            if (data is not ChoiceFrameData frameData)
                return;

            foreach (var choiceOption in frameData.Options)
            {
                var choiceOptionView = Instantiate(_choiceOptionPrefab, transform);
                choiceOptionView.OnOptionSelected += OnOptionSelected;
                choiceOptionView.Init(choiceOption);
            }
        }

        private void OnOptionSelected(ChoiceOption option)
        {
            FrameController.ShowFrame(option.NextFrameId);
        }
    }
}