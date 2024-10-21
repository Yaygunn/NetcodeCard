using UnityEngine;
using UnityEngine.UI;

namespace Yaygun
{
	public class HealthBar : MonoBehaviour
	{
        [SerializeField] private Image _healthImage;
		
        private int _barOwnerPlayerIndex;

        private void Start()
        {
            EventHub.Ev_HealthChanged += OnHealthChanged;
        }

        public void SetBarOwnerPlayerIndex(int playerIndex)
        {
            _barOwnerPlayerIndex = playerIndex;
        }

        private void OnHealthChanged(int player, float newRatio)
        {
            if (_barOwnerPlayerIndex != player)
                return;

            _healthImage.fillAmount = newRatio;
        }
    }
}
