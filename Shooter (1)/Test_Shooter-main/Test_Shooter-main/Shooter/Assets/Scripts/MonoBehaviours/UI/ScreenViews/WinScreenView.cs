using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.MonoBehaviours.UI.ScreenViews
{
    public class WinScreenView : ScreenViewController
    {
        [SerializeField] 
        private Button _restartBtn;

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
            _restartBtn.onClick.AddListener(Restart);
        }

        private void UnsubscribeFromEvents()
        {
            _restartBtn.onClick.RemoveListener(Restart);
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}
