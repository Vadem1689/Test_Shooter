using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.MonoBehaviours.UI.ScreenViews
{
    public class PauseScreenView : ScreenViewController
    {
        internal static event Action ResumeEvent;

        [SerializeField] 
        private Button _resumeBtn;

        [SerializeField] 
        private Button _restartBtn;

        [SerializeField] 
        private Button _exitBtn;

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
            _resumeBtn.onClick.AddListener(Resume);
            _restartBtn.onClick.AddListener(Restart);
            _exitBtn.onClick.AddListener(Exit);
        }

        private void UnsubscribeFromEvents()
        {
            _resumeBtn.onClick.RemoveListener(Resume);
            _restartBtn.onClick.RemoveListener(Restart);
            _exitBtn.onClick.RemoveListener(Exit);
        }

        private void Resume()
        {
            ResumeEvent?.Invoke();
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}