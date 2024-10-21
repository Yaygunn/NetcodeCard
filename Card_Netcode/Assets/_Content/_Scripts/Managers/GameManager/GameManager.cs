using UnityEngine;
using Unity.Netcode;
using System;
using System.Linq;

namespace Yaygun
{
	public class GameManager : NetworkBehaviour
	{
		public static GameManager Instance;

        private ulong?[] _players = new ulong?[2];

        NetworkVariable<int> score = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
        private void OnEnable()
        {
            if(Instance == null)
            {
                Instance = this;
                Initialiee();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void Initialiee()
        {
            score.OnValueChanged += PrintScore;
        }

        public int GetPlayerIndex(ulong playerID)
        {
            if(_players.Contains(playerID))
                return Array.IndexOf(_players, playerID);
            else if (_players[0] == null)
            {
                _players[0] = playerID;
                return 0;
            }
            _players[1] = playerID;
            return 1;
        }
        [ServerRpc]
        public void IncreaseScoreServerRpc()
        {
            score.Value++;
        }

        private void PrintScore(int previousValue, int newValue)
        {
            print(score.Value);
        }
    }
}
