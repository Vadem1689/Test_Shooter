using Assets.Scripts.Enums;
using Assets.Scripts.MonoBehaviours.UI.ScreenViews;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviours.UI
{
    public class MainCanvasController : Singleton<MainCanvasController>
    {
        [SerializeField] 
        private StartMenuScreenView _startMenuScreenView;
        
        [SerializeField]
        private GameScreenView _gameScreenView;
        
        [SerializeField] 
        private PauseScreenView _pauseScreenView;

        [SerializeField] 
        private WinScreenView _winScreenView;

        private ScreenViewController _currentScreen;
        
        public void SwitchScreen(ScreenStates screenStates)
        {
            if (_currentScreen == null)
            {
                _currentScreen = _startMenuScreenView;
            }

            _currentScreen.Hide();

            _currentScreen = SelectUiController(screenStates);
            _currentScreen.Show();
        }

        private ScreenViewController SelectUiController(ScreenStates screenStates)
        {
            switch (screenStates)
            {
                case ScreenStates.StartMenu:
                    return _startMenuScreenView;

                case ScreenStates.Game:
                    return _gameScreenView;

                case ScreenStates.Pause:
                    return _pauseScreenView;

                case ScreenStates.Win:
                    return _winScreenView;
            }
            return null;
        }
    }
}