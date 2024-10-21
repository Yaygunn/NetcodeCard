using Unity.Netcode;
using UnityEngine;

namespace Yaygun
{
	public class PlayerNetworkController : NetworkBehaviour
	{
        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                GetPlayerIndexServerRpc();
            }
        }

        private void Update()
        {
            if (!IsOwner)
                return;

            if (Input.GetKeyDown(KeyCode.C))
            {
                PerformActionServerRpc();
            }
        }

        [ServerRpc]
        public void PerformActionServerRpc()
        {
            GameManager.Instance.IncreaseScoreServerRpc();
            Debug.Log($"{(int)OwnerClientId} performed an action on the server.");
            GameManager.Instance.GiveDamage(OwnerClientId, 1);
        }

        [ServerRpc]
        public void GetPlayerIndexServerRpc(ServerRpcParams rpcParams = default)
        {
            ulong clientID = rpcParams.Receive.SenderClientId;
            int valueToSend = GameManager.Instance.GetPlayerIndex(clientID);

            GetPlayerIndexClientRpc(valueToSend, CreateClientRpcParams(clientID));
        }

        [ClientRpc]
        public void GetPlayerIndexClientRpc(int value, ClientRpcParams clientRpcParams = default)
        {
            print("Client Value recieved from server : " + value);
            PlayerData.Instance.SetPlayerData(value);
        }
        private int GetOwnerID()
        {
            return (int)OwnerClientId;
        }

        private ClientRpcParams CreateClientRpcParams(ulong clientID)
        {
            return new ClientRpcParams
            {
                Send = new ClientRpcSendParams
                {
                    TargetClientIds = new ulong[] { clientID }
                }
            };
        }
    }
}
