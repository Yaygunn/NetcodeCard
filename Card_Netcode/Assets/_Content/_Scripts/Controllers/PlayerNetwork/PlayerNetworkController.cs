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
            PlayerData.Instance.SetPlayerData(value, this);
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

        [ServerRpc]
        public void PlayedCardServerRpc(int cardIndex, ServerRpcParams rpcParams = default)
        {
            GameManager.Instance.WantToPlayCard(OwnerClientId, cardIndex);
        }

        [ServerRpc]
        public void WantToTakeBackCardServerRpc()
        {
            GameManager.Instance.WantToTakeBackCard(OwnerClientId);
        }
    }
}
