using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviours.UI.ScreenViews
{
    public abstract class ScreenViewController : MonoBehaviour, IAppearable
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}