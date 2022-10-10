using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MonoBehaviours.UI.ScreenViews
{
    public class StartMenuScreenView : ScreenViewController
    {
        internal static event Action StartGameEvent;

        [SerializeField] 
        private Button _startGameBtn;

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
            _startGameBtn.onClick.AddListener(OnStartGameBtnClick);
        }

        private void UnsubscribeFromEvents()
        {
            _startGameBtn.onClick.RemoveListener(OnStartGameBtnClick);
        }

        private void OnStartGameBtnClick()
        {
            StartGameEvent?.Invoke();
        }
    }
}