using UnityEngine;
using UnityEngine.SceneManagement;

namespace Visual.Novel.Utils
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
