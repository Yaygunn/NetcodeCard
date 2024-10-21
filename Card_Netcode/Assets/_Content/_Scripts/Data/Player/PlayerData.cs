using UnityEngine;
using Yaygun.Utilities.Singleton;

namespace Yaygun
{
	public class PlayerData : Singleton<PlayerData>
	{
		public int PlayerIndex { get; private set; } = -666;
		public int EnemyIndex { get; private set; }
		public PlayerNetworkController PlayerNetworkController { get; private set; }

		public void SetPlayerData(int playerIndex, PlayerNetworkController controller)
		{
			if(PlayerIndex != -666)
			{
				print("Trying to set PlayerIndex twice");
				return;
			}

			PlayerIndex = playerIndex;
			PlayerNetworkController = controller;
			SetEnemyIndex();

            EventHub.PlayerDataSet();
		}

		private void SetEnemyIndex()
		{
            EnemyIndex = 0;
			if (PlayerIndex == 0)
				EnemyIndex = 1;

        }
	}
}
