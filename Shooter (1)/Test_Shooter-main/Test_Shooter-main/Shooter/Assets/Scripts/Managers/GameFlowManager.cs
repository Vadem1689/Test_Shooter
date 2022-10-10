using Assets.Scripts.Enums;
using Assets.Scripts.MonoBehaviours.Points;
using Assets.Scripts.MonoBehaviours.UI;
using Assets.Scripts.MonoBehaviours.UI.ScreenViews;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameFlowManager : MonoBehaviour
    {
        private void Awake()
        {
            SetGamePause(false);
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void SubscribeEvents()
        {
            StartMenuScreenView.StartGameEvent += OpenGame;
            GameScreenView.OpenPauseEvent += OpenPause;
            PauseScreenView.ResumeEvent += ResumeGame;
            WayPoints.WinEvent += OpenWin;
        }

        private void UnsubscribeEvents()
        {
            StartMenuScreenView.StartGameEvent -= OpenGame;
            GameScreenView.OpenPauseEvent -= OpenPause;
            PauseScreenView.ResumeEvent -= ResumeGame;
            WayPoints.WinEvent -= OpenWin;
        }
        
        private void OpenPause()
        {
            MainCanvasController.Instance.SwitchScreen(ScreenStates.Pause);
            SetGamePause(true);
        }

        private void ResumeGame()
        {
            OpenGame();
            SetGamePause(false);
        }

        private void OpenGame()
        {
            MainCanvasController.Instance.SwitchScreen(ScreenStates.Game);
        }

        private void OpenWin()
        {
            MainCanvasController.Instance.SwitchScreen(ScreenStates.Win);
        }

        private void SetGamePause(bool isPause)
        {
            Time.timeScale = isPause ? 0 : 1;
        }
    }
}