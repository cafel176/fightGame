using UnityEngine;
using System.Collections;

namespace K2Games
{
    public class HUD : MonoBehaviour
    {
        public static HUD Instance;

        public TransitionGroup transitionGroup;

        void Start()
        {
            Instance = this;
        }

        public void Show()
        {
            transitionGroup.TriggerGroupTransition();
        }

        public void Close()
        {
            transitionGroup.TriggerGroupFadeOut();
        }
    }
}