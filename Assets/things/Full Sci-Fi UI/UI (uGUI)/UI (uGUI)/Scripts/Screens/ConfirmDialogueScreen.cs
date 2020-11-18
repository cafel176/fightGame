using UnityEngine;
using System.Collections;

namespace K2Games
{
    public class ConfirmDialogueScreen : MonoBehaviour
    {
        public static ConfirmDialogueScreen Instance;

        public TransitionalObject mainTransition;

        void Start()
        {
            Instance = this;

            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameManager.instance.pause(true);
            mainTransition.TriggerTransition();
        }

        public void Close()
        {
            gameManager.instance.pause(false);
            mainTransition.TriggerFadeOut();
        }
    }
}