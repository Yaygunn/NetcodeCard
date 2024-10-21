using UnityEngine;

namespace Yaygun
{
	public class UIPlayerDifferentiator : MonoBehaviour
	{
		[SerializeField] private HealthBar _playerHealthBar;
		[SerializeField] private HealthBar _enemyHealthBar;

        private void Start()
        {
            SetHealthBars();
        }

        private void SetHealthBars()
        {
            _playerHealthBar.SetBarOwnerPlayerIndex(PlayerData.Instance.PlayerIndex);

            int enemyIndex = 0;
            if (PlayerData.Instance.PlayerIndex == 0) 
                enemyIndex = 1;
            _enemyHealthBar.SetBarOwnerPlayerIndex(enemyIndex);
        }
    }
}
