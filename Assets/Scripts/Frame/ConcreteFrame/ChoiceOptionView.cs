using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Visual.Novel.Frame
{
    public class ChoiceOptionView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        public event Action<ChoiceOption> OnOptionSelected;

        public void Init(ChoiceOption choiceOption)
        {
            _text.text = choiceOption.Text;
            Button button = GetComponent<Button>();
            if(button == null)
                return;
            
            button.onClick.AddListener(() =>
            {
                OnOptionSelected?.Invoke(choiceOption);
            });
        }
    }
}