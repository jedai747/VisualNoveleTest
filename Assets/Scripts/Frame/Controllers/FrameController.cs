using System.Collections.Generic;
using System.Linq;
using Frame.Convertor;
using UnityEngine;
using Visual.Novel.Frame.Factory;

namespace Visual.Novel.Frame
{
    public class FrameController : MonoBehaviour
    {
        [SerializeField] private TextAsset _jsonFile;
        [SerializeField] private Transform _uiParent;

        private Dictionary<int, FrameData> _frames;
        private BaseFrame _currentFrame;

        public void Init()
        {
            LoadFrames();
            ShowFrame(1);
        }

        private void LoadFrames()
        {
            var frames = FrameLoader.Load(_jsonFile.text);
            _frames = frames.ToDictionary(frame => frame.Id);
        }

        public void ShowFrame(int id)
        {
            if (_currentFrame != null)
                _currentFrame.Hide();

            if (!_frames.TryGetValue(id, out FrameData data))
            {
                Debug.LogError("Frame not found: " + id);
                return;
            }

            _currentFrame = FrameFactory.CreateFrame(data, _uiParent);
            _currentFrame.Show(data, this);
        }
        public void ShowNextFrame()
        {
            if (_currentFrame == null)
                return;

            int nextId = GetNextFrameId(_currentFrame.FrameData.Id);
            if (nextId != -1)
                ShowFrame(nextId);
            else
                Debug.Log("No next frame found");
        }

        private int GetNextFrameId(int currentId)
        {
            var ids = _frames.Keys.OrderBy(id => id).ToList();
            int index = ids.IndexOf(currentId);
            if (index >= 0 && index + 1 < ids.Count)
                return ids[index + 1];
            return -1;
        }
    }
}