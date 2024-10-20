using UnityEngine;
using Unity.Netcode;
using System;

namespace Yaygun
{
	public class GameManager : NetworkBehaviour
	{
		public static GameManager Instance;

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
