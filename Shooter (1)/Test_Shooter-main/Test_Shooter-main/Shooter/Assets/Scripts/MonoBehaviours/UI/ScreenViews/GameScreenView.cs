using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MonoBehaviours.UI.ScreenViews
{
    public class GameScreenView : ScreenViewController
    {
        internal static event Action OpenPauseEvent;

        [SerializeField]
        private Button _pauseBtn;

        private void OnEnable()
        {
            SubscribeOnEvents();
        }

        private void OnDisable()
        {
            UnsubscribeFromEvents();
        }

        private void SubscribeOnEvents()
        {
            _pauseBtn.onClick.AddListener(Pause);
        }

        private void UnsubscribeFromEvents()
        {
            _pauseBtn.onClick.RemoveListener(Pause);
        }

        private void Pause()
        {
            OpenPauseEvent?.Invoke();
        }
    }
}
