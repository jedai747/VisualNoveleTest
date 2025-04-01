using UnityEngine;
using UnityEngine.EventSystems;
using System;

namespace Visual.Novel.Frame
{
    public class TapCatcher : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnTap;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnTap?.Invoke();
        }
    }
}