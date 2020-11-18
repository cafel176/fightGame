using UnityEngine;
using System.Collections;

namespace K2Games
{
    public class LoadScene : MonoBehaviour
    {
        public string sceneName;

        public void LoadSceneOnCLick()
        {
            Application.LoadLevel(sceneName);
        }
    }
}