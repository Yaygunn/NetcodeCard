using UnityEngine;
using Yaygun.Utilities.Singleton;

namespace Yaygun
{
	public class PlayerData : Singleton<PlayerData>
	{
		public int PlayerIndex { get; private set; } = -666;

		public void SetPlayerData(int playerIndex)
		{
			if(PlayerIndex != -666)
			{
				print("Trying to set PlayerIndex twice");
				return;
			}

			PlayerIndex = playerIndex;
			EventHub.PlayerDataSet();
		}
	}
}
